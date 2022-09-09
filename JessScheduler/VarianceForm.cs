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
    public partial class VarianceForm : Form
    {
        public VarianceForm()
        {
            InitializeComponent();
        }

        public List<Variance> variances = new List<Variance>();

        private void VarianceForm_Load(object sender, EventArgs e)
        {
            foreach (Variance variance in variances)
            {
                ListViewItem item = new ListViewItem(variance.PropertyName);
                item.SubItems.Add(variance.valA.ToString());
                item.SubItems.Add(variance.valB.ToString());
                lvVariances.Items.Add(item);
            }
            return;
        }

        private void btnYes_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Yes;
            this.Close();
            return;
        }

        private void btnNo_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.No;
            this.Close();
            return;
        }
    }
}
