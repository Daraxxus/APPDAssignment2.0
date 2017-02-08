using APPDAssignment2._0.Database;
using APPDAssignment2._0.Screens;
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
using static APPDAssignment2._0.DataModels;

namespace APPDAssignment2._0
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public DatabaseManager databaseManager;
        public Booking booking;
        public MainWindow()
        {
            InitializeComponent();
            Switcher.pageSwitcher = this;
            Loaded += MainWindow_Loaded;
            Switcher.Switch(new Mainpage());
            databaseManager = new DatabaseManager();
            booking = new Booking();
        }

        private void MainWindow_Loaded(object sender, RoutedEventArgs e)
        {
            Application.Current.MainWindow = this;
        }

        public void Navigate(UserControl nextPage)
        {
            this.screenContentControl.Content = nextPage;
        }

        public void Navigate(UserControl nextPage, object state)
        {
            this.screenContentControl.Content = nextPage;
            ISwitchable s = nextPage as ISwitchable;

            if (s != null)
                s.UtilizeState(state);
            else
                throw new ArgumentException("NextPage is not ISwitchable! "
                  + nextPage.Name.ToString());
        }
    }
}
