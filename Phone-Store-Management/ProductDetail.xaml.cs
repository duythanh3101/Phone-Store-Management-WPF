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
    /// Interaction logic for ProductDetail.xaml
    /// </summary>
    public partial class ProductDetail : Window
    {
        public ProductDetail()
        {
            InitializeComponent();
        }

        public ProductDetail(Product product)
        {
            InitializeComponent();
            imgProduct.Source = new BitmapImage(new Uri(product.ImageURL));
            txtDisplayName.Text = product.DisplayName;
            txtBrand.Text = product.Brand;
            txtPrice.Text = product.Price.ToString();
            txtDesc.Text = product.Description;
            txtQuantity.Text = product.Quantity.ToString();
        }

        private void Window_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            Close();
        }
    }
}
