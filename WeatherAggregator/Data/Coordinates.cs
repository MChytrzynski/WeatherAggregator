using System;
using System.Collections.Generic;
using System.Text;

namespace WeatherAggregator.Data
{
    /// <summary>
    /// Struct describing coordinates, containst Latitude and Longitutde
    /// </summary>
    public struct Coordinates
    {
        public Coordinates(string Latitude,string Longitude)
        {
            this.Latitude = Latitude;
            this.Longitude = Longitude;
        }
        public string Latitude { get; private set; }
        public string Longitude { get; private set; }
    }
}
