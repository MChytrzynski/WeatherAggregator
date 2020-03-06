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
        public double Latitude { get; set; }
        public double Longitude { get; set; }
    }
}
