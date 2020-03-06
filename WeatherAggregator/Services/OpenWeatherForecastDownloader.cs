using System;
using System.Threading.Tasks;
using WeatherAggregator.Data;
using WeatherAggregator.Data.Models;

namespace WeatherAggregator.Services
{
    /// <summary>
    /// Class that handles downloading forecasts from OpenWeather API
    /// </summary>
    class OpenWeatherForecastDownloader : IForecastDownloader
    {
        /// <summary>
        /// Downloads current weather state at given coordinates
        /// </summary>
        /// <param name="coordinates"><see cref="Coordinates"></see>/></param>
        /// <returns>Returns deserialized ForecastModel object</returns>
        public Task<ForecastModel> GetForecast(Coordinates coordinates)
        {
            throw new NotImplementedException();
        }
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
