using System;
using System.Windows;
using System.Windows.Controls;

namespace Calendar
{
    /// <summary>
    /// Interaction logic for ChangeTimeWindow.xaml
    /// </summary>
    public partial class ChangeTimeWindow
    {

        public int MinYear;
        public int MaxYear;

        public ChangeTimeWindow()
        {
            InitializeComponent();
            Initialize();
        }

        private void Initialize()
        {
            DateTime now = DateTime.Today;
            MinYear = now.Year - 5;
            MaxYear = now.Year + 5;
            ComboBoxItem item;

            for (int i = MinYear; i <= MaxYear; i++)
            {
                item = new ComboBoxItem();
                item.Content = "" + i;
                YearSelection.Items.Add(item);
            }

            MonthSelection.SelectedIndex = now.Month - 1;
            YearSelection.SelectedIndex = 5;
        }

        private void OkButton_OnClick(object sender, RoutedEventArgs e)
        {
            MainWindow mainWindow = Owner as MainWindow;
            if (mainWindow != null)
            {
                int month = MonthSelection.SelectedIndex + 1;
                int year = int.Parse(YearSelection.SelectionBoxItem.ToString());

                mainWindow.CurrYearButton.Content = MonthSelection.SelectionBoxItem + 
                                                    ", " + 
                                                    year;
                mainWindow.CalendarTable.Date = new DateTime(year, month, 1);
                mainWindow.Opacity = 1;
            }

            Hide();
        }

        public void ChangeTime(int month, int year)
        {
            MainWindow mainWindow = Owner as MainWindow;

            if (mainWindow != null)
            {
                MonthSelection.SelectedIndex = month - 1;
                YearSelection.SelectedIndex = year - MinYear;
                mainWindow.CurrYearButton.Content = MonthSelection.SelectionBoxItem +
                                                    ", " +
                                                    year;
                
                mainWindow.CalendarTable.Date = new DateTime(year, month, 1);
            }
        }
    }
}
