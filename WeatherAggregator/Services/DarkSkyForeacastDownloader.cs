using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using WeatherAggregator.Data;
using WeatherAggregator.Data.Models;

namespace WeatherAggregator.Services
{
    class DarkSkyForeacastDownloader : IForecastDownloader
    {
        #region Private Fields
        private readonly HttpClient httpClient;
        private string connectionString;
        private string apiKey;
        #endregion
        #region Constructor
        public DarkSkyForeacastDownloader(HttpClient httpClient)
        {
            this.httpClient = httpClient;
            connectionString = ApiConnectionData.DarkSkyCurrentWeatherConnectionString;
            apiKey = ApiConnectionData.DarkSkyApiKey;
        }
        #endregion
        #region Private Methods
        /// <summary>
        /// Create apropriate connection string to get current weather
        /// String pattern
        /// https://api.darksky.net/forecast/{apiKey}/{latitude},{longitude}?units=si
        /// </summary>
        /// <param name="coordinates"></param>
        /// <returns></returns>
        private string ComposeCurrentWeatherRequestString(Coordinates coordinates)
        {
            return $"{connectionString}/{apiKey}/{coordinates.Latitude},{coordinates.Longitude}?units=si";
        }
        #endregion
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
                var deserializedResponse= JsonConvert.DeserializeObject<DarkSkyDeserializer>(responseString);
                //create and return forecast model with forecast data
                return new ForecastModel() {WeatherDescriptor=deserializedResponse.Currently.Summary, Date=DateTime.Today,SourceType=ForecastSourceType.DarkSky, Location=coordinates, Temperature=deserializedResponse.Currently.Temperature};
            }
            catch (Exception e)
            {
                MessageBox.Show($"Downloading forecast from DarkSky.net failed, an exception has occured: {e.Message }");
                return new ForecastModel() { WeatherDescriptor = "Weather download failed", Date = DateTime.Today, SourceType = ForecastSourceType.DarkSky };
            }
        }

        public Task<ForecastModel> GetForecast(Coordinates coordinates, DateTime date)
        {
            throw new NotImplementedException();
        }
    }
}
