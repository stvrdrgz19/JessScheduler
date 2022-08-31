using Dapper;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SQLite;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace JessScheduler
{
	public class Appointment
	{
		public string Name { get; set; }
		public string Phone { get; set; }
		public string Address { get; set; }
		public DateTime DateTime { get; set; }
		public string Status { get; set; }
		public string Notes { get; set; }

		public static void SaveAppointment(Appointment appointment, ListView lv, ComboBox cb, string filterBy, bool showScheduled, bool showNotScheduled)
		{
			using (IDbConnection conn = new SQLiteConnection(DatabaseActivity.LoadConnectionString()))
			{
				conn.Execute(@"INSERT INTO Appointments (Name, Phone, Address, DateTime, Status) 
					VALUES (@Name, @Phone, @Address, @DateTime, @Status)",
					appointment);
			}
			LoadAppointments(lv, cb, filterBy, showScheduled, showNotScheduled);
		}

		public static void LoadAppointments(ListView lv, ComboBox cb, string filterBy, bool showScheduled, bool showNotScheduled)
		{
			lv.Items.Clear();
			List<Appointment> appintments = DatabaseActivity.GetAppointments(cb, filterBy, showScheduled, showNotScheduled);
			foreach (Appointment appointment in appintments)
			{
				ListViewItem app = new ListViewItem(appointment.Name);
				app.SubItems.Add(appointment.Phone);
				app.SubItems.Add(appointment.Address);
				switch(appointment.Status)
				{
					case "Scheduled":
						app.SubItems.Add(appointment.DateTime.ToString("MM/dd/yyyy hh:mm tt"));
						break;
					case "Not Scheduled":
						app.SubItems.Add("NOT SCHEDULED");
						break;
					case "On Hold":
						app.SubItems.Add("ON HOLD");
						break;
					case "Cancelled":
						app.SubItems.Add("CANCELLED");
						break;
				}
				lv.Items.Add(app);
			}
		}
	}
}
