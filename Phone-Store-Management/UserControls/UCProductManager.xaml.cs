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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Phone_Store_Management.UserControls
{
    /// <summary>
    /// Interaction logic for UCProductManager.xaml
    /// </summary>
    public partial class UCProductManager : UserControl
    {
        public UCProductManager()
        {
            InitializeComponent();
        }

        private void ShowOrHideCRUDMenu_Click(object sender, RoutedEventArgs e)
        {
            if (gridCRUD.Visibility == Visibility.Collapsed)
                gridCRUD.Visibility = Visibility.Visible;
            else
                gridCRUD.Visibility = Visibility.Collapsed;
        }
    }
}
