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
    public partial class CreateSessionForm : Form
    {
        public CreateSessionForm()
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

        private void CreateSessionForm_Load(object sender, EventArgs e)
        {
            SetPlaceholder(txtTitle, "Session Title");
            SetPlaceholder(txtCourse, "Course Name");
            SetPlaceholder(txtLevel, "Level");
            SetPlaceholder(txtGroup, "Group");
            AddDatePickerEffects(dtStart);
            AddDatePickerEffects(dtEnd);
            AddHoverEffect(btnCreateSession);
        }
        private void SetPlaceholder(TextBox txt, string placeholder)
        {
            if (string.IsNullOrWhiteSpace(txt.Text))
            {
                txt.Text = placeholder;
                txt.ForeColor = Color.Gray;
            }
            txt.Enter += (s, e) =>
            {
                if (txt.Text == placeholder) {
                    txt.Text = "";
                    txt.ForeColor = Color.Black;
                }
                txt.BackColor = Color.FromArgb(240, 248, 255);
            };
            txt.Leave += (s, e) =>
            {
                if (string.IsNullOrWhiteSpace (txt.Text))
                {
                    txt.Text = placeholder;
                    txt.ForeColor = Color.Gray;
                }
                txt.BackColor = Color.White;
            };

            }
        private void AddDatePickerEffects (DateTimePicker dt)
        {
            dt.Enter += (s, e) =>
            {
                dt.CalendarMonthBackground = Color.FromArgb(240, 248, 255);
                dt.CalendarTitleBackColor = Color.FromArgb(240, 248, 255);
            };
            dt.Leave += (s, e) =>
            {
                dt.CalendarMonthBackground = Color.White;
                dt.CalendarTitleBackColor = Color.White;
            };
        }
        private void AddHoverEffect(Button btn)
        {
            btn.MouseEnter += (s, e) =>
            {
                btn.BackColor = Color.FromArgb(65, 75, 100);
            };
            btn.MouseLeave += (s, e) =>
            {
                btn.BackColor = Color.FromArgb(50, 60, 80);
            };
        }

        private void btnCreateSession_Click(object sender, EventArgs e)
        {
          
            try
            {
                string title = txtTitle.Text.Trim();
                string course = txtCourse.Text.Trim();
                string level = txtLevel.Text.Trim();
                string group = txtGroup.Text.Trim();
                DateTime start = dtStart.Value;
                DateTime end = dtEnd.Value;
                DateTime now = DateTime.Now;
                
                if (string.IsNullOrWhiteSpace(title) || title == "Session Title" || string.IsNullOrWhiteSpace(course) || course == "Course Name" ||
                    string.IsNullOrWhiteSpace(level) || level == "Level" || string.IsNullOrEmpty(group) || group == "Group")
                {
                    MessageBox.Show("فضلا املا جميع الحقول قبل المتابعة");
                    return;
                }
                if(start>=end)
                {
                    MessageBox.Show("وقت البداية يجب ان يكون قبل وقت النهاية");
                    return;
                }
                if(start < now)
                {
                    MessageBox.Show("لا يمكن ان يكون وقت بداية الجلسة اقل من الوقت الحالي");
                    return;
                }
                if(start.Date!=end.Date)
                {
                    MessageBox.Show("يجب ان يكون وقت بداية الجلسة ووقت نهايتها في نفس اليوم");
                    return;
                }
                string token = Guid.NewGuid().ToString("N").Substring(0, 12); //هذه الدالة تنشى قيمة عالمية فريدة
                string query = "INSERT INTO sessions (title, course_name, `level`, group_name, start_time, end_time, token) " +
                    "VALUES (@title, @course, @level, @group, @start, @end, @token)";
                // نمرر القيم بامان عبر المعاملات
                int rows = DB.ExecuteNonQuery(query,DB.Param("@title", title), DB.Param("@course", course), DB.Param("@level", level),
                   DB.Param("@group", group), DB.Param("@start", start), DB.Param("@end", end), DB.Param("@token", token));
                if(rows > 0)
                {
                    MessageBox.Show("تم انشاء الجلسة بنجاح");
                    this.Close();
                }
            } catch (Exception ex)
            {
                DB.LogError(ex);
                MessageBox.Show("حدث خطا اثناء انشاء الجلسة \n");
            }

        }

        private void bgPicture_Click(object sender, EventArgs e)
        {

        }
    }
}
