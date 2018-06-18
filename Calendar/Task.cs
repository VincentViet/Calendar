using System;
using System.Windows;

namespace Calendar
{
    public class Task
    {
        #region Field
        private string _title;
        private string _detail;
        private Point _startTime;
        private Point _endTime;
        #endregion

        public string Title { get => _title; set => _title = value; }
        public Point StartTime { get => _startTime; set => _startTime = value; }
        public Point EndTime { get => _endTime; set => _endTime = value; }
        public string Detail { get => _detail; set => _detail = value; }
    }
}
