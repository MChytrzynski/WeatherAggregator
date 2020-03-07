using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;

namespace WeatherAggregator.ViewModels.Base
{
    class RelayCommand : ICommand
    {
        public event EventHandler CanExecuteChanged;
        private readonly Action action;
        /// <summary>
        /// Default constructor
        /// </summary>
        /// <param name="action"></param>
        public RelayCommand(Action action)
        {
            this.action = action;
        }
        /// <summary>
        /// Can always execute
        /// </summary>
        /// <param name="parameter"></param>
        /// <returns></returns>
        public bool CanExecute(object parameter)
        {
            return true;
        }

        /// <summary>
        /// Invoke the action on the view model.
        /// </summary>
        /// <param name="parameter"></param>
        public void Execute(object parameter)
        {
            action();
        }

    }
}
