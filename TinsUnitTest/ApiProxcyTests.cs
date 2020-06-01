using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Xunit;
using Tines;
using System.Net;
using Moq.Protected;
using System.Threading;
using Moq;
using System.IO;
using System.Configuration;
using System.Net.Http;
using Assert = Xunit.Assert;
using TinsUnitTest.Helpers.HtppClient;
using System.Web.Http.Results;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json.Linq;
using Newtonsoft.Json;

namespace TinsUnitTest
{
    [TestClass]
    public class ApiProxyTests
    {
        [TestMethod]
        [Fact]
        public async Task ShouldReturnPosts()
        {

            var handlerMock = FakeHttpMessageHandler.NewMock();
            string json = "";
            string path = Path.GetDirectoryName(AppDomain.CurrentDomain.BaseDirectory.Replace("\\bin\\Debug","")) + ConfigurationManager.AppSettings["TestJson"];
            var directory = System.IO.Path.GetDirectoryName(path);

            using (StreamReader r = new StreamReader(path))
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
            var client = HttpClientHelper.NewTestClient(handlerMock.Object);
            var proxy = new ApiProxyTestClass(client);


            var  retrievedData = await proxy.GetLocationAsync(client.BaseAddress.ToString());

            //Assert.NotNull(retrievedData);
            Assert.True(retrievedData.Any());
            Assert.Equal(json,retrievedData);
         

        }

        [TestMethod]
        [Fact]
        public async Task WhenTheCallIsSuccessfulThenWeShouldReceiveAListOfStrings()
        {
            var handler = FakeHttpMessageHandler.NewMock();
            string jsonData = @"{'City': 'Dublin'}";
            handler.SetupSuccessfulCall(new List<string> { jsonData });
            var client = HttpClientHelper.NewTestClient(handler.Object);

            var proxy = new ApiProxyTestClass(client);
            var result = (await proxy.GetLocationAsync(client.BaseAddress.ToString()));
            Assert.Contains("Dublin",result.ToString());
            Assert.NotNull(result);
           
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
