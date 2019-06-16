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
        private BillDAO billDAO;
        private CustomerInfoDAO customerInfoDAO;
        private WarrantyDAO warrantyDAO;

        private CustomerInfo customer;
        public static bool IsSuccessPayment = false;


        public BillDetailWindow()
        {
            InitializeComponent();
        }

        public BillDetailWindow(Basket basket, CustomerInfo cus)
        {
            InitializeComponent();
            listBillProducts.ItemsSource = basket.Details;
            this.basket = basket;
            this.customer = cus;

            billDAO = new BillDAO();
            customerInfoDAO = new CustomerInfoDAO();
            warrantyDAO = new WarrantyDAO();
        }

        private void ConfirmButton_Click(object sender, RoutedEventArgs e)
        {
            MessageBoxResult result = MessageBox.Show("Are you sure?", "", MessageBoxButton.YesNo);
            switch (result)
            {
                case MessageBoxResult.Yes:
                    Pay();
                    IsSuccessPayment = true;
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
                BillDate = DateTime.Now,
                CashierID = LoginViewModel.UserID,
                TotalPrice = basket.TotalPrice()
            };

         
            foreach (var item in basket.Details)
            {
                //Thêm vào bảng chi tiết hóa đơn
                BillDetail detail = new BillDetail()
                {
                    BillID = bill.BillID,
                    ProductId = item.ProductId,
                    Amount = item.Quantity,
                    UnitPrice = item.UnitPrice,
                };
                bill.BillDetails.Add(detail);

                //Thêm vào bảng bảo hành
                Warranty war = new Warranty()
                {
                    PhoneNumber = customer.PhoneNumber,
                    ProductID = item.ProductId,
                    StartDate = bill.BillDate,
                    EndDate = bill.BillDate.AddDays(Constant.ONEYEAR)
                };
                warrantyDAO.Add(war);
            }

            //Thêm vào bảng hóa đơn
            billDAO.Add(bill);

            if (!customerInfoDAO.IsExisted(customer.PhoneNumber))
            {
                //Thêm vào bảng khách hàng
                customerInfoDAO.Add(customer);
            }
            

            MessageBox.Show("Thanh toán thành công",
                                   "Result",
                                   MessageBoxButton.OK,
                                   MessageBoxImage.Information);
            Close();
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
