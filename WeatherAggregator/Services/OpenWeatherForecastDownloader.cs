using System;
using System.Net.Http;
using System.Threading.Tasks;
using System.Windows;
using WeatherAggregator.Data;
using WeatherAggregator.Data.Models;

namespace WeatherAggregator.Services
{
    /// <summary>
    /// Class that handles downloading forecasts from OpenWeather API
    /// </summary>
    class OpenWeatherForecastDownloader : IForecastDownloader
    {   
        #region Private Fields
        private readonly HttpClient httpClient;
        private string connectionString;
        private string apiKey;
        #endregion
        #region Constructor
        public OpenWeatherForecastDownloader(HttpClient httpClient)
        {
            this.httpClient = httpClient;
            connectionString = ApiConnectionData.OpenWeatherCurrentWeatherConnectionString;
            apiKey = ApiConnectionData.OpenWeatherApiKey;
        }
        #endregion
        #region Private Methods
        /// <summary>
        /// Create apropriate connection string to get current weather
        /// String pattern
        /// http://api.openweathermap.org/data/2.5/weather?lat={latitude}&lon={longitude}&appid={apiKey}
        /// </summary>
        /// <param name="coordinates"></param>
        /// <returns></returns>
        private string ComposeCurrentWeatherRequestString(Coordinates coordinates)
        {
            return $"{connectionString}lat={coordinates.Latitude}&lon={coordinates.Longitude}&appid={apiKey}";
        }
        #endregion
        #region Public Methods
        /// <summary>
        /// Downloads current weather state at given coordinates
        /// </summary>
        /// <param name="coordinates"><see cref="Coordinates"></see>/></param>
        /// <returns>Returns deserialized ForecastModel object</returns>
        public async Task<ForecastModel> GetForecast(Coordinates coordinates)
        {
            try
            {
                string requestString = ComposeCurrentWeatherRequestString(coordinates);
                //get data from api
                HttpResponseMessage response = await httpClient.GetAsync(requestString);
                //check if request is successful, otherwise throw exception
                response.EnsureSuccessStatusCode();
                //extract data from response
                string responseString = await response.Content.ReadAsStringAsync();
                //deserialize response
                var deserializedResponse = OpenWeatherDeserializer.FromJson(responseString);
                //create and return forecast model with forecast data
                return new ForecastModel() { Date=DateTime.Today, Location=coordinates, SourceType=ForecastSourceType.OpenWeather, Temperature=deserializedResponse.Main.Temp, WeatherCode=deserializedResponse.Weather[0].Id.ToString() };
            }
            catch (Exception e)
            {
                MessageBox.Show($"Downloading forecast from OpenWeatherMaps.com failed, an exception has occured: {e.Message }");
            }
            return null;
        }
        /// <summary>
        /// Downloads forecast for a given date at given coordinates
        /// </summary>
        /// <param name="coordinates"><see cref="Coordinates"></see>/></param>
        /// <param name="date"> is a date between now and 5 days from now</param>
        /// <returns>Returns deserialized ForecastModel object</returns>
        async public Task<ForecastModel> GetForecast(Coordinates coordinates, DateTime date)
        {
            throw new NotImplementedException();
        }
        #endregion
    }
}
