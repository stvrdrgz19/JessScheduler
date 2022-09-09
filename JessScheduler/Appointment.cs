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
		public int Id { get; set; }
		public string Name { get; set; }
		public string Phone { get; set; }
		public string Address { get; set; }
		public string Status { get; set; }
		public DateTime DateTime { get; set; }
		public string Notes { get; set; }

		public static void SaveAppointment(Appointment appointment, LoadSchema loadSchema, Filters filter)
		{
			using (IDbConnection conn = new SQLiteConnection(DatabaseActivity.LoadConnectionString()))
			{
				conn.Execute(@"INSERT INTO Appointments (Name, Phone, Address, Status, DateTime, Notes) 
					VALUES (@Name, @Phone, @Address, @Status, @DateTime, @Notes)",
					appointment);
			}
			LoadAppointments(loadSchema, filter);
		}

		public static void UpdateAppointment(Appointment appointment, LoadSchema loadSchema, Filters filter, int appointmentId)
		{
			using (IDbConnection conn = new SQLiteConnection(DatabaseActivity.LoadConnectionString()))
            {
				conn.Execute(String.Format("UPDATE Appointments SET Name = @Name, Phone = @Phone, Address = @Address, Status = @Status, DateTime = @DateTime, Notes = @Notes WHERE Id = {0}", appointmentId), appointment);
            }
			LoadAppointments(loadSchema, filter);
        }

		public static void DeleteAppointment(LoadSchema loadSchema, Filters filter, int appointmentId)
		{
			using (IDbConnection conn = new SQLiteConnection(DatabaseActivity.LoadConnectionString()))
            {
				conn.Execute(String.Format("DELETE FROM Appointments WHERE Id = {0}", appointmentId));
            }
			LoadAppointments(loadSchema, filter);
		}

		public static void LoadAppointments(LoadSchema loadSchema, Filters filter)
		{
			loadSchema.ScheduleList.Items.Clear();

			List<Appointment> appointments = DatabaseActivity.GetUnscheduledAppointments(filter, loadSchema);
			appointments.AddRange(DatabaseActivity.GetAppointments(loadSchema));

			foreach (Appointment appointment in appointments)
			{
				ListViewItem app = new ListViewItem(appointment.Name);
				app.SubItems.Add(Utilities.FormatPhoneNumber(appointment.Phone));
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
				app.SubItems.Add(appointment.Id.ToString());
				app.SubItems.Add(appointment.Notes);
				loadSchema.ScheduleList.Items.Add(app);
			}
		}
	}
}
