﻿using Phone_Store_Management.DAO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using Phone_Store_Management.Windows;
namespace Phone_Store_Management.ViewModel
{
    public class LoginViewModel: BaseViewModel
    {
        public static int UserID;
        public bool IsLogin { get; set; }

        private string _UserName;
        public string UserName { get => _UserName; set { _UserName = value; OnPropertyChanged(); }}
        private string _Password;
        public string Password { get => _Password; set { _Password = value; OnPropertyChanged(); } }

        public ICommand CloseCommand { get; set; }
        public ICommand LoginCommand { get; set; }
        public ICommand PasswordChangedCommand { get; set; }

        public LoginViewModel()
        {
            IsLogin = false;
            CloseCommand = new RelayCommand<Window>((p) => { return true; }, (p) => { p.Close(); });
            LoginCommand = new RelayCommand<Window>((p) => { return true; }, (p) => { Login(p); });
            PasswordChangedCommand = new RelayCommand<PasswordBox>((p) => { return true; }, (p) => { Password = p.Password; });
        }

        private void Login(Window p)
        {
            if (p == null)
                return;
            if (UserName != null && Password != null)
            {
                var roleId = new UserDAO().GetUserRole(UserName, Password);

                if (roleId != -1)
                {
                    GeneralDashboard db = null;
                    switch (roleId)
                    {
                        //manager or admin
                        case 1:
                            //db = new ManagerDashboard();
                            db = new GeneralDashboard();
                            db.SetManagerUI();
                            break;
                        case 2:
                            //db = new CashierDashboard();
                            db = new GeneralDashboard();
                            db.SetCashierUI();
                            break;
                        default:
                            break;
                    }
                    IsLogin = true;
                    //Store user id
                    UserID = new UserDAO().GetUserID(UserName);
                    db.SetLoggedInUser(new UserDAO().Get(UserID));
                    db.Show();
                    p.Close();
                }
                else
                {
                    IsLogin = false;
                    MessageBox.Show("Sai tài khoản hoặc mật khẩu!");
                }
            }
            else
            {
                IsLogin = false;
                MessageBox.Show("Sai tài khoản hoặc mật khẩu!");
            }


        }
    }
}
