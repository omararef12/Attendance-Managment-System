using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AttendanceSystem_csharp
{
    public partial class ReportsForm : Form
    {
        private DataTable reportsTable;
        public ReportsForm()
        {
            InitializeComponent();
            reportsGrid.AutoGenerateColumns = false;
            AddCloseHover(btnClose);
            CreateColumns();
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
            reportsGrid.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "colSessionID",
                HeaderText = "Session ID",
                DataPropertyName = "id",
                Width = 80
            });
            reportsGrid.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "colTitle",
                HeaderText = "Title",
                DataPropertyName = "title",
                Width = 180
            });
            reportsGrid.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "colCourse",
                HeaderText = "Course",
                DataPropertyName = "course",
                Width = 150
            });
            reportsGrid.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "colLevel",
                HeaderText = "Level",
                DataPropertyName = "level",
                Width = 150
            });
            reportsGrid.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "colCount",
                HeaderText = "Students Count",
                DataPropertyName = "students_count",
                Width = 130
            });
        }
        private void LoadReports()
        {
            try
            {
                string query = @"SELECT s.id, s.title, s.course_name AS course, s.`level`, COUNT(a.id) AS students_count 
FROM sessions s LEFT JOIN attendance a ON s.id = a.session_id GROUP BY s.id, s.title, s.course_name, s.`level` ORDER BY s.id DESC";
                reportsTable = DB.ExecuteQuery(query);
                reportsGrid.DataSource = reportsTable;
                lblCount.Text = "عدد الجلسات: " + reportsTable.Rows.Count;
                reportsTable.Columns.Add("title_lower", typeof(string));
                reportsTable.Columns.Add("course_lower", typeof(string));
                reportsTable.Columns.Add("level_lower", typeof(string));
                foreach (DataRow row in reportsTable.Rows)
                {
                    row["title_lower"] = row["title"].ToString().ToLower();
                    row["course_lower"] = row["course"].ToString().ToLower();
                    row["level_lower"] = row["level"].ToString().ToLower();
                }
            } catch (Exception ex)
            {
                DB.LogError(ex);
                MessageBox.Show("حدث خطا اثناء تحميل التقرير");
            }
        }

        private void lblTitle_Click(object sender, EventArgs e)
        {

        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void ReportsForm_Load(object sender, EventArgs e)
        {
            SetSearchPlaceholder();
            LoadReports();
        }
        private void SetSearchPlaceholder()
        {
            if( string.IsNullOrWhiteSpace(txtSearch.Text))
            {
                txtSearch.Text = "Search by the name of course and level...";
                txtSearch.ForeColor = Color.Gray;
            }
            txtSearch.Enter += (s, e) =>
            {
                if (txtSearch.Text == "Search by the name of course and level...")
                {
                    txtSearch.Text = "";
                    txtSearch.ForeColor = Color.Black;
                }
            };
            txtSearch.Leave += (s, e) =>
            {
                if (string.IsNullOrWhiteSpace(txtSearch.Text))
                {
                    txtSearch.Text = "Search by the name of course and level...";
                    txtSearch.ForeColor = Color.Gray;
                }
            };

        }

        private void txtSearch_TextChanged(object sender, EventArgs e)
        {
            FilterReports();
        }

        private void FilterReports()
        {
            if (reportsTable == null)
                return;
            string keyword = txtSearch.Text.Trim();
            if(string.IsNullOrWhiteSpace(keyword) || keyword == "Search by the name of course and level...")
            {
                reportsTable.DefaultView.RowFilter = "";
                lblCount.Text = "عدد الجلسات: " + reportsTable.Rows.Count;
                return;
            }
            string lowered = keyword.ToLower();
            string safe = lowered.Replace("'", "''");
            reportsTable.DefaultView.RowFilter = $"course_lower LIKE '%{safe}%' OR level_lower LIKE '%{safe}%'";
            lblCount.Text = "عدد الجلسات: " + reportsTable.DefaultView.Count;
        }
    }
}
