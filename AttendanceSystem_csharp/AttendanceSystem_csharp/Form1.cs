using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace AttendanceSystem_csharp
{
    public partial class Dashboard : Form
    {
        public Dashboard()
        {
            InitializeComponent();
            setHoverEffect(btnDashboard);
            setHoverEffect(btnSessions);
            setHoverEffect(btnReports);
            setHoverEffect(btnSettings);
            AddCloseHover(btnClose);
            AddMinimizeHover(btnMinimize);
        }
        private void setHoverEffect(Button btn)
        {
            btn.MouseEnter += (s, e) => { btn.BackColor = Color.FromArgb(80, 90, 120); };
            btn.MouseLeave += (s, e) => { btn.BackColor = Color.FromArgb(65, 75, 100); };
        }

        private void AddCloseHover(Button btn)
        {
            btn.MouseEnter += (s, e) =>
            {
                btn.BackColor = Color.FromArgb(200, 50, 50);
            };
            btn.MouseLeave += (s, e) => { btn.BackColor = Color.FromArgb(30, 40, 55); };
        }

        private void AddMinimizeHover(Button btn)
        {
            btn.MouseEnter += (s, e) =>
            {
                btn.BackColor = Color.FromArgb(45, 55, 75);
            };
            btn.MouseLeave += (s, e) => { btn.BackColor = Color.FromArgb(30, 40, 55); };
        }

        private void button1_Click(object sender, EventArgs e)
        {
         
        }

        private void Dashboard_Load(object sender, EventArgs e)
        {
           
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnMinimize_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void btnSessions_Click(object sender, EventArgs e)
        {
            SessionsForm sf = new SessionsForm();
            sf.ShowDialog(); //يضهر فورم الجلسات فوق الداشبورد
        }

        private void btnReports_Click(object sender, EventArgs e)
        {
            ReportsForm rf = new ReportsForm();
            rf.ShowDialog();
        }

        private void btnSettings_Click(object sender, EventArgs e)
        {
            SettingsForm sf = new SettingsForm();
            sf.ShowDialog();
        }

        private void bgPicture_Click(object sender, EventArgs e)
        {

        }
    }
}
