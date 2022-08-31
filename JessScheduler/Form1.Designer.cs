namespace JessScheduler
{
	partial class Form1
	{
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.IContainer components = null;

		/// <summary>
		/// Clean up any resources being used.
		/// </summary>
		/// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
		protected override void Dispose(bool disposing)
		{
			if (disposing && (components != null))
			{
				components.Dispose();
			}
			base.Dispose(disposing);
		}

		#region Windows Form Designer generated code

		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
			this.label1 = new System.Windows.Forms.Label();
			this.cbShow = new System.Windows.Forms.ComboBox();
			this.label2 = new System.Windows.Forms.Label();
			this.dateFrom = new System.Windows.Forms.DateTimePicker();
			this.dateTo = new System.Windows.Forms.DateTimePicker();
			this.label3 = new System.Windows.Forms.Label();
			this.lvAppointments = new System.Windows.Forms.ListView();
			this.chScheduled = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
			this.chName = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
			this.chPhone = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
			this.chAddress = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
			this.chDateTime = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
			this.btnEdit = new System.Windows.Forms.Button();
			this.btnDelete = new System.Windows.Forms.Button();
			this.btnMaps = new System.Windows.Forms.Button();
			this.groupBox1 = new System.Windows.Forms.GroupBox();
			this.btnSave = new System.Windows.Forms.Button();
			this.checkScheduled = new System.Windows.Forms.CheckBox();
			this.dateScheduleTime = new System.Windows.Forms.DateTimePicker();
			this.dateScheduleDate = new System.Windows.Forms.DateTimePicker();
			this.label7 = new System.Windows.Forms.Label();
			this.tbAddress = new System.Windows.Forms.TextBox();
			this.label6 = new System.Windows.Forms.Label();
			this.tbPhone = new System.Windows.Forms.TextBox();
			this.label5 = new System.Windows.Forms.Label();
			this.tbName = new System.Windows.Forms.TextBox();
			this.label4 = new System.Windows.Forms.Label();
			this.dateTimePicker1 = new System.Windows.Forms.DateTimePicker();
			this.groupBox1.SuspendLayout();
			this.SuspendLayout();
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.Location = new System.Drawing.Point(13, 13);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(37, 13);
			this.label1.TabIndex = 0;
			this.label1.Text = "Show:";
			// 
			// cbShow
			// 
			this.cbShow.FormattingEnabled = true;
			this.cbShow.Items.AddRange(new object[] {
            "Both",
            "Scheduled",
            "Not Scheduled"});
			this.cbShow.Location = new System.Drawing.Point(50, 10);
			this.cbShow.Name = "cbShow";
			this.cbShow.Size = new System.Drawing.Size(121, 21);
			this.cbShow.TabIndex = 1;
			// 
			// label2
			// 
			this.label2.AutoSize = true;
			this.label2.Location = new System.Drawing.Point(840, 15);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(33, 13);
			this.label2.TabIndex = 2;
			this.label2.Text = "From:";
			// 
			// dateFrom
			// 
			this.dateFrom.Format = System.Windows.Forms.DateTimePickerFormat.Short;
			this.dateFrom.Location = new System.Drawing.Point(874, 12);
			this.dateFrom.Name = "dateFrom";
			this.dateFrom.Size = new System.Drawing.Size(94, 20);
			this.dateFrom.TabIndex = 3;
			// 
			// dateTo
			// 
			this.dateTo.Format = System.Windows.Forms.DateTimePickerFormat.Short;
			this.dateTo.Location = new System.Drawing.Point(1002, 12);
			this.dateTo.Name = "dateTo";
			this.dateTo.Size = new System.Drawing.Size(94, 20);
			this.dateTo.TabIndex = 5;
			// 
			// label3
			// 
			this.label3.AutoSize = true;
			this.label3.Location = new System.Drawing.Point(978, 15);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(23, 13);
			this.label3.TabIndex = 4;
			this.label3.Text = "To:";
			// 
			// lvAppointments
			// 
			this.lvAppointments.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.chScheduled,
            this.chName,
            this.chPhone,
            this.chAddress,
            this.chDateTime});
			this.lvAppointments.FullRowSelect = true;
			this.lvAppointments.GridLines = true;
			this.lvAppointments.HideSelection = false;
			this.lvAppointments.Location = new System.Drawing.Point(16, 37);
			this.lvAppointments.Name = "lvAppointments";
			this.lvAppointments.Size = new System.Drawing.Size(1080, 309);
			this.lvAppointments.TabIndex = 6;
			this.lvAppointments.UseCompatibleStateImageBehavior = false;
			this.lvAppointments.View = System.Windows.Forms.View.Details;
			// 
			// chScheduled
			// 
			this.chScheduled.Text = "S";
			this.chScheduled.Width = 22;
			// 
			// chName
			// 
			this.chName.Text = "Name";
			this.chName.Width = 204;
			// 
			// chPhone
			// 
			this.chPhone.Text = "Phone";
			this.chPhone.Width = 100;
			// 
			// chAddress
			// 
			this.chAddress.Text = "Address";
			this.chAddress.Width = 600;
			// 
			// chDateTime
			// 
			this.chDateTime.Text = "Date/Time";
			this.chDateTime.Width = 150;
			// 
			// btnEdit
			// 
			this.btnEdit.Location = new System.Drawing.Point(15, 349);
			this.btnEdit.Name = "btnEdit";
			this.btnEdit.Size = new System.Drawing.Size(75, 23);
			this.btnEdit.TabIndex = 7;
			this.btnEdit.Text = "Edit";
			this.btnEdit.UseVisualStyleBackColor = true;
			this.btnEdit.Click += new System.EventHandler(this.btnEdit_Click);
			// 
			// btnDelete
			// 
			this.btnDelete.Location = new System.Drawing.Point(92, 349);
			this.btnDelete.Name = "btnDelete";
			this.btnDelete.Size = new System.Drawing.Size(75, 23);
			this.btnDelete.TabIndex = 8;
			this.btnDelete.Text = "Delete";
			this.btnDelete.UseVisualStyleBackColor = true;
			// 
			// btnMaps
			// 
			this.btnMaps.Location = new System.Drawing.Point(169, 349);
			this.btnMaps.Name = "btnMaps";
			this.btnMaps.Size = new System.Drawing.Size(75, 23);
			this.btnMaps.TabIndex = 9;
			this.btnMaps.Text = "Maps";
			this.btnMaps.UseVisualStyleBackColor = true;
			// 
			// groupBox1
			// 
			this.groupBox1.Controls.Add(this.dateTimePicker1);
			this.groupBox1.Controls.Add(this.btnSave);
			this.groupBox1.Controls.Add(this.checkScheduled);
			this.groupBox1.Controls.Add(this.dateScheduleTime);
			this.groupBox1.Controls.Add(this.dateScheduleDate);
			this.groupBox1.Controls.Add(this.label7);
			this.groupBox1.Controls.Add(this.tbAddress);
			this.groupBox1.Controls.Add(this.label6);
			this.groupBox1.Controls.Add(this.tbPhone);
			this.groupBox1.Controls.Add(this.label5);
			this.groupBox1.Controls.Add(this.tbName);
			this.groupBox1.Controls.Add(this.label4);
			this.groupBox1.Location = new System.Drawing.Point(16, 379);
			this.groupBox1.Name = "groupBox1";
			this.groupBox1.Size = new System.Drawing.Size(1080, 157);
			this.groupBox1.TabIndex = 10;
			this.groupBox1.TabStop = false;
			this.groupBox1.Text = "Add/Edit Appointment";
			// 
			// btnSave
			// 
			this.btnSave.Location = new System.Drawing.Point(8, 126);
			this.btnSave.Name = "btnSave";
			this.btnSave.Size = new System.Drawing.Size(75, 23);
			this.btnSave.TabIndex = 14;
			this.btnSave.Text = "Save";
			this.btnSave.UseVisualStyleBackColor = true;
			this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
			// 
			// checkScheduled
			// 
			this.checkScheduled.AutoSize = true;
			this.checkScheduled.Location = new System.Drawing.Point(272, 100);
			this.checkScheduled.Name = "checkScheduled";
			this.checkScheduled.Size = new System.Drawing.Size(116, 17);
			this.checkScheduled.TabIndex = 13;
			this.checkScheduled.Text = "Not Yet Scheduled";
			this.checkScheduled.UseVisualStyleBackColor = true;
			// 
			// dateScheduleTime
			// 
			this.dateScheduleTime.Format = System.Windows.Forms.DateTimePickerFormat.Time;
			this.dateScheduleTime.Location = new System.Drawing.Point(171, 98);
			this.dateScheduleTime.Name = "dateScheduleTime";
			this.dateScheduleTime.ShowUpDown = true;
			this.dateScheduleTime.Size = new System.Drawing.Size(94, 20);
			this.dateScheduleTime.TabIndex = 12;
			// 
			// dateScheduleDate
			// 
			this.dateScheduleDate.Format = System.Windows.Forms.DateTimePickerFormat.Short;
			this.dateScheduleDate.Location = new System.Drawing.Point(71, 98);
			this.dateScheduleDate.Name = "dateScheduleDate";
			this.dateScheduleDate.Size = new System.Drawing.Size(94, 20);
			this.dateScheduleDate.TabIndex = 11;
			// 
			// label7
			// 
			this.label7.AutoSize = true;
			this.label7.Location = new System.Drawing.Point(7, 100);
			this.label7.Name = "label7";
			this.label7.Size = new System.Drawing.Size(61, 13);
			this.label7.TabIndex = 6;
			this.label7.Text = "Date/Time:";
			// 
			// tbAddress
			// 
			this.tbAddress.Location = new System.Drawing.Point(71, 72);
			this.tbAddress.Name = "tbAddress";
			this.tbAddress.Size = new System.Drawing.Size(991, 20);
			this.tbAddress.TabIndex = 5;
			// 
			// label6
			// 
			this.label6.AutoSize = true;
			this.label6.Location = new System.Drawing.Point(7, 74);
			this.label6.Name = "label6";
			this.label6.Size = new System.Drawing.Size(48, 13);
			this.label6.TabIndex = 4;
			this.label6.Text = "Address:";
			// 
			// tbPhone
			// 
			this.tbPhone.Location = new System.Drawing.Point(71, 46);
			this.tbPhone.Name = "tbPhone";
			this.tbPhone.Size = new System.Drawing.Size(991, 20);
			this.tbPhone.TabIndex = 3;
			// 
			// label5
			// 
			this.label5.AutoSize = true;
			this.label5.Location = new System.Drawing.Point(7, 48);
			this.label5.Name = "label5";
			this.label5.Size = new System.Drawing.Size(41, 13);
			this.label5.TabIndex = 2;
			this.label5.Text = "Phone:";
			// 
			// tbName
			// 
			this.tbName.Location = new System.Drawing.Point(71, 20);
			this.tbName.Name = "tbName";
			this.tbName.Size = new System.Drawing.Size(991, 20);
			this.tbName.TabIndex = 1;
			// 
			// label4
			// 
			this.label4.AutoSize = true;
			this.label4.Location = new System.Drawing.Point(7, 22);
			this.label4.Name = "label4";
			this.label4.Size = new System.Drawing.Size(38, 13);
			this.label4.TabIndex = 0;
			this.label4.Text = "Name:";
			// 
			// dateTimePicker1
			// 
			this.dateTimePicker1.Location = new System.Drawing.Point(491, 112);
			this.dateTimePicker1.Name = "dateTimePicker1";
			this.dateTimePicker1.Size = new System.Drawing.Size(253, 20);
			this.dateTimePicker1.TabIndex = 15;
			// 
			// Form1
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(1113, 551);
			this.Controls.Add(this.groupBox1);
			this.Controls.Add(this.btnMaps);
			this.Controls.Add(this.btnDelete);
			this.Controls.Add(this.btnEdit);
			this.Controls.Add(this.lvAppointments);
			this.Controls.Add(this.dateTo);
			this.Controls.Add(this.label3);
			this.Controls.Add(this.dateFrom);
			this.Controls.Add(this.label2);
			this.Controls.Add(this.cbShow);
			this.Controls.Add(this.label1);
			this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
			this.Name = "Form1";
			this.Text = "Exam Scheduler";
			this.Load += new System.EventHandler(this.Form1_Load);
			this.groupBox1.ResumeLayout(false);
			this.groupBox1.PerformLayout();
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.ComboBox cbShow;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.DateTimePicker dateFrom;
		private System.Windows.Forms.DateTimePicker dateTo;
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.ListView lvAppointments;
		private System.Windows.Forms.Button btnEdit;
		private System.Windows.Forms.Button btnDelete;
		private System.Windows.Forms.Button btnMaps;
		private System.Windows.Forms.GroupBox groupBox1;
		private System.Windows.Forms.Button btnSave;
		private System.Windows.Forms.CheckBox checkScheduled;
		private System.Windows.Forms.DateTimePicker dateScheduleTime;
		private System.Windows.Forms.DateTimePicker dateScheduleDate;
		private System.Windows.Forms.Label label7;
		private System.Windows.Forms.TextBox tbAddress;
		private System.Windows.Forms.Label label6;
		private System.Windows.Forms.TextBox tbPhone;
		private System.Windows.Forms.Label label5;
		private System.Windows.Forms.TextBox tbName;
		private System.Windows.Forms.Label label4;
		private System.Windows.Forms.ColumnHeader chScheduled;
		private System.Windows.Forms.ColumnHeader chName;
		private System.Windows.Forms.ColumnHeader chPhone;
		private System.Windows.Forms.ColumnHeader chAddress;
		private System.Windows.Forms.ColumnHeader chDateTime;
		private System.Windows.Forms.DateTimePicker dateTimePicker1;
	}
}

