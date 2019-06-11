using Microsoft.Win32;
using Phone_Store_Management.DAO;
using Phone_Store_Management.Entities;
using Phone_Store_Management.Utilities;
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
    /// Interaction logic for UCProductManager.xaml
    /// </summary>
    public partial class UCProductManager : UserControl
    {
        OpenFileDialog openFileDialog = new OpenFileDialog();
        ProductDAO objDAO;
        public UCProductManager()
        {
            InitializeComponent();
            objDAO = new ProductDAO();
            LoadData();
            openFileDialog.Filter = "Image files (*.png;*.jpeg;*.jpg)|*.png;*.jpeg;*.jpg";
        }

        private void LoadData()
        {
            listProducts.ItemsSource = new ObservableCollection<Product>(objDAO.GetAll().ToList());
        }

        private void ShowOrHideCRUDMenu_Click(object sender, RoutedEventArgs e)
        {
            if (gridCRUD.Visibility == Visibility.Collapsed)
                gridCRUD.Visibility = Visibility.Visible;
            else
                gridCRUD.Visibility = Visibility.Collapsed;
        }

        private void BtnBrowseOffline_Click(object sender, RoutedEventArgs e)
        {
            if (openFileDialog.ShowDialog() == true)
            {
                txtImageURL.Text = openFileDialog.SafeFileName;
                imgProduct.Source = new BitmapImage(new Uri((string)(openFileDialog.FileName)));
            }
        }

        private void BtnBrowseOnline_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                imgProduct.Source = new BitmapImage(new Uri((string)(txtImageURL.Text)));
            }
            catch (Exception ex)
            {
                var log = new LogError(GetType().Name + " Error parsing input to URL" + "\n" + ex.Message);
                log.Show();
            }
        }

        private void BtnAdd_Click(object sender, RoutedEventArgs e)
        {
            string[] param = new string[]
            { txtDisplayName.Text, txtBrand.Text, txtPrice.Text, txtDesc.Text, txtQuantity.Text, txtImageURL.Text};
            for(int i=0;i<param.Count();i++)
            {
                if (param[i].Equals(""))
                {
                    MessageBox.Show("Error adding product, some info missing");
                    return;
                }
            }
            Product product = new Product()
            {
                DisplayName = txtDisplayName.Text,
                Brand = txtBrand.Text,
                TypeId = 1,
                Price = double.Parse(txtPrice.Text),
                Description = txtDesc.Text,
                Quantity = int.Parse(txtQuantity.Text),
                ImageURL = txtImageURL.Text
            };
            objDAO.Add(product);
            MessageBox.Show("Product added");
            LoadData();
        }
        private void BtnSave_Click(object sender, RoutedEventArgs e)
        {
            Product product = listProducts.SelectedItem as Product;
            if (product != null)
            {
                product.DisplayName = txtDisplayName.Text;
                product.Brand = txtBrand.Text;
                product.Price = double.Parse(txtPrice.Text);
                product.Description = txtDesc.Text;
                product.Quantity = int.Parse(txtQuantity.Text);
                product.ImageURL = txtImageURL.Text;
                objDAO.Update(product);
                MessageBox.Show("Product updated");
                LoadData();
            }
        }

       
        private void BtnCancel_Click(object sender, RoutedEventArgs e)
        {
            RefreshCRUDForm();
            btnAdd.Visibility = Visibility.Visible;
            btnSave.Visibility = Visibility.Collapsed;
            btnDelete.Visibility = Visibility.Collapsed;
        }

        private void RefreshCRUDForm()
        {
            txtImageURL.Clear();
            txtID.Clear();
            txtDisplayName.Clear();
            txtBrand.Clear();
            txtPrice.Clear();
            txtQuantity.Clear();
            txtDesc.Clear();
            imgProduct.Source = null;
            listProducts.SelectedIndex = -1;
        }

        private void ListProducts_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (listProducts.SelectedIndex == -1)
            {
                btnAdd.Visibility = Visibility.Visible;
                btnSave.Visibility = Visibility.Collapsed;
                btnDelete.Visibility = Visibility.Collapsed;
            }
            else
            {
                btnAdd.Visibility = Visibility.Collapsed;
                btnSave.Visibility = Visibility.Visible;
                btnDelete.Visibility = Visibility.Visible;
            }
            Product product = listProducts.SelectedItem as Product;
            if (product != null)
            {
                txtID.Text = product.Id.ToString();
                txtDisplayName.Text = product.DisplayName;
                txtBrand.Text = product.Brand;
                txtPrice.Text = product.Price.ToString();
                txtQuantity.Text = product.Quantity.ToString();
                txtImageURL.Text = product.ImageURL;
                txtDesc.Text = product.Description;
                imgProduct.Source = new BitmapImage(new Uri(product.ImageURL));
            }
        }

        private void BtnDelete_Click(object sender, RoutedEventArgs e)
        {
            Product product = listProducts.SelectedItem as Product;
            if (product!= null)
            {
                objDAO.Delete(product);
                LoadData();
                RefreshCRUDForm();
                MessageBox.Show("Product deleted");
            }
        }
    }
}
