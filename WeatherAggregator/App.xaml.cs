using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using System.Windows;
using WeatherAggregator.Services;
using WeatherAggregator.ViewModels;

namespace WeatherAggregator
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        private ServiceProvider _serviceProvider;
        public App()
        {
            var serviceCollection = new ServiceCollection();
            ConfigureServices(serviceCollection);
            _serviceProvider = serviceCollection.BuildServiceProvider();
        }
        private void ConfigureServices(IServiceCollection services)
        {
            services.AddSingleton<MainWindow>();
            services.AddTransient<IForecastCollectionViewModel,ForecastCollectionViewModel>();
            services.AddTransient<IForecastViewModel, ForecastViewModel>();
            services.AddTransient<IForecastDownloader,OpenWeatherForecastDownloader>();
            services.AddTransient<IForecastDownloader, WeatherStackForecastDownloader>();
            services.AddTransient<IForecastDownloader, DarkSkyForeacastDownloader>();
            services.AddTransient<ILocationResolver, LocationResolver>();
            services.AddSingleton<HttpClient>();
        }

        private void Application_Startup(object sender, StartupEventArgs e)
        {
            var mainWindow = _serviceProvider.GetService<MainWindow>();
            mainWindow.Show();
        }
    }

}
