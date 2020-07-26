using Microsoft.Extensions.Options;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using Petbase.DataService.Interfaces;
using Petbase.DataService.Models;
using Petbase.DataService.Services;
using System.Net.Http;
using System.Threading.Tasks;

namespace Petbase.DataService.Tests
{
    [TestClass]
    public class PetFinderApiServiceTests
    {
        private Mock<IHttpClientFactory> mockClient;
        private Mock<IOptions<AppSettings>> mockOptions;
        private Mock<IPetFinderAuthService> mockAuth;
        private PetFinderApiService petFinderService;

        [TestInitialize]
        public void Init()
        {
            this.mockOptions = new Mock<IOptions<AppSettings>>();
            var appSettings = new AppSettings()
            {
                PetFinderBaseUrl = "https://api.petfinder.com/v2",
                PetFinderAnimalUrl = "apple",
            };
            this.mockOptions.Setup(x => x.Value).Returns(appSettings);

            this.mockAuth = new Mock<IPetFinderAuthService>();

            //Mocking the httpclient handler bc we're using httpclientfactory CreateClient method to create the client

            var httpClient = MockHttpHandler.GetClientWithHandler();

            this.mockClient = new Mock<IHttpClientFactory>(MockBehavior.Strict);
            this.mockClient.Setup(x => x.CreateClient(It.IsAny<string>())).Returns(httpClient);
            this.petFinderService = new PetFinderApiService(mockClient.Object, mockOptions.Object, mockAuth.Object);
        }

        [TestMethod]
        public void GetQueryString_returns_correct_filter()
        {
            var filter = new AnimalFilter()
            {
                Breed = "apple",
                Distance = 1,
                Location = 2,
            };

            var expected = $"{mockOptions.Object.Value.PetFinderAnimalUrl}?location=2&distance=1&breed=apple";

            var result = petFinderService.GetQueryString(filter);
            Assert.AreEqual(expected, result);
        }


        [TestMethod]
        public async Task Get_calls_correct_get_token_method()
        {
            mockAuth.Setup(x => x.GetAccessToken()).Returns(Task.FromResult("I am a token"));
            mockAuth.Setup(x => x.GetTokenFromCache()).Returns(" ");
            var result = await petFinderService.Get(mockOptions.Object.Value.PetFinderAnimalUrl);

            mockAuth.Verify(x => x.GetAccessToken(), Times.Exactly(1));         
        }
    }
}
