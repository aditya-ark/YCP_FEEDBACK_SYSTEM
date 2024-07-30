namespace YCPFeedback
{
    partial class StudentBatch
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
            this.lbl_selectsubject = new System.Windows.Forms.Label();
            this.ddl_selectbatch = new MetroFramework.Controls.MetroComboBox();
            this.SuspendLayout();
            // 
            // lbl_selectsubject
            // 
            this.lbl_selectsubject.AutoSize = true;
            this.lbl_selectsubject.BackColor = System.Drawing.Color.White;
            this.lbl_selectsubject.Font = new System.Drawing.Font("Palatino Linotype", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_selectsubject.Location = new System.Drawing.Point(54, 21);
            this.lbl_selectsubject.Name = "lbl_selectsubject";
            this.lbl_selectsubject.Size = new System.Drawing.Size(156, 36);
            this.lbl_selectsubject.TabIndex = 3;
            this.lbl_selectsubject.Text = "Select Batch";
            // 
            // ddl_selectbatch
            // 
            this.ddl_selectbatch.FontSize = MetroFramework.MetroComboBoxSize.Tall;
            this.ddl_selectbatch.FormattingEnabled = true;
            this.ddl_selectbatch.IntegralHeight = false;
            this.ddl_selectbatch.ItemHeight = 29;
            this.ddl_selectbatch.Items.AddRange(new object[] {
            "1",
            "2"});
            this.ddl_selectbatch.Location = new System.Drawing.Point(61, 80);
            this.ddl_selectbatch.Name = "ddl_selectbatch";
            this.ddl_selectbatch.Size = new System.Drawing.Size(141, 35);
            this.ddl_selectbatch.TabIndex = 4;
            this.ddl_selectbatch.UseSelectable = true;
            this.ddl_selectbatch.SelectedIndexChanged += new System.EventHandler(this.ddl_selectbatch_SelectedIndexChanged);
            // 
            // StudentBatch
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(284, 262);
            this.Controls.Add(this.ddl_selectbatch);
            this.Controls.Add(this.lbl_selectsubject);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Movable = false;
            this.Name = "StudentBatch";
            this.Resizable = false;
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.StudentBatch_FormClosing);
            this.Load += new System.EventHandler(this.StudentBatch_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lbl_selectsubject;
        private MetroFramework.Controls.MetroComboBox ddl_selectbatch;
    }
}