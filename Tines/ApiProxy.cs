using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Runtime.Serialization;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Tines
{
    public class ApiProxy :IDisposable
    {
        protected HttpClient _client;

        public ApiProxy()
        {
            _client = new HttpClient
            {
                BaseAddress = new Uri("http://free.ipwhois.io/json/")
            };
        }

        public async Task<string> GetValues(string url)
        {
            string TinsResponse = "";
            try
            {
                
                HttpResponseMessage response = _client.GetAsync(url).Result;
                TinsResponse = JObject.Parse(await response.Content.ReadAsStringAsync()).ToString();
            }
            catch (Exception e)
            {
                throw new ServiceFailedException(e);
            }
            return TinsResponse;
        }

        public  async Task<string> GetLocationAsync(string url)
        {
            string TinsResponse = "";
            try
            {
                var request = new HttpRequestMessage(HttpMethod.Post, url);
                request.Headers.Accept.Clear();
                request.Headers.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                _client.BaseAddress = new Uri(url);

                         
                HttpResponseMessage response = await _client.SendAsync(request);
               
                if (response.IsSuccessStatusCode)
                {
                    TinsResponse = JObject.Parse(await response.Content.ReadAsStringAsync()).ToString();
                }
                else
                {
                    TinsResponse =  await GetValues(url);
                }
            }
            catch(Exception ex)
            {
                throw new ServiceFailedException(ex);
            }
            return TinsResponse;
        }

        public void Dispose()
        {
            ((IDisposable)_client).Dispose();
        }

     
    }

    
   
}
