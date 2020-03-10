
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
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
    class WeatherStackForecastDownloader : IForecastDownloader
    {
        #region Private Fields
        private readonly HttpClient httpClient;
        private string connectionString;
        private string apiKey;
        #endregion
        #region Constructor
        public WeatherStackForecastDownloader(HttpClient httpClient)
        {
            this.httpClient = httpClient;
            connectionString = ApiConnectionData.WeatherStackCurrentWeatherConnectionString;
            apiKey = ApiConnectionData.WeatherStackApiKey;
        }
        #endregion
        #region Private Methods
        /// <summary>
        /// Create apropriate connection string to get current weather
        /// String pattern
        /// http://api.weatherstack.com/current?access_key={apikey}&query={latitude},{longitude}
        /// </summary>
        /// <param name="coordinates"></param>
        /// <returns></returns>
        private string ComposeCurrentWeatherRequestString(Coordinates coordinates)
        {
            return $"{connectionString}?access_key={apiKey}&query={coordinates.Latitude},{coordinates.Longitude}";
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
                HttpResponseMessage responseMessage = await httpClient.GetAsync(requestString);
                //check if request is successful, otherwise throw exception
                responseMessage.EnsureSuccessStatusCode();
                //extract data from response
                string responseString = await responseMessage.Content.ReadAsStringAsync();
                //deserialize response to JArray
                var response = JsonConvert.DeserializeObject<JToken>(responseString);
                if (!(response is JArray) && response["error"] != null)
                {
                    throw new Exception(response["error"].Last.First.ToString());
                }
                //response JArray to target type
                var deserializedResponse= response.ToObject<WeatherStackDeserializer>();
                //create and return forecast model with forecast data
                return new ForecastModel() { Date=DateTime.Today, Location=coordinates, SourceType=ForecastSourceType.WeatherStack, Temperature=deserializedResponse.Current.Temperature, WeatherDescriptor=deserializedResponse.Current.WeatherDescriptions[0]};
            }
            catch (Exception e)
            {
                MessageBox.Show($"Downloading forecast from WeatherStack failed, an exception has occured: {e.Message }");
                return new ForecastModel() { WeatherDescriptor = "Weather download failed", Date = DateTime.Today, SourceType = ForecastSourceType.WeatherStack };
            }
        }
        #endregion
        /// <summary>
        /// Downloads forecast for a given date at given coordinates
        /// </summary>
        /// <param name="coordinates"><see cref="Coordinates"></see>/></param>
        /// <param name="date"> is a date between now and 5 days from now</param>
        /// <returns>Returns deserialized ForecastModel object</returns>
        public Task<ForecastModel> GetForecast(Coordinates coordinates, DateTime date)
        {
            throw new NotImplementedException();
        }
    }
}
