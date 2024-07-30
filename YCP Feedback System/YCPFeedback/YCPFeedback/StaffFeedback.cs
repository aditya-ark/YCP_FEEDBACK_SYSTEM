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
    public partial class StaffFeedback : MetroForm
    {
        SqlConnection cn;
        SqlCommand cmd;
        SqlDataReader dr;

        string query = null, subjectname = null, subcode = null;

        bool[] status = new bool[10];

        short count = 1, subjectcount = 0;

        List<string> subname = new List<string>();
        List<string> subject = new List<string>();

        string[] que = new string[10];

        const int ON = 1;
        const int OFF = 0;

        public StaffFeedback()
        {
            InitializeComponent();
        }

        private void StaffFeedback_Load(object sender, EventArgs e)
        {
            fillDropDownList();
            updateDate();
            getQuestions();
            ddl_selectsubject.SelectedIndex = -1;
        }

        public void fillDropDownList()
        {
            query = "select SubjectName from FacultyMaster where DepartmentCode = '" + HomePage.deptcode +"' and Semester = '" + HomePage.studsem + "' and Status = '" + ON + "' Order By SubjectName ASC";

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
                subname.Add(dr[0].ToString());
            }

            foreach (string str in subname)
            {
                if (str.Length > 7)
                {
                    try
                    {
                        if (int.Parse(str.Substring(7)) == StudentBatch.batch)
                        {
                            subject.Add(str.Substring(0,7));
                        }
                    }
                    catch (Exception ee)
                    {
                        MetroMessageBox.Show(Owner, "Subject were not in Correct Format.", "YCPFeedback", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                else
                {
                    subject.Add(str);
                }
            }

            ddl_selectsubject.DataSource = subject;

            dr.Close();
            cn.Close();
        }

        private void updateDate()
        {
            lbl_date.Text = (DateTime.Now.ToString("dd/MM/yyyy"));
        }

        private void ddl_selectsubject_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (ddl_selectsubject.SelectedIndex == -1)
            {
                btn_submit.Enabled = false;
                txt_suggestion.Enabled = false;

                lbl_facultyname.Text = string.Empty;
                lbl_subjectname.Text = string.Empty;

                updatePanelEnabledTrue(false);
            }
            else
            {
                if (ddl_selectsubject.SelectedItem.ToString().Length == 7)
                {
                    if (ddl_selectsubject.SelectedItem.ToString().Substring(3, 4) == "(PR)")
                    {
                        foreach(string str in subname)
                        {
                            if (str.Length > 7 && (str.Substring(0, 7).Equals(ddl_selectsubject.SelectedItem.ToString())))
                            {
                                subjectname = ddl_selectsubject.SelectedItem.ToString() + StudentBatch.batch;
                            
                            }
                            else if(str.Length == 7 && (str.Substring(0, 7).Equals(ddl_selectsubject.SelectedItem.ToString())))
                            {
                                subjectname = ddl_selectsubject.SelectedItem.ToString();
                            }
                        }
                    }
                    else
                        subjectname = ddl_selectsubject.SelectedItem.ToString();
                }
                else
                {
                    subjectname = ddl_selectsubject.SelectedItem.ToString();
                }

                bool st = updateEnable();

                getFacultyNameAndSubjectCode(subjectname);

                if (st == true)
                {
                    btn_submit.Enabled = false;
                    txt_suggestion.Enabled = false;

                    updatePanelEnabledTrue(false);
                }
                else
                {
                    btn_submit.Enabled = true;
                    txt_suggestion.Enabled = true;

                    
                    updatePanelEnabled();
                }
            }

            changeColorToDefault();
        }

        private bool updateEnable()
        {
            query = "select Marks from MarksTable where Username = '" + HomePage.studenr + "' and DepartmentCode = '" + HomePage.deptcode + "' and Semester = '" + HomePage.studsem + "' and SubjectName = '" + subjectname + "' and Status = '" + ON + "'";

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

            if (dr.Read())
            {
                return (true);
            }
            else
            {
                return (false);
            }
        }

        private void changeColorToDefault()
        {
            for (int i = 1; i < 11; i++)
            {
                for (int j = 1; j < 6; j++)
                {
                    Button btn = (Button)(this.Controls.Find("btn_" + i + j, true).FirstOrDefault());
                    btn.BackColor = Color.LightGray;

                    Label lbl = (Label)(this.Controls.Find("lbl_ans" + i, true).FirstOrDefault());
                    lbl.Text = "0";
                }
            }
        }

        private void getFacultyNameAndSubjectCode(string subname)
        {
            query = "select SubjectCode, FacultyName from FacultyMaster where SubjectName = '" + subname + "' and DepartmentCode = '" + HomePage.deptcode + "' and Semester = '" + HomePage.studsem + "' and Status = '" + ON + "'";

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

            if (dr.Read())
            {
                subcode = dr[0].ToString();
                lbl_subjectname.Text = subcode.Substring(0, 5);
                lbl_facultyname.Text = dr[1].ToString();
            }

            dr.Close();
            cn.Close();
        }

        private void updatePanelEnabledTrue(bool status)
        {
            for (int i = 1; i < 11; i++)
            {
                Panel pnl = (Panel)(this.Controls.Find("pnl_question" + i, true).FirstOrDefault());
                pnl.Enabled = status;
            }
        }

        private void updatePanelEnabled()
        {
            for (int i = 0; i < 10; i++)
            {
                Panel pnl = (Panel)(this.Controls.Find("pnl_question" + (i + 1), true).FirstOrDefault());
                pnl.Enabled = status[i];
            }
        }

        private void btn_nextpage_Click(object sender, EventArgs e)
        {
            if (subject.Count == subjectcount)
            {
                CollegeFeedback frm_collegefeedback = new CollegeFeedback();
                frm_collegefeedback.Show();
                this.Hide();
            }
            else
            {
                lbl_ratinginfo.Focus();
                MetroMessageBox.Show(Owner, "Please Submit All Feedback.", "YCPFeedback", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Questions frm_ques = new Questions();
            frm_ques.Show();
            this.Hide();
        }

        private void getQuestions()
        {
            int i = 0;

            query = "select Question, Status from QuestionMaster";

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
                que[i] = dr[0].ToString();
                status[i] = Convert.ToBoolean(int.Parse(dr[1].ToString()));

                i++;
            }

            updateQuestion();

            dr.Close();
            cn.Close();
        }

        private void updateQuestion()
        { 
            for (int i = 0; i < 10; i++)
            {
                Label lbl = (Label)(this.Controls.Find("lbl_question" + (i + 1), true).FirstOrDefault());
                lbl.Text = "Q" + (i + 1) + ". " + que[i];
            }
        }

//---------------------------------------------------Change Color-----------------------------------------//        

        private void changeColor(int i, int j)
        {
            int temp = j;

            Label lbl = (Label)(this.Controls.Find("lbl_ans" + i, true).FirstOrDefault());
            lbl.Text = j.ToString();
            
            j++;

            if (temp < 3)
            {
                while (temp > 0)
                {
                    Button btn = (Button)(this.Controls.Find("btn_" + i + temp, true).FirstOrDefault());
                    btn.BackColor = Color.FromArgb(255, 102, 102);

                    temp--;
                }
            }
            else
            {
                while (temp > 0)
                {
                    Button btn = (Button)(this.Controls.Find("btn_" + i + temp, true).FirstOrDefault());
                    btn.BackColor = Color.DeepSkyBlue;

                    temp--;
                }
            }

            while (j < 6)
            {
                Button btn = (Button)(this.Controls.Find("btn_" + i + j, true).FirstOrDefault());
                btn.BackColor = Color.LightGray;

                j++;
            }
        }

//---------------------------------------------------Ratting Button Question 1-----------------------------------------//

        private void btn_11_Click(object sender, EventArgs e)
        {
            changeColor(1,1);
        }

        private void btn_12_Click(object sender, EventArgs e)
        {
            changeColor(1,2);
        }

        private void btn_13_Click(object sender, EventArgs e)
        {
            changeColor(1,3);
        }

        private void btn_14_Click(object sender, EventArgs e)
        {
            changeColor(1,4);
        }

        private void btn_15_Click(object sender, EventArgs e)
        {
            changeColor(1,5);
        }

        private void lbl_grade1_Paint(object sender, PaintEventArgs e)
        {
            ControlPaint.DrawBorder(e.Graphics, lbl_grade1.DisplayRectangle, Color.DeepSkyBlue, ButtonBorderStyle.Solid);
        }

        private void lbl_ans1_Paint(object sender, PaintEventArgs e)
        {
            ControlPaint.DrawBorder(e.Graphics, lbl_ans1.DisplayRectangle, Color.DeepSkyBlue, ButtonBorderStyle.Solid);
        }

//---------------------------------------------------Ratting Button Question 2-----------------------------------------//

        private void btn_21_Click(object sender, EventArgs e)
        {
            changeColor(2,1);
        }

        private void btn_22_Click(object sender, EventArgs e)
        {
            changeColor(2,2);
        }

        private void btn_23_Click(object sender, EventArgs e)
        {
            changeColor(2,3);
        }

        private void btn_24_Click(object sender, EventArgs e)
        {
            changeColor(2,4);
        }

        private void btn_25_Click(object sender, EventArgs e)
        {
            changeColor(2,5);
        }

        private void lbl_grade2_Paint(object sender, PaintEventArgs e)
        {
            ControlPaint.DrawBorder(e.Graphics, lbl_grade2.DisplayRectangle, Color.DeepSkyBlue, ButtonBorderStyle.Solid);
        }

        private void lbl_ans2_Paint(object sender, PaintEventArgs e)
        {
            ControlPaint.DrawBorder(e.Graphics, lbl_ans2.DisplayRectangle, Color.DeepSkyBlue, ButtonBorderStyle.Solid);
        }

//---------------------------------------------------Ratting Button Question 3-----------------------------------------//

        private void btn_31_Click(object sender, EventArgs e)
        {
            changeColor(3,1);
        }

        private void btn_32_Click(object sender, EventArgs e)
        {
            changeColor(3,2);
        }

        private void btn_33_Click(object sender, EventArgs e)
        {
            changeColor(3,3);
        }

        private void btn_34_Click(object sender, EventArgs e)
        {
            changeColor(3,4);
        }

        private void btn_35_Click(object sender, EventArgs e)
        {
            changeColor(3,5);
        }

        private void lbl_grade3_Paint(object sender, PaintEventArgs e)
        {
            ControlPaint.DrawBorder(e.Graphics, lbl_grade3.DisplayRectangle, Color.DeepSkyBlue, ButtonBorderStyle.Solid);
        }

        private void lbl_ans3_Paint(object sender, PaintEventArgs e)
        {
            ControlPaint.DrawBorder(e.Graphics, lbl_ans3.DisplayRectangle, Color.DeepSkyBlue, ButtonBorderStyle.Solid);
        }

//---------------------------------------------------Ratting Button Question 4-----------------------------------------//

        private void btn_41_Click(object sender, EventArgs e)
        {
            changeColor(4,1);
        }

        private void btn_42_Click(object sender, EventArgs e)
        {
            changeColor(4,2);
        }

        private void btn_43_Click(object sender, EventArgs e)
        {
            changeColor(4,3);
        }

        private void btn_44_Click(object sender, EventArgs e)
        {
            changeColor(4,4);
        }

        private void btn_45_Click(object sender, EventArgs e)
        {
            changeColor(4,5);
        }

        private void lbl_grade4_Paint(object sender, PaintEventArgs e)
        {
            ControlPaint.DrawBorder(e.Graphics, lbl_grade4.DisplayRectangle, Color.DeepSkyBlue, ButtonBorderStyle.Solid);
        }

        private void lbl_ans4_Paint(object sender, PaintEventArgs e)
        {
            ControlPaint.DrawBorder(e.Graphics, lbl_ans4.DisplayRectangle, Color.DeepSkyBlue, ButtonBorderStyle.Solid);
        }

//---------------------------------------------------Ratting Button Question 5-----------------------------------------//

        private void btn_51_Click(object sender, EventArgs e)
        {
            changeColor(5,1);
        }

        private void btn_52_Click(object sender, EventArgs e)
        {
            changeColor(5,2);
        }

        private void btn_53_Click(object sender, EventArgs e)
        {
            changeColor(5,3);
        }

        private void btn_54_Click(object sender, EventArgs e)
        {
            changeColor(5,4);
        }

        private void btn_55_Click(object sender, EventArgs e)
        {
            changeColor(5,5);
        }

        private void lbl_grade5_Paint(object sender, PaintEventArgs e)
        {
            ControlPaint.DrawBorder(e.Graphics, lbl_grade5.DisplayRectangle, Color.DeepSkyBlue, ButtonBorderStyle.Solid);
        }

        private void lbl_ans5_Paint(object sender, PaintEventArgs e)
        {
            ControlPaint.DrawBorder(e.Graphics, lbl_ans5.DisplayRectangle, Color.DeepSkyBlue, ButtonBorderStyle.Solid);
        }

//---------------------------------------------------Ratting Button Question 6-----------------------------------------//

        private void btn_61_Click(object sender, EventArgs e)
        {
            changeColor(6,1);
        }

        private void btn_62_Click(object sender, EventArgs e)
        {
            changeColor(6,2);
        }

        private void btn_63_Click(object sender, EventArgs e)
        {
            changeColor(6,3);
        }

        private void btn_64_Click(object sender, EventArgs e)
        {
            changeColor(6,4);
        }

        private void btn_65_Click(object sender, EventArgs e)
        {
            changeColor(6,5);
        }

        private void lbl_grade6_Paint(object sender, PaintEventArgs e)
        {
            ControlPaint.DrawBorder(e.Graphics, lbl_grade6.DisplayRectangle, Color.DeepSkyBlue, ButtonBorderStyle.Solid);
        }

        private void lbl_ans6_Paint(object sender, PaintEventArgs e)
        {
            ControlPaint.DrawBorder(e.Graphics, lbl_ans6.DisplayRectangle, Color.DeepSkyBlue, ButtonBorderStyle.Solid);
        }

//---------------------------------------------------Ratting Button Question 7-----------------------------------------//

        private void btn_71_Click(object sender, EventArgs e)
        {
            changeColor(7,1);
        }

        private void btn_72_Click(object sender, EventArgs e)
        {
            changeColor(7,2);
        }

        private void btn_73_Click(object sender, EventArgs e)
        {
            changeColor(7,3);
        }

        private void btn_74_Click(object sender, EventArgs e)
        {
            changeColor(7,4);
        }

        private void btn_75_Click(object sender, EventArgs e)
        {
            changeColor(7,5);
        }

        private void lbl_grade7_Paint(object sender, PaintEventArgs e)
        {
            ControlPaint.DrawBorder(e.Graphics, lbl_grade7.DisplayRectangle, Color.DeepSkyBlue, ButtonBorderStyle.Solid);
        }

        private void lbl_ans7_Paint(object sender, PaintEventArgs e)
        {
            ControlPaint.DrawBorder(e.Graphics, lbl_ans7.DisplayRectangle, Color.DeepSkyBlue, ButtonBorderStyle.Solid);
        }

//---------------------------------------------------Ratting Button Question 8-----------------------------------------//

        private void btn_81_Click(object sender, EventArgs e)
        {
            changeColor(8,1);
        }

        private void btn_82_Click(object sender, EventArgs e)
        {
            changeColor(8,2);
        }

        private void btn_83_Click(object sender, EventArgs e)
        {
            changeColor(8,3);
        }

        private void btn_84_Click(object sender, EventArgs e)
        {
            changeColor(8,4);
        }

        private void btn_85_Click(object sender, EventArgs e)
        {
            changeColor(8,5);
        }

        private void lbl_grade8_Paint(object sender, PaintEventArgs e)
        {
            ControlPaint.DrawBorder(e.Graphics, lbl_grade8.DisplayRectangle, Color.DeepSkyBlue, ButtonBorderStyle.Solid);
        }

        private void lbl_ans8_Paint(object sender, PaintEventArgs e)
        {
            ControlPaint.DrawBorder(e.Graphics, lbl_ans8.DisplayRectangle, Color.DeepSkyBlue, ButtonBorderStyle.Solid);
        }

//---------------------------------------------------Ratting Button Question 9-----------------------------------------//

        private void btn_91_Click(object sender, EventArgs e)
        {
            changeColor(9,1);
        }

        private void btn_92_Click(object sender, EventArgs e)
        {
            changeColor(9,2);
        }

        private void btn_93_Click(object sender, EventArgs e)
        {
            changeColor(9,3);
        }

        private void btn_94_Click(object sender, EventArgs e)
        {
            changeColor(9,4);
        }

        private void btn_95_Click(object sender, EventArgs e)
        {
            changeColor(9,5);
        }

        private void lbl_grade9_Paint(object sender, PaintEventArgs e)
        {
            ControlPaint.DrawBorder(e.Graphics, lbl_grade9.DisplayRectangle, Color.DeepSkyBlue, ButtonBorderStyle.Solid);
        }

        private void lbl_ans9_Paint(object sender, PaintEventArgs e)
        {
            ControlPaint.DrawBorder(e.Graphics, lbl_ans9.DisplayRectangle, Color.DeepSkyBlue, ButtonBorderStyle.Solid);
        }

//---------------------------------------------------Ratting Button Question 10-----------------------------------------//

        private void lbl_grade10_Paint(object sender, PaintEventArgs e)
        {
            ControlPaint.DrawBorder(e.Graphics, lbl_grade10.DisplayRectangle, Color.DeepSkyBlue, ButtonBorderStyle.Solid);
        }

        private void lbl_ans10_Paint(object sender, PaintEventArgs e)
        {
            ControlPaint.DrawBorder(e.Graphics, lbl_ans10.DisplayRectangle, Color.DeepSkyBlue, ButtonBorderStyle.Solid);
        }

        private void btn_101_Click(object sender, EventArgs e)
        {
            changeColor(10,1);
        }

        private void btn_102_Click(object sender, EventArgs e)
        {
            changeColor(10,2);
        }

        private void btn_103_Click(object sender, EventArgs e)
        {
            changeColor(10,3);
        }

        private void btn_104_Click(object sender, EventArgs e)
        {
            changeColor(10,4);
        }

        private void btn_105_Click(object sender, EventArgs e)
        {
            changeColor(10,5);
        }

        private void ms_stafffeedback_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {
            HomePage frm_homepage = new HomePage();
            frm_homepage.Show();
            this.Hide();
        }

        private void StaffFeedback_FormClosing(object sender, FormClosingEventArgs e)
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

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void shapeContainer1_Load(object sender, EventArgs e)
        {

        }

        private void btn_submit_Click(object sender, EventArgs e)
        {
            if (checkAnsLabel() == 1)
            {
                MetroMessageBox.Show(Owner, "Please Submit All Answers.", "YCPFeedback", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                if (count == 1)
                {
                    updateStudentStatus();
                    updateFeedbackStatus();
                    count++;
                }

                for (int i = 1; i < 11; i++)
                {
                    int len = ((i.ToString()).Count()); 

                    Panel pnl = (Panel)(this.Controls.Find("pnl_question" + i, true).FirstOrDefault());

                    if (pnl.Enabled == true)
                    {
                        Label lbl = (Label)(this.Controls.Find("lbl_question" + i, true).FirstOrDefault());
                        Label lbl_ans = (Label)(this.Controls.Find("lbl_ans" + i, true).FirstOrDefault());

                        updateMarksToDB(lbl.Text.Substring(len + 3), lbl_ans.Text);
                    }
                }

                if (txt_suggestion.Text != string.Empty)
                    updateSuggestionToDB(txt_suggestion.Text);

                subjectcount++;
                lbl_ratinginfo.Focus();
                ddl_selectsubject.SelectedIndex = -1;
                txt_suggestion.Text = string.Empty;

                /*if (subjectcount == subject.Count)
                {
                    ms_stafffeedbacllogout.Enabled = true;
                }*/

                MetroMessageBox.Show(Owner, "Saved Successfully.", "YCPFeedback", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void updateFeedbackStatus()
        {
            query = "update FeedbackStatus set StaffStatus = '" + ON + "' where DepartmentCode = '" + HomePage.deptcode + "' and Semester = '" + HomePage.studsem + "' and StaffStatus = '" + OFF + "'";

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

        private void updateSuggestionToDB(string suggestion)
        {
            query = "insert into SuggestionMaster(DepartmentCode,Semester,SubjectCode,SubjectName,FacultyName,Suggestion,FeedbackDate,Status) values(@departmentcode,@semester,@subjectcode,@subjectname,@facultyname,@suggestion,@feedbackdate,@status)";

            cn = new SqlConnection(Logo.connection);

            try
            {
                cn.Open();
                cmd = new SqlCommand(query, cn);

                cmd.Parameters.AddWithValue("@departmentcode", HomePage.deptcode);
                cmd.Parameters.AddWithValue("@semester", int.Parse(HomePage.studsem));
                cmd.Parameters.AddWithValue("@subjectcode", int.Parse(subcode));
                cmd.Parameters.AddWithValue("@subjectname", subjectname);
                cmd.Parameters.AddWithValue("@facultyname", lbl_facultyname.Text);
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

        private void updateMarksToDB(string question,string marks)
        {
            query = "insert into MarksTable(Username,DepartmentCode,Semester,SubjectCode,SubjectName,FacultyName,Question,Marks,Status) values(@username,@departmentcode,@semester,@subjectcode,@subjectname,@facultyname,@question,@marks,@status)";

            cn = new SqlConnection(Logo.connection);

            try
            {
                cn.Open();
                cmd = new SqlCommand(query, cn);

                cmd.Parameters.AddWithValue("@username", HomePage.studenr);
                cmd.Parameters.AddWithValue("@departmentcode", HomePage.deptcode);
                cmd.Parameters.AddWithValue("@semester", int.Parse(HomePage.studsem));
                cmd.Parameters.AddWithValue("@subjectcode", int.Parse(subcode));
                cmd.Parameters.AddWithValue("@subjectname", subjectname);
                cmd.Parameters.AddWithValue("@facultyname", lbl_facultyname.Text);
                cmd.Parameters.AddWithValue("@question", question);
                cmd.Parameters.AddWithValue("@marks", int.Parse(marks));
                cmd.Parameters.AddWithValue("@status", ON);
            }
            catch (SqlException se)
            { 
            
            }

            cmd.ExecuteNonQuery();

            cn.Close();
        }

        private int checkAnsLabel()
        {
            for (int i = 1; i < 11; i++)
            {
                Panel pnl = (Panel)(this.Controls.Find("pnl_question" + i, true).FirstOrDefault());
                Label lbl_ans = (Label)(this.Controls.Find("lbl_ans" + i, true).FirstOrDefault());

                if (pnl.Enabled == true && lbl_ans.Text.Equals("0"))
                {
                    return (1);
                }
            }

            return (0);
        }

        private void ms_stafffeedbacllogout_Click(object sender, EventArgs e)
        {
            if (MetroMessageBox.Show(Owner, "Please Submit College Feedback. Click on Next Section. Do you want to Exit?", "YCPFeedback", MessageBoxButtons.YesNo, MessageBoxIcon.Error) == DialogResult.Yes)
            {
                HomePage frm_homepage = new HomePage();
                frm_homepage.Show();
                this.Hide();
            }
        }
    }
}
