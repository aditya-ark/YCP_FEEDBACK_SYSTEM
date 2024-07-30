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
using MetroFramework.Controls;

namespace YCPFeedback
{
    public partial class CollegeFeedback : MetroForm
    {
        SqlConnection cn;
        SqlCommand cmd;
        SqlDataReader dr;

        string query = null;

        string[] facility = new string[15];

        bool[] status = new bool[15];

        const int ON = 1;
        const int OFF = 0;

        const short EXCELLENT = 11;
        const short VERYGOOD = 12;
        const short SATISFACTORY = 13;
        const short POOR = 14;

        public CollegeFeedback()
        {
            InitializeComponent();
        }

        private void CollegeFeedback_Load(object sender, EventArgs e)
        {
            updateDate();
            getFacilities();
        }

        private void getFacilities()
        {
            int i = 0;

            query = "select Facility, Status from FacilityMaster Order By FacilityNo ASC";

            cn = new SqlConnection(Logo.connection);

            try
            {
                cn.Open();
                cmd = new SqlCommand(query, cn);
            }
            catch (SqlException ex)
            {

            }

            dr = cmd.ExecuteReader();

            while (dr.Read())
            {
                facility[i] = dr[0].ToString();
                status[i] = Convert.ToBoolean(int.Parse(dr[1].ToString()));

                i++;
            }

            updateFacility();
            updatePanelEnabled();

            dr.Close();
            cn.Close();
        }

        private void updateFacility()
        {
            for (int i = 0; i < 15; i++)
            {
                Label lbl = (Label)(this.Controls.Find("lbl_facility" + (i + 1), true).FirstOrDefault());
                lbl.Text = (i + 1) + ". " + facility[i];
            }
        }

        private void updatePanelEnabled()
        {
            for (int i = 0; i < 15; i++)
            {
                if (status[i] == false)
                {
                    Panel pnl = (Panel)(this.Controls.Find("pnl_facility" + (i + 1), true).FirstOrDefault());
                    pnl.Enabled = false;
                }
            }
        }

        private void updatePanelFalse()
        {
            for (int i = 0; i < 15; i++)
            {
                Panel pnl = (Panel)(this.Controls.Find("pnl_facility" + (i + 1), true).FirstOrDefault());
                pnl.Enabled = false;
            }
        }

        private void updateDate()
        {
            lbl_date.Text = (DateTime.Now.ToString("dd/MM/yyyy"));
        }

        private void ms_collegefeedbacklogout_Click(object sender, EventArgs e)
        {
            HomePage frm_homepage = new HomePage();
            frm_homepage.Show();
            this.Hide();
        }

        private void btn_finish_Click(object sender, EventArgs e)
        {
            FinishPage frm_finishpage = new FinishPage();
            frm_finishpage.Show();
            this.Hide();
        }

        private void CollegeFeedback_FormClosing(object sender, FormClosingEventArgs e)
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

        private void btn_submit_Click(object sender, EventArgs e)
        {
            if (checkRadioButtonStatus() == 1)
            {
                MetroMessageBox.Show(Owner, "Please Submit All Answers.", "YCPFeedback", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                updateFeedbackStatus();
                updateStudentStatus();

                for (int i = 1; i < 16; i++)
                {
                    Panel pnl = (Panel)(this.Controls.Find("pnl_facility" + i, true).FirstOrDefault());

                    Label lbl = (Label)(this.Controls.Find("lbl_facility" + i, true).FirstOrDefault());

                    MetroRadioButton rbte = (MetroRadioButton)(this.Controls.Find("rbt_e" + i, true).FirstOrDefault());
                    MetroRadioButton rbtv = (MetroRadioButton)(this.Controls.Find("rbt_v" + i, true).FirstOrDefault());
                    MetroRadioButton rbts = (MetroRadioButton)(this.Controls.Find("rbt_s" + i, true).FirstOrDefault());
                    MetroRadioButton rbtp = (MetroRadioButton)(this.Controls.Find("rbt_p" + i, true).FirstOrDefault());

                    if (pnl.Enabled == true)
                    {
                        int len = ((i.ToString()).Count()); 

                        int value = checkRadioButton(rbte, rbtv, rbts, rbtp);
                        updateToCollegeMarksDB(lbl.Text.Substring(len + 2), value);
                    }
                }

                if (txt_suggestion.Text != string.Empty)
                {
                    updateSuggestionToDB(txt_suggestion.Text);
                }

                lbl_ratinginfo.Focus();
                txt_suggestion.Text = string.Empty;
                txt_suggestion.Enabled = false;
                btn_submit.Enabled = false;
                btn_finish.Enabled = true;
                ms_collegefeedbacklogout.Enabled = true;

                updatePanelFalse();

                MetroMessageBox.Show(Owner, "Saved Successfully.", "YCPFeedback", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void updateFeedbackStatus()
        {
            query = "update FeedbackStatus set CollegeStatus = '" + ON + "' where DepartmentCode = '" + HomePage.deptcode + "' and Semester = '" + HomePage.studsem + "' and CollegeStatus = '" + OFF + "'";

            cn = new SqlConnection(Logo.connection);

            try
            {
                cn.Open();
                cmd = new SqlCommand(query, cn);
            }
            catch (SqlException se)
            {

            }

            cmd.ExecuteNonQuery();

            cn.Close();
        }

        private int checkRadioButtonStatus()
        {
            for (int i = 1; i < 16; i++)
            { 
                Panel pnl = (Panel)(this.Controls.Find("pnl_facility" + i, true).FirstOrDefault());
                
                MetroRadioButton rbte = (MetroRadioButton)(this.Controls.Find("rbt_e" + i, true).FirstOrDefault());
                MetroRadioButton rbtv = (MetroRadioButton)(this.Controls.Find("rbt_v" + i, true).FirstOrDefault());
                MetroRadioButton rbts = (MetroRadioButton)(this.Controls.Find("rbt_s" + i, true).FirstOrDefault());
                MetroRadioButton rbtp = (MetroRadioButton)(this.Controls.Find("rbt_p" + i, true).FirstOrDefault());

                if (pnl.Enabled == true && (!rbte.Checked && !rbtv.Checked && !rbts.Checked && !rbtp.Checked))
                {
                    return (1);
                }
            }

            return (0);
        }

        private int checkRadioButton(System.Windows.Forms.RadioButton rb1, System.Windows.Forms.RadioButton rb2, System.Windows.Forms.RadioButton rb3, System.Windows.Forms.RadioButton rb4)
        {
            if (rb1.Checked == true)
                return (EXCELLENT);
            else if (rb2.Checked == true)
                return (VERYGOOD);
            else if (rb3.Checked == true)
                return (SATISFACTORY);
            else if (rb4.Checked == true)
                return (POOR);

            return (0);
        }

        private void updateToCollegeMarksDB(string facility, int value)
        {
            query = "insert into CollegeMarks(DepartmentCode,Semester,Facility,Impression,FeedbackDate,Status) values(@departmentcode,@semester,@facility,@impression,@feedbackdate,@status)";

            cn = new SqlConnection(Logo.connection);

            try
            {
                cn.Open();
                cmd = new SqlCommand(query, cn);

                cmd.Parameters.AddWithValue("@departmentcode", HomePage.deptcode);
                cmd.Parameters.AddWithValue("@semester", int.Parse(HomePage.studsem));
                cmd.Parameters.AddWithValue("@facility", facility);
                cmd.Parameters.AddWithValue("@impression", value);
                cmd.Parameters.AddWithValue("@feedbackdate", DateTime.Now.ToString("dd/MM/yyyy"));
                cmd.Parameters.AddWithValue("@status", ON);
            }
            catch (SqlException se)
            {

            }

            cmd.ExecuteNonQuery();

            cn.Close();
        }

        private void updateSuggestionToDB(string suggestion)
        {
            query = "insert into CollegeSuggestion(DepartmentCode,Semester,Suggestion,FeedbackDate,Status) values(@departmentcode,@semester,@suggestion,@feedbackdate,@status)";

            cn = new SqlConnection(Logo.connection);

            try
            {
                cn.Open();
                cmd = new SqlCommand(query, cn);

                cmd.Parameters.AddWithValue("@departmentcode", HomePage.deptcode);
                cmd.Parameters.AddWithValue("@semester", int.Parse(HomePage.studsem));
                cmd.Parameters.AddWithValue("@suggestion", suggestion);
                cmd.Parameters.AddWithValue("@feedbackdate", DateTime.Now.ToString("dd/MM/yyyy"));
                cmd.Parameters.AddWithValue("@status", ON);
            }
            catch (SqlException se)
            {

            }

            cmd.ExecuteNonQuery();

            cn.Close();
        }

        private void updateStudentStatus()
        {
            query = "update StudentMaster set Status = '" + OFF + "' where Username = '" + HomePage.studenr + "'";

            cn = new SqlConnection(Logo.connection);

            try
            {
                cn.Open();
                cmd = new SqlCommand(query, cn);
            }
            catch (SqlException se)
            {

            }

            cmd.ExecuteNonQuery();

            cn.Close();
        }
    }
}