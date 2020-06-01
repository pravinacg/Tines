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
            string HTTPAgentPath;
            if (args.Length == 0)
            {
                Console.WriteLine("Missing input ,Please pass filename along with Path");
                 HTTPAgentPath = Console.ReadLine();
            }
            else
            {
                HTTPAgentPath = args[0];
            }
          
           
            //Read any file of json type

            string json = "";
            if(!File.Exists(HTTPAgentPath))
            {
                Console.WriteLine("File not found");
                return;
            }
            using (StreamReader r = new StreamReader(HTTPAgentPath))
            {
                json = r.ReadToEnd();
               
            }

            RootAgents agentList = JsonConvert.DeserializeObject<RootAgents>(json);

            string locationURL;
            string agentName;
            string tinsResponse="";
            ApiProxy proxy = new ApiProxy();

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
                        foreach(string jsonResponseCollection in arrResult)
                        {
                            locationURL = ParseJson.parsePrint(locationURL, jsonResponseCollection); 
                        }
                       
                        Console.WriteLine(locationURL);
                        

                    }

                }
               
            }

            Console.ReadLine();

        }

    }
}
