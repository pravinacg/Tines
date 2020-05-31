using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Security.Policy;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Web;

namespace Tines
{

    public static class ParseJson
    {
        
        public static string ParseURL(string URL,string Json)
        {
            string validatedURL = URL;
            string key = "";
            string keyVal = "";
            JObject jsonTins = JObject.Parse(Json);

            // NameValueCollection qscoll = HttpUtility.ParseQueryString(URL);

            Dictionary<string, string> qscoll = GetParams(URL);
            // Iterate through the collection.
            StringBuilder sb = new StringBuilder("<br />");
            foreach (String s in qscoll.Values)
            {
                if(s.Contains('.'))
                {
                    var array = s.Split('.');
                    key = array[1].ToString().Replace("}}","").Trim();
                }
                if(Json.Contains(key))
                {

                }
                JToken value;
                if (jsonTins.TryGetValue(key, out value))
                {
                    keyVal = value.ToString();
                }
                validatedURL = validatedURL.Replace(s, keyVal);
            }
           
            return validatedURL;
        }

        static List<string> getStringToReplace(string uri)
        {
            List<string> ab = new List<string>();
            var xy = uri.Split().Where(x => x.StartsWith("{") && x.EndsWith("}")).ToList();
            return ab;
        }

        static Dictionary<string, string> splitStingByChar(string uri)
        {
            var matches = Regex.Matches(uri, @"\{{([^}}]+)\}}", RegexOptions.Compiled);
            return matches.Cast<Match>().ToDictionary(
                m => Uri.UnescapeDataString(m.Index.ToString()),
                m => Uri.UnescapeDataString(m.Value)
            );
            //var pattern = @"\{{([^}}]+)\}}";
            //Dictionary<string, string> KVPs = (from Match m in Regex.Matches(uri, pattern)
            //                                   select new
            //                                   {
            //                                       key = m.Index.ToString(),
            //                                       value = m.Value
            //                                   }
            //).ToDictionary(p => p.key, p => p.value);


            //return KVPs;


        }
        static Dictionary<string, string> GetParams(string uri)
        {
            var matches = Regex.Matches(uri, @"[\?&](([^&=]+)=([^&=#]*))", RegexOptions.Compiled);
           
            return matches.Cast<Match>().ToDictionary(
                m => Uri.UnescapeDataString(m.Groups[2].Value),
                m => Uri.UnescapeDataString(m.Groups[3].Value)
            );
        }

        public static string parsePrint(string url,string tinsResponse)
        {
            string validatedURL = url;
            string key = "";
            string keyVal = "";
            JObject jsonTins = JObject.Parse(tinsResponse);
            Dictionary<string, string> qscoll = splitStingByChar(url);
            StringBuilder sb = new StringBuilder("<br />");

            foreach (String s in qscoll.Values)
            {
                keyVal = "";
                if (s.Contains('.'))
                {
                    var array = s.Split('.');
                    key = array[array.Length-1].ToString().Replace("}}", "").Trim();
                }
               
                JToken value;
                JObject jo = JObject.Parse(tinsResponse);

                foreach (JToken token in jo.FindTokens(key))
                {
                   keyVal = token.ToString();
                }

                
                validatedURL = (keyVal != ""?validatedURL.Replace(s, keyVal):validatedURL);
            }

            return validatedURL;
        
        }

        public static List<JToken> FindTokens(this JToken containerToken, string name)
        {
            List<JToken> matches = new List<JToken>();
            FindTokens(containerToken, name, matches);
            return matches;
        }

        private static void FindTokens(JToken containerToken, string name, List<JToken> matches)
        {
            if (containerToken.Type == JTokenType.Object)
            {
                foreach (JProperty child in containerToken.Children<JProperty>())
                {
                    if (child.Name == name)
                    {
                        matches.Add(child.Value);
                    }
                    FindTokens(child.Value, name, matches);
                }
            }
            else if (containerToken.Type == JTokenType.Array)
            {
                foreach (JToken child in containerToken.Children())
                {
                    FindTokens(child, name, matches);
                }
            }
        }

    }
}
