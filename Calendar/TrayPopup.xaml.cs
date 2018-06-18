using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Calendar
{
    /// <summary>
    /// Interaction logic for TrayPopup.xaml
    /// </summary>
    public partial class TrayPopup : UserControl
    {
        private MainWindow _ownerMainWindow;

        public TrayPopup()
        {
            InitializeComponent();
            CalendarButton.IsEnabled = false;
        }

        public MainWindow OwnerMainWindow { get => _ownerMainWindow; set => _ownerMainWindow = value; }

        private void CalendarButton_OnClick(object sender, RoutedEventArgs e)
        {
            _ownerMainWindow?.Show();
            Visibility = Visibility.Collapsed;
        }

        private void QuitButton_OnClick(object sender, RoutedEventArgs e)
        {
            _ownerMainWindow?.Quit();
            Application.Current.Shutdown();
        }

        private void Button_OnMouseEnter(object sender, MouseEventArgs e)
        {
            Button button = sender as Button;

            if (button != null)
            {
                button.Foreground = Brushes.Black;
            }
            
        }

        private void Button_OnMouseLeave(object sender, MouseEventArgs e)
        {
            Button button = sender as Button;

            if (button != null)
            {
                button.Foreground = Brushes.White;
            }
        }
    }
}
