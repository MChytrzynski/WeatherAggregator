using System;
using System.Collections.Generic;
using System.Text;
using WeatherAggregator.ViewModels.Base;
using WeatherAggregator.Data;
using WeatherAggregator.Data.Models;
using WeatherAggregator.Services;
using System.Windows;

namespace WeatherAggregator.ViewModels
{
    /// <summary>
    /// A View model containing single forecast, downloads its data using injected <see cref="IForecastDownloader"/>
    /// </summary>
    class ForecastViewModel : BaseViewModel, IForecastViewModel
    {
        #region Private Fields
        //injected forecast downloader
        private readonly IForecastDownloader forecastDownloader;
        private readonly Coordinates coordinates;
        private ForecastModel forecast;
        #endregion
        #region Constructor
        public ForecastViewModel(IForecastDownloader forecastDownloader, Coordinates coordinates)
        {
            this.forecastDownloader = forecastDownloader;
            this.coordinates = coordinates;
            GetForecast();
        }
        #endregion
        #region Properties
        /// <summary>
        /// Contains whole downloaded forecast, invokes propertychanged event for every property depending on its data
        /// </summary>
        private ForecastModel Forecast
        {
            get { return forecast; }
            set
            {
                if (forecast != value)
                {
                    //if forecast changed, invoke propertychanged for each property using its data
                    forecast = value;
                    InvokePropertyChanged(nameof(ForecastSource));
                    InvokePropertyChanged(nameof(Temperature));
                    InvokePropertyChanged(nameof(Descriptor));
                    InvokePropertyChanged(nameof(Date));
                }
            }
        }

        /// <summary>
        /// Informs which implementation of <see cref="IForecastDownloader"/> was used to get this forecast
        /// </summary>
        public ForecastSourceType? ForecastSource { get { return Forecast?.SourceType; } }
        /// <summary>
        /// Informs about temperature in this forecast
        /// </summary>
        public int? Temperature { get { return Convert.ToInt32(Forecast?.Temperature); } }
        /// <summary>
        /// Date that is covered by this forecast
        /// </summary>
        public string Date { get { return Forecast?.Date.ToString("dd-MM-yyyy"); } }
        /// <summary>
        /// Weather descriptor represents weather conditions at requested location
        /// <see cref="https://openweathermap.org/weather-conditions"/>
        /// </summary>
        public string Descriptor { get { return Forecast?.WeatherDescriptor; } }
        #endregion
        #region Private methods
        /// <summary>
        /// Downloads forecast data using <see cref="forecastDownloader"/>
        /// </summary>
        private async void GetForecast()
        {
            Forecast=await forecastDownloader.GetForecast(coordinates);
        }
        #endregion
    }
}
