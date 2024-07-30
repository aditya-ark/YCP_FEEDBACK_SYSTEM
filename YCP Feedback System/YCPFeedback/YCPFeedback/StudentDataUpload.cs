using MetroFramework;
using MetroFramework.Forms;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.OleDb;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing.Text;

namespace YCPFeedback
{
    public partial class StudentDataUpload : MetroForm
    {
        SqlConnection cn;
        SqlCommand cmd;
        SqlDataReader dr;

        string excelstring = null, query = null, excelpath = null, department = null, semester = null;

        bool st;

        List<string> deptcode = new List<string>();
        List<string> semcode = new List<string>();

        const int ON = 1;
        const int OFF = 0;

        private const int MarginWidth = 4;
        private const int MarginHeight = 4;

        public StudentDataUpload()
        {
            InitializeComponent();
        }

        private void DataUpload_Load(object sender, EventArgs e)
        {      
            excelstring = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source={0};Extended Properties='Excel 8.0;HDR=NO;IMEX=1'";
            
            fillDropDownList();
            fillSemDropDown();
            updateDate();
        }

        private void fillSemDropDown()
        {
            for (int i = 1; i < 7; i++)
                semcode.Add(i.ToString());

            ddl_selectsem.DataSource = semcode;
            ddl_selectsem.SelectedIndex = -1;
        }

        private void fillDropDownList()
        {
            query = "select DepartmentCode from DepartmentMaster where Status = '" + ON + "'";

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
                string dept = dr[0].ToString();

                /*if (dept.Equals("MEA") || dept.Equals("MEB") || dept.Equals("EJA") || dept.Equals("EJB"))
                {
                    string dt = dept.Substring(0, 2);
                    dept = dept.Substring(2);

                    dept = dt + "-" + dept;
                }*/

                if (dept.Length > 2)
                {
                    string dt = dept.Substring(0, 2);
                    dept = dept.Substring(2);

                    dept = dt + "-" + dept;
                }

                deptcode.Add(dept);
            }

            ddl_selectdept.DataSource = deptcode;
            ddl_selectdept.SelectedIndex = -1;

            cn.Close();
            dr.Close();
        }

        private void updateDate()
        {
            lbl_date.Text = (DateTime.Now.ToString("dd/MM/yyyy"));
        }

        private void btn_upload_Click(object sender, EventArgs e)
        {
            if (ddl_selectdept.SelectedIndex == -1 || ddl_selectsem.SelectedIndex == -1)
            {
                MetroMessageBox.Show(Owner, "Please Select Department and Semester.", "YCPFeedback", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                OpenFileDialog openFileDialog1 = new OpenFileDialog();
                openFileDialog1.Filter = "Excel Files|*.xlsx";
                openFileDialog1.Title = "Select a Excel File";

                if (openFileDialog1.ShowDialog() == DialogResult.OK)
                {
                    excelpath = openFileDialog1.FileName;

                    string constring = string.Format(excelstring, excelpath);

                    excelConnect(constring);
                }
            }
        }

        private void updateOldStudentStatus()
        {
            query = "update StudentMaster set Status = '" + OFF + "' where DepartmentCode = '" + department + "' and StudSemester = '" + semester + "'";

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

        private void excelConnect(string constring)
        {
            int tempcount = 0;

            using (OleDbConnection Econ = new OleDbConnection(constring))
            {
                try
                {
                    Econ.Open(); 
                }
                catch (Exception e)
                {

                }

                string sheet1 = Econ.GetOleDbSchemaTable(OleDbSchemaGuid.Tables, null).Rows[0]["Table_Name"].ToString();

                DataTable dt = Econ.GetOleDbSchemaTable(OleDbSchemaGuid.Columns, new object[] { null, null, sheet1, null });

                List<string> listColumn = new List<string>();

                foreach (DataRow row in dt.Rows)
                {
                    listColumn.Add(row["Column_name"].ToString());
                }

                DataTable dtexcel = new DataTable();

                if(listColumn.Count == 2)
                {
                    dtexcel.Columns.AddRange(new DataColumn[2] { new DataColumn(listColumn[0], typeof(string)),
                    new DataColumn(listColumn[1], typeof(string)) });

                    using (OleDbDataAdapter oda = new OleDbDataAdapter("SELECT * FROM [" + sheet1 + "]", Econ))
                    {
                        oda.Fill(dtexcel);
                    }

                    foreach (DataRow row in dtexcel.Rows)
                    {
                        string enrollment = row[0].ToString();

                        short count = (short)(enrollment.Count());
                        

                        if (count != 10 || (enrollment.Substring(2,4) != "1577"))
                        {
                            tempcount++;   
                        }
                    }

                    if (tempcount == 0)
                    { 
                        DataColumn newColumn1 = new DataColumn("DepartmentCode", typeof(string));
                        newColumn1.AllowDBNull = true;
                        dtexcel.Columns.Add(newColumn1);

                        DataColumn newColumn2 = new DataColumn("StudSemester", typeof(string));
                        newColumn2.AllowDBNull = true;
                        dtexcel.Columns.Add(newColumn2);

                        DataColumn newColumn3 = new DataColumn("Status", typeof(int));
                        newColumn3.AllowDBNull = true;
                        dtexcel.Columns.Add(newColumn3);

                        foreach (DataRow row in dtexcel.Rows)
                        {
                            row["DepartmentCode"] = department;
                            row["StudSemester"] = semester;
                            row["Status"] = ON;
                        }

                        using (cn = new SqlConnection(Logo.connection))
                        {
                            using (SqlBulkCopy copy = new SqlBulkCopy(cn))
                            {
                                copy.DestinationTableName = "StudentMaster";

                                copy.ColumnMappings.Add(listColumn[0], "Username");
                                copy.ColumnMappings.Add(listColumn[1], "StudName");
                                copy.ColumnMappings.Add("DepartmentCode", "DepartmentCode");
                                copy.ColumnMappings.Add("StudSemester", "StudSemester");
                                copy.ColumnMappings.Add("Status", "Status");

                                cn.Open();

                                try
                                {
                                    copy.WriteToServer(dtexcel);
                                    updateStatusMaster(1);              //Uploads 1 when new data is uploaded for semester
                                    updateOnUpload();
                                    MetroMessageBox.Show(Owner, "Student Data has been Successfully Saved.", "YCPFeedback", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                }
                                catch (SqlException sqe)
                                {
                                    updateOnUpload();

                                    int error = sqe.Number;

                                    if (error == 2627)
                                    {
                                        MetroMessageBox.Show(Owner, "Student Data already Exists.Please delete existing Data and Upload.", "YCPFeedback", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                    }
                                    else if (error == 4815)
                                    {
                                        MetroMessageBox.Show(Owner, "Invalid Enrollement Format.Please Upload in Suitable Format.", "YCPFeedback", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                    }
                                    else
                                    {
                                        MetroMessageBox.Show(Owner, sqe.Message.ToString(), "YCPFeedback", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                    }
                                }

                                cn.Close();
                            }
                        }
                    }
                    else
                    {
                        MetroMessageBox.Show(Owner, "Invalid Enrollement Format.Please Upload in Suitable Format.", "YCPFeedback", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    Econ.Close();
                }
                else
                {
                    MetroMessageBox.Show(Owner, "Upload Data in Suitable Format.", "YCPFeedback", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void updateOnUpload()
        {
            ddl_selectdept.SelectedIndex = -1;
            ddl_selectsem.SelectedIndex = -1;
            btn_upload.Enabled = false;
            btn_delete.Enabled = false;
        }

        private void updateStatusMaster(int localstatus)
        {
            if (localstatus == ON)
                query = "update StatusMaster set Status = '" + ON + "' where DepartmentCode = '" + department + "' and Semester = '" + semester + "'";
            else
                query = "update StatusMaster set Status = '" + OFF + "' where DepartmentCode = '" + department + "' and Semester = '" + semester + "'";

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
            ddl_selectsem.SelectionLength = 0;

            cn.Close();
        }

        private void ddl_selectdept_SelectedIndexChanged(object sender, EventArgs e)
        {
            if(ddl_selectdept.SelectedIndex != -1)
                department = ddl_selectdept.SelectedItem.ToString();

            if (department.Equals("ME-A") || department.Equals("ME-B") || department.Equals("EJ-A") || department.Equals("EJ-B"))
            {
                string dt = department.Substring(0, 2);
                string dt1 = department.Substring(3);
                department = dt + dt1;
            }

            if (ddl_selectdept.SelectedIndex != -1 && ddl_selectsem.SelectedIndex != -1)
            {
                btn_delete.Enabled = true;
                checkStatus();
            }
        }

        private void ddl_selectsem_SelectedIndexChanged(object sender, EventArgs e)
        {
            if(ddl_selectsem.SelectedIndex != -1)
                semester = ddl_selectsem.SelectedItem.ToString();

            if (ddl_selectdept.SelectedIndex != -1 && ddl_selectsem.SelectedIndex != -1)
            {
                btn_delete.Enabled = true;
                checkStatus();
            }
        }

        private void checkStatus()
        {
            query = "select Status from StatusMaster where DepartmentCode = '" + department + "' and Semester = '" + semester + "'";

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
                st = Convert.ToBoolean(int.Parse(dr[0].ToString()));
            }

            if (st == false)
                btn_upload.Enabled = true;
            else
                btn_upload.Enabled = false;

            dr.Close();
            cn.Close();
        }

        private void ms_datauploadlogout_Click(object sender, EventArgs e)
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

        private void DataUpload_FormClosing(object sender, FormClosingEventArgs e)
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

        private void btn_delete_Click(object sender, EventArgs e)
        {
            if (ddl_selectdept.SelectedIndex == -1 || ddl_selectsem.SelectedIndex == -1)
            {
                MetroMessageBox.Show(Owner, "Please Select Department and Semester.", "YCPFeedback", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                if (MetroMessageBox.Show(Owner, "Do you want to Delete all Records?", "YCPFeedback", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    query = "delete from StudentMaster where DepartmentCode = '" + department + "' and StudSemester = '" + semester + "' and Status = '" + ON + "'";

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

                    updateStatusMaster(0);

                    MetroMessageBox.Show(Owner, "Data Successfully Deleted.", "YCPFeedback", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    cn.Close();
                }

                ddl_selectdept.SelectedIndex = -1;
                ddl_selectsem.SelectedIndex = -1;
            }

            btn_delete.Enabled = false;
        }

        private void ddl_selectdept_DrawItem(object sender, DrawItemEventArgs e)
        {

        }
    }
}