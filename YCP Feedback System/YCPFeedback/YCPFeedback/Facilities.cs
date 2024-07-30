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
    public partial class Facilities : MetroForm
    {
        SqlConnection cn;
        SqlCommand cmd;
        SqlDataReader dr;

        string query = null;
        string[] facility = new string[15];

        bool[] status = new bool[15];

        const int ON = 1;
        const int OFF = 0;

        public Facilities()
        {
            InitializeComponent();
        }

        private void Facilities_Load(object sender, EventArgs e)
        {
            updateDate();
            getFacilitiesAndStatusList();
        }

        private void updateDate()
        {
            lbl_date.Text = (DateTime.Now.ToString("dd/MM/yyyy"));
        }

        private void btn_edit_Click(object sender, EventArgs e)
        {
            lbl_facilityinfo.Focus();
            updateReadOnlyTextBox(false);
        }

        private void updateReadOnlyTextBox(bool status)
        {
            if (status == false)
            {
                for (int i = 1; i < 16; i++)
                {
                    TextBox txt = (TextBox)(this.Controls.Find("txt_f" + i , true).FirstOrDefault());
                    txt.ReadOnly = false;
                }
            }
            else
            {
                for (int i = 1; i < 16; i++)
                {
                    TextBox txt = (TextBox)(this.Controls.Find("txt_f" + i, true).FirstOrDefault());
                    txt.ReadOnly = true;
                }
            }
        }

        private void getFacilitiesAndStatusList()
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

            updateFacilitiesAndStatus();

            dr.Close();
            cn.Close();
        }

        private void updateFacilitiesAndStatus()
        {
            for (int i = 0; i < 15; i++)
            {
                TextBox txt = (TextBox)(this.Controls.Find("txt_f" + (i + 1), true).FirstOrDefault());
                txt.Text = facility[i];

                MetroToggle tgl = (MetroToggle)(this.Controls.Find("tgl_f" + (i + 1), true).FirstOrDefault());
                tgl.Checked = status[i];
            }
        }

        private void btn_save_Click(object sender, EventArgs e)
        {
            DialogResult dialogresult = MetroMessageBox.Show(Owner,"Do you want save changes?","YCPFeedback",MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (dialogresult == DialogResult.Yes)
            {
                getFacilities();
                getStatus();

                for (int i = 0; i < 15; i++)
                    updateFacilitiesToDB(i + 1, facility[i], status[i]);

                updateReadOnlyTextBox(true);
                
                lbl_facilityinfo.Focus();
                MetroMessageBox.Show(Owner, "Facilities has been Successfully Saved.", "YCPFeedback", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                Facilities frm_facilities = new Facilities();
                frm_facilities.Show();
                this.Hide();
            }
        }

        private void getFacilities()
        {
            for (int i = 0; i < 15; i++)
            {
                TextBox txt = (TextBox)(this.Controls.Find("txt_f" + (i + 1), true).FirstOrDefault());
                facility[i] = txt.Text;
            }
        }

        private void getStatus()
        {
            for (int i = 0; i < 15; i++)
            {
                MetroToggle tgl = (MetroToggle)(this.Controls.Find("tgl_f" + (i + 1), true).FirstOrDefault());
                status[i] = Convert.ToBoolean((tgl.CheckState));
            }
        }

        private void updateFacilitiesToDB(int facno, string fac, bool status)
        {
            query = "update FacilityMaster set Facility = '" + fac + "', Status = '" + Convert.ToInt32(status) + "' where FacilityNo = '" + facno + "'";

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

        private void ms_adminlogout_Click(object sender, EventArgs e)
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

        private void Facilities_FormClosing(object sender, FormClosingEventArgs e)
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
