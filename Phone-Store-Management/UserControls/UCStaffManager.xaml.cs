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
    /// Interaction logic for UCStaffManager.xaml
    /// </summary>
    public partial class UCStaffManager : UserControl
    {
        private ObservableCollection<User> listUsers;

        public UCStaffManager()
        {
            InitializeComponent();
            var db = new DBStoreManagementEntities();
            listUsers = new ObservableCollection<User>(db.Users.ToList());
            listitem.ItemsSource = listUsers;
        }

        private void editUser_Click(object sender, RoutedEventArgs e)
        {

        }

        private void deleteUser_Click(object sender, RoutedEventArgs e)
        {
            var db = new DBStoreManagementEntities();
            User u = (User)listitem.SelectedItems[0];
            User user = GetUserByID(u.Id);
            if (user != null)
            {
                //db.Users.Remove(user);
                db.Entry(user).State = System.Data.Entity.EntityState.Deleted;
            }
            db.SaveChanges();

        }

        private User GetUserByID(int id)
        {
            var db = new DBStoreManagementEntities();
            return db.Users.SingleOrDefault(c => c.Id == id);
        }
    }
}
