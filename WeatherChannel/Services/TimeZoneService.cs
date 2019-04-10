using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using WeatherChannel.Model;

namespace WeatherChannel.Services
{
    public class TimeZoneService : ITimeZoneService
    {
        private IConfiguration _config;
        private ILogger<TimeZoneService> _logger;

        public TimeZoneService(IConfiguration config, ILogger<TimeZoneService> logger)
        {
            _config = config;
            _logger = logger;
        }

        public async Task<string> GetTimeZoneAsync(decimal lon, decimal lat)
        {
            try
            {
                using (var client = new HttpClient())
                {
                    var url = new Uri(string.Format(_config.GetValue<string>("ZoneAPI:APIUrl"), lat, lon, 
                        new DateTimeOffset(DateTime.UtcNow).ToUnixTimeSeconds(),
                        _config.GetValue<string>("ZoneAPI:APIKey")));


                    var response = await client.GetAsync(url);
                    string json;

                    if (response.IsSuccessStatusCode)
                    {
                        using (var content = response.Content)
                        {
                            json = await content.ReadAsStringAsync();
                        }


                        return JsonConvert.DeserializeObject<TimeZoneModel>(json).timeZoneName;
                    }
                    else
                    {
                        _logger.LogError($"Error From Service {url}: Status Code: {(int)response.StatusCode}" +
                            $"Response Phrase: {response.ReasonPhrase}");
                        return null;
                    }


                }
            }
            catch (Exception ex)
            {
                _logger.LogError($"Error while retrieving timezone { ex}");
                throw ex;
            }

        }
    }
}
