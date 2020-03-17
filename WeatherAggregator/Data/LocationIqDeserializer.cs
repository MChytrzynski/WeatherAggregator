﻿// <auto-generated />
//
// To parse this JSON data, add NuGet 'Newtonsoft.Json' then do:
//
//    using ConsoleApp15;
//
//    var locationIq = LocationIq.FromJson(jsonString);

namespace WeatherAggregator
{
    using System;
    using System.Collections.Generic;

    using System.Globalization;
    using Newtonsoft.Json;
    using Newtonsoft.Json.Converters;

    public partial class LocationIqDeserializer
    {
        [JsonProperty("place_id", NullValueHandling = NullValueHandling.Ignore)]
        public long? PlaceId { get; set; }

        [JsonProperty("licence", NullValueHandling = NullValueHandling.Ignore)]
        public Uri Licence { get; set; }

        [JsonProperty("osm_type", NullValueHandling = NullValueHandling.Ignore)]
        public string? OsmType { get; set; }

        [JsonProperty("osm_id", NullValueHandling = NullValueHandling.Ignore)]
        public string OsmId { get; set; }

        [JsonProperty("boundingbox", NullValueHandling = NullValueHandling.Ignore)]
        public List<string> Boundingbox { get; set; }

        [JsonProperty("lat", NullValueHandling = NullValueHandling.Ignore)]
        public string Lat { get; set; }

        [JsonProperty("lon", NullValueHandling = NullValueHandling.Ignore)]
        public string Lon { get; set; }

        [JsonProperty("display_name", NullValueHandling = NullValueHandling.Ignore)]
        public string DisplayName { get; set; }

        [JsonProperty("class", NullValueHandling = NullValueHandling.Ignore)]
        public string? Class { get; set; }

        [JsonProperty("type", NullValueHandling = NullValueHandling.Ignore)]
        public string Type { get; set; }

        [JsonProperty("importance", NullValueHandling = NullValueHandling.Ignore)]
        public double? Importance { get; set; }

        [JsonProperty("icon", NullValueHandling = NullValueHandling.Ignore)]
        public Uri Icon { get; set; }
    }



}
