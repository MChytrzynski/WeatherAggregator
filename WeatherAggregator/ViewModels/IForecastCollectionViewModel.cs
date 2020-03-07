using System.Collections.Generic;
using System.Windows.Input;
using WeatherAggregator.Data.Models;

namespace WeatherAggregator.ViewModels
{
    public interface IForecastCollectionViewModel
    {
        /// <summary>
        /// List containing all forecasts
        /// </summary>
        public List<ForecastModel> ForecastsCollection { get; set; }
        double Latitude { get; set; }
        double Longitude { get; set; }
        /// <summary>
        /// Calls method that downloads forecast from each provider
        /// </summary>
        ICommand StartForecastDownloads { get; set; }
    }
}