using DataService.Interfaces;
using Microsoft.Extensions.Options;
using Newtonsoft.Json;
using Petbase.Interfaces;
using Petbase.Models;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace Petbase.Services
{
    public class PetFinderApiService : IPetFinderApiService
    {
        private readonly IOptions<AppSettings> settings;
        private readonly ICacheService cacheService;
        private readonly HttpClient client;

        public PetFinderApiService(IHttpClientFactory clientFactory, IOptions<AppSettings> settings, ICacheService cacheService)
        {
            this.settings = settings;
            this.cacheService = cacheService;
            this.client = clientFactory.CreateClient();
        }

        public async Task<string> GetAccessToken()
        {
            string credentials = $"{settings.Value.PetFinderApiKey}:{settings.Value.PetFinderApiSecret}";
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Basic", Convert.ToBase64String(Encoding.UTF8.GetBytes(credentials)));

            var requestData = new List<KeyValuePair<string, string>>();
            requestData.Add(new KeyValuePair<string, string>("grant_type", "client_credentials"));

            FormUrlEncodedContent requestBody = new FormUrlEncodedContent(requestData);
            var request = await client.PostAsync(settings.Value.PetFinderAuthority, requestBody);

            if (request.IsSuccessStatusCode)
            {
                var responsestring = await request.Content.ReadAsStringAsync();
                var token = JsonConvert.DeserializeObject<TokenResponse>(responsestring);
                cacheService.SaveCache("accessToken", token.AccessToken);
                return token.AccessToken;
            }
            else
            {
                //need to handle exception
                return null;
            }
        }

        public string GetTokenFromCache()
        {
            return cacheService.GetCache("accessToken")?.ToString();
        }

        public async Task<AnimalResult> GetPets(AnimalFilter filters)
        {
            var token = GetTokenFromCache();
            if (string.IsNullOrWhiteSpace(token))
            {
                token = await GetAccessToken();
            }

            var request = new HttpRequestMessage(HttpMethod.Get, GetQueryString(filters));
            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
            var response = await client.SendAsync(request);
            if (response.IsSuccessStatusCode)
            {
                var result = await response.Content.ReadAsStringAsync();
                var animal = JsonConvert.DeserializeObject<AnimalResult>(result);
                return animal;
            }

            return null;
        }

        private string GetQueryString(AnimalFilter filters)
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
                    parameters.Add($"{property.Name}={property.GetValue(filters)}");
                }
            }

            var queryUrl = $"{settings.Value.PetFinderAnimalUrl}?{string.Join('&', parameters.ToArray())}";
            return queryUrl;
        }
    }
}
