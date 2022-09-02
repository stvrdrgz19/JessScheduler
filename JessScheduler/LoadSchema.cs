using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace JessScheduler
{
    public class LoadSchema
    {
        public ListView ScheduleList { get; set; }
        public ComboBox FilterByField { get; set; }
        public string FilterByValue { get; set; }
        public bool ShowScheduled { get; set; }
        public bool ShowNotScheduled { get; set; }
        public bool OnHold { get; set; }
        public bool Cancelled { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }

        public LoadSchema(ListView ScheduleList, ComboBox FilterByField, string FilterByValue, bool ShowScheduled, bool ShowNotScheduled, bool OnHold, bool Cancelled, DateTime StartDate, DateTime EndDate)
        {
            this.ScheduleList = ScheduleList;
            this.FilterByField = FilterByField;
            this.FilterByValue = FilterByValue;
            this.ShowScheduled = ShowScheduled;
            this.ShowNotScheduled = ShowNotScheduled;
            this.OnHold = OnHold;
            this.Cancelled = Cancelled;
            this.StartDate = StartDate;
            this.EndDate = EndDate;
        }
    }
}
