using MetroFramework.Forms;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Runtime.InteropServices;
using System.Configuration;
using MetroFramework;
using System.Data.Sql;

namespace YCPFeedback
{
    public partial class Logo : MetroForm
    {
        public static string connection = null, date = null;
        
        public Logo()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            connection = ConfigurationManager.ConnectionStrings["YCPFeedback.Properties.Settings.YCPFeedbackDBConnectionString"].ConnectionString;
            
            Taskbar.Hide();
            
            TopMost = true;

            string currentyear = DateTime.Now.Year.ToString();
            int newyear = int.Parse(currentyear.Substring(2,2));
            DateTime value = new DateTime(int.Parse(currentyear),06,01);

            if (DateTime.Now > value)
            {
                date = currentyear + "-" + (newyear + 1);
                lbl_ayear.Text = date;
            }
            else
            {
                //date = (newyear - 1) + "-" + currentyear;
                date = "20" + (newyear - 1) + "-" + currentyear.Substring(2, 2);
                lbl_ayear.Text = date;
            }
        }

        private void tmr_redirect_Tick(object sender, EventArgs e)
        {
            HomePage frm_homepage = new HomePage();
            tmr_redirect.Enabled = false;
            frm_homepage.Show();
            this.Hide();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void Logo_FormClosing(object sender, FormClosingEventArgs e)
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

    public class Taskbar
    {
        [DllImport("user32.dll")]
        private static extern int FindWindow(string className, string windowText);

        [DllImport("user32.dll")]
        private static extern int ShowWindow(int hwnd, int command);

        [DllImport("user32.dll")]
        public static extern int FindWindowEx(int parentHandle, int childAfter, string className, int windowTitle);

        [DllImport("user32.dll")]
        private static extern int GetDesktopWindow();

        private const int SW_HIDE = 0;
        private const int SW_SHOW = 1;

        protected static int Handle
        {
            get
            {
                return FindWindow("Shell_TrayWnd", "");
            }
        }

        protected static int HandleOfStartButton
        {
            get
            {
                int handleOfDesktop = GetDesktopWindow();
                int handleOfStartButton = FindWindowEx(handleOfDesktop, 0, "button", 0);
                return handleOfStartButton;
            }
        }

        private Taskbar()
        {
            
        }

        public static void Show()
        {
            ShowWindow(Handle, SW_SHOW);
            ShowWindow(HandleOfStartButton, SW_SHOW);
        }

        public static void Hide()
        {
            ShowWindow(Handle, SW_HIDE);
            ShowWindow(HandleOfStartButton, SW_HIDE);
        }
    }
}
