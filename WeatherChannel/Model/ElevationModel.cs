using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WeatherChannel.Model
{


    public class Location
    {
        public double lat { get; set; }
        public double lng { get; set; }
    }

    public class Result
    {
        public double elevation { get; set; }
        public Location location { get; set; }
        public double resolution { get; set; }
    }

    public class ElevationModel
    {
        public IList<Result> results { get; set; }
        public string status { get; set; }
    }


    
}
