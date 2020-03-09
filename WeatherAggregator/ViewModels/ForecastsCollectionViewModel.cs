using System.Collections.Generic;
using System.Collections.ObjectModel;
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
        private ObservableCollection<IForecastViewModel> forecastsCollection;
        #endregion
        #region Constructor
        public ForecastCollectionViewModel(IEnumerable<IForecastDownloader> forecastDownloaders)
        {
            StartForecastDownloads = new RelayCommand(() => InitializeForecastsDownloads());
            this.forecastDownloaders = forecastDownloaders;
        }
        #endregion
        #region Public Properties
        /// <summary>
        /// Calls method that downloads forecast from each provider
        /// </summary>
        public ICommand StartForecastDownloads { get; set; }
        /// <summary>
        /// List containing all forecasts viewmodels
        /// </summary>
        public ObservableCollection<IForecastViewModel> ForecastsCollection
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
        /// Create forecastviewmodel for each forecast downloader and inject that forecast downloader through constructor
        /// </summary>
        private void InitializeForecastsDownloads()
        {
            ForecastsCollection = new ObservableCollection<IForecastViewModel>();
            var coordinates = new Coordinates(Latitude, Longitude);
            foreach (var forecastDownloader in forecastDownloaders)
            {
                forecastsCollection.Add(new ForecastViewModel(forecastDownloader,coordinates));
            }
        }
        #endregion
    }
}
