using System;
using System.Collections.Generic;

namespace Calendar
{
    [Serializable]
    public class Plan
    {
//        private DateTime _date;
//
//        public DateTime Date { get => _date; set => _date = value; }
        public List<Task> Tasks;

        public Plan()
        {
            Tasks = new List<Task>();
        }
    }
}
