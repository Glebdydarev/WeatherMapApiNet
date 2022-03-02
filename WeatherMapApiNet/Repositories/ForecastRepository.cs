using ForecastApp.OpenWeatherMapModels;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System.Net.Http;
namespace ForecastApp.Repositories
{
    public class ForecastRepository : IForecastRepository
    {
        

        WeatherResponse IForecastRepository.GetForecast(string city)
        {
            //var weatherResponse = new WeatherResponse();

            string IDOWeather = Constants.Open_Weather_APPID;
            // Connection String
            var client = new HttpClient();
            var weatherURL = $"http://api.openweathermap.org/data/2.5/weather?q={city}&units=imperial&appid={IDOWeather}";

 
            try
            {
                var response = client.GetStringAsync(weatherURL).Result;

                // Deserialize the string content into JToken object
                var content = JsonConvert.DeserializeObject<WeatherResponse>(response);

                return content;

            }
            catch { return null; }

            
        }

    }
}
