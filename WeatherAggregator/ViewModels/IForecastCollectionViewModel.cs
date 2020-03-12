using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Windows.Input;
using WeatherAggregator.Data.Models;

namespace WeatherAggregator.ViewModels
{
    public interface IForecastCollectionViewModel
    {
        /// <summary>
        /// List containing all forecasts
        /// </summary>
        public ObservableCollection<IForecastViewModel> ForecastsCollection { get; set; }
        public string LocationQuery { get; set; }
        /// <summary>
        /// Calls method that downloads forecast from each provider
        /// </summary>
        ICommand StartForecastDownloads { get; set; }
    }
}