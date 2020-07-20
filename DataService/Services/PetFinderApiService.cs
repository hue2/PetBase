using Microsoft.Extensions.Options;
using Newtonsoft.Json;
using Petbase.DataService.Interfaces;
using Petbase.DataService.Models;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;

namespace Petbase.DataService.Services
{
    public class PetFinderApiService : IPetFinderApiService
    {
        private readonly IOptions<AppSettings> settings;
        private readonly IPetFinderAuthService authService;
        private readonly HttpClient client;

        public PetFinderApiService(IHttpClientFactory clientFactory, IOptions<AppSettings> settings, IPetFinderAuthService authService)
        {
            this.settings = settings;
            this.client = clientFactory.CreateClient();
            this.authService = authService;
        }

        public async Task<AnimalResult> GetPets(AnimalFilter filters)
        {
            var result = new AnimalResult();
            var filter = GetQueryString(filters);
            var response = await Get(filter);

            if (response.IsSuccessStatusCode)
            {
                var data = await response.Content.ReadAsStringAsync();
                result = JsonConvert.DeserializeObject<AnimalResult>(data);
            }
            else
            {
                throw new Exception(response.ReasonPhrase);
            }

            return result;
        }


        public async Task<HttpResponseMessage> Get(string filter)
        {
            var token = authService.GetTokenFromCache();
            if (string.IsNullOrWhiteSpace(token))
            {
                token = await authService.GetAccessToken();
            }

            var request = new HttpRequestMessage(HttpMethod.Get, filter);
            client.BaseAddress = new Uri(settings.Value.PetFinderBaseUrl);
            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
            var response = await client.SendAsync(request);
            return response;
        }

        public string GetQueryString(AnimalFilter filters)
        {
            if (filters == null)
            {
                return settings.Value.PetFinderAnimalUrl;
            }

            List<string> parameters = new List<string>();
            foreach (var property in filters.GetType().GetProperties())
            {
                if (property.GetValue(filters) != null)
                {
                    parameters.Add($"{property.Name.ToLower()}={property.GetValue(filters)}");
                }
            }

            var queryUrl = $"{settings.Value.PetFinderAnimalUrl}?{string.Join('&', parameters.ToArray())}";
            return queryUrl;
        }
    }
}
