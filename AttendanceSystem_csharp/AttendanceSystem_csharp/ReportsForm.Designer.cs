namespace AttendanceSystem_csharp
{
    partial class ReportsForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ReportsForm));
            this.HeaderPanel = new System.Windows.Forms.Panel();
            this.btnClose = new System.Windows.Forms.Button();
            this.lblTitle = new System.Windows.Forms.Label();
            this.reportsGrid = new System.Windows.Forms.DataGridView();
            this.txtSearch = new System.Windows.Forms.TextBox();
            this.lblCount = new System.Windows.Forms.Label();
            this.bgPicture = new System.Windows.Forms.PictureBox();
            this.HeaderPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.reportsGrid)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bgPicture)).BeginInit();
            this.SuspendLayout();
            // 
            // HeaderPanel
            // 
            this.HeaderPanel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(40)))), ((int)(((byte)(55)))));
            this.HeaderPanel.Controls.Add(this.btnClose);
            this.HeaderPanel.Controls.Add(this.lblTitle);
            this.HeaderPanel.Dock = System.Windows.Forms.DockStyle.Top;
            this.HeaderPanel.Location = new System.Drawing.Point(0, 0);
            this.HeaderPanel.Name = "HeaderPanel";
            this.HeaderPanel.Size = new System.Drawing.Size(900, 60);
            this.HeaderPanel.TabIndex = 0;
            // 
            // btnClose
            // 
            this.btnClose.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnClose.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnClose.ForeColor = System.Drawing.Color.White;
            this.btnClose.Location = new System.Drawing.Point(848, 17);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(40, 40);
            this.btnClose.TabIndex = 1;
            this.btnClose.Text = "X";
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // lblTitle
            // 
            this.lblTitle.AutoSize = true;
            this.lblTitle.Font = new System.Drawing.Font("Segoe UI", 16.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTitle.ForeColor = System.Drawing.Color.White;
            this.lblTitle.Location = new System.Drawing.Point(386, 9);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(118, 38);
            this.lblTitle.TabIndex = 0;
            this.lblTitle.Text = "Reports";
            this.lblTitle.Click += new System.EventHandler(this.lblTitle_Click);
            // 
            // reportsGrid
            // 
            this.reportsGrid.AllowUserToAddRows = false;
            this.reportsGrid.AllowUserToDeleteRows = false;
            this.reportsGrid.AllowUserToResizeColumns = false;
            this.reportsGrid.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.reportsGrid.BackgroundColor = System.Drawing.Color.White;
            this.reportsGrid.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.reportsGrid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.reportsGrid.Location = new System.Drawing.Point(23, 138);
            this.reportsGrid.Name = "reportsGrid";
            this.reportsGrid.ReadOnly = true;
            this.reportsGrid.RowHeadersVisible = false;
            this.reportsGrid.RowHeadersWidth = 51;
            this.reportsGrid.RowTemplate.Height = 24;
            this.reportsGrid.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.reportsGrid.Size = new System.Drawing.Size(850, 450);
            this.reportsGrid.TabIndex = 1;
            // 
            // txtSearch
            // 
            this.txtSearch.Font = new System.Drawing.Font("Segoe UI", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtSearch.ForeColor = System.Drawing.Color.Gray;
            this.txtSearch.Location = new System.Drawing.Point(443, 79);
            this.txtSearch.Name = "txtSearch";
            this.txtSearch.Size = new System.Drawing.Size(400, 31);
            this.txtSearch.TabIndex = 2;
            this.txtSearch.Text = "Search by the name of course and level...";
            this.txtSearch.TextChanged += new System.EventHandler(this.txtSearch_TextChanged);
            // 
            // lblCount
            // 
            this.lblCount.AutoSize = true;
            this.lblCount.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCount.Location = new System.Drawing.Point(68, 93);
            this.lblCount.Name = "lblCount";
            this.lblCount.Size = new System.Drawing.Size(143, 23);
            this.lblCount.TabIndex = 3;
            this.lblCount.Text = "Sessions Count: 0";
            // 
            // bgPicture
            // 
            this.bgPicture.Dock = System.Windows.Forms.DockStyle.Fill;
            this.bgPicture.Image = ((System.Drawing.Image)(resources.GetObject("bgPicture.Image")));
            this.bgPicture.Location = new System.Drawing.Point(0, 0);
            this.bgPicture.Name = "bgPicture";
            this.bgPicture.Size = new System.Drawing.Size(900, 600);
            this.bgPicture.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.bgPicture.TabIndex = 4;
            this.bgPicture.TabStop = false;
            // 
            // ReportsForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(900, 600);
            this.Controls.Add(this.lblCount);
            this.Controls.Add(this.txtSearch);
            this.Controls.Add(this.reportsGrid);
            this.Controls.Add(this.HeaderPanel);
            this.Controls.Add(this.bgPicture);
            this.DoubleBuffered = true;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "ReportsForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "ReportsForm";
            this.Load += new System.EventHandler(this.ReportsForm_Load);
            this.HeaderPanel.ResumeLayout(false);
            this.HeaderPanel.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.reportsGrid)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bgPicture)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel HeaderPanel;
        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.DataGridView reportsGrid;
        private System.Windows.Forms.TextBox txtSearch;
        private System.Windows.Forms.Label lblCount;
        private System.Windows.Forms.PictureBox bgPicture;
    }
}