using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WeatherChannel.Services;
using WeatherChannel.Helper;
namespace WeatherChannel.Controllers
{

    [Route("api/[Controller]")]
    [Produces("Application/Json")]
    public class LocationController : Controller
    {
        private IWeatherService _weatherService;
        private ILogger<LocationController> _logger;
        private IElevationService _elevationService;
        private ITimeZoneService _timeZoneService;

        public LocationController(IWeatherService weatherService, ITimeZoneService timeZoneService, IElevationService elevationService,
            ILogger<LocationController> logger)
        {
            _elevationService = elevationService;
            _timeZoneService = timeZoneService;
            _weatherService = weatherService;
            _logger = logger;


        }

        [HttpGet()]
        [HttpGet("{zipcode}")]
        [ProducesResponseType(200)]
        [ProducesResponseType(400)]
        public async Task<IActionResult> Get(string zipcode)
        {
            try
            {
                if (string.IsNullOrEmpty(zipcode))
                {
                    return BadRequest("Please provide zipcode");
                }


                var wTask = await _weatherService.GetWeatherInfoAsync(zipcode);

                var tTask = _timeZoneService.GetTimeZoneAsync(wTask.lon, wTask.lat);
                var eTask = _elevationService.GetElevationAsync(wTask.lon, wTask.lat);

                await Task.WhenAll(tTask, eTask);


                var output = string.Format("At the location {0}, the temperature is {1} K, the timezone is {2}, and the elevation is {3} Meter"
                    , wTask.cityName, wTask.temp, tTask.Result, eTask.Result);

                return Ok(output);
            }
            catch (Exception ex)
            {
                _logger.LogError($"Failed to get City Info: {ex} ");

                return BadRequest("Failed to get data from service");

            }
        }
    }
}
