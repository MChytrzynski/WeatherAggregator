namespace WeatherAggregator
{
    using System;
    using System.Collections.Generic;

    using System.Globalization;
    using Newtonsoft.Json;
    using Newtonsoft.Json.Converters;

    public partial class DarkSkyDeserializer
    {
        [JsonProperty("latitude", NullValueHandling = NullValueHandling.Ignore)]
        public double? Latitude { get; set; }

        [JsonProperty("longitude", NullValueHandling = NullValueHandling.Ignore)]
        public double? Longitude { get; set; }

        [JsonProperty("timezone", NullValueHandling = NullValueHandling.Ignore)]
        public string Timezone { get; set; }

        [JsonProperty("currently", NullValueHandling = NullValueHandling.Ignore)]
        public Currently Currently { get; set; }

        [JsonProperty("hourly", NullValueHandling = NullValueHandling.Ignore)]
        public Hourly Hourly { get; set; }

        [JsonProperty("daily", NullValueHandling = NullValueHandling.Ignore)]
        public Daily Daily { get; set; }

        [JsonProperty("flags", NullValueHandling = NullValueHandling.Ignore)]
        public Flags Flags { get; set; }

        [JsonProperty("offset", NullValueHandling = NullValueHandling.Ignore)]
        public long? Offset { get; set; }
    }

    public partial class Currently
    {
        [JsonProperty("time", NullValueHandling = NullValueHandling.Ignore)]
        public long? Time { get; set; }

        [JsonProperty("summary", NullValueHandling = NullValueHandling.Ignore)]
        public string Summary { get; set; }

        [JsonProperty("icon", NullValueHandling = NullValueHandling.Ignore)]
        public string Icon { get; set; }

        [JsonProperty("precipIntensity", NullValueHandling = NullValueHandling.Ignore)]
        public double? PrecipIntensity { get; set; }

        [JsonProperty("precipProbability", NullValueHandling = NullValueHandling.Ignore)]
        public double? PrecipProbability { get; set; }

        [JsonProperty("temperature", NullValueHandling = NullValueHandling.Ignore)]
        public double Temperature { get; set; }

        [JsonProperty("apparentTemperature", NullValueHandling = NullValueHandling.Ignore)]
        public double? ApparentTemperature { get; set; }

        [JsonProperty("dewPoint", NullValueHandling = NullValueHandling.Ignore)]
        public double? DewPoint { get; set; }

        [JsonProperty("humidity", NullValueHandling = NullValueHandling.Ignore)]
        public double? Humidity { get; set; }

        [JsonProperty("pressure", NullValueHandling = NullValueHandling.Ignore)]
        public double? Pressure { get; set; }

        [JsonProperty("windSpeed", NullValueHandling = NullValueHandling.Ignore)]
        public double? WindSpeed { get; set; }

        [JsonProperty("windGust", NullValueHandling = NullValueHandling.Ignore)]
        public double? WindGust { get; set; }

        [JsonProperty("windBearing", NullValueHandling = NullValueHandling.Ignore)]
        public long? WindBearing { get; set; }

        [JsonProperty("cloudCover", NullValueHandling = NullValueHandling.Ignore)]
        public double? CloudCover { get; set; }

        [JsonProperty("uvIndex", NullValueHandling = NullValueHandling.Ignore)]
        public long? UvIndex { get; set; }

        [JsonProperty("visibility", NullValueHandling = NullValueHandling.Ignore)]
        public double? Visibility { get; set; }

        [JsonProperty("ozone", NullValueHandling = NullValueHandling.Ignore)]
        public double? Ozone { get; set; }

        [JsonProperty("precipType", NullValueHandling = NullValueHandling.Ignore)]
        public string PrecipType { get; set; }
    }

    public partial class Daily
    {
        [JsonProperty("summary", NullValueHandling = NullValueHandling.Ignore)]
        public string Summary { get; set; }

        [JsonProperty("icon", NullValueHandling = NullValueHandling.Ignore)]
        public string Icon { get; set; }

        [JsonProperty("data", NullValueHandling = NullValueHandling.Ignore)]
        public List<Datum> Data { get; set; }
    }

    public partial class Datum
    {
        [JsonProperty("time", NullValueHandling = NullValueHandling.Ignore)]
        public long? Time { get; set; }

        [JsonProperty("summary", NullValueHandling = NullValueHandling.Ignore)]
        public string Summary { get; set; }

        [JsonProperty("icon", NullValueHandling = NullValueHandling.Ignore)]
        public string Icon { get; set; }

        [JsonProperty("sunriseTime", NullValueHandling = NullValueHandling.Ignore)]
        public long? SunriseTime { get; set; }

        [JsonProperty("sunsetTime", NullValueHandling = NullValueHandling.Ignore)]
        public long? SunsetTime { get; set; }

        [JsonProperty("moonPhase", NullValueHandling = NullValueHandling.Ignore)]
        public double? MoonPhase { get; set; }

        [JsonProperty("precipIntensity", NullValueHandling = NullValueHandling.Ignore)]
        public double? PrecipIntensity { get; set; }

        [JsonProperty("precipIntensityMax", NullValueHandling = NullValueHandling.Ignore)]
        public double? PrecipIntensityMax { get; set; }

        [JsonProperty("precipIntensityMaxTime", NullValueHandling = NullValueHandling.Ignore)]
        public long? PrecipIntensityMaxTime { get; set; }

        [JsonProperty("precipProbability", NullValueHandling = NullValueHandling.Ignore)]
        public double? PrecipProbability { get; set; }

        [JsonProperty("temperatureHigh", NullValueHandling = NullValueHandling.Ignore)]
        public double? TemperatureHigh { get; set; }

        [JsonProperty("temperatureHighTime", NullValueHandling = NullValueHandling.Ignore)]
        public long? TemperatureHighTime { get; set; }

        [JsonProperty("temperatureLow", NullValueHandling = NullValueHandling.Ignore)]
        public double? TemperatureLow { get; set; }

        [JsonProperty("temperatureLowTime", NullValueHandling = NullValueHandling.Ignore)]
        public long? TemperatureLowTime { get; set; }

        [JsonProperty("apparentTemperatureHigh", NullValueHandling = NullValueHandling.Ignore)]
        public double? ApparentTemperatureHigh { get; set; }

        [JsonProperty("apparentTemperatureHighTime", NullValueHandling = NullValueHandling.Ignore)]
        public long? ApparentTemperatureHighTime { get; set; }

        [JsonProperty("apparentTemperatureLow", NullValueHandling = NullValueHandling.Ignore)]
        public double? ApparentTemperatureLow { get; set; }

        [JsonProperty("apparentTemperatureLowTime", NullValueHandling = NullValueHandling.Ignore)]
        public long? ApparentTemperatureLowTime { get; set; }

        [JsonProperty("dewPoint", NullValueHandling = NullValueHandling.Ignore)]
        public double? DewPoint { get; set; }

        [JsonProperty("humidity", NullValueHandling = NullValueHandling.Ignore)]
        public double? Humidity { get; set; }

        [JsonProperty("pressure", NullValueHandling = NullValueHandling.Ignore)]
        public double? Pressure { get; set; }

        [JsonProperty("windSpeed", NullValueHandling = NullValueHandling.Ignore)]
        public double? WindSpeed { get; set; }

        [JsonProperty("windGust", NullValueHandling = NullValueHandling.Ignore)]
        public double? WindGust { get; set; }

        [JsonProperty("windGustTime", NullValueHandling = NullValueHandling.Ignore)]
        public long? WindGustTime { get; set; }

        [JsonProperty("windBearing", NullValueHandling = NullValueHandling.Ignore)]
        public long? WindBearing { get; set; }

        [JsonProperty("cloudCover", NullValueHandling = NullValueHandling.Ignore)]
        public double? CloudCover { get; set; }

        [JsonProperty("uvIndex", NullValueHandling = NullValueHandling.Ignore)]
        public long? UvIndex { get; set; }

        [JsonProperty("uvIndexTime", NullValueHandling = NullValueHandling.Ignore)]
        public long? UvIndexTime { get; set; }

        [JsonProperty("visibility", NullValueHandling = NullValueHandling.Ignore)]
        public double? Visibility { get; set; }

        [JsonProperty("ozone", NullValueHandling = NullValueHandling.Ignore)]
        public double? Ozone { get; set; }

        [JsonProperty("temperatureMin", NullValueHandling = NullValueHandling.Ignore)]
        public double? TemperatureMin { get; set; }

        [JsonProperty("temperatureMinTime", NullValueHandling = NullValueHandling.Ignore)]
        public long? TemperatureMinTime { get; set; }

        [JsonProperty("temperatureMax", NullValueHandling = NullValueHandling.Ignore)]
        public double? TemperatureMax { get; set; }

        [JsonProperty("temperatureMaxTime", NullValueHandling = NullValueHandling.Ignore)]
        public long? TemperatureMaxTime { get; set; }

        [JsonProperty("apparentTemperatureMin", NullValueHandling = NullValueHandling.Ignore)]
        public double? ApparentTemperatureMin { get; set; }

        [JsonProperty("apparentTemperatureMinTime", NullValueHandling = NullValueHandling.Ignore)]
        public long? ApparentTemperatureMinTime { get; set; }

        [JsonProperty("apparentTemperatureMax", NullValueHandling = NullValueHandling.Ignore)]
        public double? ApparentTemperatureMax { get; set; }

        [JsonProperty("apparentTemperatureMaxTime", NullValueHandling = NullValueHandling.Ignore)]
        public long? ApparentTemperatureMaxTime { get; set; }

        [JsonProperty("precipType", NullValueHandling = NullValueHandling.Ignore)]
        public string PrecipType { get; set; }

        [JsonProperty("precipAccumulation", NullValueHandling = NullValueHandling.Ignore)]
        public long? PrecipAccumulation { get; set; }
    }

    public partial class Flags
    {
        [JsonProperty("sources", NullValueHandling = NullValueHandling.Ignore)]
        public List<string> Sources { get; set; }

        [JsonProperty("meteoalarm-license", NullValueHandling = NullValueHandling.Ignore)]
        public string MeteoalarmLicense { get; set; }

        [JsonProperty("nearest-station", NullValueHandling = NullValueHandling.Ignore)]
        public double? NearestStation { get; set; }

        [JsonProperty("units", NullValueHandling = NullValueHandling.Ignore)]
        public string Units { get; set; }
    }

    public partial class Hourly
    {
        [JsonProperty("summary", NullValueHandling = NullValueHandling.Ignore)]
        public string Summary { get; set; }

        [JsonProperty("icon", NullValueHandling = NullValueHandling.Ignore)]
        public string Icon { get; set; }

        [JsonProperty("data", NullValueHandling = NullValueHandling.Ignore)]
        public List<Currently> Data { get; set; }
    }


   
}
