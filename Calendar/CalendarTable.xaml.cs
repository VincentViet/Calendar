using System;
using System.Globalization;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;

namespace Calendar
{
    /// <summary>
    /// Interaction logic for CalendarTable.xaml
    /// </summary>
    public partial class CalendarTable
    {
        private DateTime _date;
        public DateTime Date
        {
            get { return _date; }
            set
            {
                _date = value;
                ResetTable();
                FillCalendar();
            }
        }

        private DateTime _selectedDate;
        public DateTime SelectedDate { get => _selectedDate; set => _selectedDate = value; }

        private readonly Style _cellStyle;
        private readonly Style _hoverCellStyle;
        private readonly Style _todayCellStyle;
        private readonly Style _selectedCellStyle;
        private readonly ChineseLunisolarCalendar _lunisolarCalendar;
        private readonly SolidColorBrush _myOrange;
        private readonly SolidColorBrush _darkGrayBrush;

        public event EventHandler SelectedDateChange;

        public CalendarTable()
        {
            InitializeComponent();
            _date = DateTime.Today;
            _cellStyle = Resources["CellStyle"] as Style;
            _hoverCellStyle = Resources["HoverCellStyle"] as Style;
            _todayCellStyle = Resources["TodayCellStyle"] as Style;
            _selectedCellStyle = Resources["SelectedCellStyle"] as Style;
            _lunisolarCalendar = new ChineseLunisolarCalendar();
            _myOrange = Application.Current.Resources["MyOrange"] as SolidColorBrush;
            _darkGrayBrush = new SolidColorBrush(Colors.DarkGray);

            ResetTable();
            FillCalendar();
        }

        private void FillCalendar()
        {
            if (_hoverCellStyle != null && _todayCellStyle != null)
            {
                DateTime dateTime = new DateTime(_date.Year, _date.Month, 1);
                int today;

                if (dateTime.Month == DateTime.Today.Month &&
                    dateTime.Year == DateTime.Today.Year)
                {
                    today = DateTime.Today.Day;
                }
                else
                {
                    today = -1;
                }

                int begin = (int)dateTime.DayOfWeek +
                            Table.ColumnDefinitions.Count;

                today += begin - 1;

                int end = DateTime.DaysInMonth(dateTime.Year, dateTime.Month) +
                          Table.ColumnDefinitions.Count +
                          (int)dateTime.DayOfWeek;

                int lunaDay;
                int lunaMonth;
                for (int i = begin; i < end; i++, dateTime = dateTime.AddDays(1))
                {
                    var element = Table.Children[i] as Button;
                    if (element != null)
                    {
                        var grid = element.Content as Grid;
                        if (grid != null)
                        {
                            var calendarLabel = grid.Children[0] as Label;
                            var lunaCalendarLabel = grid.Children[1] as Label;
                            if (calendarLabel != null &&
                                lunaCalendarLabel != null)
                            {
                                lunaDay = _lunisolarCalendar.GetDayOfMonth(dateTime);
                                lunaMonth = _lunisolarCalendar.GetMonth(dateTime);

                                if (_lunisolarCalendar.IsLeapYear(dateTime.Year))
                                {
                                    int leapMonth = _lunisolarCalendar.GetLeapMonth(dateTime.Year) - 1;

                                    if (lunaMonth > leapMonth)
                                    {
                                        lunaMonth--;
                                    }
                                }

                                if (lunaMonth > 12)
                                    lunaMonth = 12;

                                calendarLabel.Content = dateTime.Day;

                                if (lunaDay == 1 && _myOrange != null)
                                {
                                    lunaCalendarLabel.Content = lunaDay + "/" + lunaMonth;
                                    lunaCalendarLabel.Foreground = _myOrange;
                                }
                                else
                                {
                                    lunaCalendarLabel.Content = lunaDay;
                                }

                            }
                        }

                        if (i == today)
                        {
                            element.Style = _todayCellStyle;
                        }
                        else
                        {
                            element.Style = _hoverCellStyle;
                        }
                    }
                }
            }

        }

        private void ResetTable()
        {
            if (_cellStyle != null)
            {
                int totalCell = Table.ColumnDefinitions.Count *
                                Table.RowDefinitions.Count;

                for (int i = 7; i < totalCell; i++)
                {
                    var cell = Table.Children[i] as Button;

                    if (cell != null)
                    {
                        var grid = cell.Content as Grid;
                        if (grid != null)
                        {
                            var calendarLabel = grid.Children[0] as Label;
                            var lunaCalendarLabel = grid.Children[1] as Label;
                            if (calendarLabel != null &&
                                lunaCalendarLabel != null)
                            {
                                calendarLabel.Content = "";
                                lunaCalendarLabel.Content = "";
                                lunaCalendarLabel.Foreground = _darkGrayBrush;
                            }
                        }

                        cell.Style = _cellStyle;
                    }
                }

                _selectedDate = DateTime.Today;
            }
        }

        private void Cell_OnClick(object sender, RoutedEventArgs e)
        {
            if (_selectedCellStyle != null)
            {
                int begin = Table.ColumnDefinitions.Count;
                int end = Table.ColumnDefinitions.Count * Table.RowDefinitions.Count;

                for (int i = begin; i < end; i++)
                {
                    var cell = Table.Children[i] as Button;
                    if (cell != null)
                    {
                        if (cell.Style == _selectedCellStyle)
                        {
                            cell.Style = _hoverCellStyle;
                            break;
                        }
                    }
                }

                var selectedCell = sender as Button;
                if (selectedCell != null)
                {
                    if (selectedCell.Style != _todayCellStyle)
                    {
                        selectedCell.Style = _selectedCellStyle;
                    }

                    Grid cellGrid = selectedCell.Content as Grid;
                    if (cellGrid != null)
                    {
                        Label label = cellGrid.Children[0] as Label;
                        if (label != null)
                        {
                            int day = (int)label.Content ;
                            _selectedDate = new DateTime(_date.Year, _date.Month, day);
                            MainWindow.PlanManager.SelectedDate = _selectedDate;

                            SelectedDateChange?.Invoke(this, e);
                        }
                    }
                }
            }
        }
    }
}
