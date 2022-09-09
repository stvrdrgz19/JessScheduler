
namespace JessScheduler
{
    partial class VarianceForm
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
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.label1 = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.lvVariances = new System.Windows.Forms.ListView();
            this.chProperty = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.chOriginalValue = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.chNewValue = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.btnYes = new System.Windows.Forms.Button();
            this.btnNo = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // pictureBox1
            // 
            this.pictureBox1.ImageLocation = "C:\\Users\\steve.rodriguez\\source\\repos\\EnvironmentManager4\\EnvironmentManager4\\Fil" +
    "es\\Icons\\ico24.ico";
            this.pictureBox1.Location = new System.Drawing.Point(13, 13);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(40, 40);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(120, 27);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(386, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Are you sure you want to update the existing appointment using the new values?";
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.White;
            this.panel1.Controls.Add(this.lvVariances);
            this.panel1.Location = new System.Drawing.Point(-5, 63);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(643, 208);
            this.panel1.TabIndex = 2;
            // 
            // lvVariances
            // 
            this.lvVariances.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.chProperty,
            this.chOriginalValue,
            this.chNewValue});
            this.lvVariances.FullRowSelect = true;
            this.lvVariances.GridLines = true;
            this.lvVariances.HideSelection = false;
            this.lvVariances.Location = new System.Drawing.Point(18, 17);
            this.lvVariances.Name = "lvVariances";
            this.lvVariances.Size = new System.Drawing.Size(605, 173);
            this.lvVariances.TabIndex = 0;
            this.lvVariances.UseCompatibleStateImageBehavior = false;
            this.lvVariances.View = System.Windows.Forms.View.Details;
            // 
            // chProperty
            // 
            this.chProperty.Text = "Property";
            this.chProperty.Width = 100;
            // 
            // chOriginalValue
            // 
            this.chOriginalValue.Text = "Original Value";
            this.chOriginalValue.Width = 250;
            // 
            // chNewValue
            // 
            this.chNewValue.Text = "New Value";
            this.chNewValue.Width = 250;
            // 
            // btnYes
            // 
            this.btnYes.Location = new System.Drawing.Point(462, 280);
            this.btnYes.Name = "btnYes";
            this.btnYes.Size = new System.Drawing.Size(75, 23);
            this.btnYes.TabIndex = 3;
            this.btnYes.Text = "Yes";
            this.btnYes.UseVisualStyleBackColor = true;
            this.btnYes.Click += new System.EventHandler(this.btnYes_Click);
            // 
            // btnNo
            // 
            this.btnNo.Location = new System.Drawing.Point(543, 280);
            this.btnNo.Name = "btnNo";
            this.btnNo.Size = new System.Drawing.Size(75, 23);
            this.btnNo.TabIndex = 4;
            this.btnNo.Text = "No";
            this.btnNo.UseVisualStyleBackColor = true;
            this.btnNo.Click += new System.EventHandler(this.btnNo_Click);
            // 
            // VarianceForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(630, 310);
            this.Controls.Add(this.btnNo);
            this.Controls.Add(this.btnYes);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.pictureBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "VarianceForm";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "CONFIRM";
            this.TopMost = true;
            this.Load += new System.EventHandler(this.VarianceForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.panel1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.ListView lvVariances;
        private System.Windows.Forms.ColumnHeader chProperty;
        private System.Windows.Forms.ColumnHeader chOriginalValue;
        private System.Windows.Forms.ColumnHeader chNewValue;
        private System.Windows.Forms.Button btnYes;
        private System.Windows.Forms.Button btnNo;
    }
}