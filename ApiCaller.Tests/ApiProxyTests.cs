
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using ApiCaller.Tests.Helpers.HttpClient;
using Xunit;
using Tines;
using System.Net;
using Moq.Protected;
using System.Threading;
using Moq;
using Castle.Components.DictionaryAdapter.Xml;
using System.IO;
using System.Configuration;

namespace ApiCaller.Tests
{
    public class ApiProxyTests
    {
        [Fact]
        public async void ShouldReturnPosts()
        {
      
            var handlerMock = FakeHttpMessageHandler.NewMock();
            string json = "";
            
            using (StreamReader r = new StreamReader(ConfigurationManager.AppSettings["TestJson"]))
            {
                json = r.ReadToEnd();
            }
            var response = new HttpResponseMessage
            {
                StatusCode = HttpStatusCode.OK,
                Content = new StringContent(json),
            };

            handlerMock
               .Protected()
               .Setup<Task<HttpResponseMessage>>(
                  "SendAsync",
                  ItExpr.IsAny<HttpRequestMessage>(),
                  ItExpr.IsAny<CancellationToken>())
               .ReturnsAsync(response);
            var httpClient = new HttpClient(handlerMock.Object);
            var proxy = new ApiProxy();


            var retrievedData = await proxy.GetLocationAsync("http://free.ipwhois.io/json/");

            Assert.NotNull(retrievedData);
            handlerMock.Protected().Verify(
               "SendAsync",
               Times.Exactly(1),
               ItExpr.Is<HttpRequestMessage>(req => req.Method == HttpMethod.Get),
               ItExpr.IsAny<CancellationToken>());
        }

        [Fact]
        public async Task WhenTheCallIsSuccessfulThenWeShouldReceiveAListOfStrings()
        {
            var handler = FakeHttpMessageHandler.NewMock();
            handler.SetupSuccessfulCall(new List<string>{"test1", "test2"});
            var client = HttpClientHelper.NewTestClient(handler.Object);

            var proxy = new ApiProxy();

            var result = await proxy.GetValues("http://free.ipwhois.io/json/");

            Assert.NotNull(result);
            Assert.True(result.Any());
            Assert.Equal("test1", result);
          
        }

        private class ApiProxyTestClass : ApiProxy
        {
            public ApiProxyTestClass(HttpClient client)
            {
                this._client = client;
            }

           
        }
    }
}