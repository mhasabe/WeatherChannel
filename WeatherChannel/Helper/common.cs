using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WeatherChannel.Helper
{
    public static class Common
    {
        public static string convertToFahrenheitFromKelvin(decimal temp)
        {
            return (9 / 5 * (temp - 273) + 32).ToString();
        }
    }
}
