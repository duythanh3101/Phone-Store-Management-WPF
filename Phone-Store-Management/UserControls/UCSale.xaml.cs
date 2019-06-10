﻿using Phone_Store_Management.DAO;
using Phone_Store_Management.Entities;
using Phone_Store_Management.Utilities;
using Phone_Store_Management.Windows;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading;
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
        private Basket basket;
        private ProductDAO productDAO;

        public UCSale()
        {
            InitializeComponent();
            CultureInfo ci = new CultureInfo("vi-VN");
            Thread.CurrentThread.CurrentCulture = ci;
            Thread.CurrentThread.CurrentUICulture = ci;
            total.Text = MoneyConverter.ToDecimal(0);
            productDAO = new ProductDAO();
            basket = new Basket();

            listProducts = new ObservableCollection<Product>(productDAO.GetAll().ToList());
            listitem.ItemsSource = listProducts;
            listProductsInCart.ItemsSource = basket.Details;

            basket.Details.CollectionChanged += Details_CollectionChanged;
        }

        private void Details_CollectionChanged(object sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e)
        {
            if (basket.Details.Count == 0)
            {
                //update listview display products
                listProducts = new ObservableCollection<Product>(productDAO.GetAll().ToList());
                listitem.ItemsSource = listProducts;
            }
            double totalprice = basket.TotalPrice();
            total.Text = MoneyConverter.ToDecimal(totalprice);
        }

        private void AddProductInCart_Click(object sender, MouseButtonEventArgs e)
        {
            try
            {
                Product pr = (Product)listitem.SelectedItems[0];
                if (!productDAO.IsOutOfItems(pr.Id))
                {
                    basket.AddDetail(pr.Id, pr.Price, pr.DisplayName, pr.Quantity);
                }

                listProductsInCart.Items.Refresh();
                listitem.SelectedItems.Clear();
            }
            catch
            {

            }
        }

        private void PayButton_Click(object sender, RoutedEventArgs e)
        {
            var basketWindow = new BillDetailWindow(basket);
            basketWindow.ShowDialog();

            if (BillDetailWindow.IsSuccessPayment)
            {
                //Update database
                UpdateProductsInDatabase();

                //Update basket
                basket.Details.Clear();
                BillDetailWindow.IsSuccessPayment = false;
            }
        }

        private void UpdateProductsInDatabase()
        {
            foreach (var item in basket.Details)
            {
                int id = item.ProductId;
                Product pr = productDAO.Get(id);
                pr.Quantity = pr.Quantity - item.Quantity;
                productDAO.Update(pr);
            }
        }

        private void Delete_Click(object sender, RoutedEventArgs e)
        {
            Button btn = sender as Button;
            BasketDetails pr = btn.DataContext as BasketDetails; //Get product in basket
            basket.Details.Remove(pr);
        }

        private void ClearButton_Click(object sender, RoutedEventArgs e)
        {
            MessageBoxResult result = MessageBox.Show("Do you want to clear all products?", "", MessageBoxButton.YesNo);
            switch (result)
            {
                case MessageBoxResult.Yes:
                    basket.Details.Clear();
                    break;
                case MessageBoxResult.No:
                    break;
            }
        }

        private void ViewProductDetail_Click(object sender, RoutedEventArgs e)
        {
            Product pr = (Product)listitem.SelectedItems[0];
            ProductDetail uc = new ProductDetail(pr);
            uc.ShowDialog();
        }

        private void AddToCart_Click(object sender, RoutedEventArgs e)
        {
            Product pr = (Product)listitem.SelectedItems[0];
            if (!productDAO.IsOutOfItems(pr.Id))
            {
                basket.AddDetail(pr.Id, pr.Price, pr.DisplayName, pr.Quantity);
            }

            listProductsInCart.Items.Refresh();
            listitem.SelectedItems.Clear();
        }
    }
}
