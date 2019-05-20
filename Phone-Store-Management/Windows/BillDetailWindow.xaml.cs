using Phone_Store_Management.DTO;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace Phone_Store_Management.Windows
{
    /// <summary>
    /// Interaction logic for BillDetailWindow.xaml
    /// </summary>
    public partial class BillDetailWindow : Window
    {
        private ObservableCollection<ProductInCart> listItems;
        public BillDetailWindow()
        {
            InitializeComponent();
        }

        public BillDetailWindow(ObservableCollection<ProductInCart> list)
        {
            InitializeComponent();
            listBillProducts.ItemsSource = list;
            listItems = list;
        }

        private void ConfirmButton_Click(object sender, RoutedEventArgs e)
        {

        }

        private void CancelButton_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            Total.Text = listItems[0].TotalPrice.ToString();
        }

        private void Receive_TextChanged(object sender, TextChangedEventArgs e)
        {
            try
            {
                //if (!Receive.Text.Equals("") && !Total.Text.Equals(""))
                //{
                //    if ((long.Parse(Receive.Text) - long.Parse(Total.Text)) >= 0)
                //    {
                //        decimal value = 0.00M;

                //        value = Convert.ToDecimal((long.Parse(Receive.Text) - long.Parse(Total.Text)));

                //        Exchange.Text = value.ToString("C");
                //        ConfirmButton.Visibility = Visibility.Visible;
                //    }
                //    else
                //    {
                //        ConfirmButton.Visibility = Visibility.Collapsed;
                //        Exchange.Text = "";
                //    }
                //}
            }
            catch
            {

            }
        }

        private void NumberValidationTextBox(object sender, TextCompositionEventArgs e)
        {
            Regex regex = new Regex("[^0-9]+");
            e.Handled = regex.IsMatch(e.Text);
        }
    }
}
