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
		public bool Scheduled { get; set; }

		public static void SaveAppointment(Appointment appointment, ListView lv, ComboBox cb, string filterBy, bool showScheduled, bool showNotScheduled)
		{
			using (IDbConnection conn = new SQLiteConnection(DatabaseActivity.LoadConnectionString()))
			{
				conn.Execute(@"INSERT INTO Appointments (
					Scheduled
					,Name
					,Phone
					,Address
					,DateTime
					) VALUES (
					@Scheduled
					,@Name
					,@Phone
					,@Address
					,@DateTime
					)", appointment);
			}
			LoadAppointments(lv, cb, filterBy, showScheduled, showNotScheduled);
		}

		public static void LoadAppointments(ListView lv, ComboBox cb, string filterBy, bool showScheduled, bool showNotScheduled)
		{
			lv.Items.Clear();
			List<Appointment> appintments = DatabaseActivity.GetAppointments(cb, filterBy, showScheduled, showNotScheduled);
			foreach (Appointment appointment in appintments)
			{
				ListViewItem app = new ListViewItem(appointment.Scheduled.ToString());
				app.SubItems.Add(appointment.Name);
				app.SubItems.Add(appointment.Phone);
				app.SubItems.Add(appointment.Address);
				if (appointment.Scheduled)
					app.SubItems.Add(appointment.DateTime.ToString("MM/dd/yyyy hh:mm tt"));
				else
					app.SubItems.Add("NOT SCHEDULED");
				lv.Items.Add(app);
			}
		}
	}
}
