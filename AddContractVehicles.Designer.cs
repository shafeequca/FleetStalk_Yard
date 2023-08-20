namespace FleetStalk_Yard
{
    partial class AddContractVehicles
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            this.TransporterView = new System.Windows.Forms.DataGridView();
            this.txtTransporter = new System.Windows.Forms.TextBox();
            this.label28 = new System.Windows.Forms.Label();
            this.VehicleType = new System.Windows.Forms.ComboBox();
            this.label22 = new System.Windows.Forms.Label();
            this.txtVehicle = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.VehicleView = new System.Windows.Forms.DataGridView();
            this.RESET = new System.Windows.Forms.Button();
            this.SAVE = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.TransporterView)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.VehicleView)).BeginInit();
            this.SuspendLayout();
            // 
            // TransporterView
            // 
            this.TransporterView.AllowUserToAddRows = false;
            this.TransporterView.AllowUserToDeleteRows = false;
            this.TransporterView.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.TransporterView.BackgroundColor = System.Drawing.Color.White;
            this.TransporterView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.TransporterView.ColumnHeadersVisible = false;
            this.TransporterView.Location = new System.Drawing.Point(158, 64);
            this.TransporterView.Name = "TransporterView";
            this.TransporterView.ReadOnly = true;
            this.TransporterView.RowHeadersVisible = false;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TransporterView.RowsDefaultCellStyle = dataGridViewCellStyle1;
            this.TransporterView.Size = new System.Drawing.Size(208, 122);
            this.TransporterView.TabIndex = 115;
            this.TransporterView.Visible = false;
            this.TransporterView.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.TransporterView_CellClick);
            this.TransporterView.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.TransporterView_CellContentClick);
            this.TransporterView.KeyDown += new System.Windows.Forms.KeyEventHandler(this.TransporterView_KeyDown);
            // 
            // txtTransporter
            // 
            this.txtTransporter.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtTransporter.Location = new System.Drawing.Point(158, 33);
            this.txtTransporter.MaxLength = 100;
            this.txtTransporter.Name = "txtTransporter";
            this.txtTransporter.Size = new System.Drawing.Size(208, 26);
            this.txtTransporter.TabIndex = 0;
            this.txtTransporter.TextChanged += new System.EventHandler(this.txtTransporter_TextChanged);
            this.txtTransporter.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtTransporter_KeyDown);
            this.txtTransporter.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtTransporter_KeyPress);
            // 
            // label28
            // 
            this.label28.AutoSize = true;
            this.label28.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label28.ForeColor = System.Drawing.Color.White;
            this.label28.Location = new System.Drawing.Point(23, 36);
            this.label28.Name = "label28";
            this.label28.Size = new System.Drawing.Size(91, 20);
            this.label28.TabIndex = 113;
            this.label28.Text = "Transporter";
            // 
            // VehicleType
            // 
            this.VehicleType.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.VehicleType.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.VehicleType.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.VehicleType.FormattingEnabled = true;
            this.VehicleType.Items.AddRange(new object[] {
            "20FT",
            "40FT"});
            this.VehicleType.Location = new System.Drawing.Point(158, 111);
            this.VehicleType.Name = "VehicleType";
            this.VehicleType.Size = new System.Drawing.Size(208, 27);
            this.VehicleType.TabIndex = 2;
            // 
            // label22
            // 
            this.label22.AutoSize = true;
            this.label22.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label22.ForeColor = System.Drawing.Color.White;
            this.label22.Location = new System.Drawing.Point(23, 113);
            this.label22.Name = "label22";
            this.label22.Size = new System.Drawing.Size(43, 20);
            this.label22.TabIndex = 112;
            this.label22.Text = "Type";
            // 
            // txtVehicle
            // 
            this.txtVehicle.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtVehicle.Location = new System.Drawing.Point(158, 70);
            this.txtVehicle.MaxLength = 100;
            this.txtVehicle.Name = "txtVehicle";
            this.txtVehicle.Size = new System.Drawing.Size(208, 26);
            this.txtVehicle.TabIndex = 1;
            this.txtVehicle.TextChanged += new System.EventHandler(this.txtVehicle_TextChanged);
            this.txtVehicle.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtVehicle_KeyDown);
            this.txtVehicle.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtVehicle_KeyPress);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(23, 73);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(61, 20);
            this.label1.TabIndex = 116;
            this.label1.Text = "Vehicle";
            // 
            // VehicleView
            // 
            this.VehicleView.AllowUserToAddRows = false;
            this.VehicleView.AllowUserToDeleteRows = false;
            this.VehicleView.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.VehicleView.BackgroundColor = System.Drawing.Color.White;
            this.VehicleView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.VehicleView.ColumnHeadersVisible = false;
            this.VehicleView.Location = new System.Drawing.Point(158, 95);
            this.VehicleView.Name = "VehicleView";
            this.VehicleView.ReadOnly = true;
            this.VehicleView.RowHeadersVisible = false;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.VehicleView.RowsDefaultCellStyle = dataGridViewCellStyle2;
            this.VehicleView.Size = new System.Drawing.Size(208, 122);
            this.VehicleView.TabIndex = 118;
            this.VehicleView.Visible = false;
            this.VehicleView.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.VehicleView_CellClick);
            this.VehicleView.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.VehicleView_CellContentClick);
            this.VehicleView.KeyDown += new System.Windows.Forms.KeyEventHandler(this.VehicleView_KeyDown);
            // 
            // RESET
            // 
            this.RESET.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.RESET.Location = new System.Drawing.Point(273, 160);
            this.RESET.Name = "RESET";
            this.RESET.Size = new System.Drawing.Size(93, 35);
            this.RESET.TabIndex = 5;
            this.RESET.Text = "RESET";
            this.RESET.UseVisualStyleBackColor = true;
            this.RESET.Click += new System.EventHandler(this.RESET_Click);
            // 
            // SAVE
            // 
            this.SAVE.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.SAVE.Location = new System.Drawing.Point(158, 160);
            this.SAVE.Name = "SAVE";
            this.SAVE.Size = new System.Drawing.Size(93, 35);
            this.SAVE.TabIndex = 4;
            this.SAVE.Text = "&SAVE";
            this.SAVE.UseVisualStyleBackColor = true;
            this.SAVE.Click += new System.EventHandler(this.SAVE_Click);
            // 
            // AddContractVehicles
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.MidnightBlue;
            this.ClientSize = new System.Drawing.Size(376, 229);
            this.Controls.Add(this.VehicleView);
            this.Controls.Add(this.TransporterView);
            this.Controls.Add(this.RESET);
            this.Controls.Add(this.SAVE);
            this.Controls.Add(this.txtVehicle);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtTransporter);
            this.Controls.Add(this.label28);
            this.Controls.Add(this.VehicleType);
            this.Controls.Add(this.label22);
            this.Name = "AddContractVehicles";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Add Contract Vehicles";
            this.Load += new System.EventHandler(this.AddContractVehicles_Load);
            ((System.ComponentModel.ISupportInitialize)(this.TransporterView)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.VehicleView)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView TransporterView;
        private System.Windows.Forms.TextBox txtTransporter;
        private System.Windows.Forms.Label label28;
        private System.Windows.Forms.ComboBox VehicleType;
        private System.Windows.Forms.Label label22;
        private System.Windows.Forms.TextBox txtVehicle;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DataGridView VehicleView;
        private System.Windows.Forms.Button RESET;
        private System.Windows.Forms.Button SAVE;
    }
}