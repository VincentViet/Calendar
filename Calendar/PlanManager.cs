using System;
using System.Collections.Generic;
using System.IO;
using System.Web.Script.Serialization;


namespace Calendar
{
    public class PlanManager
    {
        private Dictionary<string, Plan> _plans;
        private Plan _selectedPlan;
        private DateTime _selectedDate;
        private readonly JavaScriptSerializer _javaScriptSerializer;

        public PlanManager()
        {
            _plans = null;
            _javaScriptSerializer = new JavaScriptSerializer();
        }

        public void AddTask(Task task)
        {
//            string key = _selectedDate.ToString("MM/dd/yyyy");
            if (!_plans.ContainsKey(_selectedDate.ToString("MM/dd/yyyy")))
            {
//                _selectedPlan = new Plan() { Date = _selectedDate };
                _selectedPlan = new Plan();
                _plans.Add(_selectedDate.ToString("MM/dd/yyyy"), _selectedPlan);
            }

            _selectedPlan.Tasks.Add(task);
        }

        public DateTime SelectedDate
        {
            get => _selectedDate;
            set
            {
                if (_selectedDate.Year != value.Year ||
                    _selectedDate.Month != value.Month ||
                    _selectedDate.Day != value.Day)
                {
                    _selectedDate = value;

                    if (_plans.ContainsKey(_selectedDate.ToString("MM/dd/yyyy")))
                    {
                        _selectedPlan = _plans[_selectedDate.ToString("MM/dd/yyyy")];
                    }
                }
            }
        }

        public Plan SelectedPlan { get => _selectedPlan; set => _selectedPlan = value; }
        public Dictionary<string, Plan> Plans { get => _plans;}

        public string SerializeToJSON()
        {

            try
            {
                List<string> keys  = new List<string>();
                foreach (var plan in _plans)
                {
                    if (plan.Value.Tasks.Count == 0)
                    {
                          keys.Add(plan.Key);
                    }
                }

                foreach (string key in keys)
                {
                    _plans.Remove(key);
                }

                var json = _javaScriptSerializer.Serialize(_plans);
                return json;
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public void Deserialize()
        {
            string json = Properties.Settings.Default.PlanData;

           

            try
            {
                _plans = _javaScriptSerializer.Deserialize<Dictionary<string, Plan>>(json);

                if (_plans == null)
                {
                    _plans = new Dictionary<string, Plan>();
                }
            }
            catch (Exception)
            {

                if (_plans == null)
                {
                    _plans = new Dictionary<string, Plan>();
                }

                throw;
            }

        }
    }
}
