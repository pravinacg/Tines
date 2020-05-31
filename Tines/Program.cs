using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;
using Tines.Data;
namespace Tines
{
    class Program
    {
          static async Task Main(string[] args)
        {
            string HTTPAgentPath = args[0];
            
            if(HTTPAgentPath == "")
            {
                Console.WriteLine("Missing input ,Please pass filename along with Path");
                return;
            }
           
            ApiProxy proxy = new ApiProxy();

            string json = "";
            using (StreamReader r = new StreamReader(HTTPAgentPath))
            {
                json = r.ReadToEnd();
            }
            RootAgents agentList = JsonConvert.DeserializeObject<RootAgents>(json);

            string locationURL = "";
            string agentName = "";
            string tinsResponse = "";

            if (agentList != null)
            {
                foreach (var agent in agentList.Agents)
                {
                    agentName = agent.name;

                    locationURL = (agent.options.url != null ? agent.options.url : agent.options.message);

                    if (agent.type == "HTTPRequestAgent")
                    {
                        
                        using (proxy = new ApiProxy())
                        {
                            if(locationURL.Contains("?"))
                            {
                                locationURL = ParseJson.parsePrint(locationURL, tinsResponse);
                            }
                            tinsResponse = (tinsResponse!=""? tinsResponse + "|" + await proxy.GetLocationAsync(locationURL): await proxy.GetLocationAsync(locationURL));
                        }

                    }
                    else if(agent.type == "PrintAgent")
                    {
                        var arrResult = tinsResponse.Split('|');
                        foreach(string s in arrResult)
                        {
                            locationURL = ParseJson.parsePrint(locationURL, s); 
                        }
                       
                        Console.WriteLine(locationURL);
                        

                    }

                }
               
            }

            Console.ReadLine();

        }

    }
}
