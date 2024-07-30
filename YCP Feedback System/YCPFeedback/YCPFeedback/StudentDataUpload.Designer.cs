namespace YCPFeedback
{
    partial class StudentDataUpload
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(StudentDataUpload));
            this.ms_datauploadlogout = new System.Windows.Forms.ToolStripMenuItem();
            this.label1 = new System.Windows.Forms.Label();
            this.lbl_date = new System.Windows.Forms.Label();
            this.ms_dataupload = new System.Windows.Forms.MenuStrip();
            this.panel1 = new System.Windows.Forms.Panel();
            this.pnl_maindataupload = new System.Windows.Forms.Panel();
            this.btn_previous = new MetroFramework.Controls.MetroButton();
            this.btn_upload = new MetroFramework.Controls.MetroButton();
            this.btn_delete = new MetroFramework.Controls.MetroButton();
            this.ddl_selectsem = new MetroFramework.Controls.MetroComboBox();
            this.lbl_selectsem = new System.Windows.Forms.Label();
            this.ddl_selectdept = new MetroFramework.Controls.MetroComboBox();
            this.lbl_selectdept = new System.Windows.Forms.Label();
            this.lbl_datauploadinfo = new System.Windows.Forms.Label();
            this.lbl_feedback = new System.Windows.Forms.Label();
            this.lbl_ycpname = new System.Windows.Forms.Label();
            this.lbl_dktename = new System.Windows.Forms.Label();
            this.lineShape1 = new Microsoft.VisualBasic.PowerPacks.LineShape();
            this.shapeContainer1 = new Microsoft.VisualBasic.PowerPacks.ShapeContainer();
            this.ms_dataupload.SuspendLayout();
            this.panel1.SuspendLayout();
            this.pnl_maindataupload.SuspendLayout();
            this.SuspendLayout();
            // 
            // ms_datauploadlogout
            // 
            this.ms_datauploadlogout.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.ms_datauploadlogout.Name = "ms_datauploadlogout";
            this.ms_datauploadlogout.Size = new System.Drawing.Size(92, 32);
            this.ms_datauploadlogout.Text = "Logout";
            this.ms_datauploadlogout.Click += new System.EventHandler(this.ms_datauploadlogout_Click);
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
            // ms_dataupload
            // 
            this.ms_dataupload.BackColor = System.Drawing.Color.Gainsboro;
            this.ms_dataupload.Font = new System.Drawing.Font("Palatino Linotype", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ms_dataupload.GripMargin = new System.Windows.Forms.Padding(1, 1, 0, 1);
            this.ms_dataupload.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.ms_datauploadlogout});
            this.ms_dataupload.Location = new System.Drawing.Point(0, 0);
            this.ms_dataupload.Name = "ms_dataupload";
            this.ms_dataupload.Size = new System.Drawing.Size(1327, 36);
            this.ms_dataupload.TabIndex = 0;
            this.ms_dataupload.Text = "menuStrip1";
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.pnl_maindataupload);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.lbl_date);
            this.panel1.Controls.Add(this.ms_dataupload);
            this.panel1.Location = new System.Drawing.Point(20, 123);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1327, 645);
            this.panel1.TabIndex = 14;
            // 
            // pnl_maindataupload
            // 
            this.pnl_maindataupload.AutoScroll = true;
            this.pnl_maindataupload.Controls.Add(this.btn_previous);
            this.pnl_maindataupload.Controls.Add(this.btn_upload);
            this.pnl_maindataupload.Controls.Add(this.btn_delete);
            this.pnl_maindataupload.Controls.Add(this.ddl_selectsem);
            this.pnl_maindataupload.Controls.Add(this.lbl_selectsem);
            this.pnl_maindataupload.Controls.Add(this.ddl_selectdept);
            this.pnl_maindataupload.Controls.Add(this.lbl_selectdept);
            this.pnl_maindataupload.Controls.Add(this.lbl_datauploadinfo);
            this.pnl_maindataupload.Location = new System.Drawing.Point(0, 36);
            this.pnl_maindataupload.Name = "pnl_maindataupload";
            this.pnl_maindataupload.Size = new System.Drawing.Size(1327, 597);
            this.pnl_maindataupload.TabIndex = 206;
            // 
            // btn_previous
            // 
            this.btn_previous.BackColor = System.Drawing.Color.White;
            this.btn_previous.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btn_previous.BackgroundImage")));
            this.btn_previous.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btn_previous.FontSize = MetroFramework.MetroButtonSize.Tall;
            this.btn_previous.ForeColor = System.Drawing.Color.DimGray;
            this.btn_previous.Location = new System.Drawing.Point(14, 554);
            this.btn_previous.Name = "btn_previous";
            this.btn_previous.Size = new System.Drawing.Size(149, 43);
            this.btn_previous.Style = MetroFramework.MetroColorStyle.Blue;
            this.btn_previous.TabIndex = 319;
            this.btn_previous.UseCustomBackColor = true;
            this.btn_previous.UseCustomForeColor = true;
            this.btn_previous.UseSelectable = true;
            this.btn_previous.UseStyleColors = true;
            this.btn_previous.Click += new System.EventHandler(this.btn_previous_Click);
            // 
            // btn_upload
            // 
            this.btn_upload.BackColor = System.Drawing.Color.White;
            this.btn_upload.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btn_upload.BackgroundImage")));
            this.btn_upload.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btn_upload.Enabled = false;
            this.btn_upload.FontSize = MetroFramework.MetroButtonSize.Tall;
            this.btn_upload.ForeColor = System.Drawing.Color.DimGray;
            this.btn_upload.Location = new System.Drawing.Point(465, 336);
            this.btn_upload.Name = "btn_upload";
            this.btn_upload.Size = new System.Drawing.Size(124, 49);
            this.btn_upload.Style = MetroFramework.MetroColorStyle.Blue;
            this.btn_upload.TabIndex = 318;
            this.btn_upload.UseCustomBackColor = true;
            this.btn_upload.UseCustomForeColor = true;
            this.btn_upload.UseSelectable = true;
            this.btn_upload.UseStyleColors = true;
            this.btn_upload.Click += new System.EventHandler(this.btn_upload_Click);
            // 
            // btn_delete
            // 
            this.btn_delete.BackColor = System.Drawing.Color.White;
            this.btn_delete.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btn_delete.BackgroundImage")));
            this.btn_delete.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btn_delete.Enabled = false;
            this.btn_delete.FontSize = MetroFramework.MetroButtonSize.Tall;
            this.btn_delete.ForeColor = System.Drawing.Color.DimGray;
            this.btn_delete.Location = new System.Drawing.Point(644, 336);
            this.btn_delete.Name = "btn_delete";
            this.btn_delete.Size = new System.Drawing.Size(120, 49);
            this.btn_delete.Style = MetroFramework.MetroColorStyle.Blue;
            this.btn_delete.TabIndex = 317;
            this.btn_delete.UseCustomBackColor = true;
            this.btn_delete.UseCustomForeColor = true;
            this.btn_delete.UseSelectable = true;
            this.btn_delete.UseStyleColors = true;
            this.btn_delete.Click += new System.EventHandler(this.btn_delete_Click);
            // 
            // ddl_selectsem
            // 
            this.ddl_selectsem.FontSize = MetroFramework.MetroComboBoxSize.Tall;
            this.ddl_selectsem.FormattingEnabled = true;
            this.ddl_selectsem.IntegralHeight = false;
            this.ddl_selectsem.ItemHeight = 29;
            this.ddl_selectsem.Location = new System.Drawing.Point(639, 209);
            this.ddl_selectsem.Name = "ddl_selectsem";
            this.ddl_selectsem.Size = new System.Drawing.Size(125, 35);
            this.ddl_selectsem.TabIndex = 315;
            this.ddl_selectsem.UseSelectable = true;
            this.ddl_selectsem.SelectedIndexChanged += new System.EventHandler(this.ddl_selectsem_SelectedIndexChanged);
            // 
            // lbl_selectsem
            // 
            this.lbl_selectsem.AutoSize = true;
            this.lbl_selectsem.BackColor = System.Drawing.Color.White;
            this.lbl_selectsem.Font = new System.Drawing.Font("Palatino Linotype", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_selectsem.Location = new System.Drawing.Point(460, 216);
            this.lbl_selectsem.Name = "lbl_selectsem";
            this.lbl_selectsem.Size = new System.Drawing.Size(173, 28);
            this.lbl_selectsem.TabIndex = 314;
            this.lbl_selectsem.Text = "Select Semester :";
            // 
            // ddl_selectdept
            // 
            this.ddl_selectdept.FontSize = MetroFramework.MetroComboBoxSize.Tall;
            this.ddl_selectdept.FormattingEnabled = true;
            this.ddl_selectdept.IntegralHeight = false;
            this.ddl_selectdept.ItemHeight = 29;
            this.ddl_selectdept.Location = new System.Drawing.Point(639, 119);
            this.ddl_selectdept.Name = "ddl_selectdept";
            this.ddl_selectdept.Size = new System.Drawing.Size(125, 35);
            this.ddl_selectdept.TabIndex = 313;
            this.ddl_selectdept.UseSelectable = true;
            this.ddl_selectdept.DrawItem += new System.Windows.Forms.DrawItemEventHandler(this.ddl_selectdept_DrawItem);
            this.ddl_selectdept.SelectedIndexChanged += new System.EventHandler(this.ddl_selectdept_SelectedIndexChanged);
            // 
            // lbl_selectdept
            // 
            this.lbl_selectdept.AutoSize = true;
            this.lbl_selectdept.BackColor = System.Drawing.Color.White;
            this.lbl_selectdept.Font = new System.Drawing.Font("Palatino Linotype", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_selectdept.Location = new System.Drawing.Point(440, 126);
            this.lbl_selectdept.Name = "lbl_selectdept";
            this.lbl_selectdept.Size = new System.Drawing.Size(193, 28);
            this.lbl_selectdept.TabIndex = 1;
            this.lbl_selectdept.Text = "Select Depatment :";
            // 
            // lbl_datauploadinfo
            // 
            this.lbl_datauploadinfo.AutoSize = true;
            this.lbl_datauploadinfo.BackColor = System.Drawing.Color.DeepSkyBlue;
            this.lbl_datauploadinfo.Font = new System.Drawing.Font("Palatino Linotype", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_datauploadinfo.ForeColor = System.Drawing.Color.White;
            this.lbl_datauploadinfo.Location = new System.Drawing.Point(24, 17);
            this.lbl_datauploadinfo.Name = "lbl_datauploadinfo";
            this.lbl_datauploadinfo.Size = new System.Drawing.Size(1259, 28);
            this.lbl_datauploadinfo.TabIndex = 274;
            this.lbl_datauploadinfo.Text = resources.GetString("lbl_datauploadinfo.Text");
            // 
            // lbl_feedback
            // 
            this.lbl_feedback.AutoSize = true;
            this.lbl_feedback.Font = new System.Drawing.Font("Times New Roman", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_feedback.ForeColor = System.Drawing.Color.Black;
            this.lbl_feedback.Location = new System.Drawing.Point(546, 76);
            this.lbl_feedback.Name = "lbl_feedback";
            this.lbl_feedback.Size = new System.Drawing.Size(203, 31);
            this.lbl_feedback.TabIndex = 13;
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
            this.lbl_ycpname.TabIndex = 12;
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
            this.lbl_dktename.TabIndex = 11;
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
            this.shapeContainer1.TabIndex = 16;
            this.shapeContainer1.TabStop = false;
            // 
            // StudentDataUpload
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
            this.Name = "StudentDataUpload";
            this.Resizable = false;
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.DataUpload_FormClosing);
            this.Load += new System.EventHandler(this.DataUpload_Load);
            this.ms_dataupload.ResumeLayout(false);
            this.ms_dataupload.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.pnl_maindataupload.ResumeLayout(false);
            this.pnl_maindataupload.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ToolStripMenuItem ms_datauploadlogout;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label lbl_date;
        private System.Windows.Forms.MenuStrip ms_dataupload;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label lbl_feedback;
        private System.Windows.Forms.Label lbl_ycpname;
        private System.Windows.Forms.Label lbl_dktename;
        private System.Windows.Forms.Panel pnl_maindataupload;
        private System.Windows.Forms.Label lbl_datauploadinfo;
        private MetroFramework.Controls.MetroComboBox ddl_selectdept;
        private System.Windows.Forms.Label lbl_selectdept;
        private MetroFramework.Controls.MetroComboBox ddl_selectsem;
        private System.Windows.Forms.Label lbl_selectsem;
        private Microsoft.VisualBasic.PowerPacks.LineShape lineShape1;
        private Microsoft.VisualBasic.PowerPacks.ShapeContainer shapeContainer1;
        private MetroFramework.Controls.MetroButton btn_upload;
        private MetroFramework.Controls.MetroButton btn_delete;
        private MetroFramework.Controls.MetroButton btn_previous;
    }
}