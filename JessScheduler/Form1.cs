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

        public DateTime dt = DateTime.Now;

		public void SetDefaultValues()
		{
            cbFilterBy.SelectedIndex = cbFilterBy.FindStringExact("Name");
			dateEndDate.Value = dateEndDate.Value.AddDays(+7);
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

            Filters filters = new Filters();
            filters.ShowNotScheduled = checkShowNotScheduled.Checked;
            filters.ShowOnHold = checkOnHold.Checked;
            filters.ShowCancelled = checkCancelled.Checked;

            Appointment.LoadAppointments(load, filters);
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

        public void UnlockFields(bool tf)
        {
            tbName.Enabled = tf;
            tbPhone.Enabled = tf;
            tbAddress.Enabled = tf;
            dateScheduleDateTime.Enabled = tf;
            cbStatus.Enabled = tf;
            tbNotes.Enabled = tf;
            btnSave.Enabled = tf;
        }

        public void PopulateAppointmentFields()
        {
            tbName.Text = lvAppointments.SelectedItems[0].SubItems[0].Text;
            tbPhone.Text = lvAppointments.SelectedItems[0].SubItems[1].Text;
            tbAddress.Text = lvAppointments.SelectedItems[0].SubItems[2].Text;
            tbNotes.Text = lvAppointments.SelectedItems[0].SubItems[5].Text;

            if (lvAppointments.SelectedItems[0].SubItems[3].Text == "NOT SCHEDULED")
            {
                cbStatus.SelectedIndex = cbStatus.FindStringExact("Not Scheduled");
                dateScheduleDateTime.Value = dt;
                return;
            }
            if (lvAppointments.SelectedItems[0].SubItems[3].Text == "ON HOLD")
            {
                cbStatus.SelectedIndex = cbStatus.FindStringExact("On Hold");
                dateScheduleDateTime.Value = dt;
                return;
            }
            if (lvAppointments.SelectedItems[0].SubItems[3].Text == "CANCELLED")
            {
                cbStatus.SelectedIndex = cbStatus.FindStringExact("Cancelled");
                dateScheduleDateTime.Value = dt;
                return;
            }
            else
            {
                cbStatus.SelectedIndex = cbStatus.FindStringExact("Scheduled");
                dateScheduleDateTime.Text = lvAppointments.SelectedItems[0].SubItems[3].Text;
                dateScheduleDateTime.Enabled = false;
            }

        }

        private void Form1_Load(object sender, EventArgs e)
		{
			SetDefaultValues();
            LoadAppointments();
            UnlockFields(false);
            return;
        }

        private void lvAppointments_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (lvAppointments.SelectedItems.Count == 0)
                return;
            PopulateAppointmentFields();
            return;
        }

        private void btnNew_Click(object sender, EventArgs e)
        {
            UnlockFields(true);
            ResetFields();
            //un-select all listview items
            return;
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            UnlockFields(true);
            //some magic stuff to let the app know it's updating an existing entry, not creating a new entry
            //probably store and use the selected row's ID (SQL ID)
            return;
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (lvAppointments.SelectedItems.Count == 0)
                return;

            string name = lvAppointments.SelectedItems[0].SubItems[0].Text;
            string date = lvAppointments.SelectedItems[0].SubItems[3].Text;
            string labelName = "Date";
            if (date == "NOT SCHEDULED" || date == "ON HOLD" || date == "CANCELLED")
                labelName = "Status";

            string message = String.Format("Are you sure you want to delete the selected Appointment? This cannot be undone.\r\n\r\nName: {0}\r\n{1}: {2}",
                name,
                labelName,
                date);
            string caption = "CONFIRM";
            MessageBoxButtons buttons = MessageBoxButtons.YesNo;
            MessageBoxIcon icon = MessageBoxIcon.Question;
            DialogResult result;

            result = MessageBox.Show(message, caption, buttons, icon);
            if (result == DialogResult.Yes)
                return;
            else
                return;
        }

        private void btnMaps_Click(object sender, EventArgs e)
        {
            //DatabaseActivity.CreateDatabaseFile();
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

            Filters filters = new Filters();
            filters.ShowNotScheduled = checkShowNotScheduled.Checked;
            filters.ShowOnHold = checkOnHold.Checked;
            filters.ShowCancelled = checkCancelled.Checked;

            Appointment.SaveAppointment(appointment, load, filters);
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

        private void dateStartDate_ValueChanged(object sender, EventArgs e)
        {
            LoadAppointments();
            return;
        }

        private void dateEndDate_ValueChanged(object sender, EventArgs e)
        {
            LoadAppointments();
            return;
        }
    }
}
