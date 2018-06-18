using System;
using System.Windows;

namespace Calendar
{
    /// <summary>
    /// Interaction logic for EditEvent.xaml
    /// </summary>
    public partial class EditEvent : Window
    {
        public EditEvent()
        {
            InitializeComponent();
        }

        private void EditButton_OnClick(object sender, RoutedEventArgs e)
        {
            int startHour = int.Parse(StartHour.SelectionBoxItem.ToString());
            int startMinute = int.Parse(StartMinute.SelectionBoxItem.ToString());
            int endHour = int.Parse(EndHour.SelectionBoxItem.ToString());
            int endMinute = int.Parse(EndMinute.SelectionBoxItem.ToString());

            TimeSpan startTime = new TimeSpan(0, startHour, startMinute, 0);
            TimeSpan endTime = new TimeSpan(0, endHour, endMinute, 0);

            if (TitleTextBox.Text == "")
            {
                FailedMessage.Content = "You have to fill the title.";

            }
            else if (endTime < startTime)
            {
                FailedMessage.Content = "End time has to after start time.";

            }
            else
            {
                string key = MainWindow.PlanManager.SelectedDate.ToString("MM/dd/yyyy");
                MainWindow mainWindow = Owner as MainWindow;

                if (MainWindow.PlanManager.Plans.ContainsKey(key) &&
                    mainWindow != null)
                {
                    Plan selectedPlan = MainWindow.PlanManager.Plans[key];
                    int index = mainWindow.EventGrid.Children.IndexOf(mainWindow.SelectedEventButton);
                    Task task = selectedPlan.Tasks[index];

                    task.Detail = Detail.Text;
                    task.EndTime = new Point(endTime.Hours, endTime.Minutes);
                    task.StartTime = new Point(startHour, startMinute);
                    task.Title = TitleTextBox.Text;

                    mainWindow.ShowEvents();
                }
                Owner.Opacity = 1;
                Hide();
            }

        }

        private void CancelButton_OnClick(object sender, RoutedEventArgs e)
        {
            Owner.Opacity = 1;
            Hide();
        }

        public void ResetUI()
        {
            TitleTextBox.Text = "";
            Detail.Text = "";
            FailedMessage.Content = "";
            StartHour.SelectedIndex = 0;
            StartMinute.SelectedIndex = 0;
            EndHour.SelectedIndex = 0;
            EndMinute.SelectedIndex = 0;
        }
    }
}
