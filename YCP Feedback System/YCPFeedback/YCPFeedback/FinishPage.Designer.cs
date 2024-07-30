namespace YCPFeedback
{
    partial class FinishPage
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FinishPage));
            this.panel1 = new System.Windows.Forms.Panel();
            this.lnk_logout = new System.Windows.Forms.LinkLabel();
            this.lbl_finishinfo = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.lbl_date = new System.Windows.Forms.Label();
            this.ms_finishinfo = new System.Windows.Forms.MenuStrip();
            this.ms_finishlogout = new System.Windows.Forms.ToolStripMenuItem();
            this.lbl_feedback = new System.Windows.Forms.Label();
            this.lbl_ycpname = new System.Windows.Forms.Label();
            this.lbl_dktename = new System.Windows.Forms.Label();
            this.lineShape1 = new Microsoft.VisualBasic.PowerPacks.LineShape();
            this.shapeContainer1 = new Microsoft.VisualBasic.PowerPacks.ShapeContainer();
            this.panel1.SuspendLayout();
            this.ms_finishinfo.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.lnk_logout);
            this.panel1.Controls.Add(this.lbl_finishinfo);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.lbl_date);
            this.panel1.Controls.Add(this.ms_finishinfo);
            this.panel1.Location = new System.Drawing.Point(20, 123);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1327, 645);
            this.panel1.TabIndex = 19;
            // 
            // lnk_logout
            // 
            this.lnk_logout.AutoSize = true;
            this.lnk_logout.Font = new System.Drawing.Font("Palatino Linotype", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lnk_logout.ForeColor = System.Drawing.Color.DeepSkyBlue;
            this.lnk_logout.LinkArea = new System.Windows.Forms.LinkArea(0, 6);
            this.lnk_logout.LinkBehavior = System.Windows.Forms.LinkBehavior.HoverUnderline;
            this.lnk_logout.LinkColor = System.Drawing.Color.DeepSkyBlue;
            this.lnk_logout.Location = new System.Drawing.Point(569, 266);
            this.lnk_logout.Name = "lnk_logout";
            this.lnk_logout.Size = new System.Drawing.Size(104, 37);
            this.lnk_logout.TabIndex = 12;
            this.lnk_logout.TabStop = true;
            this.lnk_logout.Text = "Logout";
            this.lnk_logout.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lnk_logout.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.lnk_logout_LinkClicked);
            // 
            // lbl_finishinfo
            // 
            this.lbl_finishinfo.AutoSize = true;
            this.lbl_finishinfo.BackColor = System.Drawing.Color.White;
            this.lbl_finishinfo.Font = new System.Drawing.Font("Palatino Linotype", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_finishinfo.Location = new System.Drawing.Point(383, 192);
            this.lbl_finishinfo.Name = "lbl_finishinfo";
            this.lbl_finishinfo.Size = new System.Drawing.Size(507, 28);
            this.lbl_finishinfo.TabIndex = 11;
            this.lbl_finishinfo.Text = "Your Feedback has been Successfully saved please";
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
            // ms_finishinfo
            // 
            this.ms_finishinfo.BackColor = System.Drawing.Color.Gainsboro;
            this.ms_finishinfo.Font = new System.Drawing.Font("Palatino Linotype", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ms_finishinfo.GripMargin = new System.Windows.Forms.Padding(1, 1, 0, 1);
            this.ms_finishinfo.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.ms_finishlogout});
            this.ms_finishinfo.Location = new System.Drawing.Point(0, 0);
            this.ms_finishinfo.Name = "ms_finishinfo";
            this.ms_finishinfo.Size = new System.Drawing.Size(1327, 36);
            this.ms_finishinfo.TabIndex = 0;
            this.ms_finishinfo.Text = "menuStrip1";
            // 
            // ms_finishlogout
            // 
            this.ms_finishlogout.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.ms_finishlogout.ForeColor = System.Drawing.Color.Transparent;
            this.ms_finishlogout.Name = "ms_finishlogout";
            this.ms_finishlogout.Size = new System.Drawing.Size(92, 32);
            this.ms_finishlogout.Text = "Logout";
            // 
            // lbl_feedback
            // 
            this.lbl_feedback.AutoSize = true;
            this.lbl_feedback.Font = new System.Drawing.Font("Times New Roman", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_feedback.ForeColor = System.Drawing.Color.Black;
            this.lbl_feedback.Location = new System.Drawing.Point(546, 76);
            this.lbl_feedback.Name = "lbl_feedback";
            this.lbl_feedback.Size = new System.Drawing.Size(203, 31);
            this.lbl_feedback.TabIndex = 18;
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
            this.lbl_ycpname.TabIndex = 17;
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
            this.lbl_dktename.TabIndex = 16;
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
            this.shapeContainer1.TabIndex = 20;
            this.shapeContainer1.TabStop = false;
            // 
            // FinishPage
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
            this.Name = "FinishPage";
            this.Resizable = false;
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FinishPage_FormClosing);
            this.Load += new System.EventHandler(this.FinishPage_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ms_finishinfo.ResumeLayout(false);
            this.ms_finishinfo.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label lbl_feedback;
        private System.Windows.Forms.Label lbl_ycpname;
        private System.Windows.Forms.Label lbl_dktename;
        private System.Windows.Forms.MenuStrip ms_finishinfo;
        private Microsoft.VisualBasic.PowerPacks.LineShape lineShape1;
        private Microsoft.VisualBasic.PowerPacks.ShapeContainer shapeContainer1;
        private System.Windows.Forms.Label lbl_date;
        private System.Windows.Forms.Label lbl_finishinfo;
        private System.Windows.Forms.LinkLabel lnk_logout;
        private System.Windows.Forms.ToolStripMenuItem ms_finishlogout;
    }
}