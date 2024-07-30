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
    public partial class ChangePassword : MetroForm
    {
        SqlConnection cn;
        SqlCommand cmd;
        SqlDataReader dr;

        string query = null;

        const int ON = 1;
        const int OFF = 0;

        public ChangePassword()
        {
            InitializeComponent();
        }

        private void ChangePassword_Load(object sender, EventArgs e)
        {
            updateDate();
        }

        private void updateDate()
        {
            lbl_date.Text = (DateTime.Now.ToString("dd/MM/yyyy"));
        }

        private void btn_submit_Click(object sender, EventArgs e)
        {
            checkOldPassowrd();
            clear();
        }

        private void checkOldPassowrd()
        {
            query = "select Password from AdminMaster where Password = '" + txt_oldpassword.Text + "' and Status = '" + ON + "'";

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
                updateNewPassword();
            }
            else
            {
                MetroMessageBox.Show(Owner, "Wrong Password.", "YCPFeedback", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            dr.Close();
            cn.Close();
        }

        private void updateNewPassword()
        {
            if (txt_newpassword.Text.Equals(txt_confirmpassword.Text))
            {
                query = "update AdminMaster set Password = '" + txt_confirmpassword.Text + "' where Password = '" + txt_oldpassword.Text + "' and Status = '" + ON + "'";

                cn = new SqlConnection(Logo.connection);

                try
                {
                    cn.Open();
                    cmd = new SqlCommand(query, cn);
                }
                catch (Exception e)
                {

                }

                cmd.ExecuteNonQuery();

                MetroMessageBox.Show(Owner, "Password Successfully Changed.", "YCPFeedbackSuper", MessageBoxButtons.OK, MessageBoxIcon.Information);
                cn.Close();
            }
            else
            {
                MetroMessageBox.Show(Owner, "Password does not Match.", "YCPFeedbackSuper", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void ms_changepasswordlogout_Click(object sender, EventArgs e)
        {
            HomePage frm_homepage = new HomePage();
            frm_homepage.Show();
            this.Hide();
        }

        private void btn_previous_Click(object sender, EventArgs e)
        {
            AdminChoice frm_adminchoice = new AdminChoice();
            frm_adminchoice.Show();
            this.Hide();
        }

        private void ChangePassword_FormClosing(object sender, FormClosingEventArgs e)
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

        private void txt_confirmpassword_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                checkOldPassowrd();
                clear();
            }
        }

        private void clear()
        {
            txt_confirmpassword.Text = string.Empty;
            txt_newpassword.Text = string.Empty;
            txt_oldpassword.Text = string.Empty;
        }
    }
}
