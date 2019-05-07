using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace Phone_Store_Management.Utilities
{
    public class LogError
    {
        public string Error;
        public LogError(string error)
        {
            Error = error;
        }

        public void Show()
        {
            MessageBox.Show(Error, "Error", MessageBoxButton.OK, MessageBoxImage.Error);
        }

    }
}
