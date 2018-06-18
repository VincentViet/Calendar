using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Input;
using System.Windows.Threading;
using Hardcodet.Wpf.TaskbarNotification;
using System.Diagnostics;
using System.Runtime.Remoting.Channels;
using Calendar.Properties;


namespace Calendar
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow
    {
        #region Field
        private readonly ChangeTimeWindow _changeTimeWindow;
        private readonly AddEvent _addEventWindow;
        private readonly ShowEventDetail _showEventDetail;
        private readonly DispatcherTimer _timer;
        private readonly TaskbarIcon _taskbarIcon;
        private readonly MyBalloonTip _balloonTip;
        private readonly TrayPopup _trayPopup;
        private readonly EditEvent _editEvent;
        private readonly SetReminder _setReminderWindow;
        private Event _selectedEventButton;
        private int _notifyTick;
        //private readonly RoutedUICommand _quitCommand;
        #endregion

        public static readonly PlanManager PlanManager = new PlanManager();
        private const string LogFilePath = "./Calendar.log";
        private readonly Style _myEventButton = Application.Current.FindResource("MyEventButton") as Style;
        public ContextMenu EventMenu { get; } = Application.Current.FindResource("EventMenu") as ContextMenu;
        public Event SelectedEventButton { get => _selectedEventButton; set => _selectedEventButton = value; }

        public MainWindow()
        {
            InitializeComponent();

            #region Timer
            _timer = new DispatcherTimer();
            _timer.Tick += Timer_Tick;
            _timer.Interval = new TimeSpan(0, 0, 1);
            Clock.Content = DateTime.Now.ToString("G");
            #endregion

            _changeTimeWindow = new ChangeTimeWindow();
            _addEventWindow = new AddEvent();
            _showEventDetail = new ShowEventDetail();
            _taskbarIcon = Application.Current.FindResource("TaskbarIcon") as TaskbarIcon;
            _balloonTip = new MyBalloonTip();
            _trayPopup = new TrayPopup();
            _editEvent = new EditEvent();
            _setReminderWindow = new SetReminder();


//            CommandBindings.Add(
//                new CommandBinding(CustomCommand.EditCommand, EditCommand_Executed, EditCommand_CanExecute));
//            CommandBindings.Add(new CommandBinding(CustomCommand.DeleteCommand, DeleteCommand_Executed,
//                DeleteCommand_CanExecute));

            Focus();


            _taskbarIcon.TrayPopup = _trayPopup;
            _taskbarIcon.PopupActivation = PopupActivationMode.RightClick;

            _taskbarIcon.TrayMouseDoubleClick += TaskbarIconOnTrayMouseDoubleClick;

            Initialize();
        }

        private void TaskbarIconOnTrayMouseDoubleClick(object sender, RoutedEventArgs e)
        {
            _trayPopup.Visibility = Visibility.Visible;
            _trayPopup.CalendarButton.IsEnabled = false;
            Show();
            Focus();
        }

        private void DeleteCommand_CanExecute(object sender, CanExecuteRoutedEventArgs e)
        {
            e.CanExecute = true;

        }
        public void DeleteCommand_Executed(Event senderEvent)
        {

            string key = PlanManager.SelectedDate.ToString("MM/dd/yyyy");
            _selectedEventButton = senderEvent;

            if (PlanManager.Plans.ContainsKey(key) &&
                _selectedEventButton != null)
            {
                Plan selectedPlan = PlanManager.Plans[key];
                int index = EventGrid.Children.IndexOf(_selectedEventButton);
                Task task = selectedPlan.Tasks[index];

                selectedPlan.Tasks.Remove(task);

                ShowEvents();
            }
        }

        private void EditCommand_CanExecute(object sender, CanExecuteRoutedEventArgs e)
        {
            e.CanExecute = true;
        }

        public void EditCommand_Executed(Event senderEvent)
        {
            if (_editEvent != null)
            {
                Opacity = 0.4;
                _editEvent.ResetUI();

                _selectedEventButton = senderEvent;
                

                _editEvent.ShowDialog();
            }
        }

        private void Initialize()
        {

            CurrYearButton.Content = _changeTimeWindow.MonthSelection.SelectionBoxItem +
                                     ", " +
                                     _changeTimeWindow.YearSelection.SelectionBoxItem;

            FileStream fileStream = new FileStream(LogFilePath, FileMode.Append, FileAccess.Write);
            StreamWriter streamWriter = new StreamWriter(fileStream);

            NotifyToggleButton.IsChecked = Properties.Settings.Default.IsNotify;

            try
            {
                PlanManager.Deserialize();
            }
            catch (Exception e)
            {
                streamWriter.WriteLine(DateTime.Now.ToString("G"));
                streamWriter.WriteLine(e.Message);
                streamWriter.WriteLine();
            }

            streamWriter.Close();
            fileStream.Close();

            PlanManager.SelectedDate = DateTime.Today;
            ShowEvents();
        }

        private void PrevButton_Click(object sender, RoutedEventArgs e)
        {
            var button = sender as Button;
            if (button != null)
            {
                //                int year = int.Parse(_chooseYearModal.YearSelection.SelectionBoxItem.ToString());
                //                int month = _chooseMonthModal.MonthSelection.SelectedIndex + 1;

                int year = int.Parse(_changeTimeWindow.YearSelection.SelectionBoxItem.ToString());
                int month = _changeTimeWindow.MonthSelection.SelectedIndex + 1;

                month--;

                if (month < 1)
                {
                    month = 12;
                    year--;
                    //                    _chooseYearModal.Update_UI(year);
                }

                if (year < _changeTimeWindow.MinYear)
                {
                    return;
                }

                _changeTimeWindow.ChangeTime(month, year);
                //                _chooseMonthModal.MonthSelection.SelectedIndex = month - 1;
                //                _chooseMonthModal.Update_UI(month);

            }
        }

        private void ReturnToday(object sender, RoutedEventArgs e)
        {
            int month = DateTime.Now.Month;
            int year = DateTime.Now.Year;
            _changeTimeWindow.ChangeTime(month, year);

            CalendarTable.SelectedDate = DateTime.Now;
            ShowEvents();
        }

        private void NextButton_Click(object sender, RoutedEventArgs e)
        {
            var button = sender as Button;
            if (button != null)
            {
                int year = int.Parse(_changeTimeWindow.YearSelection.SelectionBoxItem.ToString());
                int month = _changeTimeWindow.MonthSelection.SelectedIndex + 1;

                month++;

                if (month > 12)
                {
                    month = 1;
                    year++;

                }


                if (year > _changeTimeWindow.MaxYear)
                {
                    return;
                }

                _changeTimeWindow.ChangeTime(month, year);
            }
        }

        private void CurrYear_Click(object sender, RoutedEventArgs e)
        {

            if (_changeTimeWindow != null)
            {
                Opacity = 0.4;
                _changeTimeWindow.ShowDialog();
            }
        }


        /// <summary>
        /// ToDo: Save data to PlanData.json
        /// </summary>
        public void Quit()
        {
            FileStream fileStream = new FileStream(LogFilePath, FileMode.Append, FileAccess.Write);
            StreamWriter streamWriter = new StreamWriter(fileStream);

            Properties.Settings.Default.TimeReminder = (int) _setReminderWindow.Slider.Value;
            if (NotifyToggleButton.IsChecked != null) Settings.Default.IsNotify = (bool) NotifyToggleButton.IsChecked;


            Properties.Settings.Default.Save();

            try
            {
                //PlanManager.SerializeToJSON(DataFilePath);
                Properties.Settings.Default.PlanData = PlanManager.SerializeToJSON();
                Properties.Settings.Default.Save();
            }
            catch (Exception exception)
            {
                streamWriter.WriteLine(DateTime.Now.ToString("G"));
                streamWriter.WriteLine(exception.Message);
                streamWriter.WriteLine();
            }

            streamWriter.Close();
            fileStream.Close();
        }

        protected override void OnClosing(CancelEventArgs e)
        {
            e.Cancel = true;

            _changeTimeWindow.Hide();
            _addEventWindow.Hide();
            _showEventDetail.Hide();
            _editEvent.Hide();
            _setReminderWindow.Hide();

            _trayPopup.Visibility = Visibility.Visible;
            _trayPopup.CalendarButton.IsEnabled = true;
            Hide();
        }

        private void MainWindow_OnActivated(object sender, EventArgs e)
        {
            string processName = Process.GetCurrentProcess().ProcessName;
            Process[] processes = Process.GetProcessesByName(processName);

            if (processes.Length > 1)
            {
                MessageBox.Show(string.Format("{0} is running!", processName), "Error!!!", MessageBoxButton.OK, MessageBoxImage.Error);
                Application.Current.Shutdown();
            }

            _changeTimeWindow.Owner = this;
            _showEventDetail.Owner = this;
            _trayPopup.OwnerMainWindow = this;
            _editEvent.Owner = this;
            _setReminderWindow.Owner = this;
            _addEventWindow.Owner = this;
            _balloonTip.OwnerWindow = this;
            _timer.Start();
        }


        private void SetReminderButton_OnClick(object sender, RoutedEventArgs e)
        {
            Opacity = 0.4;
            _setReminderWindow.ShowDialog();
        }

        private void Timer_Tick(object sender, EventArgs e)
        {
            DateTime now = DateTime.Now;

            #region Clock Update 

            Clock.Content = now.ToString(format: "G");

            #endregion

            #region Check new day                       

            if (now.Second == 0 && now.Minute == 0 && now.Hour == 0)
            {
                int month = now.Month;
                int year = now.Year;
                _changeTimeWindow.ChangeTime(month, year);
            }

            #endregion

            #region Notify

            int timeout = (int)_setReminderWindow.Slider.Value * 60;
            if (_notifyTick >= timeout &&
                PlanManager.Plans.ContainsKey(now.ToString("MM/dd/yyyy")) &&
                NotifyToggleButton.IsChecked == true)
            {

                Plan todayPlan = PlanManager.Plans[now.ToString("MM/dd/yyyy")];
                List<Task> taskListNotify =
                    todayPlan.Tasks.Where(task =>
                        ((int)task.StartTime.X < now.Hour ||
                         ((int)task.StartTime.X == now.Hour &&
                          (int)task.StartTime.Y <= now.Minute)) &&

                        ((int)task.EndTime.X > now.Hour ||
                         ((int)task.EndTime.X == now.Hour &&
                          (int)task.EndTime.Y >= now.Minute))).ToList();

                string notifyContent = "Những công việc cần làm hôm nay:\n";

                foreach (Task task in taskListNotify)
                {
                    string startHourString;
                    string startMinuteString;
                    string endHourString;
                    string endMinuteString;

                    if (task.StartTime.X < 10)
                    {
                        startHourString = "0" + (int)task.StartTime.X;
                    }
                    else
                    {
                        startHourString = "" + (int)task.StartTime.X;
                    }

                    if (task.StartTime.Y < 10)
                    {
                        startMinuteString = "0" + (int)task.StartTime.Y;
                    }
                    else
                    {
                        startMinuteString = "" + (int)task.StartTime.Y;
                    }

                    if (task.EndTime.X < 10)
                    {
                        endHourString = "0" + (int)task.EndTime.X;
                    }
                    else
                    {
                        endHourString = "" + (int)task.EndTime.X;
                    }

                    if (task.EndTime.Y < 10)
                    {
                        endMinuteString = "0" + (int)task.EndTime.Y;
                    }
                    else
                    {
                        endMinuteString = "" + (int)task.EndTime.Y;
                    }

                    notifyContent += string.Format("{0}: {1}:{2} - {3}:{4}\n",
                        task.Title,
                        startHourString,
                        startMinuteString,
                        endHourString,
                        endMinuteString);

                    _balloonTip.Content = notifyContent;

                    try
                    {
                        _taskbarIcon.ShowCustomBalloon(_balloonTip, PopupAnimation.Scroll, 10000);
                    }
                    catch (Exception exeption)
                    {
                        FileStream fileStream = new FileStream(LogFilePath, FileMode.Append, FileAccess.Write);
                        StreamWriter streamWriter = new StreamWriter(fileStream);

                        streamWriter.WriteLine(DateTime.Now.ToString("G"));
                        streamWriter.WriteLine(exeption.Message);
                        streamWriter.WriteLine();

                        streamWriter.Close();
                        fileStream.Close();
                    }
                }

                _notifyTick = 0;
            }
            else
            {
                _notifyTick++;
            }

            #endregion
        }

        private void AddEventButton_OnClick(object sender, RoutedEventArgs e)
        {
            if (_addEventWindow != null)
            {
                Opacity = 0.4;
                _addEventWindow.ResetUI();

                string day, month;
                if (CalendarTable.SelectedDate.Day < 10)
                {
                    day = "0" + CalendarTable.SelectedDate.Day;
                }
                else
                {
                    day = "" + CalendarTable.SelectedDate.Day;
                }

                if (CalendarTable.SelectedDate.Month < 10)
                {
                    month = "0" + CalendarTable.SelectedDate.Month;
                }
                else
                {
                    month = "" + CalendarTable.SelectedDate.Month;
                }

                var year = "" + CalendarTable.SelectedDate.Year;

                var content = day + "/" + month + "/" + year;

                _addEventWindow.DateLabel.Content = content;

                _addEventWindow.ShowDialog();
            }
        }

        private void CalendarTable_OnSelectedDateChange(object sender, EventArgs e)
        {

            ShowEvents();
        }

        public void ShowEvents()
        {
            #region Reset EventGrid

            int count = EventGrid.Children.Count;
            EventGrid.Children.RemoveRange(0, count);
            //            for (int index = 0; index < count; index++)
            //            {
            //                EventGrid.Children.RemoveAt(index);
            //            }

            #endregion

            if (_myEventButton != null &&
                PlanManager.Plans.ContainsKey(CalendarTable.SelectedDate.ToString("MM/dd/yyyy")))
            {

                Plan currentPlan = PlanManager.SelectedPlan;

                int i = 0;
                int buttonHeight = 50;

                foreach (Task task in currentPlan.Tasks)
                {
                    double marginTop = buttonHeight * i * 2.5;

                    var eventButton = new Event()
                    {
                        Margin = new Thickness(0, 10, 0, 0),
                        Height = buttonHeight,
                    };

                    eventButton.TitleLabel.Content = task.Title;
                    eventButton.Owner = this;
                    eventButton.DoubleClick += EventButton_OnClick;

                    EventGrid.Children.Add(eventButton);
                    i++;
                }
            }
        }


        private void EventButton_OnClick(object sender, EventArgs e)
        {
            if (sender is Event button)
            {
                Plan plan = PlanManager.SelectedPlan;
                int index = EventGrid.Children.IndexOf(button);
                Task task = plan.Tasks[index];

                _showEventDetail.Title.Content = task.Title;
                _showEventDetail.Detail.Text = task.Detail;

                string startHourString;
                string startMinuteString;
                string endHourString;
                string endMinuteString;

                if (task.StartTime.X < 10)
                {
                    startHourString = "0" + (int)task.StartTime.X;
                }
                else
                {
                    startHourString = "" + (int)task.StartTime.X;
                }

                if (task.StartTime.Y < 10)
                {
                    startMinuteString = "0" + (int)task.StartTime.Y;
                }
                else
                {
                    startMinuteString = "" + (int)task.StartTime.Y;
                }

                if (task.EndTime.X < 10)
                {
                    endHourString = "0" + (int)task.EndTime.X;
                }
                else
                {
                    endHourString = "" + (int)task.EndTime.X;
                }

                if (task.EndTime.Y < 10)
                {
                    endMinuteString = "0" + (int)task.EndTime.Y;
                }
                else
                {
                    endMinuteString = "" + (int)task.EndTime.Y;
                }

                string startTimeString = startHourString + " : " + startMinuteString;
                string endTimeString = endHourString + " : " + endMinuteString;

                _showEventDetail.StartTime.Content = "Start: " + startTimeString;
                _showEventDetail.EndTime.Content = "End: " + endTimeString;

                Opacity = 0.4;
                _showEventDetail.ShowDialog();
            }
        }

        //        private void MainWindow_OnStateChanged(object sender, EventArgs e)
        //        {
        //            if (WindowState == WindowState.Minimized)
        //            {
        //                _trayPopup.Visibility = Visibility.Visible;
        //                _trayPopup.CalendarButton.IsEnabled = true;
        //            }
        //        }

        private void Clock_Click(object sender, RoutedEventArgs e)
        {
            Process.Start(Application.ResourceAssembly.Location);
            Application.Current.Shutdown();
        }

        private void ControlBar_OnMouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            DragMove();
        }

        private void CloseWindowButton_OnClick(object sender, RoutedEventArgs e)
        {
            Close();
        }

        private void MinimizeButton_OnClick(object sender, RoutedEventArgs e)
        {
            WindowState = WindowState.Minimized;
        }
    }
}
