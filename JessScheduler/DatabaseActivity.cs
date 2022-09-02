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

		public static List<Appointment> GetAppointments(ComboBox cb, string filterValue, bool showScheduled, bool showNotScheduled)
		{
			using (IDbConnection conn = new SQLiteConnection(LoadConnectionString()))
			{
				string scriptStart = "Select Scheduled, Name, Phone, Address, DateTime FROM Appointments";
				string whereClause = "";
				string orderBy = "ORDER BY DateTime";

				if (!String.IsNullOrWhiteSpace(filterValue))
				{
					whereClause = String.Format("WHERE {0} LIKE '%{1}%'", cb.Text, filterValue);
					if (showScheduled && !showNotScheduled)
						whereClause += " AND Scheduled = 1";
					else if (!showScheduled && showNotScheduled)
						whereClause += " AND Scheduled = 0";
				}
				else
				{
					if (showScheduled && !showNotScheduled)
						whereClause += "WHERE Scheduled = 1";
					else if (!showScheduled && showNotScheduled)
						whereClause += "WHERE Scheduled = 0";
				}
				string script = String.Format("{0} {1} {2}", scriptStart, whereClause, orderBy);
				return conn.Query<Appointment>(script, new DynamicParameters()).ToList();
			}
		}

		public static List<Appointment> GetAppointmentsX(LoadSchema loadSchema)
		{
			using (IDbConnection conn = new SQLiteConnection(LoadConnectionString()))
			{
				List<string> statuses = new List<string>();
				if (loadSchema.ShowScheduled)
					statuses.Add("Scheduled");
				if (loadSchema.ShowNotScheduled)
					statuses.Add("Not Scheduled");
				if (loadSchema.OnHold)
					statuses.Add("On Hold");
				if (loadSchema.Cancelled)
					statuses.Add("Cancelled");

				string scriptStart = "Select Name, Phone, Address, Status, DateTime, Notes FROM Appointments";
				string whereClause = "";
				string orderBy = " ORDER BY DateTime";

				if (!String.IsNullOrWhiteSpace(loadSchema.FilterByValue))
				{
					whereClause = String.Format("WHERE {0} LIKE '%{1}%'", loadSchema.FilterByField.Text, loadSchema.FilterByValue);

					switch (statuses.Count)
					{
						case 1:
							whereClause += String.Format(" AND Status = '{0}'", statuses[0]);
							break;
						case 2:
							whereClause += String.Format(" AND Status IN ('{0}', '{1}')", statuses[0], statuses[1]);
							break;
						case 3:
							whereClause += String.Format(" AND Status IN ('{0}', '{1}', '{2}')", statuses[0], statuses[1], statuses[2]);
							break;
						case 4:
							whereClause += String.Format(" AND Status IN ('{0}', '{1}', '{2}', '{3}')", statuses[0], statuses[1], statuses[2], statuses[3]);
							break;
					}
				}
				else
				{
					switch (statuses.Count)
					{
						case 1:
							whereClause += String.Format("WHERE Status = '{0}'", statuses[0]);
							break;
						case 2:
							whereClause += String.Format("WHERE Status IN ('{0}', '{1}')", statuses[0], statuses[1]);
							break;
						case 3:
							whereClause += String.Format("WHERE Status IN ('{0}', '{1}', '{2}')", statuses[0], statuses[1], statuses[2]);
							break;
						case 4:
							whereClause += String.Format("WHERE Status IN ('{0}', '{1}', '{2}', '{3}')", statuses[0], statuses[1], statuses[2], statuses[3]);
							break;
					}
				}
				string script = String.Format("{0} {1} {2}", scriptStart, whereClause, orderBy);
				return conn.Query<Appointment>(script, new DynamicParameters()).ToList();
			}
		}
	}
}
