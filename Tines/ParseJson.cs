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
        //NOTE:Alternate way is to use dynamic object and expandoObject, which will create classes dynamically
        
            
        // Will return string collection from URL which needs to replace
        static Dictionary<string, string> GetStringsToReplace(string uri)
        {
            var matches = Regex.Matches(uri, @"\{{([^}}]+)\}}", RegexOptions.Compiled);
            return matches.Cast<Match>().ToDictionary(
                m => Uri.UnescapeDataString(m.Index.ToString()),
                m => Uri.UnescapeDataString(m.Value)
            );
           
        }
       
        //This method will replace URL parmater from json response ,find textToReplace in json collection 
        public static string parsePrint(string url,string tinsResponse)
        {
            string validatedURL = url;
            string key = "";
            string keyVal = "";
         
            Dictionary<string, string> qscoll = GetStringsToReplace(url);
         
            foreach (String stringToReplace in qscoll.Values)
            {
                keyVal = "";
                if (stringToReplace.Contains('.'))
                {
                    var array = stringToReplace.Split('.');
                    key = array[array.Length-1].ToString().Replace("}}", "").Trim();
                }
               
               
                JObject responseObject = JObject.Parse(tinsResponse);

                foreach (JToken token in responseObject.FindTokens(key))
                {
                   keyVal = token.ToString();
                }

                
                validatedURL = (keyVal != "" ? validatedURL.Replace(stringToReplace, keyVal):validatedURL);
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
