using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WeatherChannel.Model;

namespace WeatherChannel.Services
{
    public interface ITimeZoneService
    {
        Task<string> GetTimeZoneAsync(decimal lon, decimal lat);
    }
}
