using APPDAssignment2._0.Database;
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
using System.Windows.Shapes;

namespace APPDAssignment2._0.Windows
{
    /// <summary>
    /// Interaction logic for PreviousBookings.xaml
    /// </summary>
    public partial class PreviousBookings : Window
    {
        BookingManager bookingManager;
        MainWindow mainWindow = (MainWindow)Application.Current.MainWindow;
        public PreviousBookings()
        {
            InitializeComponent();
            bookingManager = new BookingManager();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            int i = 0;
            foreach (var booking in bookingManager.prevBookings(mainWindow.NRIC))
            {
                Label Venuelabel = new Label()
                {
                    Tag = i + " Venue"
                };
                Venuelabel.Content = booking.ResourceName;

                Label Datelabel = new Label()
                {
                    Tag = i + " date"
                };
                Datelabel.Content = booking.SlotDate;

                Label STimelabel = new Label()
                {
                    Tag = i + " Stime"
                };
                STimelabel.Content = booking.StartTime;

                Label ETimelabel = new Label()
                {
                    Tag = i + " ETime"
                };
                ETimelabel.Content = booking.EndTime;

                Datelabel.Margin = new Thickness { Top = 3, Bottom = 3, Left = 3, Right = 3 };
                Venuelabel.Margin = new Thickness { Top = 3, Bottom = 3, Left = 3, Right = 3 };
                STimelabel.Margin = new Thickness { Top = 3, Bottom = 3, Left = 3, Right = 3 };
                ETimelabel.Margin = new Thickness { Top = 3, Bottom = 3, Left = 3, Right = 3 };
                this.PreviousBooking.Children.Add(Datelabel);
                this.PreviousBooking.Children.Add(Venuelabel);
                this.PreviousBooking.Children.Add(STimelabel);
                this.PreviousBooking.Children.Add(ETimelabel);
                i++;
            }
        }

        private void button_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
