using System;
using System.Collections.Generic;
using System.Text;

namespace WeatherAggregator
{
    /// <summary>
    /// Stores API keys and connection strings for different weather data providers
    /// </summary>
    public static class ApiConnectionData
    {
        /// <summary>
        /// Api key used to connect to OpenWeather API
        /// <see cref="https://openweathermap.org/appid"/>
        /// </summary>
        public const string OpenWeatherApiKey = "YOUR_API_KEY";
        /// <summary>
        /// Api key used to connect to WeatherStack API
        /// <see cref="https://weatherstack.com/signup/free"/>
        /// </summary>
        public const string WeatherStackApiKey = "YOUR_API_KEY";
        /// <summary>
        /// Api key used to connect to DarkSky API
        /// <see cref="https://darksky.net/dev"/>
        /// </summary>
        public const string DarkSkyApiKey = "YOUR_API_KEY";
        /// <summary>
        /// Api key used to connect to LocationIQ API
        /// <see cref="https://locationiq.com/register"/>
        /// </summary>
        public const string LocationIQApiKey = "YOUR_API_KEY";
        /// <summary>
        /// OpenWeather connection string used to get current weather
        /// </summary>
        public const string OpenWeatherCurrentWeatherConnectionString = "http://api.openweathermap.org/data/2.5/weather?";
        /// <summary>
        /// WeatherStack connection string used to get current weather
        /// </summary>
        public const string WeatherStackCurrentWeatherConnectionString = "http://api.weatherstack.com/current";
        /// <summary>
        /// DarkSky connection string used to get current weather
        /// </summary>
        public const string DarkSkyCurrentWeatherConnectionString = "https://api.darksky.net/forecast";
        /// <summary>
        /// LocationIQ connection string used to resolve locations
        /// </summary>
        public const string LocationIQConnectionString = "https://eu1.locationiq.com/v1/search.php";


    }
}
