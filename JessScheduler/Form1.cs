using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
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
        public int EditAppointmentID;
        public int DeleteAppointmentID;
        public int SelectedAppointmentID;
        public bool IsEditActive = false;
        public Appointment EditAppointment;

		public void SetDefaultValues()
		{
            cbFilterBy.SelectedIndex = cbFilterBy.FindStringExact("Name");
			dateEndDate.Value = dateEndDate.Value.AddDays(+28);
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
            btnCancel.Enabled = tf;
        }

        public void ToggleFiltersAndButtons(bool tf)
        {
            cbFilterBy.Enabled = tf;
            tbFilterBy.Enabled = tf;
            checkShowScheduled.Enabled = tf;
            checkShowNotScheduled.Enabled = tf;
            checkOnHold.Enabled = tf;
            checkCancelled.Enabled = tf;
            dateStartDate.Enabled = tf;
            dateEndDate.Enabled = tf;
            lvAppointments.Enabled = tf;
            btnNew.Enabled = tf;
            btnEdit.Enabled = tf;
            btnDelete.Enabled = tf;
            btnMaps.Enabled = tf;
        }

        public void PopulateAppointmentFields()
        {
            tbName.Text = lvAppointments.SelectedItems[0].SubItems[0].Text;
            tbPhone.Text = Utilities.UnformatPhoneNumber(lvAppointments.SelectedItems[0].SubItems[1].Text);
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

                Appointment selectedAppointment = DatabaseActivity.GetAppointmentByID(SelectedAppointmentID);
                dateScheduleDateTime.Text = selectedAppointment.DateTime.ToString();

                dateScheduleDateTime.Enabled = false;
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

        public void CheckForOnHoldAppointments()
        {
            List<string> onHoldNames = new List<string>();
            List<Appointment> appointmentsOnHold = DatabaseActivity.GetOnHoldAppointments();
            foreach (Appointment appointment in appointmentsOnHold)
            {
                if (DateTime.Now >= appointment.DateTime)
                {
                    onHoldNames.Add(appointment.Name);
                }
            }
            if (onHoldNames.Count() > 0)
            {
                string message = "Check the following On Hold Orders:\r\n\r\n";
                message += String.Join("\r\n", onHoldNames);
                string caption = "ON HOLD";
                MessageBoxButtons buttons = MessageBoxButtons.OK;
                MessageBoxIcon icon = MessageBoxIcon.Exclamation;

                MessageBox.Show(message, caption, buttons, icon);
            }
        }

        private void Form1_Load(object sender, EventArgs e)
		{
			SetDefaultValues();
            LoadAppointments();
            UnlockFields(false);
            CheckForOnHoldAppointments();
            return;
        }

        private void lvAppointments_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (lvAppointments.SelectedItems.Count == 0)
                return;

            SelectedAppointmentID = Int32.Parse(lvAppointments.SelectedItems[0].SubItems[4].Text);
            PopulateAppointmentFields();
            return;
        }

        private void btnNew_Click(object sender, EventArgs e)
        {
            UnlockFields(true);
            ToggleFiltersAndButtons(false);
            ResetFields();
            foreach (ListViewItem item in lvAppointments.Items)
                item.Selected = false;
            return;
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            if (lvAppointments.SelectedItems.Count == 0)
                return;

            UnlockFields(true);
            ToggleFiltersAndButtons(false);
            EditAppointmentID = Int32.Parse(lvAppointments.SelectedItems[0].SubItems[4].Text);
            IsEditActive = true;
            EditAppointment = DatabaseActivity.GetAppointmentByID(EditAppointmentID);
            return;
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (lvAppointments.SelectedItems.Count == 0)
                return;

            string name = lvAppointments.SelectedItems[0].SubItems[0].Text;
            string date = lvAppointments.SelectedItems[0].SubItems[3].Text;
            DeleteAppointmentID = Int32.Parse(lvAppointments.SelectedItems[0].SubItems[4].Text);
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

                Appointment.DeleteAppointment(load, filters, DeleteAppointmentID);
            }
            return;
        }

        private void btnMaps_Click(object sender, EventArgs e)
        {
            if (lvAppointments.SelectedItems.Count == 0)
                return;

            //MessageBox.Show(String.Format());

            //string addr = lvAppointments.SelectedItems[0].SubItems[2].Text;

            //string linkStart = @"https://www.google.com/maps/dir/";
            //Process.Start(String.Format("{0}{1}", linkStart, addr.Replace(" ", "+")));
            return;
        }

        private void cbStatus_SelectedIndexChanged(object sender, EventArgs e)
        {
            switch (cbStatus.Text)
            {
                case "Scheduled":
                    dateScheduleDateTime.Enabled = true;
                    labelDateTime.Text = @"Date/Time:";
                    break;
                case "On Hold":
                    dateScheduleDateTime.Enabled = true;
                    labelDateTime.Text = @"Hold Until:";
                    break;
                case "Not Scheduled":
                case "Cancelled":
                    dateScheduleDateTime.Enabled = false;
                    labelDateTime.Text = @"Date/Time:";
                    break;
            }
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
            if (appointment.Status == "Scheduled" || appointment.Status == "On Hold")
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

            if (IsEditActive)
            {
                List<Variance> variances = EditAppointment.Compare(appointment);
                if (variances.Count > 0)
                {
                    VarianceForm variancePrompt = new VarianceForm();
                    variancePrompt.variances = variances;
                    var dialogResult = variancePrompt.ShowDialog();

                    if (dialogResult == DialogResult.Yes)
                    {
                        Appointment.UpdateAppointment(appointment, load, filters, EditAppointmentID);
                    }
                }
                IsEditActive = false;
            }
            else
                Appointment.SaveAppointment(appointment, load, filters);
            ResetFields();
            UnlockFields(false);
            ToggleFiltersAndButtons(true);
            return;
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            ResetFields();
            UnlockFields(false);
            ToggleFiltersAndButtons(true);
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
