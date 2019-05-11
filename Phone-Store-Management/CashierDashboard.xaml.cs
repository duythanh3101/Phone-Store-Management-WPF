using Phone_Store_Management.UserControls;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace Phone_Store_Management
{
    /// <summary>
    /// Interaction logic for Dashboard.xaml
    /// </summary>
    public partial class CashierDashboard : Window
    {
        public CashierDashboard()
        {
            InitializeComponent();
            GridMain.Children.Add(new UCSale());
        }

        private void ButtonOpenMenu_Click(object sender, RoutedEventArgs e)
        {
            ButtonCloseMenu.Visibility = Visibility.Visible;
            ButtonOpenMenu.Visibility = Visibility.Collapsed;
        }

        private void ButtonCloseMenu_Click(object sender, RoutedEventArgs e)
        {
            ButtonCloseMenu.Visibility = Visibility.Collapsed;
            ButtonOpenMenu.Visibility = Visibility.Visible;
        }

        private void ListViewMenu_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            UserControl usc = null;
            GridMain.Children.Clear();

            int index = ListViewMenu.SelectedIndex;
            MoveCursorMenu(index);

            switch (((ListViewItem)((ListView)sender).SelectedItem).Name)
            {
                case "ItemSale":
                    usc = new UCSale();
                    GridMain.Children.Add(usc);
                    break;
                case "ItemBill":
                    usc = new UCBill();
                    GridMain.Children.Add(usc);
                    break;
                case "ItemPersonalInfo":
                    usc = new UCPersonalInfo();
                    GridMain.Children.Add(usc);
                    break;
                case "ItemLogOut":
                    var loginWindow = new LoginWindow();
                    loginWindow.Show();
                    Close();
                    break;
                default:
                    break;
            }
        }

        private void MoveCursorMenu(int index)
        {
            TrainsitionigContentSlide.OnApplyTemplate();
            GridCursor.Margin = new Thickness(0, (10 + (60 * index)), 0, 0);
        }
    }
}
