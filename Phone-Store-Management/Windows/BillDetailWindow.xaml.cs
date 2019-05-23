using Phone_Store_Management.DAO;
using Phone_Store_Management.Entities;
using Phone_Store_Management.Utilities;
using Phone_Store_Management.ViewModel;
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
        private Basket basket;

        public BillDetailWindow()
        {
            InitializeComponent();
        }

        public BillDetailWindow(Basket basket)
        {
            InitializeComponent();
            listBillProducts.ItemsSource = basket.Details;
            this.basket = basket;
        }

        private void ConfirmButton_Click(object sender, RoutedEventArgs e)
        {
            MessageBoxResult result = MessageBox.Show("Are you sure?", "", MessageBoxButton.YesNo);
            switch (result)
            {
                case MessageBoxResult.Yes:
                    Pay();
                    break;
                case MessageBoxResult.No:
                    break;
                default:
                    break;
            }
        }

        public void Pay()
        {
            Bill bill = new Bill()
            {
                BillDate = DateTime.Today,
                CashierID = LoginViewModel.UserID,
                TotalPrice = basket.TotalPrice(),
            };

            foreach (var item in basket.Details)
            {
                BillDetail detail = new BillDetail()
                {
                    BillID = bill.BillID,
                    ProductId = item.ProductId,
                    Amount = item.Quantity,
                    UnitPrice = item.UnitPrice,
                };
                bill.BillDetails.Add(detail);

                //Update quantity of product in database
                Product pro = new ProductDAO().Get(item.ProductId);
                pro.Quantity -= item.Quantity;
            }

            new BillDAO().Add(bill);
            MessageBox.Show("Thanh toán thành công",
                                   "Result",
                                   MessageBoxButton.OK,
                                   MessageBoxImage.Information);
            Close();
            basket.Details.Clear();
        }

        private void CancelButton_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            Total.Text = MoneyConverter.ToDecimal(basket.TotalPrice());
        }

        private void Receive_TextChanged(object sender, TextChangedEventArgs e)
        {
            try
            {
                if (!Receive.Text.Equals("") && !Total.Text.Equals(""))
                {
                    double total = basket.TotalPrice();
                    double receive = double.Parse(Receive.Text);
                    if (receive - total >= 0)
                    {
                        Exchange.Text = MoneyConverter.ToDecimal(receive - total);
                        ConfirmButton.Visibility = Visibility.Visible;
                    }
                    else
                    {
                        ConfirmButton.Visibility = Visibility.Collapsed;
                        Exchange.Text = "$0.00";
                    }
                }
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
