using Phone_Store_Management.DAO;
using Phone_Store_Management.DTO;
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
        private ObservableCollection<Product> list;

        public UCSale()
        {
            InitializeComponent();
            var db = new DBStoreManagementEntities();

            list = new ObservableCollection<Product>(db.Products.ToList());
            listitem.ItemsSource = list;
        }
    }
}
