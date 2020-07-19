using Microsoft.Extensions.Options;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using Newtonsoft.Json;
using Petbase.DataService.Interfaces;
using Petbase.DataService.Models;
using Petbase.DataService.Services;
using System;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace Petbase.DataService.Tests
{
    [TestClass]
    public class PetFinderAuthServiceTests
    {
        private Mock<IHttpClientFactory> mockClient;
        private Mock<ICacheService> mockCacheService;
        private Mock<IOptions<AppSettings>> mockOptions;
        private PetFinderAuthService authService;

       [TestInitialize]
       public void Init()
       {
            this.mockOptions = new Mock<IOptions<AppSettings>>();
            this.mockCacheService = new Mock<ICacheService>();

            var appSettings = new AppSettings()
            {
                PetFinderBaseUrl = "https://api.petfinder.com/v2",
                PetFinderAnimalUrl = "apple",
            };
            this.mockOptions.Setup(x => x.Value).Returns(appSettings);

            var content = new StringContent(JsonConvert.SerializeObject(new TokenResponse()
            {
                AccessToken = "123",
                ExpiresIn = DateTime.Now.Hour,
                TokenType = "access",
            }), Encoding.UTF8, "application/json");
            //Mocking the httpclient handler bc we're using httpclientfactory CreateClient method to create the client
            var httpClient = MockHttpHandler.GetClientWithHandler(content);

            this.mockClient = new Mock<IHttpClientFactory>(MockBehavior.Strict);
            this.mockClient.Setup(x => x.CreateClient(It.IsAny<string>())).Returns(httpClient);
            this.authService = new PetFinderAuthService(mockClient.Object, mockOptions.Object, mockCacheService.Object);
        }

        [TestMethod]
        public async Task GetToken_save_token_to_cache_after_fetch()
        {
            mockCacheService.Setup(x => x.SaveCache(It.IsAny<object>(), It.IsAny<object>()));
            var token = await authService.GetAccessToken();
            mockCacheService.Verify(x => x.SaveCache(It.IsAny<object>(), It.IsAny<object>()), Times.Once);
        }
    }
}
