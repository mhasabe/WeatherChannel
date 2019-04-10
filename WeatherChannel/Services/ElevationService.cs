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
    public class ElevationService : IElevationService
    {
        private IConfiguration _config;
        private ILogger<ElevationService> _logger;

        public ElevationService(IConfiguration config, ILogger<ElevationService> logger)
        {
            _config = config;
            _logger = logger;
        }

        public async Task<string> GetElevationAsync(decimal lon, decimal lat)
        {
            try
            {
                using (var client = new HttpClient())
                {
                    var url = new Uri(string.Format(_config.GetValue<string>("ElevationAPI:APIUrl"), lat, lon,
                        _config.GetValue<string>("ElevationAPI:APIKey")));

                    var response = await client.GetAsync(url);

                    string json;
                    if (response.IsSuccessStatusCode)
                    {

                        using (var content = response.Content)
                        {
                            json = await content.ReadAsStringAsync();
                        }

                        return JsonConvert.DeserializeObject<ElevationModel>(json).results.FirstOrDefault().elevation.ToString();
                    }
                    else
                    {

                        return null;
                    }
                }
            }
            catch (Exception ex)
            {
                _logger.LogError($"Error while retrieving Elevation Data {ex}");
                throw;
            }

        }

    }
}
