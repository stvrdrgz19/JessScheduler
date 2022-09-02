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
			dateStartDate.Value = dateStartDate.Value.AddDays(-7);
            cbStatus.SelectedIndex = cbStatus.FindStringExact("Scheduled");
        }

        public void LoadAppointments()
        {
            LoadSchema load = new LoadSchema(
                lvAppointments,
                cbFilterBy,
                tbFilterBy.Text,
                checkShowScheduled.Checked,
                checkShowNotScheduled.Checked,
                checkOnHold.Checked,
                checkCancelled.Checked,
                dateStartDate.Value,
                dateEndDate.Value
                );

            Appointment.LoadAppointments(load);
            return;
        }

        public void ResetFields()
		{
            tbName.Text = "";
            tbPhone.Text = "";
            tbAddress.Text = "";
            dateScheduleDateTime.Value = DateTime.Now;
            cbStatus.SelectedIndex = cbStatus.FindStringExact("Scheduled");
            tbNotes.Text = "";
		}

		private void Form1_Load(object sender, EventArgs e)
		{
			SetDefaultValues();
            LoadAppointments();
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

            LoadSchema load = new LoadSchema(
                lvAppointments,
                cbFilterBy,
                tbFilterBy.Text,
                checkShowScheduled.Checked,
                checkShowNotScheduled.Checked,
                checkOnHold.Checked,
                checkCancelled.Checked,
                dateStartDate.Value,
                dateEndDate.Value
                );

            Appointment.SaveAppointment(appointment, load);
            ResetFields();
            return;
		}

        private void checkShowScheduled_CheckedChanged(object sender, EventArgs e)
        {
            LoadAppointments();
            return;
        }

        private void checkShowNotScheduled_CheckedChanged(object sender, EventArgs e)
        {
            LoadAppointments();
            return;
        }

        private void cbFilterBy_SelectedIndexChanged(object sender, EventArgs e)
        {
            LoadAppointments();
            return;
        }

        private void tbFilterBy_TextChanged(object sender, EventArgs e)
        {
            LoadAppointments();
            return;
        }

        private void checkOnHold_CheckedChanged(object sender, EventArgs e)
        {
            LoadAppointments();
            return;
        }

        private void checkCancelled_CheckedChanged(object sender, EventArgs e)
        {
            LoadAppointments();
            return;
        }

        private void cbStatus_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbStatus.Text != "Scheduled")
                dateScheduleDateTime.Enabled = false;
            else 
                dateScheduleDateTime.Enabled = true;
            return;
        }
    }
}
