namespace AttendanceSystem_csharp
{
    partial class SettingsForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(SettingsForm));
            this.headerPanel = new System.Windows.Forms.Panel();
            this.btnClose = new System.Windows.Forms.Button();
            this.lblTitle = new System.Windows.Forms.Label();
            this.mainPanel = new System.Windows.Forms.Panel();
            this.btnOpenLogsFolder = new System.Windows.Forms.Button();
            this.btnOpenQRCodes = new System.Windows.Forms.Button();
            this.bgPicture = new System.Windows.Forms.PictureBox();
            this.headerPanel.SuspendLayout();
            this.mainPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.bgPicture)).BeginInit();
            this.SuspendLayout();
            // 
            // headerPanel
            // 
            this.headerPanel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(40)))), ((int)(((byte)(55)))));
            this.headerPanel.Controls.Add(this.btnClose);
            this.headerPanel.Controls.Add(this.lblTitle);
            this.headerPanel.Dock = System.Windows.Forms.DockStyle.Top;
            this.headerPanel.Location = new System.Drawing.Point(0, 0);
            this.headerPanel.Name = "headerPanel";
            this.headerPanel.Size = new System.Drawing.Size(950, 60);
            this.headerPanel.TabIndex = 0;
            // 
            // btnClose
            // 
            this.btnClose.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnClose.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnClose.FlatAppearance.BorderSize = 0;
            this.btnClose.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnClose.Font = new System.Drawing.Font("Segoe UI", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnClose.ForeColor = System.Drawing.Color.White;
            this.btnClose.Location = new System.Drawing.Point(903, 12);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(35, 35);
            this.btnClose.TabIndex = 1;
            this.btnClose.Text = "X";
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // lblTitle
            // 
            this.lblTitle.AutoSize = true;
            this.lblTitle.Font = new System.Drawing.Font("Segoe UI", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTitle.ForeColor = System.Drawing.Color.White;
            this.lblTitle.Location = new System.Drawing.Point(450, 15);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(102, 31);
            this.lblTitle.TabIndex = 0;
            this.lblTitle.Text = "Settings";
            // 
            // mainPanel
            // 
            this.mainPanel.BackColor = System.Drawing.Color.LightGray;
            this.mainPanel.Controls.Add(this.btnOpenLogsFolder);
            this.mainPanel.Controls.Add(this.btnOpenQRCodes);
            this.mainPanel.Controls.Add(this.bgPicture);
            this.mainPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.mainPanel.Location = new System.Drawing.Point(0, 60);
            this.mainPanel.Name = "mainPanel";
            this.mainPanel.Padding = new System.Windows.Forms.Padding(20);
            this.mainPanel.Size = new System.Drawing.Size(950, 540);
            this.mainPanel.TabIndex = 1;
            // 
            // btnOpenLogsFolder
            // 
            this.btnOpenLogsFolder.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(40)))), ((int)(((byte)(55)))));
            this.btnOpenLogsFolder.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnOpenLogsFolder.FlatAppearance.BorderSize = 0;
            this.btnOpenLogsFolder.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnOpenLogsFolder.Font = new System.Drawing.Font("Segoe UI Semibold", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnOpenLogsFolder.ForeColor = System.Drawing.Color.White;
            this.btnOpenLogsFolder.Location = new System.Drawing.Point(502, 120);
            this.btnOpenLogsFolder.Name = "btnOpenLogsFolder";
            this.btnOpenLogsFolder.Size = new System.Drawing.Size(270, 270);
            this.btnOpenLogsFolder.TabIndex = 1;
            this.btnOpenLogsFolder.Text = "Open Logs Folder";
            this.btnOpenLogsFolder.UseVisualStyleBackColor = false;
            this.btnOpenLogsFolder.Click += new System.EventHandler(this.btnOpenLogsFolder_Click);
            // 
            // btnOpenQRCodes
            // 
            this.btnOpenQRCodes.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(40)))), ((int)(((byte)(55)))));
            this.btnOpenQRCodes.FlatAppearance.BorderSize = 0;
            this.btnOpenQRCodes.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnOpenQRCodes.Font = new System.Drawing.Font("Segoe UI Semibold", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnOpenQRCodes.ForeColor = System.Drawing.Color.White;
            this.btnOpenQRCodes.Location = new System.Drawing.Point(112, 120);
            this.btnOpenQRCodes.Name = "btnOpenQRCodes";
            this.btnOpenQRCodes.Size = new System.Drawing.Size(270, 270);
            this.btnOpenQRCodes.TabIndex = 0;
            this.btnOpenQRCodes.Text = "Open QR Codes Folder";
            this.btnOpenQRCodes.UseVisualStyleBackColor = false;
            this.btnOpenQRCodes.Click += new System.EventHandler(this.btnOpenQRCodes_Click);
            // 
            // bgPicture
            // 
            this.bgPicture.Dock = System.Windows.Forms.DockStyle.Fill;
            this.bgPicture.Image = ((System.Drawing.Image)(resources.GetObject("bgPicture.Image")));
            this.bgPicture.Location = new System.Drawing.Point(20, 20);
            this.bgPicture.Name = "bgPicture";
            this.bgPicture.Size = new System.Drawing.Size(910, 500);
            this.bgPicture.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.bgPicture.TabIndex = 4;
            this.bgPicture.TabStop = false;
            // 
            // SettingsForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 23F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(950, 600);
            this.Controls.Add(this.mainPanel);
            this.Controls.Add(this.headerPanel);
            this.DoubleBuffered = true;
            this.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Name = "SettingsForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "SettingsForm";
            this.headerPanel.ResumeLayout(false);
            this.headerPanel.PerformLayout();
            this.mainPanel.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.bgPicture)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel headerPanel;
        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.Panel mainPanel;
        private System.Windows.Forms.Button btnOpenQRCodes;
        private System.Windows.Forms.Button btnOpenLogsFolder;
        private System.Windows.Forms.PictureBox bgPicture;
    }
}