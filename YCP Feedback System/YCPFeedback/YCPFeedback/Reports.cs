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
using iTextSharp.text;
using iTextSharp.text.pdf;
using System.IO;
using System.Windows.Forms.DataVisualization.Charting;

namespace YCPFeedback
{
    public partial class Reports : MetroForm
    {
        SqlConnection cn;
        SqlCommand cmd;
        SqlDataReader dr;

        List<string> deptcode = new List<string>();
        List<string> date = new List<string>();
        List<string> subject = new List<string>();

        short report = 0;

        string query = null, dept = null, newdate = null, pdfname = null;

        int sem;

        const int ON = 1;
        const int OFF = 0;

        public Reports()
        {
            InitializeComponent();
        }

        private void Reports_Load(object sender, EventArgs e)
        {
            updateDate();
            fillDeptDropDownList();
            gridVisible();

            cht_faculty.ChartAreas[0].AxisY.Minimum = 0;
            cht_faculty.ChartAreas[0].AxisY.Maximum = 100;
        }

        private void fillDeptDropDownList()
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

            cn.Close();
            dr.Close();

            ddl_selectdept.DataSource = deptcode;
        }

        private void updateDate()
        {
            lbl_date.Text = (DateTime.Now.ToString("dd/MM/yyyy"));
        }

        private void ms_reportslogout_Click(object sender, EventArgs e)
        {
            HomePage frm_homepage = new HomePage();
            frm_homepage.Show();
            this.Hide();
        }

        private void Reports_FormClosing(object sender, FormClosingEventArgs e)
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

        private void fillDateDropDownList()
        {
            string dept = getDepartmentCode();
            
            query = "select FeedbackDate from DateMaster where DepartmentCode = '" + dept + "' and Semester = '" + sem + "' and Status = '" + ON +"'";

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
                string dt = (dr[0].ToString());
                date.Add(dt);
            }

            ddl_selectdate.DataSource = date;

            date.Clear();

            cn.Close();
            dr.Close();
        }

        private void ddl_selectdept_SelectedIndexChanged(object sender, EventArgs e)
        {
            dept = ddl_selectdept.SelectedItem.ToString();

            ddl_selectsem_SelectedIndexChanged(this, EventArgs.Empty);
        }

        private void ddl_selectsem_SelectedIndexChanged(object sender, EventArgs e)
        {
            ddl_report.SelectedIndex = -1;
            ddl_selectdate.DataSource = null;
          
            gridVisible();

            if(ddl_selectsem.SelectedIndex != -1)
                sem = int.Parse(ddl_selectsem.SelectedItem.ToString());

            fillDateDropDownList();
        }

        private void ddl_selectdate_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (ddl_report.SelectedIndex != -1)
            {
                if (ddl_report.SelectedIndex != 5)
                {
                    gridVisible();
                    gridDataShow();

                    cht_faculty.DataSource = null;
                    cht_faculty.Visible = false;
                }
                else
                {
                    cht_faculty.DataSource = null;

                    gridDataShow();

                    btn_export.Visible = true;  
                    dgv_staffreport.Visible = false;
                    cht_faculty.Visible = true;
                }
            }
        }

        private void ddl_report_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (ddl_selectdate.SelectedIndex != -1)
            {
                if (ddl_report.SelectedIndex != 5)
                {
                    gridVisible();
                    gridDataShow();

                    cht_faculty.Visible = false;
                }
                else
                {
                    gridDataShow();

                    btn_delete.Visible = false;
                    btn_export.Visible = true;  
                    dgv_staffreport.Visible = false;
                    cht_faculty.Visible = true;
                }
            }
        }

        private void gridDataShow()
        {
            report = (short)ddl_report.SelectedIndex;

            ddl_selectsubject.Visible = false;
            lbl_selectsubject.Visible = false;
            lbl_facultyname.Visible = false;
            lbl_faculty.Visible = false;

            newdate = ddl_selectdate.SelectedItem.ToString();

            if (report == 0)
                collegeDataBind(newdate);
            else if (report == 1)
                collegeSuggestionDataBind(newdate);
            else if (report == 2)
                facultyDataBind(newdate);
            else if (report == 3)
                facultysuggestionDataBind(newdate);
            else if (report == 4)
                questionDataBind(newdate);
            else if (report == 5)
                chartDataBind(newdate);
        }

        private void facultysuggestionDataBind(string date)
        {
            dgv_staffreport.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;

            string dept = getDepartmentCode();
            
            query = "select FacultyName,SubjectName,Suggestion from SuggestionMaster where DepartmentCode = '" + dept + "' and Semester = '" + sem + "' and FeedbackDate = '" + date + "' and Status = '" + ON + "' ORDER BY SubjectName ASC";

            cn = new SqlConnection(Logo.connection);

            try
            {
                cn.Open();
                cmd = new SqlCommand(query, cn);
            }
            catch (SqlException se)
            {

            }

            SqlDataAdapter da = new SqlDataAdapter();
            da.SelectCommand = cmd;

            DataTable dt = new DataTable();
            da.Fill(dt);

            dgv_staffreport.DataSource = dt;

            cmd.ExecuteNonQuery();
            cn.Close();            
        }

        private void collegeSuggestionDataBind(string date)
        {
            dgv_staffreport.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;

            string dept = getDepartmentCode();

            query = "select Suggestion from CollegeSuggestion where DepartmentCode = '" + dept + "' and Semester = '" + sem + "' and FeedbackDate = '" + date + "' and Status = '" + ON + "' Order By Suggestion ASC";

            cn = new SqlConnection(Logo.connection);

            try
            {
                cn.Open();
                cmd = new SqlCommand(query, cn);
            }
            catch (SqlException se)
            { 
            
            }

            SqlDataAdapter da = new SqlDataAdapter();
            da.SelectCommand = cmd;

            DataTable dt = new DataTable();
            da.Fill(dt);

            dgv_staffreport.DataSource = dt;

            cmd.ExecuteNonQuery();
            cn.Close();
        }

        private void questionDataBind(string date)
        {
            ddl_selectsubject.Visible = true;
            lbl_selectsubject.Visible = true;
            fillSubjectDropDownList();
            ddl_selectsubject.SelectedIndex = -1;

            dgv_staffreport.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;

            string dept = getDepartmentCode();

            query = "select FacultyName,SubjectName,Question,Performance,Percentage from PerformanceMaster where DepartmentCode = '" + dept + "' and Semester = '" + sem + "' and FeedbackDate = '" + date + "' and Status = '" + ON + "' ORDER BY SubjectName ASC,Question ASC";

            cn = new SqlConnection(Logo.connection);

            try
            {
                cn.Open();
                cmd = new SqlCommand(query, cn);
            }
            catch (SqlException se)
            {

            }

            SqlDataAdapter da = new SqlDataAdapter();
            da.SelectCommand = cmd;

            DataTable dt = new DataTable();
            da.Fill(dt);

            dgv_staffreport.DataSource = dt;

            cmd.ExecuteNonQuery();
            cn.Close();

            dgv_staffreport.Columns["FacultyName"].DisplayIndex = 0;
            dgv_staffreport.Columns["SubjectName"].DisplayIndex = 1;
        }

        private void facultyDataBind(string date)
        {
            dgv_staffreport.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;

            string dept = getDepartmentCode();

            query = "select FacultyName,SubjectName,Performance,Percentage from FacultyPerformance where DepartmentCode = '" + dept + "' and Semester = '" + sem + "' and FeedbackDate = '" + date + "' and Status = '" + ON + "' ORDER BY SubjectName ASC";

            cn = new SqlConnection(Logo.connection);

            try
            {
                cn.Open();
                cmd = new SqlCommand(query, cn);
            }
            catch (SqlException se)
            {

            }

            SqlDataAdapter da = new SqlDataAdapter();
            da.SelectCommand = cmd;

            DataTable dt = new DataTable();
            da.Fill(dt);

            dgv_staffreport.DataSource = dt;

            cmd.ExecuteNonQuery();
            cn.Close();            
        }

        private void collegeDataBind(string date)
        {
            dgv_staffreport.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;

            string dept = getDepartmentCode();

            query = "select Facility,Excellent,VeryGood,Satisfactory,Poor from CollegePerformance where DepartmentCode = '" + dept + "' and Semester = '" + sem + "' and FeedbackDate = '" + date + "' and Status = '" + ON + "' ORDER BY Facility";

            cn = new SqlConnection(Logo.connection);

            try
            {
                cn.Open();
                cmd = new SqlCommand(query, cn);
            }
            catch (SqlException se)
            {

            }

            SqlDataAdapter da = new SqlDataAdapter();
            da.SelectCommand = cmd;

            DataTable dt = new DataTable();
            da.Fill(dt);

            dgv_staffreport.DataSource = dt;

            cmd.ExecuteNonQuery();
            cn.Close();            
        }

        private void subjectDataBind(string newdate)
        {
            dgv_staffreport.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;

            string dept = getDepartmentCode();

            string sub = ddl_selectsubject.SelectedItem.ToString();

            query = "select Question,Performance,Percentage from PerformanceMaster where DepartmentCode = '" + dept + "' and Semester = '" + sem + "' and FeedbackDate = '" + newdate + "' and SubjectName = '" + sub + "' and Status = '" + ON + "' ORDER BY FacultyName ASC,Question ASC";

            cn = new SqlConnection(Logo.connection);

            try
            {
                cn.Open();
                cmd = new SqlCommand(query, cn);
            }
            catch (SqlException se)
            {

            }

            SqlDataAdapter da = new SqlDataAdapter();
            da.SelectCommand = cmd;

            DataTable dt = new DataTable();
            da.Fill(dt);

            dgv_staffreport.DataSource = dt;

            lbl_faculty.Visible = true;
            lbl_facultyname.Visible = true;

            cmd.ExecuteNonQuery();
            cn.Close();            
        }

        private void chartDataBind(string date)
        {
            string dept = getDepartmentCode();

            query = "select SubjectName,Percentage from FacultyPerformance where DepartmentCode = '" + dept + "' and Semester = '" + sem + "' and FeedbackDate = '" + date + "' and Status = '" + ON + "' ORDER BY SubjectName ASC";

            cn = new SqlConnection(Logo.connection);

            try
            {
                cn.Open();
                cmd = new SqlCommand(query, cn);
            }
            catch (SqlException se)
            {

            }

            cht_faculty.DataSource = null;

            SqlDataAdapter da = new SqlDataAdapter();
            da.SelectCommand = cmd;

            DataTable dt = new DataTable();
            da.Fill(dt);

            cht_faculty.DataSource = dt;

            cht_faculty.ChartAreas[0].AxisX.Interval = 1;

            cht_faculty.Series["Excellent"].XValueMember = "SubjectName";
            cht_faculty.Series["Excellent"].YValueMembers = "Percentage";

            cht_faculty.DataBind();

            foreach (DataPoint dp in cht_faculty.Series["Excellent"].Points)
            {
                if (dp.YValues[0] > 80)
                    dp.Color = Color.Green;
                else if (dp.YValues[0] > 50 && dp.YValues[0] < 81)
                    dp.Color = Color.Yellow;
                else if (dp.YValues[0] > 20 && dp.YValues[0] < 51)
                    dp.Color = Color.DeepSkyBlue;
                else
                    dp.Color = Color.Red;
            }

            cn.Close();            
        }

        private void fillSubjectDropDownList()
        {
            string dept = getDepartmentCode();

            query = "select SubjectName from FacultyPerformance where DepartmentCode = '" + dept + "' and Semester = '" + sem + "'";

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

            while (dr.Read())
            {
                subject.Add(dr[0].ToString());
            }

            dr.Close();
            cn.Close();

            ddl_selectsubject.DataSource = subject;
        }

        private void gridVisible()
        {
            if (ddl_selectdate.SelectedIndex == -1)
            {
                dgv_staffreport.Visible = false;
                btn_delete.Visible = false;
                btn_export.Visible = false;
            }
            else
            {
                dgv_staffreport.Visible = true;
                btn_delete.Visible = true;
                btn_export.Visible = true;
            }
        }

        private void clear()
        {
            ddl_selectsem.SelectedIndex = -1;
            ddl_selectdate.SelectedIndex = -1;
            ddl_report.SelectedIndex = -1;
        }

        private void btn_delete_Click(object sender, EventArgs e)
        {            
            DialogResult dialogresult = MetroMessageBox.Show(Owner, "Do you want Delete Records?", "YCPFeedback", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            string dept = getDepartmentCode();

            if (dialogresult == DialogResult.Yes)
            {
                if (report == 0)
                    query = "update CollegePerformance set Status = '" + OFF + "' where DepartmentCode = '" + dept + "' and Semester = '" + sem + "' and FeedbackDate = '" + newdate + "' and Status = '" + ON + "'";
                else if (report == 1)
                    query = "update CollegeSuggestion set Status = '" + OFF + "' where DepartmentCode = '" + dept + "' and Semester = '" + sem + "' and FeedbackDate = '" + newdate + "' and Status = '" + ON + "'";
                else if (report == 2)
                    query = "update FacultyPerformance set Status = '" + OFF + "' where DepartmentCode = '" + dept + "' and Semester = '" + sem + "' and FeedbackDate = '" + newdate + "' and Status = '" + ON + "'";
                else if (report == 3)
                    query = "update SuggestionMaster set Status = '" + OFF + "' where DepartmentCode = '" + dept + "' and Semester = '" + sem + "' and FeedbackDate = '" + newdate + "' and Status = '" + ON + "'";
                else if (report == 4)
                    query = "update PerformanceMaster set Status = '" + OFF + "' where DepartmentCode = '" + dept + "' and Semester = '" + sem + "' and FeedbackDate = '" + newdate + "' and Status = '" + ON + "'";

                deleteRecords();
                checkDeleteStatus();

                ddl_report.SelectedIndex = -1;
                ddl_selectdate.SelectedIndex = -1;
                ddl_selectsem.SelectedIndex = -1;
            }
        }

        private void deleteRecords()
        {
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

            MetroMessageBox.Show(Owner, "Record Successfully Deleted.", "YCPFeedback", MessageBoxButtons.OK, MessageBoxIcon.Information);

            cn.Close();
        }

        private void checkDeleteStatus()
        {
            int st1 = 0, st2 = 0, st3 = 0, st4 = 0;

            if (report == 0)
            {
                st1 = checkCollegeSuggestionStatus();
                st2 = checkFacultyPerformanceStatus();
                st3 = checkSuggestionMasterStatus();
                st4 = checkPerformanceMasterStatus();

                if (st1 == OFF && st2 == OFF && st3 == OFF && st4 == OFF)
                {
                    deleteFeedbackDate();
                }
            }
            else if (report == 1)
            {
                    st1 = checkCollegePerformanceStatus();
                    st2 = checkFacultyPerformanceStatus();
                    st3 = checkSuggestionMasterStatus();
                    st4 = checkPerformanceMasterStatus();

                    if (st1 == OFF && st2 == OFF && st3 == OFF && st4 == OFF)
                    {
                        deleteFeedbackDate();
                    }
            }
            else if (report == 2)
            {
                st1 = checkCollegePerformanceStatus();
                st2 = checkCollegeSuggestionStatus();
                st3 = checkSuggestionMasterStatus();
                st4 = checkPerformanceMasterStatus();

                if (st1 == OFF && st2 == OFF && st3 == OFF && st4 == OFF)
                {
                    deleteFeedbackDate();
                }
            }
            else if (report == 3)
            {
                st1 = checkCollegePerformanceStatus();
                st2 = checkCollegeSuggestionStatus();
                st3 = checkFacultyPerformanceStatus();
                st4 = checkPerformanceMasterStatus();

                if (st1 == OFF && st2 == OFF && st3 == OFF && st4 == OFF)
                {
                    deleteFeedbackDate();
                }
            }
            else if (report == 4)
            {
                st1 = checkCollegePerformanceStatus();
                st2 = checkCollegeSuggestionStatus();
                st3 = checkFacultyPerformanceStatus();
                st4 = checkSuggestionMasterStatus();

                if (st1 == OFF && st2 == OFF && st3 == OFF && st4 == OFF)
                {
                    deleteFeedbackDate();
                }
            }
        }

        private int checkPerformanceMasterStatus()
        {
            string dept = getDepartmentCode();

            query = "select Status from PerformanceMaster where DepartmentCode = '" + dept + "' and Semester = '" + sem + "' and FeedbackDate = '" + newdate + "' and Status = '" + ON + "'";

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
                return (1);
            }

            return (0);
        }

        private int checkSuggestionMasterStatus()
        {
            string dept = getDepartmentCode();

            query = "select Status from SuggestionMaster where DepartmentCode = '" + dept + "' and Semester = '" + sem + "' and FeedbackDate = '" + newdate + "' and Status = '" + ON + "'";

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
                return (1);
            }

            return (0);
        }

        private int checkFacultyPerformanceStatus()
        {
            string dept = getDepartmentCode();

            query = "select Status from FacultyPerformance where DepartmentCode = '" + dept + "' and Semester = '" + sem + "' and FeedbackDate = '" + newdate + "' and Status = '" + ON + "'";

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
                return (1);
            }

            return (0);
        }

        private int checkCollegeSuggestionStatus()
        {
            string dept = getDepartmentCode();

            query = "select Status from CollegeSuggestion where DepartmentCode = '" + dept + "' and Semester = '" + sem + "' and FeedbackDate = '" + newdate + "' and Status = '" + ON + "'";

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
                return (1);
            }

            return (0);
        }

        private int checkCollegePerformanceStatus()
        {
            string dept = getDepartmentCode();

            query = "select Status from CollegePerformance where DepartmentCode = '" + dept + "' and Semester = '" + sem + "' and FeedbackDate = '" + newdate + "' and Status = '" + ON + "'";

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
                return (1);
            }

            return (0);
        }

        private void deleteFeedbackDate()
        {
            string newdept = getDepartmentCode();

            query = "update DateMaster set Status = '" + OFF + "' where DepartmentCode = '" + newdept + "' and Semester = '" + sem + "' and FeedbackDate = '" + newdate + "' and Status = '" + ON + "'";

            cn = new SqlConnection(Logo.connection);

            try
            {
                cn.Open();
                cmd = new SqlCommand(query, cn);
            }
            catch(Exception e)
            { 
            
            }

            cmd.ExecuteNonQuery();

            cn.Close();
        }

        private void btn_export_Click(object sender, EventArgs e)
        {
            DataTable dt = copyToDataTable();
            generatePDF(dt);
        }

        private DataTable copyToDataTable()
        {
            DataTable dt = new DataTable("GridData");

            foreach (DataGridViewColumn col in dgv_staffreport.Columns)
            {
                dt.Columns.Add(col.HeaderText);
            }

            foreach (DataGridViewRow row in dgv_staffreport.Rows)
            {
                DataRow newrow = dt.NewRow();

                foreach (DataGridViewCell cell in row.Cells)
                {
                    newrow[cell.ColumnIndex] = cell.Value;
                }

                dt.Rows.Add(newrow);
            }

            return (dt);
        }

        private void generatePDF(DataTable dt)
        {
            SaveFileDialog sfd = new SaveFileDialog();
            sfd.Title = "Save Report";
            sfd.Filter = "(*.pdf)|*.pdf";
            sfd.InitialDirectory = @"C:\";

            try
            {
                if (sfd.ShowDialog() == DialogResult.OK)
                {
                    int i = 1;

                    Document doc = new Document(PageSize.A4);

                    FileStream fs = new FileStream(sfd.FileName, FileMode.Create, FileAccess.Write);

                    i++;

                    PdfWriter writer = PdfWriter.GetInstance(doc, fs);

                    doc.Open();

                    Chunk glue = new Chunk(new iTextSharp.text.pdf.draw.VerticalPositionMark());

                    Paragraph dkte = new Paragraph("D.K.T.E. SOCIETY'S");
                    dkte.Font.SetStyle(iTextSharp.text.Font.BOLD);

                    Paragraph ycp = new Paragraph("YASHWANTRAO CHAVAN POLYTECHNIC");
                    ycp.Font.SetStyle(iTextSharp.text.Font.BOLD);

                    Paragraph feedback;

                    if(ddl_report.SelectedIndex != 5)
                        feedback = new Paragraph(ddl_report.SelectedItem.ToString().ToUpper() + " REPORT");
                    else
                        feedback = new Paragraph("FACULTY PERFORMANCE GRAPH");

                    feedback.Font.SetStyle(iTextSharp.text.Font.BOLD);

                    Paragraph line = new Paragraph(new Chunk(new iTextSharp.text.pdf.draw.LineSeparator(0.0F, 100.0F, BaseColor.BLACK, Element.ALIGN_LEFT, 1)));

                    Paragraph department = new Paragraph("Department : " + ddl_selectdept.SelectedItem.ToString());
                    department.Font.SetStyle(iTextSharp.text.Font.BOLD);
                    department.Add(new Chunk(glue));
                    department.Add("Date : " + ddl_selectdate.SelectedItem.ToString());

                    Paragraph semester = new Paragraph("Semester : " + ddl_selectsem.SelectedItem.ToString());
                    semester.Font.SetStyle(iTextSharp.text.Font.BOLD);

                    Paragraph subjectname = null;
                    
                    iTextSharp.text.Image gif = iTextSharp.text.Image.GetInstance("logo-light.jpg");
                    gif.ScaleToFit(100, 70);
                    gif.Alignment = iTextSharp.text.Image.UNDERLYING;
                    gif.SetAbsolutePosition(50, 755);
                    
                    if (ddl_selectsubject.SelectedIndex != -1)
                    {
                        subjectname = new Paragraph("Subject Name : " + ddl_selectsubject.SelectedItem.ToString());
                        subjectname.Font.SetStyle(iTextSharp.text.Font.BOLD);
                        subjectname.Add(new Chunk(glue));
                        subjectname.Add("Faculty Name : " + lbl_facultyname.Text);
                    }

                    Paragraph blank = new Paragraph(" ");

                    dkte.Alignment = Element.ALIGN_CENTER;
                    ycp.Alignment = Element.ALIGN_CENTER;
                    feedback.Alignment = Element.ALIGN_CENTER;
                    blank.Alignment = Element.ALIGN_CENTER;

                    doc.Add(gif);
                    doc.Add(dkte);
                    doc.Add(ycp);
                    doc.Add(feedback);
                    doc.Add(line);
                    doc.Add(department);
                    doc.Add(semester);

                    if (ddl_selectsubject.SelectedIndex != -1)
                        doc.Add(subjectname);

                    doc.Add(blank);

                    iTextSharp.text.Font fnt1 = FontFactory.GetFont("Times New Roman", 12, iTextSharp.text.Font.BOLD);
                    iTextSharp.text.Font fnt2 = FontFactory.GetFont("Times New Roman", 10);

                    if (ddl_report.SelectedIndex != 5)
                    {
                        if (dt != null)
                        {
                            PdfPTable PdfTable = new PdfPTable(dt.Columns.Count);
                            PdfPCell PdfPCell = null;
                            PdfPageEventHelper a = new PdfPageEventHelper();
                            a.OnStartPage(writer, doc);

                            PdfTable.HeaderRows = 1;


                            for (int rows = 0; rows < dt.Rows.Count; rows++)
                            {
                                if (rows == 0)
                                {
                                    for (int column = 0; column < dt.Columns.Count; column++)
                                    {
                                        PdfPCell = new PdfPCell(new Phrase(new Chunk(dt.Columns[column].ColumnName.ToString(), fnt1)));

                                        PdfTable.AddCell(PdfPCell);
                                    }
                                }
                                for (int column = 0; column < dt.Columns.Count; column++)
                                {
                                    PdfPCell = new PdfPCell(new Phrase(new Chunk(dt.Rows[rows][column].ToString(), fnt2)));

                                    PdfTable.AddCell(PdfPCell);
                                }

                            }

                            doc.Add(PdfTable);
                        }
                    }
                    else
                    {
                        using (MemoryStream memorystream = new MemoryStream())
                        {
                            cht_faculty.SaveImage(memorystream, ChartImageFormat.Png);
                            iTextSharp.text.Image img = iTextSharp.text.Image.GetInstance(memorystream.GetBuffer());
                            img.ScalePercent(65f);
                            img.SetAbsolutePosition(10, 435); 
                            doc.Add(img);
                        }
                    }
                    doc.Close();

                    MetroMessageBox.Show(Owner, "Report Successfully Saved.", "YCPFeedback", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch(IOException ie)
            {
                MetroMessageBox.Show(Owner, "File is used by another process.", "YCPFeedback", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void ddl_selectsubject_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (ddl_selectsubject.SelectedIndex == -1)
            {
                lbl_facultyname.Text = string.Empty;
                lbl_faculty.Text = string.Empty;
            }
            else
            {
                showFacultyName();
                subjectDataBind(newdate);
            }
        }

        private void showFacultyName()
        {
            string dept = getDepartmentCode();

            query = "Select FacultyName from PerformanceMaster where DepartmentCode = '" + dept + "' and Semester = '" + sem + "' and SubjectName = '" + ddl_selectsubject.SelectedItem.ToString() + "' and Status = '" + ON + "'";

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
                lbl_faculty.Text = "Faculty Name :";
                lbl_facultyname.Text = dr[0].ToString();
            }

            dr.Close();
            cn.Close();
        }

        string getDepartmentCode()
        {
            string newdept = null;
            newdept = dept.Substring(0, 2);
            if (dept.Length == 4)
                newdept = newdept + dept.Substring(3, 1);

            return (newdept);
        }
    }
}
