using APPDAssignment2._0.Database;
using System.Windows;
using System.Windows.Controls;
using static APPDAssignment2._0.DataModels;
using System;
using System.Globalization;
using System.Text;

namespace APPDAssignment2._0.Windows
{
    /// <summary>
    /// Interaction logic for CartBookings.xaml
    /// </summary>
    public partial class CartBookings : Window
    {
        MainWindow Mainwindow = (MainWindow)Application.Current.MainWindow;
        Bookings bookings;

        public CartBookings()
        {
            InitializeComponent();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            bookings = Mainwindow.bookings;
            int i = 0;

            foreach (var Booking in bookings.Bookings_)
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

                Button deleteButton = new Button()
                {
                    Tag = i
                };

                deleteButton.Height = 30;
                deleteButton.Width = 80;
                deleteButton.Content = "Delete";
                deleteButton.Click += new RoutedEventHandler(deleteButton_Click);

                button.Margin = new Thickness { Top = 1, Bottom = 3, Left = 3, Right = 3 };
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
                this.PreviousBooking.Children.Add(deleteButton);
                i++;
            }

        }

        void deleteButton_Click(object sender, RoutedEventArgs e)
        {
            int i;
            MessageBoxResult messageBoxResult = MessageBox.Show("Remove Cart Item?", "Confirmation", MessageBoxButton.YesNo);
            if (messageBoxResult == MessageBoxResult.Yes)
            {
                Button deleteButton = (Button)sender;
                i = Int32.Parse(deleteButton.Tag.ToString());
                CartBookings CB = new CartBookings();
                bookings.Bookings_.RemoveAt(i);
                this.Close();
                CB.Show();
            }

        }

        private void backButton_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void confirmButton_Click(object sender, RoutedEventArgs e)
        {
            StringBuilder message = new StringBuilder();
            BookingManager BM = new BookingManager();
            Bookings currentBookings = Mainwindow.bookings;
            if (BM.confirmBooking(currentBookings))
            {
                MessageBox.Show("Your Booking has Been Processed");
                foreach (var x in currentBookings.Bookings_)
                {
                    message.Append(x.ResourceName).AppendLine();
                    message.Append(x.SlotDate).AppendLine();
                    message.Append(x.StartTime + "-" + x.EndTime).AppendLine();
                    message.Append(x.Price.ToString("C2", CultureInfo.CurrentCulture)).AppendLine();
                    message.AppendLine();
                }
                MessageBox.Show(message.ToString(), "Receipt");
                currentBookings.Bookings_.Clear();
                this.Close();
            }
            else
                MessageBox.Show("Please Add Somthing to Cart before Booking");
        }
    }
}
