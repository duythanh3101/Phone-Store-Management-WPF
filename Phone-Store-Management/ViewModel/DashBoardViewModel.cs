using Phone_Store_Management.UserControls;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace Phone_Store_Management.ViewModel
{
    public class DashBoardViewModel: BaseViewModel
    {

        public ICommand CloseWindowCommand { get; set; }
        public ICommand MinimizeWindowCommand { get; set; }
        public ICommand MaximizeWindowCommand { get; set; }
        public ICommand MouseMoveWindowCommand { get; set; }

        public DashBoardViewModel()
        {
            CloseWindowCommand = new RelayCommand<Window>((p) => { return p == null ? false : true; }, (p) => { p.Close(); });
            MinimizeWindowCommand = new RelayCommand<Window>((p) => { return p == null ? false : true; }, (p) =>
            {
                if (p != null)
                {
                    if (p.WindowState != WindowState.Minimized)
                    {
                        p.WindowState = WindowState.Minimized;
                    }
                    else
                    {
                        p.WindowState = WindowState.Maximized;
                    }
                }

            });
            MaximizeWindowCommand = new RelayCommand<Window>((p) => { return p == null ? false : true; }, (p) =>
            {
                if (p != null)
                {
                    if (p.WindowState != WindowState.Maximized)
                    {
                        p.WindowState = WindowState.Maximized;
                    }
                    else
                    {
                        p.WindowState = WindowState.Normal;
                    }
                }
            });
            MouseMoveWindowCommand = new RelayCommand<Window>((p) => { return p == null ? false : true; }, (p) =>
            {
                p.DragMove();
            });
        }
    }
}
