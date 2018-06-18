using System;
using System.Windows;

namespace Calendar
{
    /// <summary>
    /// Interaction logic for AddEvent.xaml
    /// </summary>
    public partial class AddEvent
    {

        public AddEvent()
        {
            InitializeComponent();
        }

        private void AddButton_OnClick(object sender, RoutedEventArgs e)
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
            else if(endTime < startTime)
            {
                FailedMessage.Content = "End time has to after start time.";

            }
            else
            {
                Task newTask = new Task()
                {
                    Detail = Detail.Text,
                    EndTime = new Point(endTime.Hours, endTime.Minutes),
                    StartTime = new Point(startTime.Hours, startTime.Minutes),
                    Title = TitleTextBox.Text
                };

                MainWindow.PlanManager.AddTask(newTask);
                
                MainWindow mainWindow = Owner as MainWindow;
                mainWindow?.ShowEvents();

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
