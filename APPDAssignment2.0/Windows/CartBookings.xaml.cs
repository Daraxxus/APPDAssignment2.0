using APPDAssignment2._0.Database;
using System.Windows;
using System.Windows.Controls;
using static APPDAssignment2._0.DataModels;

namespace APPDAssignment2._0.Windows
{
    /// <summary>
    /// Interaction logic for CartBookings.xaml
    /// </summary>
    public partial class CartBookings : Window
    {
        MainWindow Mainwindow = (MainWindow)Application.Current.MainWindow;
        Cart cart;
        public CartBookings()
        {
            InitializeComponent();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            cart = Mainwindow.Cart;
            int i = 0;

            foreach (var Booking in cart.Cart_)
            {
                Label Venuelabel = new Label()
                {
                    Tag = i + " name"
                };
                Venuelabel.Content = Booking.ResourceName;

                Label Datelabel = new Label()
                {
                    Tag = i + " Date"
                };
                Datelabel.Content = Booking.SlotDate;

                Label STimelabel = new Label()
                {
                    Tag = i + " Stime"
                };
                STimelabel.Content = Booking.StartTime;

                Label ETimelabel = new Label()
                {
                    Tag = i + " ETime"
                };
                ETimelabel.Content = Booking.EndTime;

                Label Pricelabel = new Label()
                {
                    Tag = i + " Price"
                };
                Pricelabel.Content = Booking.Price;

                Venuelabel.Margin = new Thickness { Top = 3, Bottom = 3, Left = 3, Right = 3 };
                Datelabel.Margin = new Thickness { Top = 3, Bottom = 3, Left = 3, Right = 3 };
                STimelabel.Margin = new Thickness { Top = 3, Bottom = 3, Left = 3, Right = 3 };
                ETimelabel.Margin = new Thickness { Top = 3, Bottom = 3, Left = 3, Right = 3 };
                Pricelabel.Margin = new Thickness { Top = 3, Bottom = 3, Left = 3, Right = 3 };
                this.PreviousBooking.Children.Add(Venuelabel);
                this.PreviousBooking.Children.Add(Datelabel);
                this.PreviousBooking.Children.Add(STimelabel);
                this.PreviousBooking.Children.Add(ETimelabel);
                this.PreviousBooking.Children.Add(Pricelabel);
                i++;
            }

        }

        private void button_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void confirmButton_Click(object sender, RoutedEventArgs e)
        {
            BookingManager BM = new BookingManager();
            Cart Cart = Mainwindow.Cart;
            BM.confirmBooking(Cart);
            MessageBox.Show("Your Booking has Been Processed");
        }
    }
}
