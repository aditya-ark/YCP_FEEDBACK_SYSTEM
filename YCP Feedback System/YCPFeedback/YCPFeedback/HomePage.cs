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
    public partial class HomePage : MetroForm
    {
        SqlConnection cn;
        SqlCommand cmd;
        SqlDataReader dr;

        string query = null;
        
        public static string deptcode = null, studname = null, studsem = null, studenr = null;

        const int ON = 1;
        const int OFF = 0;

        public HomePage()
        {
            InitializeComponent();
        }

        private void HomePage_Load(object sender, EventArgs e)
        {
            
        }

        private void ms_home_Click(object sender, EventArgs e)
        {
            picbox_college.Visible = true;
            lbl_principal.Visible = true;
            lbl_principalname.Visible = true;
            lbl_hod.Visible = true;
            lbl_hodname.Visible = true;

            ms_admin.Visible = true;              //For Student GUI
            ms_student.Visible = true;
        }

        private void ms_admin_Click(object sender, EventArgs e)
        {
            lbl_loginheading.Text = "Admin Login";
            update();

            ms_admin.Visible = false;
            ms_student.Visible = true;
        }

        private void ms_student_Click(object sender, EventArgs e)
        {
            lbl_loginheading.Text = "Student Login";
            update();

            ms_student.Visible = false;
            ms_admin.Visible = true;            //For Student GUI
        }

        private void update()
        {
            txt_username.Focus();

            picbox_college.Visible = false;
            lbl_principal.Visible = false;
            lbl_principalname.Visible = false;
            lbl_hod.Visible = false;
            lbl_hodname.Visible = false;

            txt_password.Text = "";
            txt_username.Text = "";
        }

        private void btn_login_Click(object sender, EventArgs e)
        {
            checkLogin();
            txt_username.Focus();
        }

        private void validateStudentLogin()
        {
            if (txt_username.Text.Equals(txt_password.Text))
            {
                query = "select StudName, DepartmentCode, StudSemester from StudentMaster where Username = '" + txt_username.Text + "'";

                cn = new SqlConnection(Logo.connection);

                try
                {
                    cn.Open();
                    cmd = new SqlCommand(query, cn);
                }
                catch (Exception e)
                {

                }

                try
                {
                    dr = cmd.ExecuteReader();

                    if (dr.Read())
                    {
                        studname = dr[0].ToString();
                        deptcode = dr[1].ToString();
                        studsem = dr[2].ToString();
                        studenr = txt_username.Text.ToString();

                        if (checkDepartmentStatus() == true)
                        {
                            if (checkStudentStatus() == true)
                            {
                                StudentInfo frm_studinfo = new StudentInfo();
                                frm_studinfo.Show();
                                this.Hide();
                            }
                            else
                            {
                                updateTextBox();

                                MetroMessageBox.Show(Owner, "Your Feedback Already Exist.You Cant Access Feedback.", "YCPFeedback", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            }
                        }
                        else
                        {
                            updateTextBox();

                            MetroMessageBox.Show(Owner, "You Cant Access Feedback.", "YCPFeedback", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                    else
                    {
                        txt_password.Text = string.Empty;

                        MetroMessageBox.Show(Owner, "Invalid Login.", "YCPFeedback", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }

                    dr.Close();
                }
                catch (NullReferenceException re)
                {
                    updateTextBox();

                    MetroMessageBox.Show(Owner, "Server is Offline.Please Contact System Administrator.", "YCPFeedback", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }

                cn.Close();
            }
            else
            {
                txt_password.Text = string.Empty;

                MetroMessageBox.Show(Owner,"Invalid Login.","YCPFeedback",MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void updateTextBox()
        {
            txt_username.Text = string.Empty;
            txt_password.Text = string.Empty;
            txt_username.Focus();
        }

        private bool checkStudentStatus()
        {
            query = "select Status from StudentMaster where Username = '" + HomePage.studenr + "' and Status = '" + ON + "'";

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
                
            return (false);
        }

        private bool checkDepartmentStatus()
        {
            bool st = false;

            query = "select status from DepartmentStatus where DepartmentCode = '" + deptcode + "' and Semester = '" + studsem + "'";

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
                    st = Convert.ToBoolean(int.Parse(dr[0].ToString()));
                }

            dr.Close();
            cn.Close();

            return (st);
        }

        private void validateAdminLogin()
        {
            query = "select Username, Password from AdminMaster where Username = '" + txt_username.Text + "' COLLATE Latin1_General_CS_AS and Password = '" + txt_password.Text + "' COLLATE Latin1_General_CS_AS and Status = '" + ON + "'";

            cn = new SqlConnection(Logo.connection);

            try
            {
                cn.Open();
                cmd = new SqlCommand(query, cn);
            }
            catch (Exception e)
            {

            }

            try
            {
                dr = cmd.ExecuteReader();
            
                if (dr.Read())
                {
                    AdminChoice frm_adminchoice = new AdminChoice();
                    frm_adminchoice.Show();
                    this.Hide();
                }
                else
                {
                    txt_password.Text = string.Empty;
                    MetroMessageBox.Show(Owner, "Invalid Login.", "YCPFeedback", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }

                dr.Close();
            }
            catch (NullReferenceException re)
            {
                updateTextBox();

                MetroMessageBox.Show(Owner, "Server is Offline.Please Contact System Administrator.", "YCPFeedback", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }

            cn.Close();
        }

        private void HomePage_FormClosing(object sender, FormClosingEventArgs e)
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

        private void txt_password_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                checkLogin();
            }
        }

        private void checkLogin()
        {
            if (lbl_loginheading.Text.Equals("Admin Login"))
                validateAdminLogin();
            else
                validateStudentLogin();
        }

        private void txt_password_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == '\'')
            {
                e.Handled = true;
            }
        }
    }
}
