﻿using APPDAssignment2._0.Database;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;
using static APPDAssignment2._0.DataModels;

namespace APPDAssignment2._0.Screens
{
    /// <summary>
    /// Interaction logic for Login.xaml
    /// </summary>
    public partial class Login : UserControl
    {
        string Username_;
        string Password_;
        List<string> uname = new List<string>();
        List<string> upass = new List<string>();

        public Login()
        {
            InitializeComponent();
        }

        private void cancelButton_Click(object sender, RoutedEventArgs e)
        {
            Switcher.Switch(new Mainpage());
        }
        private void loginButton_Click(object sender, RoutedEventArgs e)
        {
            Username_ = usernameBox.Text;
            Password_ = passwordBox.Text;
            if (usernameBox.Text == string.Empty || passwordBox.Text == string.Empty) //doesn't detect null
            {
                MessageBox.Show("Fields must both be filled in");
            }
            else
            {
                //DatabaseManager dm = new DatabaseManager();
                MainWindow mainWindow = (MainWindow)Application.Current.MainWindow;
                DatabaseManager dm = mainWindow.databaseManager;
                foreach (User u in dm.Users)
                {
                    uname.Add(u.Username);
                    upass.Add(u.Password);
                } //works

                if (uname.IndexOf(Username_) != -1) //if username exists
                {
                    if (upass.IndexOf(Password_) != -1) //if password exist
                    {
                        if ((uname.IndexOf(Username_)) == (upass.IndexOf(Password_))) //if password matches username
                        {
                            Switcher.Switch(new ResourceSelection(0));
                        }
                        else
                        {
                            MessageBox.Show("Invalid Username or Password 1");
                        }
                    }
                    else
                    {
                        MessageBox.Show("Invalid Username or Password 2");
                    }
                }
                else
                {
                    MessageBox.Show("Invalid Username or Password 3");
                }
            }
        }
    }
}
