using System;

namespace WeatherAggregator.Data.Models
{
    /// <summary>
    /// Contains data that describes weather at given time
    /// </summary>
    class ForecastModel
    {
        /// <summary>
        /// Requested location
        /// </summary>
        public Coordinates Location { get; set; }
        /// <summary>
        /// Date that is covered by this forecast
        /// </summary>
        public DateTime Date { get; set; }
        /// <summary>
        /// Temperature at requested location
        /// </summary>
        public double Temperature { get; set; }
        /// <summary>
        /// Weather code describing weather conditions at requested location
        /// <see cref="https://openweathermap.org/weather-conditions"/>
        /// </summary>
        public string WeatherCode { get; set; }
        /// <summary>
        /// Forecast provider used to get this forecast
        /// </summary>
        public ForecastSourceType SourceType { get; set; }
    }
}
