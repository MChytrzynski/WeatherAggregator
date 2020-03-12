
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using WeatherAggregator.Data;

namespace WeatherAggregator.Services
{
    class LocationResolver : ILocationResolver
    {
        #region Private Fields
        private readonly HttpClient httpClient;
        private string connectionString;
        private string apiKey;
        #endregion
        #region Constructor
        public LocationResolver(HttpClient httpClient)
        {
            this.httpClient = httpClient;
            connectionString = ApiConnectionData.LocationIQConnectionString;
            apiKey = ApiConnectionData.LocationIQApiKey;
        }
        #endregion
        #region Private methods
        private string ComposeRequestString(string query)
        {
            return $"{connectionString}?key={apiKey}&q={query}&format=json";
        }
        #endregion
        #region Public methods
        /// <summary>
        /// Resolves query into Coordinates object using LocationIq API
        /// </summary>
        /// <param name="locationQuery"></param>
        /// <returns></returns>
        public async Task<Coordinates> ResolveLocation(string locationQuery)
        {
            try
            {
                if (String.IsNullOrEmpty(locationQuery))
                    throw new Exception("Location cannot be empty");
                string requestString = ComposeRequestString(locationQuery);
                //get data from api
                HttpResponseMessage response = await httpClient.GetAsync(requestString);
                //check if request is successful, otherwise throw exception
                response.EnsureSuccessStatusCode();
                //extract data from response
                string responseString = await response.Content.ReadAsStringAsync();
                //deserialize response
                var Jresponse = JsonConvert.DeserializeObject<JToken>(responseString);
                if (!(Jresponse is JArray) && Jresponse["error"] != null)
                {
                    throw new Exception(Jresponse["error"].Last.First.ToString());
                }
                //response JArray to target type
                var deserializedResponse = Jresponse.ToObject<List<LocationIqDeserializer>>();
                //create and return coordinates object with resolved latitude and longitude
                return new Coordinates(deserializedResponse[0]?.Lat,deserializedResponse[0]?.Lon);
            }
            catch (Exception e)
            {
                MessageBox.Show($"Resolving location failed, an exception has occured: {e.Message }");
                return new Coordinates();
            }
        }
        #endregion
    }
}
