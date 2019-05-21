using Phone_Store_Management.DAO;
using Phone_Store_Management.DTO;
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
    /// Interaction logic for UCSale.xaml
    /// </summary>
    public partial class UCSale : UserControl
    {
        private ObservableCollection<Product> listProducts;
        private ObservableCollection<ProductInCart> Cart;

        public UCSale()
        {
            InitializeComponent();
            var db = new DBStoreManagementEntities();

            Cart = new ObservableCollection<ProductInCart>();
            listProducts = new ObservableCollection<Product>(db.Products.ToList());
            listitem.ItemsSource = listProducts;
            listProductsInCart.ItemsSource = Cart;
        }

        private void AddProductInCart_Click(object sender, MouseButtonEventArgs e)
        {
            try
            {
                Product pr = (Product)listitem.SelectedItems[0];
                //Check if product is exist in the cart
                int position = GetPositionOfProductInCartByID(pr.Id);
                if (position != -1)
                {
                    //Increase amount of products
                    Cart[position].Count++;
                }
                else // if not exist, add product into a cart
                {
                    Cart.Add(new ProductInCart(pr.Id, pr.DisplayName, pr.Brand, pr.TypeId, pr.Price, pr.Description, pr.Quantity,
                        pr.ImageURL, 1));
                }

                listProductsInCart.Items.Refresh();
                listitem.SelectedItems.Clear();

                double totalprice = Cart.Sum(p => p.GetTotalPrice());
                decimal value = 0.00M;
                value = Convert.ToDecimal(totalprice);
                total.Text = value.ToString("C");
                ProductDetail uc = new ProductDetail(pr);
                uc.ShowDialog();
            }
            catch
            {

            }
        }

        /// <summary>
        /// Get position of product in cart by id
        /// if exist, return this postion
        /// else return -1
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        private int GetPositionOfProductInCartByID(int id)
        {
            int len = Cart.Count;
            for (int i = 0; i < len; i++)
            {
                if (id == Cart[i].Id)
                {
                    return i;
                }
            }
            return -1;
        }

        private void PayButton_Click(object sender, RoutedEventArgs e)
        {
            var billWindow = new BillDetailWindow(Cart);
            billWindow.ShowDialog();
        }

        private void Delete_Click(object sender, RoutedEventArgs e)
        {
            Button btn = sender as Button;
            ProductInCart pr = btn.DataContext as ProductInCart; //Get product in cart
            int pos = GetPositionOfProductInCartByID(pr.Id); // Get posiotion of product in cart listview
            Cart.RemoveAt(pos);
        }

        private void ClearButton_Click(object sender, RoutedEventArgs e)
        {
            MessageBoxResult result = MessageBox.Show("Do you want to clear all products?", "", MessageBoxButton.YesNo);
            switch (result)
            {
                case MessageBoxResult.Yes:
                    Cart.Clear();
                    break;
                case MessageBoxResult.No:
                    break;
            }
        }
    }
}
