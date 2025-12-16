using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AttendanceSystem_csharp
{
    public partial class SettingsForm : Form
    {
        public SettingsForm()
        {
            InitializeComponent();
            AddCloseHover(btnClose);
        }
        private void AddCloseHover(Button btn)
        {
            btn.MouseEnter += (s, e) =>
            {
                btn.BackColor = Color.FromArgb(200, 50, 50);
            };
            btn.MouseLeave += (s, e) => { btn.BackColor = Color.FromArgb(30, 40, 55); };
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnOpenQRCodes_Click(object sender, EventArgs e)
        {
            try
            {
                string folderPath = Path.Combine(Application.StartupPath, @"..\..\qr_codes");
                folderPath = Path.GetFullPath(folderPath);
                if(!Directory.Exists(folderPath))
                    Directory.CreateDirectory(folderPath);
                System.Diagnostics.Process.Start("explorer.exe", folderPath);
            }
            catch (Exception ex) { 
                DB.LogError(ex);
                MessageBox.Show("حدث خطا اثناء فتح المجلد ","خطأ",MessageBoxButtons.OK,MessageBoxIcon.Error);
            }
        }

        private void btnOpenLogsFolder_Click(object sender, EventArgs e)
        {
            try
            {
                string folderPath = Path.Combine(Application.StartupPath, @"..\..\logs");
                folderPath = Path.GetFullPath(folderPath);
                if (!Directory.Exists(folderPath))
                    Directory.CreateDirectory(folderPath);
                System.Diagnostics.Process.Start("explorer.exe", folderPath);
            }
            catch (Exception ex)
            {
                DB.LogError(ex);
                MessageBox.Show("حدث خطا اثناء فتح المجلد ", "خطأ", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
