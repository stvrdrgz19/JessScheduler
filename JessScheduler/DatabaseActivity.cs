using Dapper;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SQLite;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
			//SQLiteConnection.CreateFile(String.Format(@"{0}\Files\Database.db", Environment.CurrentDirectory));
			SQLiteConnection.CreateFile(String.Format(@"{0}\Files\Database.db", @"C:\Users\stvrd\Downloads\Test"));
			CreateTable();
		}

		public static void CreateTable()
		{
			SQLiteConnection conn = new SQLiteConnection(LoadConnectionString());
			conn.Open();

			string appointments = @"CREATE TABLE Appointments (
				Id INTEGER NOT NULL UNIQUE,
				Scheduled INTEGER NOT NULL,
				Name TEXT NOT NULL,
				Phone TEXT NOT NULL,
				Address TEXT NOT NULL,
				Date TEXT NOT NULL,
				Time TEXT NOT NULL,
				PRIMARY KEY(Id AUTOINCREMENT)
			);";

			SQLiteCommand command = new SQLiteCommand(appointments, conn);
			command.ExecuteNonQuery();
		}

		public static List<Appointment> GetAppointments()
		{
			List <Appointment> appointments = new List<Appointment>();
			using (IDbConnection conn = new SQLiteConnection(LoadConnectionString()))
			{
				return conn.Query<Appointment>("Select Scheduled, Name, Phone, Address, Date, Time FROM Appointments", new DynamicParameters()).ToList();
			}
		}
	}
}
