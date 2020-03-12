using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Threading.Tasks;
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
        private readonly ILocationResolver locationResolver;
        private ObservableCollection<IForecastViewModel> forecastsCollection;
        #endregion
        #region Constructor
        public ForecastCollectionViewModel(IEnumerable<IForecastDownloader> forecastDownloaders,ILocationResolver locationResolver)
        {
            StartForecastDownloads = new RelayCommand(() => InitializeForecastsDownloads());
            this.forecastDownloaders = forecastDownloaders;
            this.locationResolver = locationResolver;
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
        public string LocationQuery { get; set; }
        #endregion
        #region Private methods
        /// <summary>
        /// Try to resolve location query, if it was successful, create forecastviewmodel for each forecast downloader and inject that forecast downloader through constructor
        /// </summary>
        private async void InitializeForecastsDownloads()
        {
            //resolve location query into coordinates
            var coordinates = await locationResolver.ResolveLocation(LocationQuery);
            //check if resolving was successful
            if (coordinates.Latitude is null || coordinates.Latitude is null)
                return;
            //clean forecastcollection
            ForecastsCollection = new ObservableCollection<IForecastViewModel>();
            //create forecastviewmodel for each forecast downloader and inject that downloader 
            foreach (var forecastDownloader in forecastDownloaders)
            {
                forecastsCollection.Add(new ForecastViewModel(forecastDownloader,coordinates));
            }
        }
        #endregion
    }
}
