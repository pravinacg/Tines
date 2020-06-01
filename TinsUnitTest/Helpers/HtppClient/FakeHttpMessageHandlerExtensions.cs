using Moq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Formatting;


namespace TinsUnitTest.Helpers.HtppClient
{
    public static class FakeHttpMessageHandlerExtensions
    {
       public static void SetupSuccessfulCall<T>(this Mock<FakeHttpMessageHandler> handler, T returnObj) =>
            handler.Setup(h => h.Send(It.IsAny<HttpRequestMessage>()))
                .Returns(new HttpResponseMessage
                {
                    StatusCode = HttpStatusCode.OK,
                    Content = new ObjectContent<T>(returnObj, new JsonMediaTypeFormatter())
                });

        public static void SetupFailedCall(this Mock<FakeHttpMessageHandler> handler) =>
            handler.Setup(h => h.Send(It.IsAny<HttpRequestMessage>()))
                .Returns(new HttpResponseMessage
                {
                    StatusCode = HttpStatusCode.InternalServerError
                });
    }
}
