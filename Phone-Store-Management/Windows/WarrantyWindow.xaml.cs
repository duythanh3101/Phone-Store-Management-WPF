using Phone_Store_Management.DAO;
using Phone_Store_Management.Entities;
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
using System.Windows.Shapes;

namespace Phone_Store_Management.Windows
{
    /// <summary>
    /// Interaction logic for WarrantyWindow.xaml
    /// </summary>
    public partial class WarrantyWindow : Window
    {
        private ObservableCollection<Warranty> list;
        private WarrantyDAO warrantyDAO;

        public WarrantyWindow()
        {
            InitializeComponent();

            warrantyDAO = new WarrantyDAO();
            list = new ObservableCollection<Warranty>();
            //listWarranties = list;
        }

        private void FindButton_Click(object sender, RoutedEventArgs e)
        {
            string phoneNumber = txtPhoneNumber.Text.ToString();
            if (!phoneNumber.Equals(""))
            {
                List<Warranty> lst = warrantyDAO.Get(phoneNumber);
                foreach (var item in lst)
                {
                    item.Product = new ProductDAO().Get(item.ProductID);
                }
                if (lst.Count != 0)
                {
                    listWarranties.ItemsSource = lst;
                    txtNotFound.Visibility = Visibility.Hidden;
                }
                else
                {
                    txtNotFound.Visibility = Visibility.Visible;
                }
            }
        }
    }
}
