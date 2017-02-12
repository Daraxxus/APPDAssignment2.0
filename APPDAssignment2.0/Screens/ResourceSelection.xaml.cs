using APPDAssignment2._0.Windows;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using APPDAssignment2._0.Database;
using static APPDAssignment2._0.DataModels;

namespace APPDAssignment2._0.Screens
{
    /// <summary>
    /// Interaction logic for ResourceSelection.xaml
    /// </summary>
    public partial class ResourceSelection : UserControl
    {
        bool PageCheck = true;
        int ResourceScreen;
        List<string> Resource_ = new List<string>();

        public ResourceSelection()
        {
            InitializeComponent();
        }

        public ResourceSelection(int resourceScreen)
        {
            InitializeComponent();
            this.ResourceScreen = resourceScreen;
            //if 0, category screen, if > 0 than resource
        }

        private void backButton_Click(object sender, RoutedEventArgs e)
        {
            Switcher.Switch(new Mainpage());
        }

        private void Usercontrol_loaded(object sender, RoutedEventArgs e)
        {
            MainWindow mainWindow = (MainWindow)Application.Current.MainWindow;
            DatabaseManager dm = mainWindow.databaseManager;
            Resource_.Clear();

            if (ResourceScreen == 0)
            {
                foreach (Category c in dm.Categories)
                {
                    Resource_.Add(c.CategoryName);
                }
            }
            else
            {
                foreach (Resource r in dm.Resources)
                {
                    if (r.CategoryID == ResourceScreen)
                    {
                        Resource_.Add(r.ResourceName);
                        PageCheck = false;
                    }
                }
            }

            if (ResourceScreen > 0)
            {
                previousbookingButton.Visibility = Visibility.Hidden;
                cartButton.Visibility = Visibility.Hidden;
            }

            for (int i = 0; i < Resource_.Count; i++)
            {
                Button button = new Button()
                {
                    Tag = i + 1
                };
                button.Height = 80;
                button.Width = 260;
                button.Click += new RoutedEventHandler(button_Click);
                StackPanel stackPanel = new StackPanel();

                //Image image = new Image()
                //{
                //    Width = 200,
                //    Height = 100,
                //    Source = (BitmapSource)new ImageSourceConverter().ConvertFrom(oneItem.R_Image),
                //    Stretch = Stretch.UniformToFill
                //};

                TextBlock textBlock = new TextBlock()
                {
                    Text = string.Format("{0}", Resource_[i]),
                    HorizontalAlignment = HorizontalAlignment.Center
                };
                //stackPanel.Children.Add(image);
                stackPanel.Children.Add(textBlock);
                button.Content = stackPanel;

                button.Margin = new Thickness { Top = 3, Bottom = 3, Left = 3, Right = 3 };
                this.itemButtonsUniformGrid.Children.Add(button);
            } //MAKE SCROLLABLE/NEXT PAGE/RESIZABLE
        }
        void button_Click(object sender, RoutedEventArgs e)
        {
            Button button = (Button)sender;
            if (PageCheck) //if true set up Resource listing
            {
                Switcher.Switch(new ResourceSelection(Int32.Parse(button.Tag.ToString())));
            }
            else
            {
                if (ResourceScreen == 1)
                {
                    Switcher.Switch(new BookingSelection(int.Parse(button.Tag.ToString()),
                        ResourceScreen));
                }
                else
                {
                    Switcher.Switch(new BookingSelection(int.Parse(button.Tag.ToString())+6,
                       ResourceScreen));
                }
            }
        }

        private void cartButton_Click(object sender, RoutedEventArgs e)
        {
            CartBookings Cartbookings = new CartBookings();
            Cartbookings.Show();
        }

        private void previousbookingButton_Click(object sender, RoutedEventArgs e)
        {
            PreviousBookings Previousbookings = new PreviousBookings();
            Previousbookings.Show();
        }
    }
}
