using System.Collections.Generic;
using System.Windows;
using APPDAssignment2._0.Database;
using APPDAssignment2._0.Screens;
using static APPDAssignment2._0.DataModels;

namespace APPDAssignment2._0.Windows
{
    /// <summary>
    /// Interaction logic for Window.xaml
    /// </summary>
    public partial class SignUp : Window
    {
        string Username_;
        string Password_;
        string confirmP_;
        string NRIC;
        List<string> uname = new List<string>();
        List<string> upass = new List<string>();
        List<string> NRIC_ = new List<string>();

        public SignUp()
        {
            InitializeComponent();
        }

        private void registerButton_Click(object sender, RoutedEventArgs e)
        {
            this.Username_ = usernameBox.Text;
            this.Password_ = passwordBox.Text;
            this.confirmP_ = confrimBox.Text;
            this.NRIC = NRICBox.Text;

            MainWindow mainWindow = (MainWindow)Application.Current.MainWindow;
            DatabaseManager dm = mainWindow.databaseManager;
            BookingManager bm = mainWindow.bookingManager;
            User newUser = mainWindow.newUser;

            if ((Username_ == string.Empty) || (Password_ == string.Empty) || (confirmP_ == string.Empty) || (NRIC == string.Empty))
            {
                MessageBox.Show("All fields must be filled in");
            }

            foreach (DataModels.User u in dm.Users)
            {
                uname.Add(u.Username);
                upass.Add(u.Password);
                NRIC_.Add(u.NRIC);
            }

            if (NRIC_.Contains((NRIC.ToUpper())))
            {
                MessageBox.Show("This NRIC has been linked with an account already");
            }
            else if (uname.Contains(Username_))
            {
                MessageBox.Show("Username has been used");
            }
            else if (Password_ != confirmP_)
            {
                MessageBox.Show("Passwords do not match");
            }
            else
            {
                newUser = new User();
                NewUser nUser = new NewUser();

                nUser.NRIC = NRIC;
                nUser.Username = Username_;
                nUser.Password = Password_;
                newUser.NewUser_.Add(nUser);

                mainWindow.newUser = newUser;
                bm.SaveUserInformation(newUser);
                MessageBox.Show("Account Created");
                Switcher.Switch(new Login());
                this.Close();
                dm.RefreshUsers();
            }
            //usernameBox
            //passwordBox
            //confirmBox
        }
        private void cancelButton_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
