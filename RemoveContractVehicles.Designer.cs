namespace FleetStalk_Yard
{
    partial class RemoveContractVehicles
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
            this.cboTransporter = new System.Windows.Forms.ComboBox();
            this.label28 = new System.Windows.Forms.Label();
            this.cboVehicle = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.RESET = new System.Windows.Forms.Button();
            this.SAVE = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // cboTransporter
            // 
            this.cboTransporter.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.cboTransporter.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cboTransporter.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cboTransporter.FormattingEnabled = true;
            this.cboTransporter.Location = new System.Drawing.Point(154, 22);
            this.cboTransporter.Name = "cboTransporter";
            this.cboTransporter.Size = new System.Drawing.Size(203, 24);
            this.cboTransporter.TabIndex = 115;
            this.cboTransporter.SelectedIndexChanged += new System.EventHandler(this.cboTransporter_SelectedIndexChanged);
            // 
            // label28
            // 
            this.label28.AutoSize = true;
            this.label28.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label28.ForeColor = System.Drawing.Color.White;
            this.label28.Location = new System.Drawing.Point(14, 25);
            this.label28.Name = "label28";
            this.label28.Size = new System.Drawing.Size(91, 20);
            this.label28.TabIndex = 116;
            this.label28.Text = "Transporter";
            // 
            // cboVehicle
            // 
            this.cboVehicle.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.cboVehicle.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cboVehicle.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cboVehicle.FormattingEnabled = true;
            this.cboVehicle.Location = new System.Drawing.Point(154, 63);
            this.cboVehicle.Name = "cboVehicle";
            this.cboVehicle.Size = new System.Drawing.Size(203, 24);
            this.cboVehicle.TabIndex = 117;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(14, 66);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(61, 20);
            this.label1.TabIndex = 118;
            this.label1.Text = "Vehicle";
            // 
            // RESET
            // 
            this.RESET.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.RESET.Location = new System.Drawing.Point(261, 113);
            this.RESET.Name = "RESET";
            this.RESET.Size = new System.Drawing.Size(96, 32);
            this.RESET.TabIndex = 120;
            this.RESET.Text = "&Reset";
            this.RESET.UseVisualStyleBackColor = true;
            this.RESET.Click += new System.EventHandler(this.RESET_Click);
            // 
            // SAVE
            // 
            this.SAVE.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.SAVE.Location = new System.Drawing.Point(154, 113);
            this.SAVE.Name = "SAVE";
            this.SAVE.Size = new System.Drawing.Size(90, 32);
            this.SAVE.TabIndex = 119;
            this.SAVE.Text = "&Save";
            this.SAVE.UseVisualStyleBackColor = true;
            this.SAVE.Click += new System.EventHandler(this.SAVE_Click);
            // 
            // RemoveContractVehicles
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.MidnightBlue;
            this.ClientSize = new System.Drawing.Size(391, 181);
            this.Controls.Add(this.RESET);
            this.Controls.Add(this.SAVE);
            this.Controls.Add(this.cboVehicle);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.cboTransporter);
            this.Controls.Add(this.label28);
            this.Name = "RemoveContractVehicles";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Remove Contract Vehicles";
            this.Load += new System.EventHandler(this.RemoveContractVehicles_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox cboTransporter;
        private System.Windows.Forms.Label label28;
        private System.Windows.Forms.ComboBox cboVehicle;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button RESET;
        private System.Windows.Forms.Button SAVE;
    }
}