using Microsoft.Extensions.Options;
using Newtonsoft.Json;
using Petbase.DataService.Interfaces;
using Petbase.DataService.Models;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace Petbase.DataService.Services
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

            return result;
        }

        public async Task<string> GetAccessToken()
        {         
            var content = new StringContent(           
                JsonConvert.SerializeObject(
                    new
                    {
                        client_id = settings.Value.PetFinderApiKey,
                        client_secret = settings.Value.PetFinderApiSecret,
                        grant_type = "client_credentials"
                    }), 
            Encoding.UTF8, "application/json");
                    
            var request = await client.PostAsync(settings.Value.PetFinderAuthority, content);

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

        public async Task<HttpResponseMessage> Get(string filter)
        {
            var token = GetTokenFromCache();
            if (string.IsNullOrWhiteSpace(token))
            {
                token = await GetAccessToken();
            }

            var request = new HttpRequestMessage(HttpMethod.Get, filter);
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

        public string GetTokenFromCache()
        {
            return cacheService.GetCache("accessToken")?.ToString();
        }
    }
}
