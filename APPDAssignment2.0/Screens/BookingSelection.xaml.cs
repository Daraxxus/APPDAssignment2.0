using System;
using System.Collections.Generic;
using System.Globalization;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;
using APPDAssignment2._0.Database;
using static APPDAssignment2._0.DataModels;

namespace APPDAssignment2._0.Screens
{
    /// <summary>
    /// Interaction logic for BookingSelection.xaml
    /// </summary>
    public partial class BookingSelection : UserControl
    {
        List<string> StartTime = new List<string>();
        List<string> EndTime = new List<string>();
        List<DateTime?> Date = new List<DateTime?>();
        List<decimal> Price_ = new List<decimal>();
        List<string> Resourcename = new List<string>();
        List<string> TimeSlot = new List<string>();
        List<string> Catname = new List<string>();
        int resourceid;
        private int categoryid;

        public BookingSelection()
        {
            InitializeComponent();
        }

        public BookingSelection(int Resourceid, int Categoryid)
        {
            InitializeComponent();
            this.resourceid = Resourceid;
            this.categoryid = Categoryid-1;
        }

        private void Usercontrol_loaded(object sender, RoutedEventArgs e)
        {
            MainWindow mainWindow = (MainWindow)Application.Current.MainWindow;
            DatabaseManager dm = mainWindow.databaseManager;

            foreach (Resource r in dm.Resources)
            {
                Resourcename.Add(r.ResourceName);
            }

            foreach (Category c in dm.Categories)
            {
                Price_.Add(c.Price);
                Catname.Add(c.CategoryName);
            }

            foreach (Booking b in dm.Bookings)
            {
                StartTime.Add(b.StartTime);
                EndTime.Add(b.EndTime);
                if (!Date.Contains(b.SlotDate))
                {
                    Date.Add(b.SlotDate);
                }
            }

            foreach (string s in StartTime)
            {
                if (!TimeSlot.Contains(s + " - " + EndTime[StartTime.IndexOf(s)]))
                {
                    TimeSlot.Add(s + " - " + EndTime[StartTime.IndexOf(s)]);
                }
            }

            PriceBox.Text = Price_[categoryid].ToString("C2", CultureInfo.CurrentCulture) + "(" + Catname[categoryid] + ") per hour";
            ResourceBox.Text = Resourcename[resourceid-1];
            DateBox.ItemsSource = Date;
            TimeslotBox.ItemsSource = TimeSlot;
        }
    }
}
