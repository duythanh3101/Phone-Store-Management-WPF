using Phone_Store_Management.DAO;
using Phone_Store_Management.Entities;
using Phone_Store_Management.ViewModel;
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
        private ObservableCollection<Bill> listBills;
        private BillDAO billDAO;

        public UCBill()
        {
            InitializeComponent();            
            billDAO = new BillDAO();
            listBills = new ObservableCollection<Bill>(billDAO.GetAll());
           

            if (CashierDashboard.isStart)
            {
                HideComponents();
                listBills = new ObservableCollection<Bill>(billDAO.GetAll().Where(b => b.CashierID == LoginViewModel.UserID));
            }
            ListBills.ItemsSource = listBills;
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

        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {

        }

        private void Find_Click(object sender, RoutedEventArgs e)
        {
            List<Bill> lst = listBills.ToList();
            if (!startDate.Text.ToString().Equals(""))
            {
                lst = lst.FindAll(b => b.BillDate >= DateTime.Parse(startDate.Text));       
            }
            if (!endDate.Text.ToString().Equals(""))
            {
                lst = lst.FindAll(b => b.BillDate <= DateTime.Parse(endDate.Text));
            }
            if (!CashierIDTextBox.ToString().Equals(""))
            {
                lst = lst.FindAll(b => b.CashierID == int.Parse(CashierIDTextBox.Text));
            }

            if (lst.Count > 0)
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
    }
}
