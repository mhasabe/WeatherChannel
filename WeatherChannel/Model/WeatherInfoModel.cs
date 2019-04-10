using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WeatherChannel.Model
{

    public class WeatherInfo
    {
        public decimal temp { get; set; }
        public decimal lon { get; set; }
        public decimal lat { get; set; }
        public string cityName { get; set; }

    }



    //Data Sync 
    public class WeatherInfoModel
    {
        public coord coord { get; set; }

        [JsonProperty("main")]
        public main temp { get; set; }

        [JsonProperty("name")]
        public string cityName { get; set; }
    }

    public class coord
    {
        [JsonProperty("lon")]
        public decimal lon { get; set; }

        [JsonProperty("lat")]
        public decimal lat { get; set; }
    }

    public class main
    {
        [JsonProperty("temp")]
        public decimal temp { get; set; }

        [JsonProperty("pressure")]
        public decimal lot { get; set; }

        [JsonProperty("temp_min")]
        public decimal temp_min { get; set; }


        [JsonProperty("temp_max")]
        public decimal temp_max { get; set; }

    }
}
