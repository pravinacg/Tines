using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace TinsUnitTest.Helpers.HtppClient
{
    public static class HttpClientHelper
    {
        public static System.Net.Http.HttpClient NewTestClient(HttpMessageHandler handler)
        {
            return new System.Net.Http.HttpClient(handler) { BaseAddress = new Uri("http://free.ipwhois.io/json/") };
        }
    }
}
