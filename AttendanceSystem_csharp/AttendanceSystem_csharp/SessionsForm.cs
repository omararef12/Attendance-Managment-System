using MySql.Data.MySqlClient;
using QRCoder;
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
    public partial class SessionsForm : Form
    {
        // تم إضافة هذا السطر فقط — لحفظ أحدث جدول جلسات
        private DataTable sessionsTable;

        public SessionsForm()
        {
            InitializeComponent();
            sessionsGrid.AutoGenerateColumns = false; // منع انشاء الاعمدة
            CreateColumns();
            AddCloseHover(btnClose);
        }

        private void SessionsForm_Load(object sender, EventArgs e)
        {
            SetSearchPlaceholder();
            LoadSessions();
        }

        private void SetSearchPlaceholder()
        {
            if (string.IsNullOrWhiteSpace(txtSearch.Text))
            {
                txtSearch.Text = "search sessions...";
                txtSearch.ForeColor = Color.Gray;
            }

            txtSearch.Enter += (s, e) =>
            {
                if (txtSearch.Text == "search sessions...")
                {
                    txtSearch.Text = "";
                    txtSearch.ForeColor = Color.Black;
                }
            };

            txtSearch.Leave += (s, e) =>
            {
                if (string.IsNullOrWhiteSpace(txtSearch.Text))
                {
                    txtSearch.Text = "search sessions...";
                    txtSearch.ForeColor = Color.Gray;
                }
            };
        }

        private void AddCloseHover(Button btn)
        {
            btn.MouseEnter += (s, e) =>
            {
                btn.BackColor = Color.FromArgb(200, 50, 50);
            };
            btn.MouseLeave += (s, e) => { btn.BackColor = Color.FromArgb(30, 40, 55); };
        }

        private void CreateColumns()
        {
            sessionsGrid.Columns.Add(new DataGridViewTextBoxColumn() // ID
            {
                Name = "colID",
                HeaderText = "ID",
                DataPropertyName = "id",
                Width = 50
            });

            sessionsGrid.Columns.Add(new DataGridViewTextBoxColumn() // title
            {
                Name = "colTitle",
                HeaderText = "Title",
                DataPropertyName = "title",
                Width = 150
            });

            sessionsGrid.Columns.Add(new DataGridViewTextBoxColumn() // course
            {
                Name = "colCourse",
                HeaderText = "Course",
                DataPropertyName = "course_name",
                Width = 130
            });

            sessionsGrid.Columns.Add(new DataGridViewTextBoxColumn() // level
            {
                Name = "colLevel",
                HeaderText = "Level",
                DataPropertyName = "level",
                Width = 80
            });

            sessionsGrid.Columns.Add(new DataGridViewTextBoxColumn() // group
            {
                Name = "colGroup",
                HeaderText = "Group",
                DataPropertyName = "group_name",
                Width = 80
            });

            sessionsGrid.Columns.Add(new DataGridViewTextBoxColumn() // Start time
            {
                Name = "colStart",
                HeaderText = "Start Time",
                DataPropertyName = "start_time",
                Width = 150
            });

            sessionsGrid.Columns.Add(new DataGridViewTextBoxColumn() // end time
            {
                Name = "colEnd",
                HeaderText = "End Time",
                DataPropertyName = "end_time",
                Width = 150
            });
            sessionsGrid.Columns.Add(new DataGridViewTextBoxColumn() // end time
            {
                Name = "colToken",
                HeaderText = "Token",
                DataPropertyName = "token",
                Width = 150
            });
            sessionsGrid.Columns.Add(new DataGridViewButtonColumn() // attendance
            {
                Name = "colAttendance",
                HeaderText = "Attendance",
                Text = "Open",
                UseColumnTextForButtonValue = true,
                Width = 100
            });
            sessionsGrid.Columns.Add(new DataGridViewButtonColumn() // qr
            {
                Name = "colQR",
                HeaderText = "QR Code",
                Text = "Generate",
                UseColumnTextForButtonValue = true,
                Width = 100
            });
            sessionsGrid.Columns.Add(new DataGridViewButtonColumn() // delete
            {
                Name = "colDelete",
                HeaderText = "",
                Text = "Delete",
                UseColumnTextForButtonValue = true,
                Width = 100
            });
        }


        private void LoadSessions()
        {
            try
            {
                string query = "SELECT id, title, course_name, `level`, group_name, start_time, end_time, token FROM sessions ORDER BY id DESC";
                sessionsTable = DB.ExecuteQuery(query);

                // ⭐ إضافة أعمدة LowerCase لتفعيل البحث بدون Case-Sensitive
                sessionsTable.Columns.Add("title_lower", typeof(string));
                sessionsTable.Columns.Add("course_lower", typeof(string));
                sessionsTable.Columns.Add("level_lower", typeof(string));
                sessionsTable.Columns.Add("group_lower", typeof(string));

                foreach (DataRow row in sessionsTable.Rows)
                {
                    row["title_lower"] = row["title"].ToString().ToLower();
                    row["course_lower"] = row["course_name"].ToString().ToLower();
                    row["level_lower"] = row["level"].ToString().ToLower();
                    row["group_lower"] = row["group_name"].ToString().ToLower();
                }

                sessionsGrid.DataSource = sessionsTable;
            }
            catch (Exception ex)
            {
                DB.LogError(ex);
                MessageBox.Show("حدث خطأ أثناء تحميل الجلسات.\n");
            }
        }

        private void FilterSessions()
        {
            if (sessionsTable == null)
                return;

            string keyword = txtSearch.ext.Trim().ToLower();
            string safeKeyword = keyword.Replace("'", "''");

            if (keyword == "" || keyword == "search sessions...")
            {
                sessionsTable.DefaultView.RowFilter = "";
                return;
            }

            // ⭐ استخدام الأعمدة LowerCase للحصول على بحث غير حساس للحالة
            sessionsTable.DefaultView.RowFilter =
                $"title_lower LIKE '%{safeKeyword}%' OR " +
                $"course_lower LIKE '%{safeKeyword}%' OR " +
                $"level_lower LIKE '%{safeKeyword}%' OR " +
                $"group_lower LIKE '%{safeKeyword}%'";
        }

        private void txtSearch_TextChanged(object sender, EventArgs e)
        {
            FilterSessions();
        }

        private void btnCreateSession_Click(object sender, EventArgs e)
        {
            CreateSessionForm form = new CreateSessionForm();
            form.ShowDialog();
            LoadSessions(); // تحديث الجدول بعد إنشاء جلسة جديدة
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void sessionGrid_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (sessionsGrid.Columns[e.ColumnIndex].Name == "colDelete")
            {
                DataGridViewButtonCell btn = (DataGridViewButtonCell)sessionsGrid.Rows[e.RowIndex].Cells[e.ColumnIndex];
                btn.Style.BackColor = Color.FromArgb(200,40,40);
                btn.Style.ForeColor = Color.White;
                btn.Style.Font = new Font("Segoe UI", 9, FontStyle.Bold);
            }
        }

        private void sessionsGrid_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if(e.RowIndex >= 0 && sessionsGrid.Columns[e.ColumnIndex].Name == "colAttendance")
            {
                int sessionId = Convert.ToInt32(sessionsGrid.Rows[e.RowIndex].Cells["colID"].Value);
                AttendanceForm f = new AttendanceForm(sessionId);
                f.ShowDialog();
            }
            if(e.RowIndex >= 0 && sessionsGrid.Columns[e.ColumnIndex].Name == "colQR")
            {
                GenerateQRForSession(e.RowIndex);
            }
            if (sessionsGrid.Columns[e.ColumnIndex].Name == "colDelete")
            {
                int id = Convert.ToInt32(sessionsGrid.Rows[e.RowIndex].Cells["colID"].Value);
                DeleteSession(id);
                LoadSessions();
            }
        }
        private void DeleteSession ( int id)
        {
            try
            {
                string attendance_rows = "DELETE FROM attendance WHERE session_id = @id";
                DB.ExecuteNonQuery(attendance_rows, DB.Param("@id", id));
                string session_delete = "DELETE FROM sessions WHERE id = @id";
                DB.ExecuteNonQuery(session_delete, DB.Param("@id", id));
                MessageBox.Show(" تم حذف الجلسة بنجاح","نجاح",MessageBoxButtons.OK,MessageBoxIcon.Information);
            } catch (Exception ex)
            {
                DB.LogError(ex);
                MessageBox.Show("حدث خطا اثناء حذف الجلسة ", "خطا", MessageBoxButtons.OK,MessageBoxIcon.Error);
            }
        }
        private void GenerateQRForSession(int rowIndex)
        {
            try
            {
                int sessionId = Convert.ToInt32(sessionsGrid.Rows[rowIndex].Cells["colID"].Value);
                string token = sessionsGrid.Rows[rowIndex].Cells["colToken"].Value.ToString();
                string url = $"http://localhost/attendance-system/attendance.php?token={Uri.EscapeDataString(token)}";
                string folderPath = Path.Combine(Application.StartupPath, @"..\..\qr_codes");
                folderPath = Path.GetFullPath(folderPath);
                if (!Directory.Exists(folderPath))
                    Directory.CreateDirectory(folderPath);
                string filePath = Path.Combine(folderPath, $"qr_session_{sessionId}.png");
                QRCodeGenerator qr = new QRCodeGenerator();//تم عمل هذا الكائن عشان استخداام خوارزمية توليد اباركود
                QRCodeData data = qr.CreateQrCode(url, QRCodeGenerator.ECCLevel.Q);
                QRCode code = new QRCode(data);
                using (Bitmap bmp = code.GetGraphic(20))
                {
                    bmp.Save(filePath, System.Drawing.Imaging.ImageFormat.Png);
                }
                MessageBox.Show($" qr code created successfully in the path \n {filePath}", "succesful", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                DB.LogError(ex);
                MessageBox.Show("qr code generating failed","fail",MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void contentPanel_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}