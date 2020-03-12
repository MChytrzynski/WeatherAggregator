using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using WeatherAggregator.Data;

namespace WeatherAggregator.Services
{
    public interface ILocationResolver
    {
        public Task<Coordinates> ResolveLocation(string locationQuery);
    }
}
