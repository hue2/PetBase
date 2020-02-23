using Microsoft.Extensions.Options;
using Petbase.Models;
using System.Net.Http;
using System.Text.Json;
using System.Threading.Tasks;

namespace Petbase.Services
{
    public class PetFinderApiService
    {
        private readonly IHttpClientFactory clientFactory;
        private readonly IOptions<AppSettings> settings;

        public PetFinderApiService(IHttpClientFactory clientFactory, IOptions<AppSettings> settings)
        {
            this.clientFactory = clientFactory;
            this.settings = settings;
        }

        public async Task<TokenResponse> GetAccessToken()
        {
            var request = new HttpRequestMessage(HttpMethod.Get, this.settings.Value.PetFinderAuthority);
            request.Headers.Add("client_id", this.settings.Value.PetFinderApiKey);
            request.Headers.Add("client_secret", this.settings.Value.PetFinderApiSecret);

            var client = clientFactory.CreateClient();
            var response = await client.SendAsync(request);

            if (response.IsSuccessStatusCode)
            { 
                var responseStream = await response.Content.ReadAsStreamAsync();
                return await JsonSerializer.DeserializeAsync<TokenResponse>(responseStream);
            }
            else
            {
                //need to handle exception
                return new TokenResponse();
            }
        }
    }
}
