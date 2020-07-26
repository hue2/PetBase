using Moq;
using Moq.Protected;
using System;
using System.Net;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;

namespace Petbase.DataService.Tests
{
    public class MockHttpHandler
    {
        public static HttpClient GetClientWithHandler(StringContent content = null)
        {
            var response = new HttpResponseMessage(HttpStatusCode.OK);
            response.Content = content;

            var mockHandler = new Mock<DelegatingHandler>();
            mockHandler.Protected()
                .Setup<Task<HttpResponseMessage>>("SendAsync", ItExpr.IsAny<HttpRequestMessage>(), ItExpr.IsAny<CancellationToken>())
                .ReturnsAsync(response)
                .Verifiable();
            mockHandler.As<IDisposable>().Setup(s => s.Dispose());
            var httpClient = new HttpClient(mockHandler.Object);

            return httpClient;
        }
    }
}
