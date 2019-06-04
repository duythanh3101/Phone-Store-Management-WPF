using Phone_Store_Management.Entities;
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

namespace Phone_Store_Management.Windows
{
    /// <summary>
    /// Interaction logic for ViewBillDetailWindow.xaml
    /// </summary>
    public partial class ViewBillDetailWindow : Window
    {
        public ViewBillDetailWindow()
        {
            InitializeComponent();
        }

        public ViewBillDetailWindow(List<BillDetail> list)
        {
            InitializeComponent();
            listDetails.ItemsSource = list;
        }

        private void OKButton_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }
    }
}
