using Phone_Store_Management.BUS;
using Phone_Store_Management.DAO;
using Phone_Store_Management.Entities;
using Phone_Store_Management.ViewModel;
using Phone_Store_Management.Windows;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Phone_Store_Management.UserControls
{
    /// <summary>
    /// Interaction logic for UCBill.xaml
    /// </summary>
    public partial class UCBill : UserControl
    {
        private List<Bill> listBills;
        private BillBUS billBUS;
        private BillDetailBUS billDetailBUS;

        public UCBill()
        {
            InitializeComponent();            
            billBUS = new BillBUS();
            billDetailBUS = new BillDetailBUS();
            LoadList();
        }
                
        public void HideComponents()
        {
            DeleteColumn.Width = 0;
            CashierLabel.Visibility = Visibility.Collapsed;
            CashierIDTextBox.Visibility = Visibility.Collapsed;
            CashierIDTextBox.Text = LoginViewModel.UserID.ToString();
        }

        private void DeleteButton_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                MessageBoxResult result = MessageBox.Show("Do you want to delete it?", "Confirm", MessageBoxButton.YesNo, MessageBoxImage.Question);
                switch (result)
                {
                    case MessageBoxResult.Yes:
                        Bill bill = (sender as Button).DataContext as Bill;
                        billBUS.Delete(bill);

                        MessageBox.Show("Delete Bill Success",
                                              "Result",
                                              MessageBoxButton.OK,
                                              MessageBoxImage.Information);
                        LoadList();
                        break;
                    case MessageBoxResult.No:
                        break;
                    default:
                        break;
                }
            }
            catch
            {

            }
        }

        private void Find_Click(object sender, RoutedEventArgs e)
        {
            if (startDate.Text.ToString().Equals("") || endDate.Text.ToString().Equals("") || CashierIDTextBox.Text.ToString().Equals(""))
            {
                return;      
            }

            DateTime start = DateTime.Parse(startDate.Text.ToString());
            DateTime end = DateTime.Parse(endDate.Text.ToString());
            int id = int.Parse(CashierIDTextBox.Text.ToString());

            ObservableCollection<Bill> lst = billBUS.GetAll(start, end, id);
            if (lst != null)
            {
                ListBills.ItemsSource = lst;
                ListBills.Items.Refresh();
            }
            else
            {
                MessageBox.Show("Bills Not Found",
                                "Result",
                                MessageBoxButton.OK,
                                MessageBoxImage.Information);
            }
        }

        private void ViewButton_Click(object sender, RoutedEventArgs e)
        {
            //var lst = new List<BillDetail>();
            Bill bill = (sender as Button).DataContext as Bill;
            //bill = billBUS.Get(bill.BillID);
            var lst = billDetailBUS.GetAllByID(bill.Id);
                if (lst != null)
            {
                var viewbilldetailWindow = new ViewBillDetailWindow(lst);
                viewbilldetailWindow.ShowDialog();
            }
        }

        private void LoadList()
        {
            listBills = billBUS.GetAll();

            if (CashierDashboard.isStart)
            {
                HideComponents();
                listBills = billBUS.GetAllByID(LoginViewModel.UserID);
            }
            ListBills.ItemsSource = listBills;
        }
    }
}
