using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace JessScheduler
{
	public partial class Form1 : Form
	{
		public Form1()
		{
			InitializeComponent();
		}

		public void SetDefaultValues()
		{
			cbShow.SelectedIndex = cbShow.FindStringExact("Both");
			dateFrom.Value = dateFrom.Value.AddDays(-7);
		}

		private void Form1_Load(object sender, EventArgs e)
		{
			dateScheduleTime.Text = "09:00:00";
			SetDefaultValues();
			Appointment.LoadAppointments(lvAppointments);
			return;
		}

		private void btnEdit_Click(object sender, EventArgs e)
		{
			DatabaseActivity.CreateDatabaseFile();
			return;
		}

		private void btnSave_Click(object sender, EventArgs e)
		{
			if (tbName.Text == "" || tbPhone.Text == "" || tbAddress.Text == "")
				MessageBox.Show("Please enter Name, Phone, AND Address information.");

			Appointment appointment = new Appointment();
			appointment.Name = tbName.Text;
			appointment.Phone = tbPhone.Text;
			appointment.Address = tbAddress.Text;
			if (!checkScheduled.Checked)
			{
				appointment.Date = dateScheduleDate.Value;
				appointment.Time = dateScheduleTime.Value;
				appointment.Scheduled = true;
			}
			else
				appointment.Scheduled = false;

			Appointment.SaveAppointment(appointment);
			return;
		}
	}
}
