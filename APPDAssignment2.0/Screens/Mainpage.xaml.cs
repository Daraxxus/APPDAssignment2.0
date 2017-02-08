using APPDAssignment2._0.Windows;
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

namespace APPDAssignment2._0.Screens
{
    /// <summary>
    /// Interaction logic for Mainpage.xaml
    /// </summary>
    public partial class Mainpage : UserControl
    {
        public Mainpage()
        {
            InitializeComponent();
        }

        private void loginButton_Click(object sender, RoutedEventArgs e)
        {
            Switcher.Switch(new Login());
        }

        private void signupButton_Click(object sender, RoutedEventArgs e)
        {
            SignUp _signup = new SignUp();
            _signup.Show();
        }
    }
}
