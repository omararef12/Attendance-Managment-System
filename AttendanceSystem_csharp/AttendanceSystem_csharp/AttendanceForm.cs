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
    public partial class AttendanceForm : Form
    {
        private int sessionId;
        private DataTable attendanceTable;
        public AttendanceForm(int sessionId)
        {
            InitializeComponent();
            this.sessionId = sessionId;
            attendanceGrid.AutoGenerateColumns = false;
            CreateColumns();
            SetSearchPlaceholder();
            LoadAttendance();
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

        private void AttendanceForm_Load(object sender, EventArgs e)
        {

        }
        private void LoadAttendance()
        {
            try
            {
                string query = "SELECT id, student_id, student_name, created_at FROM attendance WHERE session_id = @id ORDER BY created_at DESC";
                DataTable dt = DB.ExecuteQuery(query, DB.Param("@id", sessionId));
                attendanceTable = dt;
                attendanceTable.Columns.Add("student_name_lower", typeof(string));
                attendanceTable.Columns.Add("student_id_lower", typeof(string));
                foreach (DataRow row in attendanceTable.Rows)
                {
                    row["student_name_lower"] = row["student_name"].ToString().ToLower();
                    row["student_id_lower"] = row["student_id"].ToString().ToLower();
                }
                attendanceGrid.DataSource = attendanceTable;
                lblCount.Text = "عدد الطلاب: " + attendanceTable.DefaultView.Count;
            } catch (Exception ex)
            {
                DB.LogError(ex);
                MessageBox.Show("حدث خطا اثناء تحميل بيانات الحضور");
            }
        }
        private void CreateColumns()
        {
            attendanceGrid.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "colID",
                HeaderText = "ID",
                DataPropertyName = "id",
                Width = 60
            });
            attendanceGrid.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "colStudentName",
                HeaderText = "Student Name",
                DataPropertyName = "student_name",
                Width = 220
            });
            attendanceGrid.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "colStudentId",
                HeaderText = "Student ID",
                DataPropertyName = "student_id",
                Width = 150
            });
            attendanceGrid.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "colTime",
                HeaderText = "Time",
                DataPropertyName = "created_at",
                Width = 170
            });
        }
        private void SetSearchPlaceholder()
        {
            if (string.IsNullOrWhiteSpace(txtSearch.Text))
            {
                txtSearch.Text = "Search...";
                txtSearch.ForeColor = Color.Gray;
            }
            txtSearch.Enter += (s, e) =>
            {
                if (txtSearch.Text == "Search...")
                {
                    txtSearch.Text = "";
                    txtSearch.ForeColor = Color.Black;
                }
            };
            txtSearch.Leave += (s, e) =>
            {
                if (string.IsNullOrWhiteSpace(txtSearch.Text))
                {
                    txtSearch.Text = "Search...";
                    txtSearch.ForeColor = Color.Gray;
                }
            };
        }
        private void FilterAttendance()
        {
            if (attendanceTable == null)
                return;
            string keyword = txtSearch.Text.Trim();
            if(string.IsNullOrWhiteSpace(keyword) || keyword == "Search...")
            {
                attendanceTable.DefaultView.RowFilter = "";
                lblCount.Text = "عدد الطلاب: "+ attendanceTable.DefaultView.Count;
                return;
            }
            string lowerKeyword = keyword.ToLower();
            string safeKeyword = lowerKeyword.Replace("'", "''");
            attendanceTable.DefaultView.RowFilter = $"student_name_lower LIKE '%{safeKeyword}%' OR " + $"student_id_lower LIKE '%{safeKeyword}%'";
            lblCount.Text = "عدد الطلاب: " + attendanceTable.DefaultView.Count;
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            LoadAttendance();
            if(!string.IsNullOrWhiteSpace(txtSearch.Text)&& txtSearch.Text != "Search...")
            {
                FilterAttendance();
            } 
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void lblCount_TextChanged(object sender, EventArgs e)
        {
           
        }

        private void txtSearch_TextChanged(object sender, EventArgs e)
        {
            FilterAttendance();
        }
    }
}
