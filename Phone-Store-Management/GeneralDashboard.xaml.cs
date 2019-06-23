using MaterialDesignThemes.Wpf;
using Phone_Store_Management.Entities;
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
    /// Interaction logic for GeneralDashboard.xaml
    /// </summary>
    public partial class GeneralDashboard : Window
    {
        public static int userID;
        public GeneralDashboard()
        {
            InitializeComponent();
            GridMain.Children.Add(new UCSale());
        }

        public void SetLoggedInUser(User user)
        {
            txtLoggedInUser.Text = user.DisplayName;
            txtWelcomeText.Text = "Hi, " + user.DisplayName + "!";
            userID = user.Id;
        }

        public void SetCashierUI()
        {
            ListViewMenu.Items.Add(new LVItem("ItemSale", "Sale", MaterialDesignThemes.Wpf.PackIconKind.Shopify));
            ListViewMenu.Items.Add(new LVItem("ItemPersonalInfo", "Personal Info", MaterialDesignThemes.Wpf.PackIconKind.UserCardDetails));
            ListViewMenu.Items.Add(new LVItem("ItemBill", "Bill History", MaterialDesignThemes.Wpf.PackIconKind.Receipt));
            ListViewMenu.Items.Add(new LVItem("ItemLogOut", "Log out", MaterialDesignThemes.Wpf.PackIconKind.Logout));
        }
        public void SetManagerUI()
        {
            ListViewMenu.Items.Add(new LVItem("ItemSale", "Sale", MaterialDesignThemes.Wpf.PackIconKind.Shopify));
            ListViewMenu.Items.Add(new LVItem("ItemProductManager", "Product Manager", MaterialDesignThemes.Wpf.PackIconKind.AddShoppingCart));
            ListViewMenu.Items.Add(new LVItem("ItemStatistics", "Statistics", MaterialDesignThemes.Wpf.PackIconKind.ChartBar));
            ListViewMenu.Items.Add(new LVItem("ItemStaffManager", "Staff Manager", MaterialDesignThemes.Wpf.PackIconKind.UserSupervisor));
            ListViewMenu.Items.Add(new LVItem("ItemBill", "Bill History", MaterialDesignThemes.Wpf.PackIconKind.Receipt));
            ListViewMenu.Items.Add(new LVItem("ItemPersonalInfo", "Personal Info", MaterialDesignThemes.Wpf.PackIconKind.UserCardDetails));
            ListViewMenu.Items.Add(new LVItem("ItemLogOut", "Log out", MaterialDesignThemes.Wpf.PackIconKind.Logout));
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

            //switch (((ListViewItem)((ListView)sender).SelectedItem).Name)
            switch (((LVItem)((ListView)sender).SelectedItem).Name)
            {
                case "ItemSale":
                    usc = new UCSale();
                    GridMain.Children.Add(usc);
                    break;
                case "ItemProductManager":
                    usc = new UCProductManager();
                    GridMain.Children.Add(usc);
                    break;
                case "ItemStatistics":
                    usc = new UCStatistics();
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
                case "ItemStaffManager":
                    usc = new UCStaffManager();
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
