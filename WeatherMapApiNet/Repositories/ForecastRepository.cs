using ForecastApp.OpenWeatherMapModels;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System.Net.Http;
namespace ForecastApp.Repositories
{
    public class ForecastRepository : IForecastRepository
    {
        //private object weather;

        //private readonly string _conn;

        ////public ForecastRepository(string conn)
        ////{
        ////    _conn = conn;
        ////}

        WeatherResponse IForecastRepository.GetForecast(string city)
        {
            //var weatherResponse = new WeatherResponse();

            string IDOWeather = Constants.Open_Weather_APPID;
            // Connection String
            var client = new HttpClient();
            var weatherURL = $"http://api.openweathermap.org/data/2.5/weather?q={city}&units=imperial&appid={IDOWeather}";

            //var response2 = new WeatherResponse();
            //string IDOMaps = Constants.mapsApiKey;
             

            try
            {
                var response = client.GetStringAsync(weatherURL).Result;

                // Deserialize the string content into JToken object
                var content = JsonConvert.DeserializeObject<JToken>(response);

                // Deserialize the JToken object into our WeatherResponse Class
                return content.ToObject<WeatherResponse>();


                //get Google Maps key
                //var key = System.IO.File.ReadAllText("appsettings.json");
               // var key =  JObject.Parse(Constants.GOOGLE_MAP_KEY).ToString();

                //generate Google Maps embed address
                //weatherResponse.MapURL = $""



            }
            catch { return null; }

            
        }

    }
}
