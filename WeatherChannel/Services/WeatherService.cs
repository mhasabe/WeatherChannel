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
    public class WeatherService : IWeatherService
    {
        private IConfiguration _config;
        private readonly ILogger<WeatherInfo> _logger;

        public WeatherService(IConfiguration config, ILogger<WeatherInfo> logger)
        {
            _config = config;
            _logger = logger;
        }
        public async Task<WeatherInfo> GetWeatherInfoAsync(string zipCode)
        {
            try
            {
                using (var client = new HttpClient())
                {
                    var url = new Uri(string.Format(_config.GetValue<string>("WeatherAPI:APIUrl"), zipCode,
                            _config.GetValue<string>("WeatherAPI:APIKey")));

                    var response = await client.GetAsync(url);
                    string json;

                    if (response.IsSuccessStatusCode)
                    {
                        using (var content = response.Content)
                        {
                            json = await content.ReadAsStringAsync();
                        }

                        var result = JsonConvert.DeserializeObject<WeatherInfoModel>(json);

                        return new WeatherInfo
                        {
                            lat = result.coord.lat,
                            lon = result.coord.lon,
                            cityName = result.cityName,
                            temp = result.temp.temp
                        };
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
                _logger.LogError($"Error while retrieving weather information {ex}");

                throw ex;
            }


        }
    }
}
