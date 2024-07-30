using MetroFramework;
using MetroFramework.Forms;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace YCPFeedback
{
    public partial class StudentInfo : MetroForm
    {
        SqlConnection cn;
        SqlCommand cmd;
        SqlDataReader dr;

        string query = null;

        const int ON = 1;
        const int OFF = 0;

        public StudentInfo()
        {
            InitializeComponent();
        }

        private void StudentInfo_Load(object sender, EventArgs e)
        {
            updateStudentInfo();
            updateDate();
        }

        private void updateStudentInfo()
        {
            query = "select DepartmentName from DepartmentMaster where DepartmentCode = '" + HomePage.deptcode + "' and Status = '" + ON + "'";

            cn = new SqlConnection(Logo.connection);

            try
            {
                cn.Open();
                cmd = new SqlCommand(query, cn);
            }
            catch (Exception e)
            {

            }

            dr = cmd.ExecuteReader();

            if (dr.Read())
            {
                lbl_studname.Text = HomePage.studname;
                lbl_studenr.Text = HomePage.studenr;
                lbl_studdept.Text = dr[0].ToString();
                lbl_studsem.Text = HomePage.studsem;    
            }

            cn.Close();
            dr.Close();
        }

        private void updateDate()
        {
            lbl_date.Text = (DateTime.Now.ToString("dd/MM/yyyy"));
        }

        private void btn_proceed_Click(object sender, EventArgs e)
        {
            //StaffFeedback frm_stafffeedback = new StaffFeedback();
            //frm_stafffeedback.Show();
            //this.Hide();

            StudentBatch frm_studentbatch = new StudentBatch();
            frm_studentbatch.ShowDialog();
            this.Hide();
        }

        private void ms_studentlogout_Click(object sender, EventArgs e)
        {
            HomePage frm_homepage = new HomePage();
            frm_homepage.Show();
            this.Hide();
        }

        private void StudentInfo_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (MetroMessageBox.Show(Owner, "Do you want to Exit?", "YCPFeedback", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                Taskbar.Show();
                Environment.Exit(0);
            }
            else
            {
                e.Cancel = true;
            }
        }
    }
}
