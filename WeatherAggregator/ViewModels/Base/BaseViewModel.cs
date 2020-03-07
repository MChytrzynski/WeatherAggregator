using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace WeatherAggregator.ViewModels.Base
{
    /// <summary>
    /// Base class for all the view models
    /// </summary>
    class BaseViewModel : INotifyPropertyChanged
    {
        /// <summary>
        /// Event fired when property has changed
        /// </summary>
        public event PropertyChangedEventHandler PropertyChanged;
        /// <summary>
        /// Invokes <see cref="PropertyChanged"/> for given property name
        /// </summary>
        /// <param name="PropertyName"></param>
        internal void InvokePropertyChanged(string PropertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(PropertyName));
        }
    }
}
