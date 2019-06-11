using Phone_Store_Management.DAO;
using Phone_Store_Management.Entities;
using Phone_Store_Management.Windows;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
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
        private ObservableCollection<User> list;
        private UserDAO userDAO;    

        public UCStaffManager()
        {
            InitializeComponent();
            userDAO = new UserDAO();

            LoadList();
            listUsers.SelectionChanged += Listitem_SelectionChanged;
        }

        private void Listitem_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            User user = listUsers.SelectedItem as User;
            if (user != null)
            {
                txtId.Text = user.Id.ToString();
                txtUserName.Text = user.UserName.ToString();
                txtPassword.Text = user.Password.ToString();
                txtDisplayName.Text = user.DisplayName.ToString();
                txtRoleId.Text = user.RoleId.ToString();
                txtIdentityCard.Text = user.IdentityCard.ToString();
                txtAddress.Text = user.Address;
                dpkBirthdate.Text = user.Birthdate.ToString();
            }
            
        }

        private void UpdateButton_Click(object sender, RoutedEventArgs e)
        {
            User user = listUsers.SelectedItem as User;
            if (user != null)
            {
                user.UserName = txtUserName.Text.ToString();
                user.Password = txtPassword.Text.ToString();
                user.DisplayName = txtDisplayName.Text.ToString();
                user.RoleId = int.Parse(txtRoleId.Text.ToString());
                user.IdentityCard = txtIdentityCard.Text.ToString();
                user.Address = txtAddress.Text.ToString();
                user.Birthdate = Convert.ToDateTime(dpkBirthdate.Text.ToString());

                userDAO.Update(user);
                LoadList();
            }
         
        }

        private void LoadList()
        {
            list = new ObservableCollection<User>(userDAO.GetAll().ToList());
            listUsers.ItemsSource = list;
        }

        private void InsertButton_Click(object sender, RoutedEventArgs e)
        {
            if (!txtUserName.Text.ToString().Equals("")
                && !txtPassword.Text.ToString().Equals("")
                && !txtRoleId.Text.ToString().Equals("")
                && !txtDisplayName.Text.ToString().Equals("")
                && !dpkBirthdate.Text.ToString().Equals("")
                && !txtIdentityCard.Text.ToString().Equals("")
                && !txtAddress.Text.ToString().Equals(""))
            {
                var user = new User()
                {
                    UserName = txtUserName.Text.ToString(),
                    Password = txtPassword.Text.ToString(),
                    DisplayName = txtDisplayName.Text.ToString(),
                    RoleId = int.Parse(txtRoleId.Text.ToString()),
                    IdentityCard = txtIdentityCard.Text.ToString(),
                    Address = txtAddress.Text.ToString(),
                    Birthdate = Convert.ToDateTime(dpkBirthdate.Text.ToString())
                };

                // if user doesn't exist
                if (userDAO.GetUserID(user.UserName) != -1)
                {
                    MessageBox.Show("User is exist, please change username");
                    return;
                }

                userDAO.Add(user);
                LoadList();
                MessageBox.Show("Add successfully");

            }
            else
            {
                MessageBox.Show("Error");
                return;
            }
            
        }

        private void DeleteButton_Click(object sender, RoutedEventArgs e)
        {
            User user = listUsers.SelectedItem as User;
            if (user != null)
            {
                userDAO.Delete(user);
                LoadList();
                MessageBox.Show("Delete is Successfully");
            }
        }
    }
}
