using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using MetroFramework.Forms;
using MetroFramework;

namespace YCPFeedback
{
    public partial class StudentBatch : MetroForm
    {
        public static int batch = 0;

        public StudentBatch()
        {
            InitializeComponent();
        }

        private void StudentBatch_Load(object sender, EventArgs e)
        {

        }

        private void StudentBatch_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (batch == 0)
            {
                if (MetroMessageBox.Show(Owner, "Please Select the Batch.", "YCPFeedback", MessageBoxButtons.OK, MessageBoxIcon.Error) == DialogResult.OK)
                {
                    e.Cancel = true;
                }
            }
        }

        private void ddl_selectbatch_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (MetroMessageBox.Show(Owner, "Batch " + ddl_selectbatch.SelectedItem.ToString() + " is selected.Do you want to Proceed?", "YCPFeedback", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                batch = int.Parse(ddl_selectbatch.SelectedItem.ToString());

                StaffFeedback frm_stafffeedback = new StaffFeedback();
                this.Hide();
                frm_stafffeedback.Show();
            }
            else
            {
                    
            }
        }
    }
}
