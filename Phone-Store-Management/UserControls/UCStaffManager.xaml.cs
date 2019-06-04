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
        private UserDAO userDAO;

        public UCStaffManager()
        {
            InitializeComponent();
            userDAO = new UserDAO();
            //listUsers = new ObservableCollection<User>();

            LoadList();
            listitem.SelectionChanged += Listitem_SelectionChanged;
        }

        private void Listitem_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            User user = listitem.SelectedItem as User;
            txtId.Text = user.Id.ToString();
            txtUserName.Text = user.UserName.ToString();
            txtPassword.Text = user.Password.ToString();
            txtDisplayName.Text = user.DisplayName.ToString();
            txtRoleId.Text = user.RoleId.ToString();
            txtIdentityCard.Text = user.IdentityCard.ToString();
            txtAddress.Text = user.Address.ToString();
            dpkBirthdate.Text = user.Birthdate.ToString();
        }

        private void deleteUser_Click(object sender, RoutedEventArgs e)
        {
            //var db = new DBStoreManagementEntities();
            //User u = (User)listitem.SelectedItems[0];
            //User user = GetUserByID(u.Id);
            //if (user != null)
            //{
            //    //db.Users.Remove(user);
            //    db.Entry(user).State = System.Data.Entity.EntityState.Deleted;
            //}
            //db.SaveChanges();

        }

        private void UpdateButton_Click(object sender, RoutedEventArgs e)
        {
            User user = listitem.SelectedItem as User;
            user.UserName = txtUserName.Text.ToString();
            user.Password = txtPassword.Text.ToString();
            user.DisplayName = txtDisplayName.Text.ToString();
            user.RoleId = int.Parse(txtRoleId.Text.ToString());
            user.IdentityCard = txtIdentityCard.Text.ToString();
            user.Address = txtAddress.Text.ToString();
            user.Birthdate = Convert.ToDateTime(dpkBirthdate.Text.ToString());
            if (user != null)
            {
                userDAO.Update(user);
                LoadList();
            }
        }

        private void LoadList()
        {
            listUsers = new ObservableCollection<User>(userDAO.GetAll().ToList());
            listitem.ItemsSource = listUsers;
        }
    }
}
