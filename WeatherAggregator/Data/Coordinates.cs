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
        public Coordinates(double Latitude,double Longitude)
        {
            this.Latitude = Latitude;
            this.Longitude = Longitude;
        }
        public double Latitude { get; private set; }
        public double Longitude { get; private set; }
    }
}
