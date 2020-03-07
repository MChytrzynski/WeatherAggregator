using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Windows.Input;
using WeatherAggregator.Data;
using WeatherAggregator.Data.Models;
using WeatherAggregator.Services;
using WeatherAggregator.ViewModels.Base;

namespace WeatherAggregator.ViewModels
{
    /// <summary>
    /// View model containing all displayed forecasts
    /// </summary>
    class ForecastCollectionViewModel : BaseViewModel, IForecastCollectionViewModel
    {
        #region Private properties
        private readonly IEnumerable<IForecastDownloader> forecastDownloaders;
        private List<ForecastModel> forecastsCollection;
        #endregion
        #region Constructor
        public ForecastCollectionViewModel(IEnumerable<IForecastDownloader> forecastDownloaders)
        {
            StartForecastDownloads = new RelayCommand(() => GetForecasts());
            this.forecastDownloaders = forecastDownloaders;
        }
        #endregion
        #region Public Properties
        /// <summary>
        /// Calls method that downloads forecast from each provider
        /// </summary>
        public ICommand StartForecastDownloads { get; set; }
        /// <summary>
        /// List containing all forecasts
        /// </summary>
        public List<ForecastModel> ForecastsCollection
        {
            get
            {
                return forecastsCollection;
            }
            set
            {
                if (forecastsCollection != value)
                {
                    forecastsCollection = value;
                    InvokePropertyChanged(nameof(ForecastsCollection));
                }
            }
        }
        public double Longitude { get; set; }
        public double Latitude { get; set; }
        #endregion
        #region Private methods
        /// <summary>
        /// Calls GetForecast on each forecast downloader
        /// </summary>
        private async void GetForecasts()
        {
            forecastsCollection = new List<ForecastModel>();
            var coordinates = new Coordinates(Latitude, Longitude);
            foreach (var forecastDownloader in forecastDownloaders)
            {
                forecastsCollection.Add(await forecastDownloader.GetForecast(coordinates));
            }
        }
        #endregion
    }
}
