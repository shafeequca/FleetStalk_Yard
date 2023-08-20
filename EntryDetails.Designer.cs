namespace FleetStalk_Yard
{
    partial class EntryDetails
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            this.label9 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.Edit = new System.Windows.Forms.ToolStripMenuItem();
            this.Cancellation = new System.Windows.Forms.ToolStripMenuItem();
            this.RePrint = new System.Windows.Forms.ToolStripMenuItem();
            this.dtFrom = new System.Windows.Forms.DateTimePicker();
            this.dtTo = new System.Windows.Forms.DateTimePicker();
            this.btnShow = new System.Windows.Forms.Button();
            this.btnReset = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.lblTotal = new System.Windows.Forms.Label();
            this.btnPrint = new System.Windows.Forms.Button();
            this.OptAll = new System.Windows.Forms.RadioButton();
            this.optIn = new System.Windows.Forms.RadioButton();
            this.optOut = new System.Windows.Forms.RadioButton();
            this.groupBoxEdit = new System.Windows.Forms.GroupBox();
            this.TransporterView = new System.Windows.Forms.DataGridView();
            this.label12 = new System.Windows.Forms.Label();
            this.txtTransporter = new System.Windows.Forms.TextBox();
            this.txtApproved = new System.Windows.Forms.TextBox();
            this.label13 = new System.Windows.Forms.Label();
            this.lblBillAmount = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.txtSettlementAmount = new System.Windows.Forms.TextBox();
            this.label10 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.ExitTime = new System.Windows.Forms.DateTimePicker();
            this.label7 = new System.Windows.Forms.Label();
            this.EntryTime = new System.Windows.Forms.DateTimePicker();
            this.VehicleType = new System.Windows.Forms.ComboBox();
            this.label22 = new System.Windows.Forms.Label();
            this.RESET = new System.Windows.Forms.Button();
            this.SAVE = new System.Windows.Forms.Button();
            this.Phone = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.Driver = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.TruckNumber = new System.Windows.Forms.TextBox();
            this.groupBoxCancel = new System.Windows.Forms.GroupBox();
            this.btnExit = new System.Windows.Forms.Button();
            this.btnCancellationSave = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.Remarks = new System.Windows.Forms.TextBox();
            this.crystalReportViewer1 = new CrystalDecisions.Windows.Forms.CrystalReportViewer();
            this.lblCredit = new System.Windows.Forms.Label();
            this.label14 = new System.Windows.Forms.Label();
            this.chkCash = new System.Windows.Forms.CheckBox();
            this.chkCredit = new System.Windows.Forms.CheckBox();
            this.label15 = new System.Windows.Forms.Label();
            this.label16 = new System.Windows.Forms.Label();
            this.cboTransporter = new System.Windows.Forms.ComboBox();
            this.cboVehicle = new System.Windows.Forms.ComboBox();
            this.chkContract = new System.Windows.Forms.CheckBox();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.contextMenuStrip1.SuspendLayout();
            this.groupBoxEdit.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.TransporterView)).BeginInit();
            this.groupBoxCancel.SuspendLayout();
            this.SuspendLayout();
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.ForeColor = System.Drawing.Color.White;
            this.label9.Location = new System.Drawing.Point(322, 11);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(85, 20);
            this.label9.TabIndex = 88;
            this.label9.Text = "Date From";
            this.label9.Click += new System.EventHandler(this.label9_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(322, 39);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(66, 20);
            this.label1.TabIndex = 89;
            this.label1.Text = "Date To";
            this.label1.Click += new System.EventHandler(this.label1_Click);
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.AllowUserToDeleteRows = false;
            this.dataGridView1.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.ContextMenuStrip = this.contextMenuStrip1;
            this.dataGridView1.Location = new System.Drawing.Point(25, 71);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.ReadOnly = true;
            this.dataGridView1.RowHeadersVisible = false;
            this.dataGridView1.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridView1.Size = new System.Drawing.Size(1270, 534);
            this.dataGridView1.TabIndex = 90;
            this.dataGridView1.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellContentClick);
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.Edit,
            this.Cancellation,
            this.RePrint});
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(141, 70);
            // 
            // Edit
            // 
            this.Edit.Name = "Edit";
            this.Edit.Size = new System.Drawing.Size(140, 22);
            this.Edit.Text = "Edit";
            // 
            // Cancellation
            // 
            this.Cancellation.Name = "Cancellation";
            this.Cancellation.Size = new System.Drawing.Size(140, 22);
            this.Cancellation.Text = "Cancellation";
            // 
            // RePrint
            // 
            this.RePrint.Name = "RePrint";
            this.RePrint.Size = new System.Drawing.Size(140, 22);
            this.RePrint.Text = "Re-Print";
            // 
            // dtFrom
            // 
            this.dtFrom.CustomFormat = "dd-MM-yyyy hh:mm tt";
            this.dtFrom.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtFrom.Location = new System.Drawing.Point(414, 10);
            this.dtFrom.Name = "dtFrom";
            this.dtFrom.Size = new System.Drawing.Size(147, 20);
            this.dtFrom.TabIndex = 91;
            this.dtFrom.ValueChanged += new System.EventHandler(this.dtFrom_ValueChanged);
            // 
            // dtTo
            // 
            this.dtTo.CustomFormat = "dd-MM-yyyy hh:mm tt";
            this.dtTo.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtTo.Location = new System.Drawing.Point(414, 40);
            this.dtTo.Name = "dtTo";
            this.dtTo.Size = new System.Drawing.Size(147, 20);
            this.dtTo.TabIndex = 92;
            this.dtTo.ValueChanged += new System.EventHandler(this.dtTo_ValueChanged);
            // 
            // btnShow
            // 
            this.btnShow.Location = new System.Drawing.Point(793, 18);
            this.btnShow.Name = "btnShow";
            this.btnShow.Size = new System.Drawing.Size(60, 38);
            this.btnShow.TabIndex = 93;
            this.btnShow.Text = "Show";
            this.btnShow.UseVisualStyleBackColor = true;
            this.btnShow.Click += new System.EventHandler(this.btnShow_Click);
            // 
            // btnReset
            // 
            this.btnReset.Location = new System.Drawing.Point(936, 17);
            this.btnReset.Name = "btnReset";
            this.btnReset.Size = new System.Drawing.Size(63, 38);
            this.btnReset.TabIndex = 94;
            this.btnReset.Text = "Reset";
            this.btnReset.UseVisualStyleBackColor = true;
            this.btnReset.Click += new System.EventHandler(this.btnReset_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.White;
            this.label2.Location = new System.Drawing.Point(1003, 13);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(138, 20);
            this.label2.TabIndex = 95;
            this.label2.Text = "Collection Amount";
            this.label2.Click += new System.EventHandler(this.label2_Click);
            // 
            // lblTotal
            // 
            this.lblTotal.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTotal.ForeColor = System.Drawing.Color.Red;
            this.lblTotal.Location = new System.Drawing.Point(1153, 13);
            this.lblTotal.Name = "lblTotal";
            this.lblTotal.Size = new System.Drawing.Size(139, 20);
            this.lblTotal.TabIndex = 96;
            this.lblTotal.Text = "0";
            this.lblTotal.Click += new System.EventHandler(this.lblTotal_Click);
            // 
            // btnPrint
            // 
            this.btnPrint.Location = new System.Drawing.Point(859, 18);
            this.btnPrint.Name = "btnPrint";
            this.btnPrint.Size = new System.Drawing.Size(71, 38);
            this.btnPrint.TabIndex = 97;
            this.btnPrint.Text = "&Print Preview";
            this.btnPrint.UseVisualStyleBackColor = true;
            this.btnPrint.Click += new System.EventHandler(this.btnPrint_Click);
            // 
            // OptAll
            // 
            this.OptAll.AutoSize = true;
            this.OptAll.Checked = true;
            this.OptAll.ForeColor = System.Drawing.Color.White;
            this.OptAll.Location = new System.Drawing.Point(583, 5);
            this.OptAll.Name = "OptAll";
            this.OptAll.Size = new System.Drawing.Size(42, 17);
            this.OptAll.TabIndex = 99;
            this.OptAll.TabStop = true;
            this.OptAll.Text = "ALL";
            this.OptAll.UseVisualStyleBackColor = true;
            this.OptAll.CheckedChanged += new System.EventHandler(this.OptAll_CheckedChanged);
            // 
            // optIn
            // 
            this.optIn.AutoSize = true;
            this.optIn.ForeColor = System.Drawing.Color.White;
            this.optIn.Location = new System.Drawing.Point(583, 26);
            this.optIn.Name = "optIn";
            this.optIn.Size = new System.Drawing.Size(60, 17);
            this.optIn.TabIndex = 100;
            this.optIn.TabStop = true;
            this.optIn.Text = "In Only";
            this.optIn.UseVisualStyleBackColor = true;
            this.optIn.CheckedChanged += new System.EventHandler(this.optIn_CheckedChanged);
            // 
            // optOut
            // 
            this.optOut.AutoSize = true;
            this.optOut.ForeColor = System.Drawing.Color.White;
            this.optOut.Location = new System.Drawing.Point(583, 48);
            this.optOut.Name = "optOut";
            this.optOut.Size = new System.Drawing.Size(68, 17);
            this.optOut.TabIndex = 101;
            this.optOut.TabStop = true;
            this.optOut.Text = "Out Only";
            this.optOut.UseVisualStyleBackColor = true;
            this.optOut.CheckedChanged += new System.EventHandler(this.optOut_CheckedChanged);
            // 
            // groupBoxEdit
            // 
            this.groupBoxEdit.Controls.Add(this.TransporterView);
            this.groupBoxEdit.Controls.Add(this.label12);
            this.groupBoxEdit.Controls.Add(this.txtTransporter);
            this.groupBoxEdit.Controls.Add(this.txtApproved);
            this.groupBoxEdit.Controls.Add(this.label13);
            this.groupBoxEdit.Controls.Add(this.lblBillAmount);
            this.groupBoxEdit.Controls.Add(this.label11);
            this.groupBoxEdit.Controls.Add(this.txtSettlementAmount);
            this.groupBoxEdit.Controls.Add(this.label10);
            this.groupBoxEdit.Controls.Add(this.label8);
            this.groupBoxEdit.Controls.Add(this.ExitTime);
            this.groupBoxEdit.Controls.Add(this.label7);
            this.groupBoxEdit.Controls.Add(this.EntryTime);
            this.groupBoxEdit.Controls.Add(this.VehicleType);
            this.groupBoxEdit.Controls.Add(this.label22);
            this.groupBoxEdit.Controls.Add(this.RESET);
            this.groupBoxEdit.Controls.Add(this.SAVE);
            this.groupBoxEdit.Controls.Add(this.Phone);
            this.groupBoxEdit.Controls.Add(this.label5);
            this.groupBoxEdit.Controls.Add(this.Driver);
            this.groupBoxEdit.Controls.Add(this.label4);
            this.groupBoxEdit.Controls.Add(this.label6);
            this.groupBoxEdit.Controls.Add(this.TruckNumber);
            this.groupBoxEdit.ForeColor = System.Drawing.Color.White;
            this.groupBoxEdit.Location = new System.Drawing.Point(52, 85);
            this.groupBoxEdit.Margin = new System.Windows.Forms.Padding(13);
            this.groupBoxEdit.Name = "groupBoxEdit";
            this.groupBoxEdit.Size = new System.Drawing.Size(392, 509);
            this.groupBoxEdit.TabIndex = 103;
            this.groupBoxEdit.TabStop = false;
            this.groupBoxEdit.Visible = false;
            // 
            // TransporterView
            // 
            this.TransporterView.AllowUserToAddRows = false;
            this.TransporterView.AllowUserToDeleteRows = false;
            this.TransporterView.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.TransporterView.BackgroundColor = System.Drawing.Color.White;
            this.TransporterView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.TransporterView.ColumnHeadersVisible = false;
            this.TransporterView.Location = new System.Drawing.Point(171, 45);
            this.TransporterView.Name = "TransporterView";
            this.TransporterView.ReadOnly = true;
            this.TransporterView.RowHeadersVisible = false;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.Color.Black;
            this.TransporterView.RowsDefaultCellStyle = dataGridViewCellStyle1;
            this.TransporterView.Size = new System.Drawing.Size(191, 122);
            this.TransporterView.TabIndex = 117;
            this.TransporterView.Visible = false;
            this.TransporterView.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.TransporterView_CellClick);
            this.TransporterView.KeyDown += new System.Windows.Forms.KeyEventHandler(this.TransporterView_KeyDown);
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label12.ForeColor = System.Drawing.Color.White;
            this.label12.Location = new System.Drawing.Point(18, 19);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(91, 20);
            this.label12.TabIndex = 116;
            this.label12.Text = "Transporter";
            // 
            // txtTransporter
            // 
            this.txtTransporter.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtTransporter.Location = new System.Drawing.Point(171, 17);
            this.txtTransporter.MaxLength = 100;
            this.txtTransporter.Name = "txtTransporter";
            this.txtTransporter.Size = new System.Drawing.Size(190, 26);
            this.txtTransporter.TabIndex = 115;
            this.txtTransporter.TextChanged += new System.EventHandler(this.txtTransporter_TextChanged);
            this.txtTransporter.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtTransporter_KeyDown);
            // 
            // txtApproved
            // 
            this.txtApproved.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtApproved.Location = new System.Drawing.Point(171, 385);
            this.txtApproved.MaxLength = 100;
            this.txtApproved.Name = "txtApproved";
            this.txtApproved.Size = new System.Drawing.Size(190, 26);
            this.txtApproved.TabIndex = 113;
            // 
            // label13
            // 
            this.label13.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label13.ForeColor = System.Drawing.Color.White;
            this.label13.Location = new System.Drawing.Point(18, 377);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(147, 41);
            this.label13.TabIndex = 114;
            this.label13.Text = "Discount Approved By";
            // 
            // lblBillAmount
            // 
            this.lblBillAmount.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblBillAmount.ForeColor = System.Drawing.Color.White;
            this.lblBillAmount.Location = new System.Drawing.Point(167, 308);
            this.lblBillAmount.Name = "lblBillAmount";
            this.lblBillAmount.Size = new System.Drawing.Size(194, 20);
            this.lblBillAmount.TabIndex = 112;
            this.lblBillAmount.Text = "0";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label11.ForeColor = System.Drawing.Color.White;
            this.label11.Location = new System.Drawing.Point(18, 308);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(89, 20);
            this.label11.TabIndex = 111;
            this.label11.Text = "Bill Amount";
            // 
            // txtSettlementAmount
            // 
            this.txtSettlementAmount.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtSettlementAmount.Location = new System.Drawing.Point(171, 344);
            this.txtSettlementAmount.MaxLength = 100;
            this.txtSettlementAmount.Name = "txtSettlementAmount";
            this.txtSettlementAmount.Size = new System.Drawing.Size(190, 26);
            this.txtSettlementAmount.TabIndex = 109;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label10.ForeColor = System.Drawing.Color.White;
            this.label10.Location = new System.Drawing.Point(18, 347);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(147, 20);
            this.label10.TabIndex = 110;
            this.label10.Text = "Settlement Amount";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.ForeColor = System.Drawing.Color.White;
            this.label8.Location = new System.Drawing.Point(18, 268);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(73, 20);
            this.label8.TabIndex = 108;
            this.label8.Text = "Exit Time";
            // 
            // ExitTime
            // 
            this.ExitTime.CustomFormat = "dd-MM-yyyy hh:mm tt";
            this.ExitTime.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.ExitTime.Location = new System.Drawing.Point(171, 268);
            this.ExitTime.Name = "ExitTime";
            this.ExitTime.Size = new System.Drawing.Size(190, 20);
            this.ExitTime.TabIndex = 107;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.ForeColor = System.Drawing.Color.White;
            this.label7.Location = new System.Drawing.Point(18, 227);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(84, 20);
            this.label7.TabIndex = 106;
            this.label7.Text = "Entry Time";
            // 
            // EntryTime
            // 
            this.EntryTime.CustomFormat = "dd-MM-yyyy hh:mm tt";
            this.EntryTime.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.EntryTime.Location = new System.Drawing.Point(171, 227);
            this.EntryTime.Name = "EntryTime";
            this.EntryTime.Size = new System.Drawing.Size(190, 20);
            this.EntryTime.TabIndex = 105;
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
            this.VehicleType.Location = new System.Drawing.Point(171, 93);
            this.VehicleType.Name = "VehicleType";
            this.VehicleType.Size = new System.Drawing.Size(190, 27);
            this.VehicleType.TabIndex = 96;
            // 
            // label22
            // 
            this.label22.AutoSize = true;
            this.label22.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label22.ForeColor = System.Drawing.Color.White;
            this.label22.Location = new System.Drawing.Point(18, 95);
            this.label22.Name = "label22";
            this.label22.Size = new System.Drawing.Size(43, 20);
            this.label22.TabIndex = 104;
            this.label22.Text = "Type";
            // 
            // RESET
            // 
            this.RESET.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.RESET.ForeColor = System.Drawing.Color.Black;
            this.RESET.Location = new System.Drawing.Point(209, 432);
            this.RESET.Name = "RESET";
            this.RESET.Size = new System.Drawing.Size(153, 54);
            this.RESET.TabIndex = 100;
            this.RESET.Text = "Exit";
            this.RESET.UseVisualStyleBackColor = true;
            this.RESET.Click += new System.EventHandler(this.RESET_Click);
            // 
            // SAVE
            // 
            this.SAVE.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.SAVE.ForeColor = System.Drawing.Color.Black;
            this.SAVE.Location = new System.Drawing.Point(19, 432);
            this.SAVE.Name = "SAVE";
            this.SAVE.Size = new System.Drawing.Size(158, 54);
            this.SAVE.TabIndex = 99;
            this.SAVE.Text = "Save";
            this.SAVE.UseVisualStyleBackColor = true;
            this.SAVE.Click += new System.EventHandler(this.SAVE_Click);
            // 
            // Phone
            // 
            this.Phone.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Phone.Location = new System.Drawing.Point(171, 136);
            this.Phone.MaxLength = 10;
            this.Phone.Name = "Phone";
            this.Phone.Size = new System.Drawing.Size(190, 26);
            this.Phone.TabIndex = 97;
            this.Phone.TextChanged += new System.EventHandler(this.Phone_TextChanged);
            this.Phone.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.Phone_KeyPress);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.ForeColor = System.Drawing.Color.White;
            this.label5.Location = new System.Drawing.Point(18, 139);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(125, 20);
            this.label5.TabIndex = 103;
            this.label5.Text = "Contact Number";
            // 
            // Driver
            // 
            this.Driver.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Driver.Location = new System.Drawing.Point(171, 182);
            this.Driver.MaxLength = 100;
            this.Driver.Name = "Driver";
            this.Driver.Size = new System.Drawing.Size(190, 26);
            this.Driver.TabIndex = 98;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.Color.White;
            this.label4.Location = new System.Drawing.Point(18, 185);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(111, 20);
            this.label4.TabIndex = 102;
            this.label4.Text = "Contact Name";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.ForeColor = System.Drawing.Color.White;
            this.label6.Location = new System.Drawing.Point(18, 56);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(121, 20);
            this.label6.TabIndex = 101;
            this.label6.Text = "Vehicle Number";
            // 
            // TruckNumber
            // 
            this.TruckNumber.Enabled = false;
            this.TruckNumber.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TruckNumber.Location = new System.Drawing.Point(171, 54);
            this.TruckNumber.MaxLength = 3;
            this.TruckNumber.Name = "TruckNumber";
            this.TruckNumber.Size = new System.Drawing.Size(190, 26);
            this.TruckNumber.TabIndex = 95;
            // 
            // groupBoxCancel
            // 
            this.groupBoxCancel.Controls.Add(this.btnExit);
            this.groupBoxCancel.Controls.Add(this.btnCancellationSave);
            this.groupBoxCancel.Controls.Add(this.label3);
            this.groupBoxCancel.Controls.Add(this.Remarks);
            this.groupBoxCancel.ForeColor = System.Drawing.Color.White;
            this.groupBoxCancel.Location = new System.Drawing.Point(702, 109);
            this.groupBoxCancel.Name = "groupBoxCancel";
            this.groupBoxCancel.Size = new System.Drawing.Size(431, 230);
            this.groupBoxCancel.TabIndex = 104;
            this.groupBoxCancel.TabStop = false;
            this.groupBoxCancel.Visible = false;
            // 
            // btnExit
            // 
            this.btnExit.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnExit.ForeColor = System.Drawing.Color.Black;
            this.btnExit.Location = new System.Drawing.Point(265, 150);
            this.btnExit.Name = "btnExit";
            this.btnExit.Size = new System.Drawing.Size(117, 47);
            this.btnExit.TabIndex = 95;
            this.btnExit.Text = "Exit";
            this.btnExit.UseVisualStyleBackColor = true;
            this.btnExit.Click += new System.EventHandler(this.btnExit_Click);
            // 
            // btnCancellationSave
            // 
            this.btnCancellationSave.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCancellationSave.ForeColor = System.Drawing.Color.Black;
            this.btnCancellationSave.Location = new System.Drawing.Point(134, 150);
            this.btnCancellationSave.Name = "btnCancellationSave";
            this.btnCancellationSave.Size = new System.Drawing.Size(125, 47);
            this.btnCancellationSave.TabIndex = 94;
            this.btnCancellationSave.Text = "Save";
            this.btnCancellationSave.UseVisualStyleBackColor = true;
            this.btnCancellationSave.Click += new System.EventHandler(this.btnCancellationSave_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.White;
            this.label3.Location = new System.Drawing.Point(40, 48);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(65, 20);
            this.label3.TabIndex = 90;
            this.label3.Text = "Reason";
            // 
            // Remarks
            // 
            this.Remarks.Location = new System.Drawing.Point(134, 48);
            this.Remarks.Multiline = true;
            this.Remarks.Name = "Remarks";
            this.Remarks.Size = new System.Drawing.Size(248, 87);
            this.Remarks.TabIndex = 0;
            // 
            // crystalReportViewer1
            // 
            this.crystalReportViewer1.ActiveViewIndex = -1;
            this.crystalReportViewer1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.crystalReportViewer1.CachedPageNumberPerDoc = 10;
            this.crystalReportViewer1.Cursor = System.Windows.Forms.Cursors.Default;
            this.crystalReportViewer1.Location = new System.Drawing.Point(521, 336);
            this.crystalReportViewer1.Name = "crystalReportViewer1";
            this.crystalReportViewer1.Size = new System.Drawing.Size(440, 258);
            this.crystalReportViewer1.TabIndex = 105;
            // 
            // lblCredit
            // 
            this.lblCredit.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCredit.ForeColor = System.Drawing.Color.Red;
            this.lblCredit.Location = new System.Drawing.Point(1153, 39);
            this.lblCredit.Name = "lblCredit";
            this.lblCredit.Size = new System.Drawing.Size(139, 20);
            this.lblCredit.TabIndex = 107;
            this.lblCredit.Text = "0";
            // 
            // label14
            // 
            this.label14.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label14.ForeColor = System.Drawing.Color.White;
            this.label14.Location = new System.Drawing.Point(1003, 39);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(168, 27);
            this.label14.TabIndex = 106;
            this.label14.Text = "Contract / Credit";
            // 
            // chkCash
            // 
            this.chkCash.AutoSize = true;
            this.chkCash.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chkCash.ForeColor = System.Drawing.Color.White;
            this.chkCash.Location = new System.Drawing.Point(670, 5);
            this.chkCash.Name = "chkCash";
            this.chkCash.Size = new System.Drawing.Size(108, 20);
            this.chkCash.TabIndex = 108;
            this.chkCash.Text = "Cash Payment";
            this.chkCash.UseVisualStyleBackColor = true;
            // 
            // chkCredit
            // 
            this.chkCredit.AutoSize = true;
            this.chkCredit.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chkCredit.ForeColor = System.Drawing.Color.White;
            this.chkCredit.Location = new System.Drawing.Point(670, 27);
            this.chkCredit.Name = "chkCredit";
            this.chkCredit.Size = new System.Drawing.Size(114, 20);
            this.chkCredit.TabIndex = 109;
            this.chkCredit.Text = "Credit Payment";
            this.chkCredit.UseVisualStyleBackColor = true;
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label15.ForeColor = System.Drawing.Color.White;
            this.label15.Location = new System.Drawing.Point(22, 11);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(91, 20);
            this.label15.TabIndex = 110;
            this.label15.Text = "Transporter";
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label16.ForeColor = System.Drawing.Color.White;
            this.label16.Location = new System.Drawing.Point(24, 39);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(89, 20);
            this.label16.TabIndex = 111;
            this.label16.Text = "Vehicle No.";
            // 
            // cboTransporter
            // 
            this.cboTransporter.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.cboTransporter.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cboTransporter.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cboTransporter.FormattingEnabled = true;
            this.cboTransporter.Location = new System.Drawing.Point(118, 8);
            this.cboTransporter.Name = "cboTransporter";
            this.cboTransporter.Size = new System.Drawing.Size(203, 24);
            this.cboTransporter.TabIndex = 117;
            this.cboTransporter.SelectedIndexChanged += new System.EventHandler(this.cboTransporter_SelectedIndexChanged);
            this.cboTransporter.TextChanged += new System.EventHandler(this.cboTransporter_TextChanged);
            // 
            // cboVehicle
            // 
            this.cboVehicle.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.cboVehicle.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cboVehicle.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cboVehicle.FormattingEnabled = true;
            this.cboVehicle.Location = new System.Drawing.Point(118, 38);
            this.cboVehicle.Name = "cboVehicle";
            this.cboVehicle.Size = new System.Drawing.Size(203, 24);
            this.cboVehicle.TabIndex = 118;
            // 
            // chkContract
            // 
            this.chkContract.AutoSize = true;
            this.chkContract.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chkContract.ForeColor = System.Drawing.Color.White;
            this.chkContract.Location = new System.Drawing.Point(670, 48);
            this.chkContract.Name = "chkContract";
            this.chkContract.Size = new System.Drawing.Size(75, 20);
            this.chkContract.TabIndex = 119;
            this.chkContract.Text = "Contract";
            this.chkContract.UseVisualStyleBackColor = true;
            // 
            // EntryDetails
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.MidnightBlue;
            this.ClientSize = new System.Drawing.Size(1326, 617);
            this.Controls.Add(this.chkContract);
            this.Controls.Add(this.cboVehicle);
            this.Controls.Add(this.label16);
            this.Controls.Add(this.label15);
            this.Controls.Add(this.chkCredit);
            this.Controls.Add(this.chkCash);
            this.Controls.Add(this.lblCredit);
            this.Controls.Add(this.label14);
            this.Controls.Add(this.crystalReportViewer1);
            this.Controls.Add(this.groupBoxCancel);
            this.Controls.Add(this.groupBoxEdit);
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
            this.Controls.Add(this.cboTransporter);
            this.Name = "EntryDetails";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Entry Details";
            this.Load += new System.EventHandler(this.EntryDetails_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.contextMenuStrip1.ResumeLayout(false);
            this.groupBoxEdit.ResumeLayout(false);
            this.groupBoxEdit.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.TransporterView)).EndInit();
            this.groupBoxCancel.ResumeLayout(false);
            this.groupBoxCancel.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.DateTimePicker dtFrom;
        private System.Windows.Forms.DateTimePicker dtTo;
        private System.Windows.Forms.Button btnShow;
        private System.Windows.Forms.Button btnReset;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label lblTotal;
        private System.Windows.Forms.Button btnPrint;
        private System.Windows.Forms.RadioButton OptAll;
        private System.Windows.Forms.RadioButton optIn;
        private System.Windows.Forms.RadioButton optOut;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.ToolStripMenuItem Edit;
        private System.Windows.Forms.ToolStripMenuItem Cancellation;
        private System.Windows.Forms.GroupBox groupBoxEdit;
        private System.Windows.Forms.GroupBox groupBoxCancel;
        private System.Windows.Forms.Button btnExit;
        private System.Windows.Forms.Button btnCancellationSave;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox Remarks;
        private System.Windows.Forms.ComboBox VehicleType;
        private System.Windows.Forms.Label label22;
        private System.Windows.Forms.Button RESET;
        private System.Windows.Forms.Button SAVE;
        private System.Windows.Forms.TextBox Phone;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox Driver;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox TruckNumber;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.DateTimePicker ExitTime;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.DateTimePicker EntryTime;
        private System.Windows.Forms.TextBox txtSettlementAmount;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label lblBillAmount;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.TextBox txtApproved;
        private System.Windows.Forms.Label label13;
        private CrystalDecisions.Windows.Forms.CrystalReportViewer crystalReportViewer1;
        private System.Windows.Forms.Label lblCredit;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.ToolStripMenuItem RePrint;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.TextBox txtTransporter;
        private System.Windows.Forms.DataGridView TransporterView;
        private System.Windows.Forms.CheckBox chkCash;
        private System.Windows.Forms.CheckBox chkCredit;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.Label label16;
        private System.Windows.Forms.ComboBox cboTransporter;
        private System.Windows.Forms.ComboBox cboVehicle;
        private System.Windows.Forms.CheckBox chkContract;
    }
}