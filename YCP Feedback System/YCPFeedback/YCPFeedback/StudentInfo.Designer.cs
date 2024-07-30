namespace YCPFeedback
{
    partial class StudentInfo
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(StudentInfo));
            this.label1 = new System.Windows.Forms.Label();
            this.lbl_name = new System.Windows.Forms.Label();
            this.lbl_date = new System.Windows.Forms.Label();
            this.ms_studentinfo = new System.Windows.Forms.MenuStrip();
            this.ms_studentlogout = new System.Windows.Forms.ToolStripMenuItem();
            this.panel1 = new System.Windows.Forms.Panel();
            this.label2 = new System.Windows.Forms.Label();
            this.lbl_instruction = new System.Windows.Forms.Label();
            this.btn_proceed = new MetroFramework.Controls.MetroButton();
            this.lbl_studsem = new System.Windows.Forms.Label();
            this.lbl_semester = new System.Windows.Forms.Label();
            this.lbl_studdept = new System.Windows.Forms.Label();
            this.lbl_studenr = new System.Windows.Forms.Label();
            this.lbl_studname = new System.Windows.Forms.Label();
            this.lbl_department = new System.Windows.Forms.Label();
            this.lbl_enrollmentno = new System.Windows.Forms.Label();
            this.lbl_studentinfo = new System.Windows.Forms.Label();
            this.shapeContainer2 = new Microsoft.VisualBasic.PowerPacks.ShapeContainer();
            this.lineShape2 = new Microsoft.VisualBasic.PowerPacks.LineShape();
            this.lbl_feedback = new System.Windows.Forms.Label();
            this.lbl_ycpname = new System.Windows.Forms.Label();
            this.lbl_dktename = new System.Windows.Forms.Label();
            this.lineShape1 = new Microsoft.VisualBasic.PowerPacks.LineShape();
            this.shapeContainer1 = new Microsoft.VisualBasic.PowerPacks.ShapeContainer();
            this.ms_studentinfo.SuspendLayout();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Gainsboro;
            this.label1.Font = new System.Drawing.Font("Palatino Linotype", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(9, 5);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(67, 28);
            this.label1.TabIndex = 10;
            this.label1.Text = "Date :";
            // 
            // lbl_name
            // 
            this.lbl_name.AutoSize = true;
            this.lbl_name.BackColor = System.Drawing.Color.White;
            this.lbl_name.Font = new System.Drawing.Font("Palatino Linotype", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_name.Location = new System.Drawing.Point(32, 93);
            this.lbl_name.Name = "lbl_name";
            this.lbl_name.Size = new System.Drawing.Size(162, 28);
            this.lbl_name.TabIndex = 2;
            this.lbl_name.Text = "Student Name :";
            // 
            // lbl_date
            // 
            this.lbl_date.AutoSize = true;
            this.lbl_date.BackColor = System.Drawing.Color.Gainsboro;
            this.lbl_date.Font = new System.Drawing.Font("Palatino Linotype", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_date.Location = new System.Drawing.Point(75, 5);
            this.lbl_date.Name = "lbl_date";
            this.lbl_date.Size = new System.Drawing.Size(114, 28);
            this.lbl_date.TabIndex = 1;
            this.lbl_date.Text = "17/05/2016";
            // 
            // ms_studentinfo
            // 
            this.ms_studentinfo.BackColor = System.Drawing.Color.Gainsboro;
            this.ms_studentinfo.Font = new System.Drawing.Font("Palatino Linotype", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ms_studentinfo.GripMargin = new System.Windows.Forms.Padding(1, 1, 0, 1);
            this.ms_studentinfo.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.ms_studentlogout});
            this.ms_studentinfo.Location = new System.Drawing.Point(0, 0);
            this.ms_studentinfo.Name = "ms_studentinfo";
            this.ms_studentinfo.Size = new System.Drawing.Size(1327, 36);
            this.ms_studentinfo.TabIndex = 0;
            this.ms_studentinfo.Text = "menuStrip1";
            // 
            // ms_studentlogout
            // 
            this.ms_studentlogout.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.ms_studentlogout.Name = "ms_studentlogout";
            this.ms_studentlogout.Size = new System.Drawing.Size(92, 32);
            this.ms_studentlogout.Text = "Logout";
            this.ms_studentlogout.Click += new System.EventHandler(this.ms_studentlogout_Click);
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.lbl_instruction);
            this.panel1.Controls.Add(this.btn_proceed);
            this.panel1.Controls.Add(this.lbl_studsem);
            this.panel1.Controls.Add(this.lbl_semester);
            this.panel1.Controls.Add(this.lbl_studdept);
            this.panel1.Controls.Add(this.lbl_studenr);
            this.panel1.Controls.Add(this.lbl_studname);
            this.panel1.Controls.Add(this.lbl_department);
            this.panel1.Controls.Add(this.lbl_enrollmentno);
            this.panel1.Controls.Add(this.lbl_studentinfo);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.lbl_name);
            this.panel1.Controls.Add(this.lbl_date);
            this.panel1.Controls.Add(this.ms_studentinfo);
            this.panel1.Controls.Add(this.shapeContainer2);
            this.panel1.Location = new System.Drawing.Point(20, 123);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1327, 645);
            this.panel1.TabIndex = 15;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.White;
            this.label2.Font = new System.Drawing.Font("Palatino Linotype", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.Red;
            this.label2.Location = new System.Drawing.Point(24, 302);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(500, 28);
            this.label2.TabIndex = 314;
            this.label2.Text = "Click on Proceed Button if above Details are correct";
            // 
            // lbl_instruction
            // 
            this.lbl_instruction.AutoSize = true;
            this.lbl_instruction.BackColor = System.Drawing.Color.White;
            this.lbl_instruction.Font = new System.Drawing.Font("Palatino Linotype", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_instruction.ForeColor = System.Drawing.Color.Red;
            this.lbl_instruction.Location = new System.Drawing.Point(24, 254);
            this.lbl_instruction.Name = "lbl_instruction";
            this.lbl_instruction.Size = new System.Drawing.Size(128, 28);
            this.lbl_instruction.TabIndex = 313;
            this.lbl_instruction.Text = "Instruction :";
            // 
            // btn_proceed
            // 
            this.btn_proceed.BackColor = System.Drawing.Color.White;
            this.btn_proceed.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btn_proceed.BackgroundImage")));
            this.btn_proceed.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btn_proceed.FontSize = MetroFramework.MetroButtonSize.Tall;
            this.btn_proceed.ForeColor = System.Drawing.Color.DimGray;
            this.btn_proceed.Location = new System.Drawing.Point(576, 402);
            this.btn_proceed.Name = "btn_proceed";
            this.btn_proceed.Size = new System.Drawing.Size(143, 49);
            this.btn_proceed.Style = MetroFramework.MetroColorStyle.Blue;
            this.btn_proceed.TabIndex = 311;
            this.btn_proceed.UseCustomBackColor = true;
            this.btn_proceed.UseCustomForeColor = true;
            this.btn_proceed.UseSelectable = true;
            this.btn_proceed.UseStyleColors = true;
            this.btn_proceed.Click += new System.EventHandler(this.btn_proceed_Click);
            // 
            // lbl_studsem
            // 
            this.lbl_studsem.AutoSize = true;
            this.lbl_studsem.BackColor = System.Drawing.Color.White;
            this.lbl_studsem.Font = new System.Drawing.Font("Palatino Linotype", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_studsem.Location = new System.Drawing.Point(1044, 189);
            this.lbl_studsem.Name = "lbl_studsem";
            this.lbl_studsem.Size = new System.Drawing.Size(23, 28);
            this.lbl_studsem.TabIndex = 48;
            this.lbl_studsem.Text = "6";
            // 
            // lbl_semester
            // 
            this.lbl_semester.AutoSize = true;
            this.lbl_semester.BackColor = System.Drawing.Color.White;
            this.lbl_semester.Font = new System.Drawing.Font("Palatino Linotype", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_semester.Location = new System.Drawing.Point(922, 189);
            this.lbl_semester.Name = "lbl_semester";
            this.lbl_semester.Size = new System.Drawing.Size(111, 28);
            this.lbl_semester.TabIndex = 47;
            this.lbl_semester.Text = "Semester :";
            // 
            // lbl_studdept
            // 
            this.lbl_studdept.AutoSize = true;
            this.lbl_studdept.BackColor = System.Drawing.Color.White;
            this.lbl_studdept.Font = new System.Drawing.Font("Palatino Linotype", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_studdept.Location = new System.Drawing.Point(200, 189);
            this.lbl_studdept.Name = "lbl_studdept";
            this.lbl_studdept.Size = new System.Drawing.Size(363, 28);
            this.lbl_studdept.TabIndex = 46;
            this.lbl_studdept.Text = "Computer Science and Engineering";
            // 
            // lbl_studenr
            // 
            this.lbl_studenr.AutoSize = true;
            this.lbl_studenr.BackColor = System.Drawing.Color.White;
            this.lbl_studenr.Font = new System.Drawing.Font("Palatino Linotype", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_studenr.Location = new System.Drawing.Point(200, 141);
            this.lbl_studenr.Name = "lbl_studenr";
            this.lbl_studenr.Size = new System.Drawing.Size(122, 28);
            this.lbl_studenr.TabIndex = 45;
            this.lbl_studenr.Text = "1315770030";
            // 
            // lbl_studname
            // 
            this.lbl_studname.AutoSize = true;
            this.lbl_studname.BackColor = System.Drawing.Color.White;
            this.lbl_studname.Font = new System.Drawing.Font("Palatino Linotype", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_studname.Location = new System.Drawing.Point(200, 93);
            this.lbl_studname.Name = "lbl_studname";
            this.lbl_studname.Size = new System.Drawing.Size(238, 28);
            this.lbl_studname.TabIndex = 44;
            this.lbl_studname.Text = "Aditya Raju Karmalkar";
            // 
            // lbl_department
            // 
            this.lbl_department.AutoSize = true;
            this.lbl_department.BackColor = System.Drawing.Color.White;
            this.lbl_department.Font = new System.Drawing.Font("Palatino Linotype", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_department.Location = new System.Drawing.Point(50, 189);
            this.lbl_department.Name = "lbl_department";
            this.lbl_department.Size = new System.Drawing.Size(139, 28);
            this.lbl_department.TabIndex = 43;
            this.lbl_department.Text = "Department :";
            // 
            // lbl_enrollmentno
            // 
            this.lbl_enrollmentno.AutoSize = true;
            this.lbl_enrollmentno.BackColor = System.Drawing.Color.White;
            this.lbl_enrollmentno.Font = new System.Drawing.Font("Palatino Linotype", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_enrollmentno.Location = new System.Drawing.Point(24, 141);
            this.lbl_enrollmentno.Name = "lbl_enrollmentno";
            this.lbl_enrollmentno.Size = new System.Drawing.Size(170, 28);
            this.lbl_enrollmentno.TabIndex = 42;
            this.lbl_enrollmentno.Text = "Enrollment No. :";
            // 
            // lbl_studentinfo
            // 
            this.lbl_studentinfo.AutoSize = true;
            this.lbl_studentinfo.BackColor = System.Drawing.Color.DeepSkyBlue;
            this.lbl_studentinfo.Font = new System.Drawing.Font("Palatino Linotype", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_studentinfo.ForeColor = System.Drawing.Color.White;
            this.lbl_studentinfo.Location = new System.Drawing.Point(24, 45);
            this.lbl_studentinfo.Name = "lbl_studentinfo";
            this.lbl_studentinfo.Size = new System.Drawing.Size(1275, 28);
            this.lbl_studentinfo.TabIndex = 41;
            this.lbl_studentinfo.Text = resources.GetString("lbl_studentinfo.Text");
            // 
            // shapeContainer2
            // 
            this.shapeContainer2.Location = new System.Drawing.Point(0, 0);
            this.shapeContainer2.Margin = new System.Windows.Forms.Padding(0);
            this.shapeContainer2.Name = "shapeContainer2";
            this.shapeContainer2.Shapes.AddRange(new Microsoft.VisualBasic.PowerPacks.Shape[] {
            this.lineShape2});
            this.shapeContainer2.Size = new System.Drawing.Size(1327, 645);
            this.shapeContainer2.TabIndex = 312;
            this.shapeContainer2.TabStop = false;
            // 
            // lineShape2
            // 
            this.lineShape2.BorderColor = System.Drawing.SystemColors.ActiveBorder;
            this.lineShape2.Name = "lineShape2";
            this.lineShape2.X1 = 24;
            this.lineShape2.X2 = 1300;
            this.lineShape2.Y1 = 237;
            this.lineShape2.Y2 = 237;
            // 
            // lbl_feedback
            // 
            this.lbl_feedback.AutoSize = true;
            this.lbl_feedback.Font = new System.Drawing.Font("Times New Roman", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_feedback.ForeColor = System.Drawing.Color.Black;
            this.lbl_feedback.Location = new System.Drawing.Point(546, 76);
            this.lbl_feedback.Name = "lbl_feedback";
            this.lbl_feedback.Size = new System.Drawing.Size(203, 31);
            this.lbl_feedback.TabIndex = 14;
            this.lbl_feedback.Text = "Feedback System";
            // 
            // lbl_ycpname
            // 
            this.lbl_ycpname.AutoSize = true;
            this.lbl_ycpname.Font = new System.Drawing.Font("Times New Roman", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_ycpname.ForeColor = System.Drawing.Color.Black;
            this.lbl_ycpname.Location = new System.Drawing.Point(391, 45);
            this.lbl_ycpname.Name = "lbl_ycpname";
            this.lbl_ycpname.Size = new System.Drawing.Size(517, 31);
            this.lbl_ycpname.TabIndex = 13;
            this.lbl_ycpname.Text = "YASHWANTRAO CHAVAN POLYTECHNIC";
            // 
            // lbl_dktename
            // 
            this.lbl_dktename.AutoSize = true;
            this.lbl_dktename.Font = new System.Drawing.Font("Times New Roman", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_dktename.ForeColor = System.Drawing.Color.Black;
            this.lbl_dktename.Location = new System.Drawing.Point(525, 14);
            this.lbl_dktename.Name = "lbl_dktename";
            this.lbl_dktename.Size = new System.Drawing.Size(249, 31);
            this.lbl_dktename.TabIndex = 12;
            this.lbl_dktename.Text = "D.K.T.E. SOCIETY\'S";
            // 
            // lineShape1
            // 
            this.lineShape1.BorderColor = System.Drawing.SystemColors.ActiveBorder;
            this.lineShape1.Name = "lineShape1";
            this.lineShape1.X1 = -19;
            this.lineShape1.X2 = 1326;
            this.lineShape1.Y1 = 54;
            this.lineShape1.Y2 = 54;
            // 
            // shapeContainer1
            // 
            this.shapeContainer1.Location = new System.Drawing.Point(20, 60);
            this.shapeContainer1.Margin = new System.Windows.Forms.Padding(0);
            this.shapeContainer1.Name = "shapeContainer1";
            this.shapeContainer1.Shapes.AddRange(new Microsoft.VisualBasic.PowerPacks.Shape[] {
            this.lineShape1});
            this.shapeContainer1.Size = new System.Drawing.Size(1326, 688);
            this.shapeContainer1.TabIndex = 18;
            this.shapeContainer1.TabStop = false;
            // 
            // StudentInfo
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackImage = ((System.Drawing.Image)(resources.GetObject("$this.BackImage")));
            this.BackImagePadding = new System.Windows.Forms.Padding(60, 15, 0, 0);
            this.BackMaxSize = 200;
            this.ClientSize = new System.Drawing.Size(1366, 768);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.lbl_feedback);
            this.Controls.Add(this.lbl_ycpname);
            this.Controls.Add(this.lbl_dktename);
            this.Controls.Add(this.shapeContainer1);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Movable = false;
            this.Name = "StudentInfo";
            this.Resizable = false;
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.StudentInfo_FormClosing);
            this.Load += new System.EventHandler(this.StudentInfo_Load);
            this.ms_studentinfo.ResumeLayout(false);
            this.ms_studentinfo.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label lbl_name;
        private System.Windows.Forms.Label lbl_date;
        private System.Windows.Forms.MenuStrip ms_studentinfo;
        private System.Windows.Forms.ToolStripMenuItem ms_studentlogout;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label lbl_feedback;
        private System.Windows.Forms.Label lbl_ycpname;
        private System.Windows.Forms.Label lbl_dktename;
        private Microsoft.VisualBasic.PowerPacks.LineShape lineShape1;
        private Microsoft.VisualBasic.PowerPacks.ShapeContainer shapeContainer1;
        private System.Windows.Forms.Label lbl_studentinfo;
        private System.Windows.Forms.Label lbl_enrollmentno;
        private System.Windows.Forms.Label lbl_department;
        private System.Windows.Forms.Label lbl_studname;
        private System.Windows.Forms.Label lbl_studenr;
        private System.Windows.Forms.Label lbl_studdept;
        private System.Windows.Forms.Label lbl_studsem;
        private System.Windows.Forms.Label lbl_semester;
        private MetroFramework.Controls.MetroButton btn_proceed;
        private Microsoft.VisualBasic.PowerPacks.ShapeContainer shapeContainer2;
        private Microsoft.VisualBasic.PowerPacks.LineShape lineShape2;
        private System.Windows.Forms.Label lbl_instruction;
        private System.Windows.Forms.Label label2;

    }
}