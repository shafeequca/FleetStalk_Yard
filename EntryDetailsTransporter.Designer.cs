namespace FleetStalk_Yard
{
    partial class EntryDetailsTransporter
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
            this.optOut = new System.Windows.Forms.RadioButton();
            this.optIn = new System.Windows.Forms.RadioButton();
            this.OptAll = new System.Windows.Forms.RadioButton();
            this.btnPrint = new System.Windows.Forms.Button();
            this.lblTotal = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.btnReset = new System.Windows.Forms.Button();
            this.btnShow = new System.Windows.Forms.Button();
            this.dtTo = new System.Windows.Forms.DateTimePicker();
            this.dtFrom = new System.Windows.Forms.DateTimePicker();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.label1 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.cboTransporter = new System.Windows.Forms.ComboBox();
            this.chkCreditPayment = new System.Windows.Forms.CheckBox();
            this.crystalReportViewer1 = new CrystalDecisions.Windows.Forms.CrystalReportViewer();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // optOut
            // 
            this.optOut.AutoSize = true;
            this.optOut.ForeColor = System.Drawing.Color.White;
            this.optOut.Location = new System.Drawing.Point(590, 53);
            this.optOut.Name = "optOut";
            this.optOut.Size = new System.Drawing.Size(68, 17);
            this.optOut.TabIndex = 114;
            this.optOut.TabStop = true;
            this.optOut.Text = "Out Only";
            this.optOut.UseVisualStyleBackColor = true;
            this.optOut.CheckedChanged += new System.EventHandler(this.optOut_CheckedChanged);
            // 
            // optIn
            // 
            this.optIn.AutoSize = true;
            this.optIn.ForeColor = System.Drawing.Color.White;
            this.optIn.Location = new System.Drawing.Point(590, 34);
            this.optIn.Name = "optIn";
            this.optIn.Size = new System.Drawing.Size(60, 17);
            this.optIn.TabIndex = 113;
            this.optIn.TabStop = true;
            this.optIn.Text = "In Only";
            this.optIn.UseVisualStyleBackColor = true;
            this.optIn.CheckedChanged += new System.EventHandler(this.optIn_CheckedChanged);
            // 
            // OptAll
            // 
            this.OptAll.AutoSize = true;
            this.OptAll.Checked = true;
            this.OptAll.ForeColor = System.Drawing.Color.White;
            this.OptAll.Location = new System.Drawing.Point(590, 15);
            this.OptAll.Name = "OptAll";
            this.OptAll.Size = new System.Drawing.Size(42, 17);
            this.OptAll.TabIndex = 112;
            this.OptAll.TabStop = true;
            this.OptAll.Text = "ALL";
            this.OptAll.UseVisualStyleBackColor = true;
            this.OptAll.CheckedChanged += new System.EventHandler(this.OptAll_CheckedChanged);
            // 
            // btnPrint
            // 
            this.btnPrint.Location = new System.Drawing.Point(786, 15);
            this.btnPrint.Name = "btnPrint";
            this.btnPrint.Size = new System.Drawing.Size(94, 38);
            this.btnPrint.TabIndex = 111;
            this.btnPrint.Text = "&Print Preview";
            this.btnPrint.UseVisualStyleBackColor = true;
            this.btnPrint.Click += new System.EventHandler(this.btnPrint_Click);
            // 
            // lblTotal
            // 
            this.lblTotal.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTotal.ForeColor = System.Drawing.Color.Red;
            this.lblTotal.Location = new System.Drawing.Point(1047, 25);
            this.lblTotal.Name = "lblTotal";
            this.lblTotal.Size = new System.Drawing.Size(124, 20);
            this.lblTotal.TabIndex = 110;
            this.lblTotal.Text = "0";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.White;
            this.label2.Location = new System.Drawing.Point(997, 25);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(44, 20);
            this.label2.TabIndex = 109;
            this.label2.Text = "Total";
            // 
            // btnReset
            // 
            this.btnReset.Location = new System.Drawing.Point(897, 15);
            this.btnReset.Name = "btnReset";
            this.btnReset.Size = new System.Drawing.Size(94, 38);
            this.btnReset.TabIndex = 108;
            this.btnReset.Text = "Reset";
            this.btnReset.UseVisualStyleBackColor = true;
            this.btnReset.Click += new System.EventHandler(this.btnReset_Click);
            // 
            // btnShow
            // 
            this.btnShow.Location = new System.Drawing.Point(673, 15);
            this.btnShow.Name = "btnShow";
            this.btnShow.Size = new System.Drawing.Size(94, 38);
            this.btnShow.TabIndex = 107;
            this.btnShow.Text = "Show";
            this.btnShow.UseVisualStyleBackColor = true;
            this.btnShow.Click += new System.EventHandler(this.btnShow_Click);
            // 
            // dtTo
            // 
            this.dtTo.CustomFormat = "dd-MM-yyyy hh:mm tt";
            this.dtTo.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtTo.Location = new System.Drawing.Point(412, 49);
            this.dtTo.Name = "dtTo";
            this.dtTo.Size = new System.Drawing.Size(147, 20);
            this.dtTo.TabIndex = 106;
            // 
            // dtFrom
            // 
            this.dtFrom.CustomFormat = "dd-MM-yyyy hh:mm tt";
            this.dtFrom.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtFrom.Location = new System.Drawing.Point(412, 15);
            this.dtFrom.Name = "dtFrom";
            this.dtFrom.Size = new System.Drawing.Size(147, 20);
            this.dtFrom.TabIndex = 105;
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.AllowUserToDeleteRows = false;
            this.dataGridView1.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(25, 80);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.ReadOnly = true;
            this.dataGridView1.RowHeadersVisible = false;
            this.dataGridView1.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridView1.Size = new System.Drawing.Size(1146, 522);
            this.dataGridView1.TabIndex = 104;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(327, 49);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(66, 20);
            this.label1.TabIndex = 103;
            this.label1.Text = "Date To";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.ForeColor = System.Drawing.Color.White;
            this.label9.Location = new System.Drawing.Point(327, 16);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(85, 20);
            this.label9.TabIndex = 102;
            this.label9.Text = "Date From";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.White;
            this.label3.Location = new System.Drawing.Point(21, 31);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(91, 20);
            this.label3.TabIndex = 115;
            this.label3.Text = "Transporter";
            // 
            // cboTransporter
            // 
            this.cboTransporter.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.cboTransporter.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cboTransporter.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cboTransporter.FormattingEnabled = true;
            this.cboTransporter.Location = new System.Drawing.Point(118, 28);
            this.cboTransporter.Name = "cboTransporter";
            this.cboTransporter.Size = new System.Drawing.Size(203, 27);
            this.cboTransporter.TabIndex = 116;
            // 
            // chkCreditPayment
            // 
            this.chkCreditPayment.AutoSize = true;
            this.chkCreditPayment.ForeColor = System.Drawing.Color.White;
            this.chkCreditPayment.Location = new System.Drawing.Point(673, 57);
            this.chkCreditPayment.Name = "chkCreditPayment";
            this.chkCreditPayment.Size = new System.Drawing.Size(100, 17);
            this.chkCreditPayment.TabIndex = 125;
            this.chkCreditPayment.Text = "Credit Payment";
            this.chkCreditPayment.UseVisualStyleBackColor = true;
            this.chkCreditPayment.Visible = false;
            // 
            // crystalReportViewer1
            // 
            this.crystalReportViewer1.ActiveViewIndex = -1;
            this.crystalReportViewer1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.crystalReportViewer1.CachedPageNumberPerDoc = 10;
            this.crystalReportViewer1.Cursor = System.Windows.Forms.Cursors.Default;
            this.crystalReportViewer1.Location = new System.Drawing.Point(25, 80);
            this.crystalReportViewer1.Name = "crystalReportViewer1";
            this.crystalReportViewer1.Size = new System.Drawing.Size(1129, 522);
            this.crystalReportViewer1.TabIndex = 126;
            this.crystalReportViewer1.Visible = false;
            // 
            // EntryDetailsTransporter
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.MidnightBlue;
            this.ClientSize = new System.Drawing.Size(1193, 617);
            this.Controls.Add(this.crystalReportViewer1);
            this.Controls.Add(this.chkCreditPayment);
            this.Controls.Add(this.cboTransporter);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.optOut);
            this.Controls.Add(this.optIn);
            this.Controls.Add(this.OptAll);
            this.Controls.Add(this.btnPrint);
            this.Controls.Add(this.lblTotal);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.btnReset);
            this.Controls.Add(this.btnShow);
            this.Controls.Add(this.dtTo);
            this.Controls.Add(this.dtFrom);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.label9);
            this.Name = "EntryDetailsTransporter";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Entry Details - Transporter";
            this.Load += new System.EventHandler(this.EntryDetailsTransporter_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.RadioButton optOut;
        private System.Windows.Forms.RadioButton optIn;
        private System.Windows.Forms.RadioButton OptAll;
        private System.Windows.Forms.Button btnPrint;
        private System.Windows.Forms.Label lblTotal;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btnReset;
        private System.Windows.Forms.Button btnShow;
        private System.Windows.Forms.DateTimePicker dtTo;
        private System.Windows.Forms.DateTimePicker dtFrom;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox cboTransporter;
        private System.Windows.Forms.CheckBox chkCreditPayment;
        private CrystalDecisions.Windows.Forms.CrystalReportViewer crystalReportViewer1;
    }
}