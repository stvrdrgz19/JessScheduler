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
            cbFilterBy.SelectedIndex = cbFilterBy.FindStringExact("Name");
			dateFrom.Value = dateFrom.Value.AddDays(-7);
		}

        public static void ResetFields()
		{

		}

		private void Form1_Load(object sender, EventArgs e)
		{
			SetDefaultValues();
            Appointment.LoadAppointments(lvAppointments, cbFilterBy, tbFilterBy.Text, checkShowScheduled.Checked, checkShowNotScheduled.Checked);
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
            appointment.Status = cbStatus.Text;
            if (appointment.Status == "Scheduled")
                appointment.DateTime = dateScheduleDateTime.Value;
            appointment.Notes = tbNotes.Text;

            Appointment.SaveAppointment(appointment, lvAppointments, cbFilterBy, tbFilterBy.Text, checkShowScheduled.Checked, checkShowNotScheduled.Checked);
            ResetFields();
            return;
		}

        private void checkShowScheduled_CheckedChanged(object sender, EventArgs e)
        {
            Appointment.LoadAppointments(lvAppointments, cbFilterBy, tbFilterBy.Text, checkShowScheduled.Checked, checkShowNotScheduled.Checked);
            return;
        }

        private void checkShowNotScheduled_CheckedChanged(object sender, EventArgs e)
        {
            Appointment.LoadAppointments(lvAppointments, cbFilterBy, tbFilterBy.Text, checkShowScheduled.Checked, checkShowNotScheduled.Checked);
            return;
        }

        private void cbFilterBy_SelectedIndexChanged(object sender, EventArgs e)
        {
            Appointment.LoadAppointments(lvAppointments, cbFilterBy, tbFilterBy.Text, checkShowScheduled.Checked, checkShowNotScheduled.Checked);
            return;
        }

        private void tbFilterBy_TextChanged(object sender, EventArgs e)
        {
            Appointment.LoadAppointments(lvAppointments, cbFilterBy, tbFilterBy.Text, checkShowScheduled.Checked, checkShowNotScheduled.Checked);
            return;
        }
    }
}
