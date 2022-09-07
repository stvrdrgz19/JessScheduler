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
				if (filter.ShowNotScheduled) conditions.Add("Status='Not Scheduled'");
				if (filter.ShowOnHold) conditions.Add("Status='On Hold'");
				if (filter.ShowCancelled) conditions.Add("Status='Cancelled'");

				if (conditions.Any())
					whereClause += " WHERE " + string.Join(" OR ", conditions);
				else
					whereClause += "WHERE Status='Fail'";

				if (!String.IsNullOrWhiteSpace(loadSchema.FilterByValue))
					whereClause += String.Format(" AND {0} LIKE '%{1}%'", loadSchema.FilterByField.Text, loadSchema.FilterByValue);

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
	}
}
