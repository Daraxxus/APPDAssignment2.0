using System.Windows;
using System.Windows.Controls;

namespace APPDAssignment2._0.Windows
{
    /// <summary>
    /// Interaction logic for CartBookings.xaml
    /// </summary>
    public partial class CartBookings : Window
    {
        public CartBookings()
        {
            InitializeComponent();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            for (int i = 1; i <= 5; i++)
            {
                Label IDlabel = new Label()
                {
                    Tag = i + " name"
                };
                IDlabel.Content = i.ToString();

                Label Venuelabel = new Label()
                {
                    Tag = i + " Venue"
                };
                Venuelabel.Content = i.ToString();

                Label STimelabel = new Label()
                {
                    Tag = i + " Stime"
                };
                STimelabel.Content = i.ToString();

                Label ETimelabel = new Label()
                {
                    Tag = i + " ETime"
                };
                ETimelabel.Content = i.ToString();

                Label Pricelabel = new Label()
                {
                    Tag = i + " Price"
                };
                Pricelabel.Content = i.ToString();

                IDlabel.Margin = new Thickness { Top = 3, Bottom = 3, Left = 3, Right = 3 };
                Venuelabel.Margin = new Thickness { Top = 3, Bottom = 3, Left = 3, Right = 3 };
                STimelabel.Margin = new Thickness { Top = 3, Bottom = 3, Left = 3, Right = 3 };
                ETimelabel.Margin = new Thickness { Top = 3, Bottom = 3, Left = 3, Right = 3 };
                Pricelabel.Margin = new Thickness { Top = 3, Bottom = 3, Left = 3, Right = 3 };
                this.PreviousBooking.Children.Add(IDlabel);
                this.PreviousBooking.Children.Add(Venuelabel);
                this.PreviousBooking.Children.Add(STimelabel);
                this.PreviousBooking.Children.Add(ETimelabel);
                this.PreviousBooking.Children.Add(Pricelabel);

            }
        }
        private void button_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
