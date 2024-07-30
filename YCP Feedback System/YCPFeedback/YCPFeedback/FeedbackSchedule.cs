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
using System.Data.SqlClient;
using MetroFramework.Controls;

namespace YCPFeedback
{
    public partial class FeedbackSchedule : MetroForm
    {
        SqlConnection cn;
        SqlCommand cmd;
        SqlDataReader dr;
        SqlDataReader dr1;
        SqlDataReader dr2;

        string query = null, faculty = null, subjectname = null;

        bool[] status = new bool[21];
        bool[] updatestatus = new bool[21];
        
        bool Flag = false;

        int newsum = 0, newcount = 0, tempi = 0;

        short[] studcount = new short[21];

        const int ON = 1;
        const int OFF = 0;

        const short RATING = 5;

        const short PMIN = 0;
        const short PMAX = 20;
        const short SMIN = 21;
        const short SMAX = 50;
        const short VMIN = 51;
        const short VMAX = 80;
        const short EMIN = 81;
        const short EMAX = 100;

        const short EXCELLENT = 11;
        const short VERYGOOD = 12;
        const short SATISFACTORY = 13;
        const short POOR = 14;

        public FeedbackSchedule()
        {
            InitializeComponent();
        }

        private void FeedbackSchedule_Load(object sender, EventArgs e)
        {
            int value;

            updateDate();
            getStatusList();

            string[] deptcode = new string[7];
            deptcode[0] = "CE";
            deptcode[1] = "CW";
            deptcode[2] = "EG";
            deptcode[3] = "EJA";
            deptcode[4] = "EJB";
            deptcode[5] = "MEA";
            deptcode[6] = "MEB";

            if(getSemesterDate() == true)
                value = 1;
            else
                value = 2;

            for (int i = 0; i < 7; i++)
            {
                for (int j = value; j < 7; j = j + 2)
                {
                    getStudentCount(deptcode[i], j);
                }
            }
                
            updateStudentCount();
        }

        private void getStudentCount(string deptcode, int sem)
        {
            query = "select Count(*) from StudentMaster where DepartmentCode = '" + deptcode + "' and StudSemester = '" + sem + "' and Status = '" + OFF + "'";

            cn = new SqlConnection(Logo.connection);

            try
            {
                cn.Open();
                cmd = new SqlCommand(query, cn);
            }
            catch (SqlException se)
            { 
                
            }

            dr = cmd.ExecuteReader();

            studcount[tempi] = 0;

            if(dr.Read())
            {
                studcount[tempi] = short.Parse(dr[0].ToString());
            }

                tempi++;
            
            dr.Close();
            cn.Close();
        }

        private void updateStudentCount()
        {
            for(int i = 0; i < 21; i++)
            {
                Label lbl = (Label)(this.Controls.Find("lbl_count" + (i + 1), true).FirstOrDefault());
                lbl.Text = studcount[i].ToString();
            }
        }

        private void getStatusList()
        {
            query = "select DepartmentCode, Semester, Status from DepartmentStatus Order By DepartmentCode ASC";

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

            if (getSemesterDate() == true)
                Flag = true;
            else
                Flag = false;

            while (dr.Read())
            {
                string deptcode = dr[0].ToString();
                short sem = short.Parse(dr[1].ToString());
                bool status = Convert.ToBoolean(int.Parse((dr[2].ToString())));

                if (Flag == true)
                    updateStatusOdd(deptcode, sem, status);
                else
                    updateStatusEven(deptcode, sem, status);
            }

            dr.Close();
            cn.Close();
        }

        private void updateStatusOdd(string deptcode, short sem, bool status)
        {
            if (deptcode.Equals("CE") && (sem == 1))
                tgl_civil1.Checked = status;
            else if (deptcode.Equals("CE") && (sem == 3))
                tgl_civil2.Checked = status;
            else if (deptcode.Equals("CE") && (sem == 5))
                tgl_civil3.Checked = status;
            else if (deptcode.Equals("CW") && (sem == 1))
                tgl_computer1.Checked = status;
            else if (deptcode.Equals("CW") && (sem == 3))
                tgl_computer2.Checked = status;
            else if (deptcode.Equals("CW") && (sem == 5))
                tgl_computer3.Checked = status;
            else if (deptcode.Equals("EG") && (sem == 1))
                tgl_electrical1.Checked = status;
            else if (deptcode.Equals("EG") && (sem == 3))
                tgl_electrical2.Checked = status;
            else if (deptcode.Equals("EG") && (sem == 5))
                tgl_electrical3.Checked = status;
            else if (deptcode.Equals("EJA") && (sem == 1))
                tgl_electronicsa1.Checked = status;
            else if (deptcode.Equals("EJA") && (sem == 3))
                tgl_electronicsa2.Checked = status;
            else if (deptcode.Equals("EJA") && (sem == 5))
                tgl_electronicsa3.Checked = status;
            else if (deptcode.Equals("EJB") && (sem == 1))
                tgl_electronicsb1.Checked = status;
            else if (deptcode.Equals("EJB") && (sem == 3))
                tgl_electronicsb2.Checked = status;
            else if (deptcode.Equals("EJB") && (sem == 5))
                tgl_electronicsb3.Checked = status;
            else if (deptcode.Equals("MEA") && (sem == 1))
                tgl_mechanicala1.Checked = status;
            else if (deptcode.Equals("MEA") && (sem == 3))
                tgl_mechanicala2.Checked = status;
            else if (deptcode.Equals("MEA") && (sem == 5))
                tgl_mechanicala3.Checked = status;
            else if (deptcode.Equals("MEB") && (sem == 1))
                tgl_mechanicalb1.Checked = status;
            else if (deptcode.Equals("MEB") && (sem == 3))
                tgl_mechanicalb2.Checked = status;
            else if (deptcode.Equals("MEB") && (sem == 5))
                tgl_mechanicalb3.Checked = status;
        }

        private void updateStatusEven(string deptcode, int sem, bool status)
        {
            if (deptcode.Equals("CE") && (sem == 2))
                tgl_civil1.Checked = status;
            else if (deptcode.Equals("CE") && (sem == 4))
                tgl_civil2.Checked = status;
            else if (deptcode.Equals("CE") && (sem == 6))
                tgl_civil3.Checked = status;
            else if (deptcode.Equals("CW") && (sem == 2))
                tgl_computer1.Checked = status;
            else if (deptcode.Equals("CW") && (sem == 4))
                tgl_computer2.Checked = status;
            else if (deptcode.Equals("CW") && (sem == 6))
                tgl_computer3.Checked = status;
            else if (deptcode.Equals("EG") && (sem == 2))
                tgl_electrical1.Checked = status;
            else if (deptcode.Equals("EG") && (sem == 4))
                tgl_electrical2.Checked = status;
            else if (deptcode.Equals("EG") && (sem == 6))
                tgl_electrical3.Checked = status;
            else if (deptcode.Equals("EJA") && (sem == 2))
                tgl_electronicsa1.Checked = status;
            else if (deptcode.Equals("EJA") && (sem == 4))
                tgl_electronicsa2.Checked = status;
            else if (deptcode.Equals("EJA") && (sem == 6))
                tgl_electronicsa3.Checked = status;
            else if (deptcode.Equals("EJB") && (sem == 2))
                tgl_electronicsb1.Checked = status;
            else if (deptcode.Equals("EJB") && (sem == 4))
                tgl_electronicsb2.Checked = status;
            else if (deptcode.Equals("EJB") && (sem == 6))
                tgl_electronicsb3.Checked = status;
            else if (deptcode.Equals("MEA") && (sem == 2))
                tgl_mechanicala1.Checked = status;
            else if (deptcode.Equals("MEA") && (sem == 4))
                tgl_mechanicala2.Checked = status;
            else if (deptcode.Equals("MEA") && (sem == 6))
                tgl_mechanicala3.Checked = status;
            else if (deptcode.Equals("MEB") && (sem == 2))
                tgl_mechanicalb1.Checked = status;
            else if (deptcode.Equals("MEB") && (sem == 4))
                tgl_mechanicalb2.Checked = status;
            else if (deptcode.Equals("MEB") && (sem == 6))
                tgl_mechanicalb3.Checked = status;
        }

        private void updateDate()
        {
            lbl_date.Text = (DateTime.Now.ToString("dd/MM/yyyy"));
        }

        private void ms_feedbackschedulelogout_Click(object sender, EventArgs e)
        {
            HomePage frm_homepage = new HomePage();
            frm_homepage.Show();
            this.Hide();
        }

        private void FeedbackSchedule_FormClosing(object sender, FormClosingEventArgs e)
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

        private void btn_previous_Click(object sender, EventArgs e)
        {
            AdminChoice frm_adminchoice = new AdminChoice();
            frm_adminchoice.Show();
            this.Hide();
        }

        private void btn_save_Click(object sender, EventArgs e)
        {
            DialogResult dialogresult = MetroMessageBox.Show(Owner, "Do you want save changes?", "YCPFeedback", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (dialogresult == DialogResult.Yes)
            {
                int i, j;
                getStatus();

                if (getSemesterDate() == true)
                    Flag = true;
                else
                    Flag = false;

                toggleUpdate();

                    for (i = 1, j = 0; i < 43; i = i + 2, j++)
                    {
                        if (Flag == true)
                            updateStatusToDB(i, status[j]);
                        else
                            updateStatusToDB(i + 1, status[j]);
                    }

                lbl_questioninfo.Focus();

                FeedbackSchedule frm_feedback = new FeedbackSchedule();
                frm_feedback.Show();
                this.Hide();

                MetroMessageBox.Show(Owner, "Schedule Successfully Saved.", "YCPFeedback", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                FeedbackSchedule frm_feedback = new FeedbackSchedule();
                frm_feedback.Show();
                this.Hide();
            }
        }

        private void updateStatusToDB(int id, bool st)
        {
            query = "update DepartmentStatus set Status = '" + Convert.ToInt32(st) + "' where Id = '" + id + "'";

            cn = new SqlConnection(Logo.connection);

            try
            {
                cn.Open();
                cmd = new SqlCommand(query, cn);
            }
            catch (SqlException ex)
            {

            }

            cmd.ExecuteNonQuery();

            cn.Close();
        }

        private void getStatus()
        {
            int i = 0, j = 0;

            for (i = 0, j = 1; i < 3; i++, j++)
            { 
                MetroToggle tgl = (MetroToggle)(this.Controls.Find("tgl_civil" + j, true).FirstOrDefault());
                status[i] = Convert.ToBoolean(tgl.CheckState);
            }

            for (i = 3, j = 1; i < 6; i++, j++)
            {
                MetroToggle tgl = (MetroToggle)(this.Controls.Find("tgl_computer" + j, true).FirstOrDefault());
                status[i] = Convert.ToBoolean(tgl.CheckState);
            }

            for (i = 6, j = 1; i < 9; i++, j++)
            {
                MetroToggle tgl = (MetroToggle)(this.Controls.Find("tgl_electrical" + j, true).FirstOrDefault());
                status[i] = Convert.ToBoolean(tgl.CheckState);
            }

            for (i = 9, j = 1; i < 12; i++, j++)
            {
                MetroToggle tgl = (MetroToggle)(this.Controls.Find("tgl_electronicsa" + j, true).FirstOrDefault());
                status[i] = Convert.ToBoolean(tgl.CheckState);
            }

            for (i = 12, j = 1; i < 15; i++, j++)
            {
                MetroToggle tgl = (MetroToggle)(this.Controls.Find("tgl_electronicsb" + j, true).FirstOrDefault());
                status[i] = Convert.ToBoolean(tgl.CheckState);
            }

            for (i = 15, j = 1; i < 18; i++,j++)
            {
                MetroToggle tgl = (MetroToggle)(this.Controls.Find("tgl_mechanicala" + j, true).FirstOrDefault());
                status[i] = Convert.ToBoolean(tgl.CheckState);
            }

            for (i = 18, j = 1; i < 21; i++, j++)
            {
                MetroToggle tgl = (MetroToggle)(this.Controls.Find("tgl_mechanicalb" + j, true).FirstOrDefault());
                status[i] = Convert.ToBoolean(tgl.CheckState);
            }
        }
        private void tgl_civil1_CheckedChanged(object sender, EventArgs e)
        {
            if (tgl_civil1.CheckState == 0)
            {
                updatestatus[0] = true;
            }
            else
            {
                updatestatus[0] = false;
            }
        }

        private void clearQuestion(string deptcode, short sem)
        {
            query = "delete from QuestionStatus where DepartmentCode = '" + deptcode + "' and Semester = '" + sem + "'";

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

        private void getQuestion(string deptcode, short sem)
        {
            query = "select Question from QuestionMaster where Status = '" + ON + "'";

            cn = new SqlConnection(Logo.connection);

            try
            {
                cn.Open();
                cmd = new SqlCommand(query, cn);
            }
            catch (SqlException se)
            { 
                
            }

            dr = cmd.ExecuteReader();

            while (dr.Read())
            {
                string question = dr[0].ToString();
                bool status = true;

                updateQuestionTable(question,deptcode,sem,status);
            }

            dr.Close();
            cn.Close();
        }

        private void updateQuestionTable(string question,string deptcode,short sem,bool status)
        {
            query = "insert into QuestionStatus (Question,DepartmentCode,Semester,Status) values (@question,@deptcode,@sem,@status)";

            cn = new SqlConnection(Logo.connection);

            try
            {
                cn.Open();
                cmd = new SqlCommand(query, cn);
            }
            catch
            { 
                
            }

            cmd.Parameters.AddWithValue("@question", question);
            cmd.Parameters.AddWithValue("@deptcode", deptcode);
            cmd.Parameters.AddWithValue("@sem", sem);
            cmd.Parameters.AddWithValue("@status", Convert.ToInt32(status));

            cmd.ExecuteNonQuery();

            cn.Close();
        }

        private bool getSemesterDate()
        {
            string currentyear = DateTime.Now.Year.ToString();
            DateTime startvalue = new DateTime(int.Parse(currentyear), 06, 01);
            DateTime endvalue = new DateTime(int.Parse(currentyear), 11, 01);

            if (DateTime.Now > startvalue && DateTime.Now < endvalue)
            {
                return (true);
            }
            else
            {
                return (false);
            }
        }

        private void tgl_civil2_CheckedChanged(object sender, EventArgs e)
        {
            if (tgl_civil2.CheckState == 0)
            {
                updatestatus[1] = true;
            }
            else
            {
                updatestatus[1] = false;
            }
        }

        private void tgl_civil3_CheckedChanged(object sender, EventArgs e)
        {
            if (tgl_civil3.CheckState == 0)
            {
                updatestatus[2] = true;
            }
            else
            {
                updatestatus[2] = false;
            }
        }

        private void tgl_computer1_CheckedChanged(object sender, EventArgs e)
        {
            if (tgl_computer1.CheckState == 0)
            {
                updatestatus[3] = true;
            }
            else
            {
                updatestatus[3] = false;
            }
        }

        private void tgl_computer2_CheckedChanged(object sender, EventArgs e)
        {
            if (tgl_computer2.CheckState == 0)
            {
                updatestatus[4] = true;
            }
            else
            {
                updatestatus[4] = false;
            }
        }

        private void tgl_computer3_CheckedChanged(object sender, EventArgs e)
        {
            if (tgl_computer3.CheckState == 0)
            {
                updatestatus[5] = true;
            }
            else
            {
                updatestatus[5] = false;
            }
        }

        private void tgl_electrical1_CheckedChanged(object sender, EventArgs e)
        {
            if (tgl_electrical1.CheckState == 0)
            {
                updatestatus[6] = true;
            }
            else
            {
                updatestatus[6] = false;
            }
        }

        private void tgl_electrical2_CheckedChanged(object sender, EventArgs e)
        {
            if (tgl_electrical2.CheckState == 0)
            {
                updatestatus[7] = true;
            }
            else
            {
                updatestatus[7] = false;
            }
        }

        private void tgl_electrical3_CheckedChanged(object sender, EventArgs e)
        {
            if (tgl_electrical3.CheckState == 0)
            {
                updatestatus[8] = true;
            }
            else
            {
                updatestatus[8] = false;
            }
        }

        private void tgl_electronicsa1_CheckedChanged(object sender, EventArgs e)
        {
            if (tgl_electronicsa1.CheckState == 0)
            {
                updatestatus[9] = true;
            }
            else
            {
                updatestatus[9] = false;
            }
        }

        private void tgl_electronicsa2_CheckedChanged(object sender, EventArgs e)
        {
            if (tgl_electronicsa2.CheckState == 0)
            {
                updatestatus[10] = true;
            }
            else
            {
                updatestatus[10] = false;
            }
        }

        private void tgl_electronicsa3_CheckedChanged(object sender, EventArgs e)
        {
            if (tgl_electronicsa3.CheckState == 0)
            {
                updatestatus[11] = true;
            }
            else
            {
                updatestatus[11] = false;
            }
        }

        private void tgl_electronicsb1_CheckedChanged(object sender, EventArgs e)
        {
            if (tgl_electronicsb1.CheckState == 0)
            {
                updatestatus[12] = true;
            }
            else
            {
                updatestatus[12] = false;
            }
        }

        private void tgl_electronicsb2_CheckedChanged(object sender, EventArgs e)
        {
            if (tgl_electronicsb2.CheckState == 0)
            {
                updatestatus[13] = true;
            }
            else
            {
                updatestatus[13] = false;
            }
        }

        private void tgl_electronicsb3_CheckedChanged(object sender, EventArgs e)
        {
            if (tgl_electronicsb3.CheckState == 0)
            {
                updatestatus[14] = true;
            }
            else
            {
                updatestatus[14] = false;
            }
        }

        private void tgl_mechanicala1_CheckedChanged(object sender, EventArgs e)
        {
            if (tgl_mechanicala1.CheckState == 0)
            {
                updatestatus[15] = true;
            }
            else
            {
                updatestatus[15] = false;
            }
        }

        private void tgl_mechanicala2_CheckedChanged(object sender, EventArgs e)
        {
            if (tgl_mechanicala2.CheckState == 0)
            {
                updatestatus[16] = true;
            }
            else
            {
                updatestatus[16] = false;
            }
        }

        private void tgl_mechanicala3_CheckedChanged(object sender, EventArgs e)
        {
            if (tgl_mechanicala3.CheckState == 0)
            {
                updatestatus[17] = true;
            }
            else
            {
                updatestatus[17] = false;
            }
        }

        private void tgl_mechanicalb1_CheckedChanged(object sender, EventArgs e)
        {
            if (tgl_mechanicalb1.CheckState == 0)
            {
                updatestatus[18] = true;
            }
            else
            {
                updatestatus[18] = false;
            }
        }

        private void tgl_mechanicalb2_CheckedChanged(object sender, EventArgs e)
        {
            if (tgl_mechanicalb2.CheckState == 0)
            {
                updatestatus[19] = true;
            }
            else
            {
                updatestatus[19] = false;
            }
        }

        private void tgl_mechanicalb3_CheckedChanged(object sender, EventArgs e)
        {
            if (tgl_mechanicalb3.CheckState == 0)
            {
                updatestatus[20] = true;
            }
            else
            {
                updatestatus[20] = false;
            }
        }

        private void updateDateToDB(string deptcode, short sem)
        {
            query = "select FeedbackDate from DateMaster where DepartmentCode = '" + deptcode + "' and Semester = '" + sem + "' and FeedbackDate = '" + DateTime.Now.ToShortDateString() + "' and Status = '" + ON + "'";

            cn = new SqlConnection(Logo.connection);

            try
            {
                cn.Open();
                cmd = new SqlCommand(query, cn);
            }
            catch
            {

            }

            dr = cmd.ExecuteReader();

            if (dr.Read())
            {

            }
            else
            {
                check(deptcode,sem);       
            }

            dr.Close();
            cn.Close();
        }

        private void check(string deptcode, short sem)
        {
            query = "insert into DateMaster (DepartmentCode,Semester,FeedbackDate,Status) values (@departmentcode,@sem,@date,@status)";

            cn = new SqlConnection(Logo.connection);

            try
            {
                cn.Open();
                cmd = new SqlCommand(query, cn);
            }
            catch (SqlException se)
            { 
            
            }

            cmd.Parameters.AddWithValue("@departmentcode", deptcode);
            cmd.Parameters.AddWithValue("@sem", sem);
            cmd.Parameters.AddWithValue("@date", DateTime.Now.ToString("dd/MM/yyyy"));
            cmd.Parameters.AddWithValue("@status", ON);

            cmd.ExecuteNonQuery();

            cn.Close();
        }

        private void toggleUpdate()
        {
            if (updatestatus[0] == true)
            {
                if (getSemesterDate() == true)
                {
                    finalCall("CE", 1);
                }
                else
                {
                    finalCall("CE", 2);
                }
            }

            if (updatestatus[1] == true)
            {
                if (getSemesterDate() == true)
                {
                    finalCall("CE", 3);
                }
                else
                {
                    finalCall("CE", 4);
                }   
            }

            if (updatestatus[2] == true)
            {
                if (getSemesterDate() == true)
                {
                    finalCall("CE", 5);
                }
                else
                {
                    finalCall("CE", 6);
                }
            }

            if (updatestatus[3] == true)
            {
                if (getSemesterDate() == true)
                {
                    finalCall("CW", 1);
                }
                else
                {
                    finalCall("CW", 2);
                }
            }

            if (updatestatus[4] == true)
            {
                if (getSemesterDate() == true)
                {
                    finalCall("CW", 3);
                }
                else
                {
                    finalCall("CW", 4);
                }
            }

            if (updatestatus[5] == true)
            {
                if (getSemesterDate() == true)
                {
                    finalCall("CW", 5);
                }
                else
                {
                    finalCall("CW", 6);
                }
            }

            if (updatestatus[6] == true)
            {
                if (getSemesterDate() == true)
                {
                    finalCall("EG", 1);
                }
                else
                {
                    finalCall("EG", 2);
                }
            }

            if (updatestatus[7] == true)
            {
                if (getSemesterDate() == true)
                {
                    finalCall("EG", 3);
                }
                else
                {
                    finalCall("EG", 4);
                }
            }

            if (updatestatus[8] == true)
            {
                if (getSemesterDate() == true)
                {
                    finalCall("EG", 5);
                }
                else
                {
                    finalCall("EG", 6);
                }
            }

            if (updatestatus[9] == true)
            {
                if (getSemesterDate() == true)
                {
                    finalCall("EJA", 1);
                }
                else
                {
                    finalCall("EJA", 2);
                }   
            }

            if (updatestatus[10] == true)
            {
                if (getSemesterDate() == true)
                {
                    finalCall("EJA", 3);
                }
                else
                {
                    finalCall("EJA", 4);
                }
            }

            if (updatestatus[11] == true)
            {
                if (getSemesterDate() == true)
                {
                    finalCall("EJA", 5);
                }
                else
                {
                    finalCall("EJA", 6);
                }
            }

            if (updatestatus[12] == true)
            {
                if (getSemesterDate() == true)
                {
                    finalCall("EJB", 1);
                }
                else
                {
                    finalCall("EJB", 2);
                }   
            }

            if (updatestatus[13] == true)
            {
                if (getSemesterDate() == true)
                {
                    finalCall("EJB", 3);
                }
                else
                {
                    finalCall("EJB", 4);
                }
            }

            if (updatestatus[14] == true)
            {
                if (getSemesterDate() == true)
                {
                    finalCall("EJB", 5);
                }
                else
                {
                    finalCall("EJB", 6);
                }
            }

            if (updatestatus[15] == true)
            {
                if (getSemesterDate() == true)
                {
                    finalCall("MEA", 1);
                }
                else
                {
                    finalCall("MEA", 2);
                }
            }

            if (updatestatus[16] == true)
            {
                if (getSemesterDate() == true)
                {
                    finalCall("MEA", 3);
                }
                else
                {
                    finalCall("MEA", 4);
                }
            }

            if (updatestatus[17] == true)
            {
                if (getSemesterDate() == true)
                {
                    finalCall("MEA", 5);
                }
                else
                {
                    finalCall("MEA", 6);
                }
            }

            if (updatestatus[18] == true)
            {
                if (getSemesterDate() == true)
                {
                    finalCall("MEB", 1);
                }
                else
                {
                    finalCall("MEB", 2);
                }
            }

            if (updatestatus[19] == true)
            {
                if (getSemesterDate() == true)
                {
                    finalCall("MEB", 3);
                }
                else
                {
                    finalCall("MEB", 4);
                }
            }

            if (updatestatus[20] == true)
            {
                if (getSemesterDate() == true)
                {
                    finalCall("MEB", 5);
                }
                else
                {
                    finalCall("MEB", 6);
                }
            }
        }

        private void finalCall(string departmentcode, short semestercode)
        {
            int fs = getFacultyStatus(departmentcode, semestercode);
            int cs = getCollegeStatus(departmentcode, semestercode);

            if (fs == 1)
            {
                clearQuestion(departmentcode, semestercode);    //delete previous question from QuestionStatus Table
                getQuestion(departmentcode, semestercode);      //get new Question and insert into QuestionStatus Table
                getSubjectCode(departmentcode, semestercode);
                clearMarksTable(departmentcode, semestercode);
            }

            if (cs == 1)
            {
                clearFacility(departmentcode, semestercode);
                getFacility(departmentcode, semestercode);
                getFromFacilityStatus(departmentcode, semestercode);
                clearCollegeMarks(departmentcode, semestercode);
            }       

            if ((fs == 1) || (cs == 1))
            {
                updateDateToDB(departmentcode, semestercode);
                updateStudentMaster(departmentcode, semestercode);
            }
        }

        private void updateStudentMaster(string deptcode, short sem)
        {
            query = "update StudentMaster set Status = '" + ON + "' where DepartmentCode = '" + deptcode + "' and StudSemester = '" + sem + "' and Status = '" + OFF + "'";

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

        private void getSubjectCode(string deptcode, short sem)
        {
            long subjectcode;

            query = "select SubjectCode from FacultyMaster where DepartmentCode = '" + deptcode + "' and Semester = '" + sem + "' and Status = '" + ON + "'";

            cn = new SqlConnection(Logo.connection);

            try
            {
                cn.Open();
                cmd = new SqlCommand(query, cn);
                cmd.CommandTimeout = 120;
            }
            catch (SqlException se)
            { 
            
            }

            dr1 = cmd.ExecuteReader();

            while (dr1.Read())
            {
                subjectcode = long.Parse(dr1[0].ToString());
                getFromQuestionStatus(deptcode,sem,subjectcode);
            }

            dr1.Close();
            cn.Close();
        }

        private void getFromQuestionStatus(string deptcode, short sem, long subjectcode)
        {
            string que = null;
            double percentage = 0.0;

            query = "select Question From QuestionStatus where DepartmentCode = '" + deptcode + "' and Semester = '" + sem + "' and Status = '" + ON + "'";

            cn = new SqlConnection(Logo.connection);

            try
            {
                cn.Open();
                cmd = new SqlCommand(query, cn);
                cmd.CommandTimeout = 120;
            }
            catch (SqlException se)
            {

            }

            dr = cmd.ExecuteReader();

            while (dr.Read())
            {
                que = (dr[0].ToString());
                getFromMarksTable(deptcode, sem, que, subjectcode);    //Getting Marks From MarksTable
            }

            percentage = (newsum / newcount);

            insertToFacultyPerformance(deptcode, sem, subjectcode, percentage);

            newcount = 0;
            newsum = 0;

            dr.Close();
            cn.Close();
        }

        private void getFromMarksTable(string deptcode, short sem, string que, long subjectcode)
        {
            int marks = 0, sum = 0, count = 0;
            double percentage = 0;

            query = "select FacultyName, SubjectName, Marks from MarksTable where DepartmentCode = '" + deptcode + "' and Semester = '" + sem + "' and Question = '" + que + "' and SubjectCode = '" + subjectcode + "' and Status = '" + ON + "'";

            cn = new SqlConnection(Logo.connection);

            try
            {
                cn.Open();
                cmd = new SqlCommand(query, cn);
                cmd.CommandTimeout = 120;
            }
            catch (SqlException se)
            { 
            
            }

            dr2 = cmd.ExecuteReader();

            while (dr2.Read())
            {
                faculty = (dr2[0].ToString());
                subjectname = (dr2[1].ToString());
                marks = (int.Parse(dr2[2].ToString()));

                sum = sum + marks;

                count = count + 1;
            }

            int outof = RATING * count;

            try
            {
                percentage = ((100 * sum) / outof);

                insertToPerformanceMaster(deptcode, sem, faculty, subjectcode, subjectname, que, percentage);

                newsum = newsum + (int)percentage;  //Calculate total of one subject and all questions

                newcount = newcount + 1;
            }
            catch(DivideByZeroException de)
            { 
            
            }

            dr2.Close();
            cn.Close();
        }

        private void insertToPerformanceMaster(string deptcode, short sem, string faculty, long subjectcode, string subjectname, string que, double percentage)
        {
            string performance = getPerformance(percentage);

            query = "insert into PerformanceMaster (DepartmentCode,Semester,FacultyName,SubjectCode,SubjectName,Question,Performance,Percentage,FeedbackDate,Status) values (@departmentcode,@semester,@facultyname,@subjectcode,@subjectname,@question,@performance,@percentage,@feedbackdate,@status)";

            cn = new SqlConnection(Logo.connection);

            try
            {
                cn.Open();
                cmd = new SqlCommand(query, cn);
                cmd.CommandTimeout = 120;
            }
            catch (SqlException se)
            { 
            
            }

            cmd.Parameters.AddWithValue("@departmentcode", deptcode);
            cmd.Parameters.AddWithValue("@semester", sem);
            cmd.Parameters.AddWithValue("@facultyname", faculty);
            cmd.Parameters.AddWithValue("@subjectcode", subjectcode);
            cmd.Parameters.AddWithValue("@subjectname", subjectname);
            cmd.Parameters.AddWithValue("@question", que);
            cmd.Parameters.AddWithValue("@performance", performance);
            cmd.Parameters.AddWithValue("@percentage", percentage);
            cmd.Parameters.AddWithValue("@feedbackdate", DateTime.Now.ToString("dd/MM/yyyy"));
            cmd.Parameters.AddWithValue("@status", ON);

            cmd.ExecuteNonQuery();
            cn.Close();
        }

        private string getPerformance(double percentage)
        {
            int newpercentage = (int)(Math.Round(percentage));
            string performance = null;

            if (newpercentage >= PMIN && newpercentage <= PMAX)
            {
                performance = "Poor";
            }
            else if (newpercentage >= SMIN && newpercentage <= SMAX)
            {
                performance = "Satisfactory";
            }
            else if (newpercentage >= VMIN && newpercentage <= VMAX)
            {
                performance = "Very Good";
            }
            else if (newpercentage >= EMIN && newpercentage <= EMAX)
            {
                performance = "Excellent";
            }

            return (performance);
        }

        private void clearMarksTable(string deptcode, short sem)
        {
            query = "delete from MarksTable where DepartmentCode = '" + deptcode + "' and Semester = '" + sem + "' and Status = '" + ON + "'";

            cn = new SqlConnection(Logo.connection);

            try
            {
                cn.Open();
                cmd = new SqlCommand(query, cn);
                cmd.CommandTimeout = 120;
            }
            catch (SqlException se)
            { 
            
            }

            cmd.ExecuteNonQuery();

            cn.Close();
        }

        private void insertToFacultyPerformance(string deptcode, short sem, long subjectcode, double percentage)
        {
            string performance = getPerformance(percentage);

            query = "insert into FacultyPerformance (DepartmentCode,Semester,FacultyName,SubjectCode,SubjectName,Performance,Percentage,FeedbackDate,Status) values (@departmentcode,@semester,@facultyname,@subjectcode,@subjectname,@performance,@percentage,@feedbackdate,@status)";

            cn = new SqlConnection(Logo.connection);

            try
            {
                cn.Open();
                cmd = new SqlCommand(query, cn);
                cmd.CommandTimeout = 120;
            }
            catch (SqlException se)
            {

            }

            cmd.Parameters.AddWithValue("@departmentcode", deptcode);
            cmd.Parameters.AddWithValue("@semester", sem);
            cmd.Parameters.AddWithValue("@facultyname", faculty);
            cmd.Parameters.AddWithValue("@subjectcode", subjectcode);
            cmd.Parameters.AddWithValue("@subjectname", subjectname);
            cmd.Parameters.AddWithValue("@performance", performance);
            cmd.Parameters.AddWithValue("@percentage", percentage);
            cmd.Parameters.AddWithValue("@feedbackdate", DateTime.Now.ToString("dd/MM/yyyy"));
            cmd.Parameters.AddWithValue("@status", ON);

            cmd.ExecuteNonQuery();
            
            cn.Close();
        }

        private void clearFacility(string deptcode, short sem)
        {
            query = "delete from FacilityStatus where DepartmentCode = '" + deptcode + "' and Semester = '" + sem + "'";

            cn = new SqlConnection(Logo.connection);

            try
            {
                cn.Open();
                cmd = new SqlCommand(query, cn);
                cmd.CommandTimeout = 120;
            }
            catch (SqlException se)
            {

            }

            cmd.ExecuteNonQuery();

            cn.Close();
        }

        private void getFacility(string deptcode, short sem)
        {
            query = "select Facility from FacilityMaster where Status = '" + ON + "'";

            cn = new SqlConnection(Logo.connection);

            try
            {
                cn.Open();
                cmd = new SqlCommand(query, cn);
                cmd.CommandTimeout = 120;
            }
            catch (SqlException se)
            {

            }

            dr = cmd.ExecuteReader();

            while (dr.Read())
            {
                string facility = dr[0].ToString();
                bool status = true;

                updateFacilityTable(facility, deptcode, sem, status);
            }

            dr.Close();
            cn.Close();
        }

        private void updateFacilityTable(string facility, string deptcode, short sem, bool status)
        {
            query = "insert into FacilityStatus (Facility,DepartmentCode,Semester,Status) values (@facility,@deptcode,@sem,@status)";

            cn = new SqlConnection(Logo.connection);

            try
            {
                cn.Open();
                cmd = new SqlCommand(query, cn);
                cmd.CommandTimeout = 120;
            }
            catch
            {

            }

            cmd.Parameters.AddWithValue("@facility", facility);
            cmd.Parameters.AddWithValue("@deptcode", deptcode);
            cmd.Parameters.AddWithValue("@sem", sem);
            cmd.Parameters.AddWithValue("@status", Convert.ToInt32(status));

            cmd.ExecuteNonQuery();

            cn.Close();
        }

        private int getFacultyStatus(string deptcode, short sem)
        {
            int st = 0;

            query = "update FeedbackStatus set StaffStatus = '" + OFF + "' where DepartmentCode = '" + deptcode + "' and Semester = '" + sem + "' and StaffStatus = '" + ON + "'";

            cn = new SqlConnection(Logo.connection);

            try
            {
                cn.Open();
                cmd = new SqlCommand(query, cn);
                cmd.CommandTimeout = 120;
            }
            catch (SqlException se)
            { 
            
            }

            st = cmd.ExecuteNonQuery();

            cn.Close();

            return (st);
        }

        private int getCollegeStatus(string deptcode, short sem)
        {
            int st = 0;

            query = "update FeedbackStatus set CollegeStatus = '" + OFF + "' where DepartmentCode = '" + deptcode + "' and Semester = '" + sem + "' and CollegeStatus = '" + ON + "'";

            cn = new SqlConnection(Logo.connection);

            try
            {
                cn.Open();
                cmd = new SqlCommand(query, cn);
                cmd.CommandTimeout = 120;
            }
            catch (SqlException se)
            {

            }

            st = cmd.ExecuteNonQuery();

            cn.Close();

            return (st);
        }

        private void getFromFacilityStatus(string deptcode, short sem)
        {
            string facility = null;
            int excellent = 0, verygood = 0, satisfactory = 0, poor = 0;

            query = "select Facility From FacilityStatus where DepartmentCode = '" + deptcode + "' and Semester = '" + sem + "' and Status = '" + ON + "'";

            cn = new SqlConnection(Logo.connection);

            try
            {
                cn.Open();
                cmd = new SqlCommand(query, cn);
                cmd.CommandTimeout = 120;
            }
            catch (SqlException se)
            {

            }

            dr = cmd.ExecuteReader();

            while (dr.Read())
            {
                facility = (dr[0].ToString());
             
                excellent = getExcellentPercentage(deptcode, sem, facility);
                verygood = getVeryGoodPercentage(deptcode, sem, facility);
                satisfactory = getSatisfactoryPercentage(deptcode, sem, facility);
                poor = getPoorPercentage(deptcode, sem, facility);

                int students = (excellent + verygood + satisfactory + poor);

                calculateFacilityPercentage(deptcode, sem, facility, excellent, verygood, satisfactory, poor, students);
            }


            dr.Close();
            cn.Close();
        }

        private int getExcellentPercentage(string deptcode, short sem, string facility)
        {
            int count = 0;

            query = "select Impression from CollegeMarks where Departmentcode = '" + deptcode + "' and Semester = '" + sem + "' and Impression = '" + EXCELLENT + "' and Facility = '" + facility + "' and Status = '" + ON + "'";

            cn = new SqlConnection(Logo.connection);

            try
            {
                cn.Open();
                cmd = new SqlCommand(query, cn);
                cmd.CommandTimeout = 120;
            }
            catch (SqlException se)
            { 
            
            }

            dr1 = cmd.ExecuteReader();

            while (dr1.Read())
            {
                count++;
            }

            dr1.Close();
            cn.Close();

            return (count);
        }

        private int getVeryGoodPercentage(string deptcode, short sem, string facility)
        {
            int count = 0;

            query = "select Impression from CollegeMarks where Departmentcode = '" + deptcode + "' and Semester = '" + sem + "' and Impression = '" + VERYGOOD + "' and Facility = '" + facility + "' and Status = '" + ON + "'";

            cn = new SqlConnection(Logo.connection);

            try
            {
                cn.Open();
                cmd = new SqlCommand(query, cn);
                cmd.CommandTimeout = 120;
            }
            catch (SqlException se)
            {

            }

            dr1 = cmd.ExecuteReader();

            while (dr1.Read())
            {
                count++;
            }

            dr1.Close();
            cn.Close();

            return (count);
        }

        private int getSatisfactoryPercentage(string deptcode, short sem, string facility)
        {
            int count = 0;

            query = "select Impression from CollegeMarks where Departmentcode = '" + deptcode + "' and Semester = '" + sem + "' and Impression = '" + SATISFACTORY + "' and Facility = '" + facility + "' and Status = '" + ON + "'";

            cn = new SqlConnection(Logo.connection);

            try
            {
                cn.Open();
                cmd = new SqlCommand(query, cn);
                cmd.CommandTimeout = 120;
            }
            catch (SqlException se)
            {

            }

            dr1 = cmd.ExecuteReader();

            while (dr1.Read())
            {
                count++;
            }

            dr1.Close();
            cn.Close();

            return (count);
        }

        private int getPoorPercentage(string deptcode, short sem, string facility)
        {
            int count = 0;

            query = "select Impression from CollegeMarks where Departmentcode = '" + deptcode + "' and Semester = '" + sem + "' and Impression = '" + POOR + "' and Facility = '" + facility + "' and Status = '" + ON + "'";

            cn = new SqlConnection(Logo.connection);

            try
            {
                cn.Open();
                cmd = new SqlCommand(query, cn);
                cmd.CommandTimeout = 120;
            }
            catch (SqlException se)
            {

            }

            dr1 = cmd.ExecuteReader();

            while (dr1.Read())
            {
                count++;
            }

            dr1.Close();
            cn.Close();
            
            return (count);
        }

        private void calculateFacilityPercentage(string deptcode, short sem, string facility, int excellent, int verygood, int satisfactory, int poor, int students)
        {
            double excellentpercentage = 0.0, verygoodpercentage = 0.0, satisfactorypercentage = 0.0, poorpercentage = 0.0;

            float studentsnum = (float)(students);

            excellentpercentage = ((excellent * 100.00) / studentsnum);
            verygoodpercentage = ((verygood * 100.00) / studentsnum);
            satisfactorypercentage = ((satisfactory * 100.00) / studentsnum);
            poorpercentage = ((poor * 100.00) / studentsnum);

            insertToCollegePerformance(deptcode, sem, facility, excellentpercentage, verygoodpercentage, satisfactorypercentage, poorpercentage);
        }

        private void insertToCollegePerformance(string deptcode, int sem, string facility, double excellentpercentage, double verygoodpercentage, double satisfactorypercentage, double poorpercentage)
        {
            query = "insert into CollegePerformance (DepartmentCode,Semester,Facility,Excellent,VeryGood,Satisfactory,Poor,FeedbackDate,Status) values (@departmentcode,@semester,@facility,@excellent,@verygood,@satisfactory,@poor,@feedbackdate,@status)";

            cn = new SqlConnection(Logo.connection);

            try
            {
                cn.Open();
                cmd = new SqlCommand(query, cn);
                cmd.CommandTimeout = 120;
            }
            catch (SqlException se)
            {

            }

            cmd.Parameters.AddWithValue("@departmentcode", deptcode);
            cmd.Parameters.AddWithValue("@semester", sem);
            cmd.Parameters.AddWithValue("@facility", facility);
            cmd.Parameters.AddWithValue("@excellent", Math.Round(excellentpercentage, MidpointRounding.AwayFromZero));
            cmd.Parameters.AddWithValue("@verygood", Math.Round(verygoodpercentage, MidpointRounding.AwayFromZero));
            cmd.Parameters.AddWithValue("@satisfactory", Math.Round(satisfactorypercentage, MidpointRounding.AwayFromZero));
            cmd.Parameters.AddWithValue("@poor", Math.Round(poorpercentage, MidpointRounding.AwayFromZero));
            cmd.Parameters.AddWithValue("@feedbackdate", DateTime.Now.ToString("dd/MM/yyyy"));
            cmd.Parameters.AddWithValue("@status", ON);

            cmd.ExecuteNonQuery();

            cn.Close();
        }

        private void clearCollegeMarks(string deptcode, int sem)
        {
            query = "delete from CollegeMarks where DepartmentCode = '" + deptcode + "' and Semester = '" + sem + "' and Status = '" + ON + "'";

            cn = new SqlConnection(Logo.connection);

            try
            {
                cn.Open();
                cmd = new SqlCommand(query, cn);
                cmd.CommandTimeout = 120;
            }
            catch (SqlException se)
            {

            }

            cmd.ExecuteNonQuery();

            cn.Close();           
        }
    }
}