using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tines.Data
{

     public class Agents
    {
        /// <summary>
        /// 
        /// </summary>
        public string type { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string name { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public Options options { get; set; }
    }

    public class RootAgents
    {
        /// <summary>
         
        /// </summary>
        public List<Agents> Agents { get; set; }
    }
    public class Options
        {
            public string url { get; set; }
            public string message { get; set; }
        }

        public class Requestor
        {
            /// <summary>
            /// 
            /// </summary>
            public string type { get; set; }
            /// <summary>
            /// 
            /// </summary>
            public string name { get; set; }
            /// <summary>
            /// 
            /// </summary>
            public Options options { get; set; }
        }

    public class Location1
    {
        /// <summary>
        /// 
        /// </summary>
        public string ip { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string success { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string type { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string continent { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string continent_code { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string country { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string country_code { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string country_flag { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string country_capital { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string country_phone { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string country_neighbours { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string region { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string city { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string latitude { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string longitude { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string asn { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string org { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string isp { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string timezone { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string timezone_name { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string timezone_dstOffset { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string timezone_gmtOffset { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string timezone_gmt { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string currency { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string currency_code { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string currency_symbol { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string currency_rates { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string currency_plural { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public int completed_requests { get; set; }
    }

    public class Location
    {
        /// <summary>
        /// 
        /// </summary>
        public string ip { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string success { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string type { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string continent { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string continent_code { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string country { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string country_code { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string country_flag { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string country_capital { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string country_phone { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string country_neighbours { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string region { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string city { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string latitude { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string longitude { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string asn { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string org { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string isp { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string timezone { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string timezone_name { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string timezone_dstOffset { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string timezone_gmtOffset { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string timezone_gmt { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string currency { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string currency_code { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string currency_symbol { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string currency_rates { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string currency_plural { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public int completed_requests { get; set; }
    }

    public class results
    {
        /// <summary>
        /// 
        /// </summary>
        public string sunrise { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string sunset { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string solar_noon { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string day_length { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string civil_twilight_begin { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string civil_twilight_end { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string nautical_twilight_begin { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string nautical_twilight_end { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string astronomical_twilight_begin { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string astronomical_twilight_end { get; set; }
    }

     public class RootSunset
    {
        public string status { get; set; }
        public results results { get; set; }
    }
}
