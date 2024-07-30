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
    public partial class Questions : MetroForm
    {
        SqlConnection cn;
        SqlCommand cmd;
        SqlDataReader dr;

        string query = null;

        string[] question = new string[10];
        
        bool[] status = new bool[10];
        
        const int ON = 1;
        const int OFF = 0;

        public Questions()
        {
            InitializeComponent();
        }

        private void Questions_Load(object sender, EventArgs e)
        {
            updateDate();
            getQuestionAndStatusList();
        }

        private void pnl_question_Paint(object sender, PaintEventArgs e)
        {

        }

        private void btn_save_Click(object sender, EventArgs e)
        {
            DialogResult dialogresult = MetroMessageBox.Show(Owner,"Do you want save changes?","YCPFeedback",MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (dialogresult == DialogResult.Yes)
            {
                getQuestions();
                getStatus();

                for (int i = 0; i < 10; i++)
                    updateQuestionsToDB(i + 1, question[i], status[i]);

                updateReadOnlyTextBox(false);

                lbl_questioninfo.Focus();
                MetroMessageBox.Show(Owner, "Question Successfully Saved", "YCPFeedback", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                Questions frm_question = new Questions();
                frm_question.Show();
                this.Hide();
            }
        }

        private void btn_edit_Click(object sender, EventArgs e)
        {
            lbl_questioninfo.Focus();
            updateReadOnlyTextBox(true);
        }

        private void updateQuestionsAndStatus()
        {
            for (int i = 0; i < 10; i++)
            {
                TextBox txt = (TextBox)(this.Controls.Find("txt_q" + (i + 1), true).FirstOrDefault());
                txt.Text = question[i];

                MetroToggle tgl = (MetroToggle)(this.Controls.Find("tgl_q" + (i + 1), true).FirstOrDefault());
                tgl.Checked = status[i];
            }
        }

        private void updateReadOnlyTextBox(bool status)
        {
            if (status == true)
            {
                for (int i = 1; i < 11; i++)
                {
                    TextBox txt = (TextBox)(this.Controls.Find("txt_q" + i, true).FirstOrDefault());
                    txt.ReadOnly = false;
                }
            }
            else
            {
                for (int i = 1; i < 11; i++)
                {
                    TextBox txt = (TextBox)(this.Controls.Find("txt_q" + i, true).FirstOrDefault());
                    txt.ReadOnly = true;
                }
            }
        }

        private void getQuestionAndStatusList()
        {
            int i = 0;

            query = "select Question, Status from QuestionMaster Order By QuestionNo ASC";

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

            while(dr.Read())
            {
                question[i] = dr[0].ToString();
                status[i] = Convert.ToBoolean(int.Parse(dr[1].ToString()));
                
                i++;
            }

                updateQuestionsAndStatus();

            dr.Close();
            cn.Close();
        }


        private void updateQuestionsToDB(int queno, string que,bool status)
        {
            query = "update QuestionMaster set Question = '" + que + "', Status = '" + Convert.ToInt32(status) + "' where QuestionNo = '" + queno + "'";

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

        private void getQuestions()
        {
            for (int i = 0; i < 10; i++)
            {
                TextBox txt = (TextBox)(this.Controls.Find("txt_q" + (i + 1), true).FirstOrDefault());
                question[i] = txt.Text;
            }
        }

        private void getStatus()
        {
            for (int i = 0; i < 10; i++)
            {
                MetroToggle tgl = (MetroToggle)(this.Controls.Find("tgl_q" + (i + 1), true).FirstOrDefault());
                status[i] = Convert.ToBoolean(tgl.CheckState);
            }
        }

        private void updateDate()
        {
            lbl_date.Text = (DateTime.Now.ToString("dd/MM/yyyy"));
        }

        private void ms_adminlogout_Click(object sender, EventArgs e)
        {
            HomePage frm_homepage = new HomePage();
            frm_homepage.Show();
            this.Hide();
        }

        private void btn_previous_Click(object sender, EventArgs e)
        {
      
        }

        private void Questions_FormClosing(object sender, FormClosingEventArgs e)
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

        private void btn_previous_Click_1(object sender, EventArgs e)
        {
            AdminChoice frm_adminchoice = new AdminChoice();
            frm_adminchoice.Show();
            this.Hide();
        }
    }
}
