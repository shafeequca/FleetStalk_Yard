namespace FleetStalk_Yard
{
    partial class AddContract
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
            this.label28 = new System.Windows.Forms.Label();
            this.dtTo = new System.Windows.Forms.DateTimePicker();
            this.dtFrom = new System.Windows.Forms.DateTimePicker();
            this.label1 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.cboTransporter = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.optGeneral = new System.Windows.Forms.RadioButton();
            this.optOther = new System.Windows.Forms.RadioButton();
            this.label3 = new System.Windows.Forms.Label();
            this.cboContract = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.cboGSTType = new System.Windows.Forms.ComboBox();
            this.RESET = new System.Windows.Forms.Button();
            this.SAVE = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label28
            // 
            this.label28.AutoSize = true;
            this.label28.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label28.ForeColor = System.Drawing.Color.White;
            this.label28.Location = new System.Drawing.Point(25, 30);
            this.label28.Name = "label28";
            this.label28.Size = new System.Drawing.Size(91, 20);
            this.label28.TabIndex = 114;
            this.label28.Text = "Transporter";
            // 
            // dtTo
            // 
            this.dtTo.CustomFormat = "dd-MM-yyyy hh:mm tt";
            this.dtTo.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtTo.Location = new System.Drawing.Point(165, 107);
            this.dtTo.Name = "dtTo";
            this.dtTo.Size = new System.Drawing.Size(203, 20);
            this.dtTo.TabIndex = 2;
            // 
            // dtFrom
            // 
            this.dtFrom.CustomFormat = "dd-MM-yyyy hh:mm tt";
            this.dtFrom.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtFrom.Location = new System.Drawing.Point(165, 71);
            this.dtFrom.Name = "dtFrom";
            this.dtFrom.Size = new System.Drawing.Size(203, 20);
            this.dtFrom.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(25, 110);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(66, 20);
            this.label1.TabIndex = 119;
            this.label1.Text = "Valid To";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.ForeColor = System.Drawing.Color.White;
            this.label9.Location = new System.Drawing.Point(25, 74);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(85, 20);
            this.label9.TabIndex = 118;
            this.label9.Text = "Valid From";
            // 
            // cboTransporter
            // 
            this.cboTransporter.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.cboTransporter.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cboTransporter.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cboTransporter.FormattingEnabled = true;
            this.cboTransporter.Location = new System.Drawing.Point(165, 27);
            this.cboTransporter.Name = "cboTransporter";
            this.cboTransporter.Size = new System.Drawing.Size(203, 24);
            this.cboTransporter.TabIndex = 0;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.White;
            this.label2.Location = new System.Drawing.Point(25, 153);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(73, 20);
            this.label2.TabIndex = 123;
            this.label2.Text = "Fee Slab";
            // 
            // optGeneral
            // 
            this.optGeneral.AutoSize = true;
            this.optGeneral.Checked = true;
            this.optGeneral.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.optGeneral.ForeColor = System.Drawing.Color.White;
            this.optGeneral.Location = new System.Drawing.Point(165, 148);
            this.optGeneral.Name = "optGeneral";
            this.optGeneral.Size = new System.Drawing.Size(81, 23);
            this.optGeneral.TabIndex = 124;
            this.optGeneral.TabStop = true;
            this.optGeneral.Text = "General";
            this.optGeneral.UseVisualStyleBackColor = true;
            this.optGeneral.CheckedChanged += new System.EventHandler(this.optGeneral_CheckedChanged);
            // 
            // optOther
            // 
            this.optOther.AutoSize = true;
            this.optOther.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.optOther.ForeColor = System.Drawing.Color.White;
            this.optOther.Location = new System.Drawing.Point(252, 148);
            this.optOther.Name = "optOther";
            this.optOther.Size = new System.Drawing.Size(67, 23);
            this.optOther.TabIndex = 125;
            this.optOther.Text = "Other";
            this.optOther.UseVisualStyleBackColor = true;
            this.optOther.CheckedChanged += new System.EventHandler(this.optOther_CheckedChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.White;
            this.label3.Location = new System.Drawing.Point(25, 191);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(86, 20);
            this.label3.TabIndex = 126;
            this.label3.Text = "Copy From";
            // 
            // cboContract
            // 
            this.cboContract.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.cboContract.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cboContract.Enabled = false;
            this.cboContract.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cboContract.FormattingEnabled = true;
            this.cboContract.Location = new System.Drawing.Point(165, 191);
            this.cboContract.Name = "cboContract";
            this.cboContract.Size = new System.Drawing.Size(203, 24);
            this.cboContract.TabIndex = 3;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.Color.White;
            this.label4.Location = new System.Drawing.Point(25, 229);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(80, 20);
            this.label4.TabIndex = 128;
            this.label4.Text = "GST Type";
            // 
            // cboGSTType
            // 
            this.cboGSTType.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.cboGSTType.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cboGSTType.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cboGSTType.FormattingEnabled = true;
            this.cboGSTType.Items.AddRange(new object[] {
            "B2C",
            "B2B"});
            this.cboGSTType.Location = new System.Drawing.Point(165, 229);
            this.cboGSTType.Name = "cboGSTType";
            this.cboGSTType.Size = new System.Drawing.Size(203, 24);
            this.cboGSTType.TabIndex = 4;
            // 
            // RESET
            // 
            this.RESET.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.RESET.Location = new System.Drawing.Point(272, 278);
            this.RESET.Name = "RESET";
            this.RESET.Size = new System.Drawing.Size(96, 32);
            this.RESET.TabIndex = 6;
            this.RESET.Text = "&Reset";
            this.RESET.UseVisualStyleBackColor = true;
            this.RESET.Click += new System.EventHandler(this.RESET_Click);
            // 
            // SAVE
            // 
            this.SAVE.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.SAVE.Location = new System.Drawing.Point(165, 278);
            this.SAVE.Name = "SAVE";
            this.SAVE.Size = new System.Drawing.Size(90, 32);
            this.SAVE.TabIndex = 5;
            this.SAVE.Text = "&Save";
            this.SAVE.UseVisualStyleBackColor = true;
            this.SAVE.Click += new System.EventHandler(this.SAVE_Click);
            // 
            // AddContract
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.MidnightBlue;
            this.ClientSize = new System.Drawing.Size(406, 333);
            this.Controls.Add(this.RESET);
            this.Controls.Add(this.SAVE);
            this.Controls.Add(this.cboGSTType);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.cboContract);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.optOther);
            this.Controls.Add(this.optGeneral);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.dtTo);
            this.Controls.Add(this.dtFrom);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.cboTransporter);
            this.Controls.Add(this.label28);
            this.Name = "AddContract";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Add Contract";
            this.Load += new System.EventHandler(this.AddContract_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label28;
        private System.Windows.Forms.DateTimePicker dtTo;
        private System.Windows.Forms.DateTimePicker dtFrom;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.ComboBox cboTransporter;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.RadioButton optGeneral;
        private System.Windows.Forms.RadioButton optOther;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox cboContract;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ComboBox cboGSTType;
        private System.Windows.Forms.Button RESET;
        private System.Windows.Forms.Button SAVE;
    }
}