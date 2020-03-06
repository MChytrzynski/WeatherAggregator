using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using WeatherAggregator.Data;
using WeatherAggregator.Data.Models;

namespace WeatherAggregator.Services
{
    /// <summary>
    /// Interface describing forecast downloaders
    /// </summary>
    interface IForecastDownloader
    {
        /// <summary>
        /// Downloads current weather state at given coordinates
        /// </summary>
        /// <param name="coordinates"><see cref="Coordinates"></see>/></param>
        /// <returns></returns>
        Task<ForecastModel> GetForecast(Coordinates coordinates);
        /// <summary>
        /// Downloads forecast for a given date at given coordinates
        /// </summary>
        /// <param name="coordinates"><see cref="Coordinates"></see>/></param>
        /// <param name="date"> is a date between now and 5 days from now</param>
        /// <returns></returns>
        Task<ForecastModel> GetForecast(Coordinates coordinates, DateTime date);
    }
}
