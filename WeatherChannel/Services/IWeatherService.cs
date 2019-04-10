using System.Threading.Tasks;
using WeatherChannel.Model;

namespace WeatherChannel.Services
{
    public interface IWeatherService
    {
        Task<WeatherInfo> GetWeatherInfoAsync(string zipCode);
    }
}