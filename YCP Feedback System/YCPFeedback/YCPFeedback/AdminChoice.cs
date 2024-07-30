using MetroFramework;
using MetroFramework.Forms;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace YCPFeedback
{
    public partial class AdminChoice : MetroForm
    {
        SqlConnection cn;
        SqlCommand cmd;
        SqlDataReader dr;

        const int ON = 1;
        const int OFF = 0;

        string query = null;

        public AdminChoice()
        {
            InitializeComponent();
        }

        private void AdminChoice_Load(object sender, EventArgs e)
        {
            lbl_date.Focus();
            updateDate();
            updateLocking();

            ttp_studentdata.SetToolTip(lnk_studentdata, "Uploads or Deletes Student Data");
            ttp_facultydata.SetToolTip(lnk_staffupload, "Uploads or Deletes Faculty Data");
            ttp_question.SetToolTip(lnk_question, "Enable or Disable Staff Feedback Question");
            ttp_facilities.SetToolTip(lnk_facilities, "Enable or Disable College Feedback Facilities");
            ttp_reports.SetToolTip(lnk_reports, "View Feedback Reports");
            ttp_schedule.SetToolTip(lnk_feedbackschedule, "Enable or Disable Feedback Schedule");
            ttp_changepassword.SetToolTip(lnk_changepassword, "Change Existing Password of Administrator");
        }

        private void updateLocking()
        {
            query = "select Semester from DepartmentStatus where Status = '" + ON + "'";

            cn = new SqlConnection(Logo.connection);

            try
            { 
                cn.Open();
                cmd = new SqlCommand(query,cn);
            }
            catch(SqlException se)
            {
            
            }

            dr = cmd.ExecuteReader();

            if (dr.Read())
            {
                updateEnable(false);
            }
            else
            {
                updateEnable(true);
            }

            cn.Close();
            dr.Close();
        }

        private void updateDate()
        {
            lbl_date.Text = (DateTime.Now.ToString("dd/MM/yyyy"));
        }

        private void ms_adminchoicelogout_Click(object sender, EventArgs e)
        {
            HomePage frm_homepage = new HomePage();
            frm_homepage.Show();
            this.Hide();
        }

        private void lnk_studentdata_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            StudentDataUpload frm_studentdataupload = new StudentDataUpload();
            frm_studentdataupload.Show();
            this.Hide();
        }

        private void lnk_staffupload_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            StaffDataUpload frm_staffdataupload = new StaffDataUpload();
            frm_staffdataupload.Show();
            this.Hide();
        }

        private void lnk_question_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Questions frm_questions = new Questions();
            frm_questions.Show();
            this.Hide();
        }

        private void lnk_facilities_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Facilities frm_facilities = new Facilities();
            frm_facilities.Show();
            this.Hide();
        }

        private void lnk_changepassword_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            ChangePassword frm_changepassword = new ChangePassword();
            frm_changepassword.Show();
            this.Hide();
        }

        private void AdminChoice_FormClosing(object sender, FormClosingEventArgs e)
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

        private void lnk_feedbackschedule_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            FeedbackSchedule frm_feedbackschedule = new FeedbackSchedule();
            frm_feedbackschedule.Show();
            this.Hide();
        }

        private void lnk_reports_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Reports frm_reports = new Reports();
            frm_reports.Show();
            this.Hide();
        }

        private void updateEnable(bool status)
        {
            if (status == true)
            {
                lnk_question.Enabled = true;
                lnk_facilities.Enabled = true;
                lnk_studentdata.Enabled = true;
                lnk_staffupload.Enabled = true;
            }
            else
            {
                lnk_question.Enabled = false;
                lnk_facilities.Enabled = false;
                lnk_studentdata.Enabled = false;
                lnk_staffupload.Enabled = false;
            }
        }
    }
}
