using Newtonsoft.Json;
using SofoTest.Services.Models;
using System;
using System.Net.Http;
using System.Threading.Tasks;

namespace SofoTest.Services {

    public interface IWeatherService {
        Task<WeatherModel> FetchByZipCode(string zipCode);
    }


    /// <summary>
    /// Handle the logic for fetching weather from openweatherapi.com
    /// https://openweathermap.org/api
    /// </summary>
    public class WeatherService : IWeatherService {
        static HttpClient client = new HttpClient();

        /// <summary>
        /// Api key to use. Passed      
        /// </summary>
        private string ApiKey { get; set; }

        /// <summary>
        /// Base address for the OpenWeather Api
        /// </summary>
        private string OpenWeatherApiUri { get; set; } = "http://api.openweathermap.org/data/2.5";

        public WeatherService(string apiKey) {
            ApiKey = apiKey;
        }



        /// <summary>
        /// Fetches the weather for a specified zip code.
        /// Use an httpclient to get the result from openweathermap. Then deserialize the result into the
        /// Services.Models.WeatherModel class
        /// Documentation at https://openweathermap.org/api
        /// </summary>
        /// <param name="zipCode">ZipCode to fetch weather for</param>
        /// <returns></returns>
        public async Task<WeatherModel> FetchByZipCode(string zipCode) {
            //TODO 
            var defaultLocation = "us";
            WeatherModel model = new WeatherModel();
            try
            {
                HttpResponseMessage response = await client.GetAsync(System.String.Format("api.openweathermap.org/data/2.5/weather?zip={0},{1}&appid={2}", zipCode, defaultLocation, ApiKey));
                response.EnsureSuccessStatusCode();
                Console.WriteLine(response);
                //model = JsonConvert.DeserializeObject<WeatherModel>(response.Content.ReadAsStringAsync());
            } catch(HttpRequestException e)
            {
                Console.WriteLine("Exception : " + e.Message);
            }

            return model;       
        }

    }
}

