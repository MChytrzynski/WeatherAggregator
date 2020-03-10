using WeatherAggregator.Data;

namespace WeatherAggregator.ViewModels
{
    /// <summary>
    /// A View model containing single forecast, downloads its data using injected <see cref="IForecastDownloader"/>
    /// </summary>
    public interface IForecastViewModel
    {
        /// <summary>
        /// Informs which implementation of <see cref="IForecastDownloader"/> was used to get this forecast
        /// </summary>
        ForecastSourceType? ForecastSource { get; }
        /// <summary>
        /// Informs about temperature in this forecast
        /// </summary>
        int? Temperature { get; }
        /// <summary>
        /// Contains weather code describing current weather state
        /// <see cref="https://openweathermap.org/weather-conditions"/>
        /// </summary>
        string Descriptor { get; }
    }
}