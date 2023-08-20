namespace FleetStalk_Yard
{
    partial class MainMenu
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainMenu));
            this.panel1 = new System.Windows.Forms.Panel();
            this.btnTollReport = new System.Windows.Forms.Button();
            this.btnTollEntry = new System.Windows.Forms.Button();
            this.btnRemoveContractVehicle = new System.Windows.Forms.Button();
            this.AddContractVehicles = new System.Windows.Forms.Button();
            this.EntryDetailsTransporter = new System.Windows.Forms.Button();
            this.EntryDetails = new System.Windows.Forms.Button();
            this.btnYardEntry = new System.Windows.Forms.Button();
            this.lblUser = new System.Windows.Forms.Label();
            this.btnLogout = new System.Windows.Forms.Button();
            this.TimeLabel = new System.Windows.Forms.Label();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.timer2 = new System.Windows.Forms.Timer(this.components);
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.btnTollReport);
            this.panel1.Controls.Add(this.btnTollEntry);
            this.panel1.Controls.Add(this.btnRemoveContractVehicle);
            this.panel1.Controls.Add(this.AddContractVehicles);
            this.panel1.Controls.Add(this.EntryDetailsTransporter);
            this.panel1.Controls.Add(this.EntryDetails);
            this.panel1.Controls.Add(this.btnYardEntry);
            this.panel1.Controls.Add(this.lblUser);
            this.panel1.Controls.Add(this.btnLogout);
            this.panel1.Controls.Add(this.TimeLabel);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1203, 46);
            this.panel1.TabIndex = 0;
            this.panel1.Paint += new System.Windows.Forms.PaintEventHandler(this.panel1_Paint);
            // 
            // btnTollReport
            // 
            this.btnTollReport.Enabled = false;
            this.btnTollReport.Location = new System.Drawing.Point(724, 3);
            this.btnTollReport.Name = "btnTollReport";
            this.btnTollReport.Size = new System.Drawing.Size(101, 38);
            this.btnTollReport.TabIndex = 115;
            this.btnTollReport.Text = "Toll Report";
            this.btnTollReport.UseVisualStyleBackColor = true;
            this.btnTollReport.Click += new System.EventHandler(this.btnTollReport_Click);
            // 
            // btnTollEntry
            // 
            this.btnTollEntry.Enabled = false;
            this.btnTollEntry.Location = new System.Drawing.Point(617, 4);
            this.btnTollEntry.Name = "btnTollEntry";
            this.btnTollEntry.Size = new System.Drawing.Size(101, 38);
            this.btnTollEntry.TabIndex = 114;
            this.btnTollEntry.Text = "Toll Entry";
            this.btnTollEntry.UseVisualStyleBackColor = true;
            this.btnTollEntry.Click += new System.EventHandler(this.btnTollEntry_Click);
            // 
            // btnRemoveContractVehicle
            // 
            this.btnRemoveContractVehicle.Enabled = false;
            this.btnRemoveContractVehicle.Location = new System.Drawing.Point(508, 4);
            this.btnRemoveContractVehicle.Name = "btnRemoveContractVehicle";
            this.btnRemoveContractVehicle.Size = new System.Drawing.Size(101, 38);
            this.btnRemoveContractVehicle.TabIndex = 113;
            this.btnRemoveContractVehicle.Text = "Remove Contract Vehicles";
            this.btnRemoveContractVehicle.UseVisualStyleBackColor = true;
            this.btnRemoveContractVehicle.Click += new System.EventHandler(this.btnRemoveContractVehicle_Click);
            // 
            // AddContractVehicles
            // 
            this.AddContractVehicles.Enabled = false;
            this.AddContractVehicles.Location = new System.Drawing.Point(416, 3);
            this.AddContractVehicles.Name = "AddContractVehicles";
            this.AddContractVehicles.Size = new System.Drawing.Size(86, 38);
            this.AddContractVehicles.TabIndex = 112;
            this.AddContractVehicles.Text = "Add Contract Vehicles";
            this.AddContractVehicles.UseVisualStyleBackColor = true;
            this.AddContractVehicles.Click += new System.EventHandler(this.AddContractVehicles_Click);
            // 
            // EntryDetailsTransporter
            // 
            this.EntryDetailsTransporter.Enabled = false;
            this.EntryDetailsTransporter.Location = new System.Drawing.Point(315, 2);
            this.EntryDetailsTransporter.Name = "EntryDetailsTransporter";
            this.EntryDetailsTransporter.Size = new System.Drawing.Size(95, 38);
            this.EntryDetailsTransporter.TabIndex = 111;
            this.EntryDetailsTransporter.Text = "Add Contract";
            this.EntryDetailsTransporter.UseVisualStyleBackColor = true;
            this.EntryDetailsTransporter.Click += new System.EventHandler(this.button1_Click_1);
            // 
            // EntryDetails
            // 
            this.EntryDetails.Enabled = false;
            this.EntryDetails.Location = new System.Drawing.Point(214, 5);
            this.EntryDetails.Name = "EntryDetails";
            this.EntryDetails.Size = new System.Drawing.Size(95, 30);
            this.EntryDetails.TabIndex = 110;
            this.EntryDetails.Text = "Entry Details";
            this.EntryDetails.UseVisualStyleBackColor = true;
            this.EntryDetails.Click += new System.EventHandler(this.EntryDetails_Click);
            // 
            // btnYardEntry
            // 
            this.btnYardEntry.Enabled = false;
            this.btnYardEntry.Location = new System.Drawing.Point(113, 5);
            this.btnYardEntry.Name = "btnYardEntry";
            this.btnYardEntry.Size = new System.Drawing.Size(95, 30);
            this.btnYardEntry.TabIndex = 109;
            this.btnYardEntry.Text = "Yard Entry";
            this.btnYardEntry.UseVisualStyleBackColor = true;
            this.btnYardEntry.Click += new System.EventHandler(this.button2_Click);
            // 
            // lblUser
            // 
            this.lblUser.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblUser.ForeColor = System.Drawing.Color.Black;
            this.lblUser.Location = new System.Drawing.Point(845, 9);
            this.lblUser.Name = "lblUser";
            this.lblUser.Size = new System.Drawing.Size(238, 31);
            this.lblUser.TabIndex = 108;
            this.lblUser.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.lblUser.Click += new System.EventHandler(this.lblUser_Click);
            // 
            // btnLogout
            // 
            this.btnLogout.Enabled = false;
            this.btnLogout.Location = new System.Drawing.Point(12, 5);
            this.btnLogout.Name = "btnLogout";
            this.btnLogout.Size = new System.Drawing.Size(95, 30);
            this.btnLogout.TabIndex = 107;
            this.btnLogout.Text = "Logout";
            this.btnLogout.UseVisualStyleBackColor = true;
            this.btnLogout.Click += new System.EventHandler(this.button1_Click);
            // 
            // TimeLabel
            // 
            this.TimeLabel.Dock = System.Windows.Forms.DockStyle.Right;
            this.TimeLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TimeLabel.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
            this.TimeLabel.Location = new System.Drawing.Point(844, 0);
            this.TimeLabel.Name = "TimeLabel";
            this.TimeLabel.Size = new System.Drawing.Size(359, 46);
            this.TimeLabel.TabIndex = 106;
            this.TimeLabel.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.TimeLabel.Click += new System.EventHandler(this.TimeLabel_Click);
            // 
            // timer1
            // 
            this.timer1.Enabled = true;
            this.timer1.Interval = 1000;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // timer2
            // 
            this.timer2.Enabled = true;
            this.timer2.Interval = 60000;
            this.timer2.Tick += new System.EventHandler(this.timer2_Tick);
            // 
            // MainMenu
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(1203, 504);
            this.Controls.Add(this.panel1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.IsMdiContainer = true;
            this.Name = "MainMenu";
            this.Text = "FleetStalk_Yard";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.MainMenu_Load);
            this.panel1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label TimeLabel;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.Button btnLogout;
        private System.Windows.Forms.Label lblUser;
        private System.Windows.Forms.Button btnYardEntry;
        private System.Windows.Forms.Button EntryDetails;
        private System.Windows.Forms.Button EntryDetailsTransporter;
        private System.Windows.Forms.Button AddContractVehicles;
        private System.Windows.Forms.Button btnRemoveContractVehicle;
        private System.Windows.Forms.Timer timer2;
        private System.Windows.Forms.Button btnTollEntry;
        private System.Windows.Forms.Button btnTollReport;
    }
}