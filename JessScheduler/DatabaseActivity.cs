using Dapper;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SQLite;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace JessScheduler
{
	public class DatabaseActivity
	{
		public static string LoadConnectionString(string id = "Default")
		{
			return ConfigurationManager.ConnectionStrings[id].ConnectionString;
		}

		public static void CreateDatabaseFile()
		{
			SQLiteConnection.CreateFile(String.Format(@"{0}\Files\Database.db", Environment.CurrentDirectory));
			//SQLiteConnection.CreateFile(String.Format(@"{0}\Files\Database.db", @"C:\Users\stvrd\Downloads\Test"));
			CreateTable();
		}

		public static void CreateTable()
		{
			SQLiteConnection conn = new SQLiteConnection(LoadConnectionString());
			conn.Open();

			string appointments = @"CREATE TABLE Appointments (
				Id INTEGER NOT NULL UNIQUE,
				Name TEXT NOT NULL,
				Phone TEXT NOT NULL,
				Address TEXT NOT NULL,
				Status TEXT NOT NULL,
				DateTime TEXT NOT NULL,
				Notes TEXT NOT NULL,
				PRIMARY KEY(Id AUTOINCREMENT)
			);";

			SQLiteCommand command = new SQLiteCommand(appointments, conn);
			command.ExecuteNonQuery();
		}

		public static List<Appointment> GetUnscheduledAppointments(Filters filter, LoadSchema loadSchema)
        {
			using (IDbConnection conn = new SQLiteConnection(LoadConnectionString()))
            {
				string scriptStart = "SELECT * FROM Appointments";
				string whereClause = "";
				string orderBy = " ORDER BY Status";

				List<string> conditions = new List<string>();
				if (filter.ShowNotScheduled) conditions.Add("Not Scheduled");
				if (filter.ShowOnHold) conditions.Add("On Hold");
				if (filter.ShowCancelled) conditions.Add("Cancelled");

				if (conditions.Count > 0)
                {
					switch (conditions.Count)
                    {
						case 1:
							whereClause += String.Format(" WHERE Status = '{0}'", conditions[0]);
							break;
						case 2:
							whereClause += String.Format(" WHERE Status IN ('{0}', '{1}')", conditions[0], conditions[1]);
							break;
						case 3:
							whereClause += String.Format(" WHERE Status IN ('{0}', '{1}', '{2}')", conditions[0], conditions[1], conditions[2]);
							break;
					}

					if (!String.IsNullOrWhiteSpace(loadSchema.FilterByValue))
						whereClause += String.Format(" AND {0} LIKE '%{1}%'", loadSchema.FilterByField.Text, loadSchema.FilterByValue);
				}
				else 
					whereClause += " WHERE Status='Fail'";

				string script = String.Format("{0} {1} {2}", scriptStart, whereClause, orderBy);
				return conn.Query<Appointment>(script, new DynamicParameters()).ToList();
			}
        }

		public static List<Appointment> GetAppointments(LoadSchema loadSchema)
		{
			using (IDbConnection conn = new SQLiteConnection(LoadConnectionString()))
			{
				string scriptStart = "Select * FROM Appointments";
				string whereClause = String.Format("WHERE Status = 'Scheduled' AND DateTime >= '{0}' AND DateTime <= '{1}'", loadSchema.StartDate.ToString("yyyy-MM-dd"), loadSchema.EndDate.ToString("yyyy-MM-dd"));
				string orderBy = " ORDER BY DateTime";


				if (!String.IsNullOrWhiteSpace(loadSchema.FilterByValue))
					whereClause += String.Format(" AND {0} LIKE '%{1}%'", loadSchema.FilterByField.Text, loadSchema.FilterByValue);

				string script = String.Format("{0} {1} {2}", scriptStart, whereClause, orderBy);
				return conn.Query<Appointment>(script, new DynamicParameters()).ToList();
			}
		}

		public static Appointment GetAppointmentByID(int id)
		{
			using (IDbConnection conn = new SQLiteConnection(LoadConnectionString()))
            {
				string script = String.Format("SELECT * FROM Appointments WHERE Id = {0}", id);
				return conn.Query<Appointment>(script, new DynamicParameters()).SingleOrDefault();
			}
		}

		public static List<Appointment> GetOnHoldAppointments()
		{
			using (IDbConnection conn = new SQLiteConnection(LoadConnectionString()))
			{
				string script = "SELECT * FROM Appointments WHERE Status = 'On Hold'";
				return conn.Query<Appointment>(script, new DynamicParameters()).ToList();
			}
		}
	}
}
