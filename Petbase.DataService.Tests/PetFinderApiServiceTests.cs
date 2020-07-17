using Microsoft.Extensions.Options;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using Petbase.DataService.Interfaces;
using Petbase.DataService.Models;
using Petbase.DataService.Services;
using System.Net.Http;

namespace Petbase.DataService.Tests
{
    [TestClass]
    public class PetFinderApiServiceTests
    {
        private Mock<IHttpClientFactory> mockClient;
        private Mock<IOptions<AppSettings>> mockOptions;
        private Mock<ICacheService> mockCache;
        private PetFinderApiService petFinderService;

        [TestInitialize]
        public void Init()
        {
            this.mockClient = new Mock<IHttpClientFactory>();
            this.mockOptions = new Mock<IOptions<AppSettings>>();
            var appSettings = new AppSettings()
            {
                PetFinderAnimalUrl = "apple",
            };
            this.mockOptions.Setup(x => x.Value).Returns(appSettings);

            this.mockCache = new Mock<ICacheService>();
            this.petFinderService = new PetFinderApiService(mockClient.Object, mockOptions.Object, mockCache.Object);
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

            var expected = $"{this.mockOptions.Object.Value.PetFinderAnimalUrl}?location=2&distance=1&breed=apple";

            var result = this.petFinderService.GetQueryString(filter);
            Assert.AreEqual(expected, result);
        }
    }
}
