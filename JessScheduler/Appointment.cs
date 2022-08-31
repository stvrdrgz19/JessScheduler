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
		public DateTime Date { get; set; }
		public DateTime Time { get; set; }
		public bool Scheduled { get; set; }

		public static void SaveAppointment(Appointment appointment)
		{
			using (IDbConnection conn = new SQLiteConnection(DatabaseActivity.LoadConnectionString()))
			{
				conn.Execute(@"INSERT INTO Appointments (
					Scheduled
					,Name
					,Phone
					,Address
					,Date
					,Time
					) VALUES (
					@Scheduled
					,@Name
					,@Phone
					,@Address
					,@Date
					,@Time
					)", appointment);
			}
		}

		public static void LoadAppointments(ListView lv)
		{
			List<Appointment> appintments = DatabaseActivity.GetAppointments();
			foreach (Appointment appointment in appintments)
			{
				ListViewItem app = new ListViewItem(appointment.Scheduled.ToString());
				app.SubItems.Add(appointment.Name);
				app.SubItems.Add(appointment.Phone);
				app.SubItems.Add(appointment.Address);
				app.SubItems.Add(String.Format("{0} {1}", appointment.Date, appointment.Time));
				lv.Items.Add(app);
			}
		}
	}
}
