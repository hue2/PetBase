using Microsoft.Extensions.Options;
using Newtonsoft.Json;
using Petbase.DataService.Interfaces;
using Petbase.DataService.Models;
using System;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace Petbase.DataService.Services
{
    public class PetFinderAuthService : IPetFinderAuthService
    {
        private readonly IOptions<AppSettings> settings;
        private readonly ICacheService cacheService;
        private readonly HttpClient client;

        public PetFinderAuthService(IHttpClientFactory clientFactory, IOptions<AppSettings> settings, ICacheService cacheService)
        {
            this.settings = settings;
            this.cacheService = cacheService;
            this.client = clientFactory.CreateClient();
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

            var request = new HttpRequestMessage(HttpMethod.Post, settings.Value.PetFinderAuthority);
            request.Content = content;
            client.BaseAddress = new Uri(settings.Value.PetFinderBaseUrl);

            var response = await client.SendAsync(request);

            if (response.IsSuccessStatusCode)
            {
                var responsestring = await response.Content.ReadAsStringAsync();
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
    }
}
