using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text;
using System.Windows.Data;
using System.Windows.Markup;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using WeatherAggregator.Data;

namespace WeatherAggregator.ValueConverters
{
    /// <summary>
    /// Converts weather descriptor to <see cref="BitmapImage"/>
    /// </summary>
    class WeatherDescriptorToIconConverter :MarkupExtension,IValueConverter
    {
        
        private static WeatherDescriptorToIconConverter converter;
        /// <summary>
        /// Tries to convert weather description to coresponding icon by looking for some keywords
        /// </summary>
        /// <param name="value">Weather description</param>
        /// <param name="targetType"><see cref="BitmapImage"></see>/></param>
        /// <returns></returns>
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value == null)
                return null;
            var descriptor = value.ToString().ToLower();
            var icon = Properties.Resources.sun;
            if (descriptor.Contains("rain") || descriptor.Contains("drizzle") || descriptor.Contains("pellets"))
            {
                icon = Properties.Resources.rain;
            }
            else if (descriptor.Contains("clear") || descriptor.Contains("sun"))
            {
                icon = Properties.Resources.sun;
            }
            else if (descriptor.Contains("cloud") || descriptor.Contains("overcast"))
            {
                icon = Properties.Resources.clouds;
            }
            else if (descriptor.Contains("snow") || descriptor.Contains("blizzard") || descriptor.Contains("sleet"))
            {
                icon = Properties.Resources.snow;
            }
            else if (descriptor.Contains("fog") || descriptor.Contains("mist"))
            {
                icon = Properties.Resources.mist;
            }

            else if (descriptor.Contains("thunder"))
            {
                icon = Properties.Resources.thunderstorm;
            }
            return (BitmapSource)new ImageSourceConverter().ConvertFrom(icon);
        }
        /// <summary>
        /// Not implemented
        /// </summary>
        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
        /// <summary>
        /// Returns instance of this class for markup extension
        /// </summary>
        /// <param name="serviceProvider"></param>
        /// <returns></returns>
        public override object ProvideValue(IServiceProvider serviceProvider)
        {
            return converter ?? (converter = new WeatherDescriptorToIconConverter());
        }
    }
}
