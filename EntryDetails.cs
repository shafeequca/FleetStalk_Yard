using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using CrystalDecisions.CrystalReports.Engine;
using FleetStalk_Yard.DataSet;
using System.Data.SqlClient;
using CrystalDecisions.Windows.Forms;

namespace FleetStalk_Yard
{
    public partial class EntryDetails : Form
    {
        DataSet1 ds;
        string yard_id;
        public bool vehicleStart;

        public EntryDetails()
        {
            InitializeComponent();
            this.contextMenuStrip1.ItemClicked += new System.Windows.Forms.ToolStripItemClickedEventHandler(this.Menu_Click);
            this.contextMenuStrip1.Opening += new CancelEventHandler(contextMenuStrip1_Opening);

        }
        private void contextMenuStrip1_Opening(object sender, CancelEventArgs e)
        {
            if (dataGridView1.Rows.Count==0)
            {
                e.Cancel = true;
            }
        }
        private void Menu_Click(object sender, ToolStripItemClickedEventArgs e)
        {
            if (dataGridView1.SelectedRows.Count > 0)
            {
                int rowno = dataGridView1.SelectedRows[0].Index;
                ToolStripItem item = e.ClickedItem;
                if (Connections.Instance.user_type == "Administrator" && item.Name == "Edit" && dataGridView1.Rows[rowno].Cells[18].Value.ToString() == "A")
                {
                    groupBoxEdit.Visible = true;
                    
                    TruckNumber.Tag = dataGridView1.Rows[rowno].Cells[0].Value.ToString();
                    TruckNumber.Text = dataGridView1.Rows[rowno].Cells[3].Value.ToString();
                    VehicleType.Text = dataGridView1.Rows[rowno].Cells[2].Value.ToString();
                    EntryTime.Value = Convert.ToDateTime(dataGridView1.Rows[rowno].Cells[4].Value.ToString());
                    txtTransporter.Text = dataGridView1.Rows[rowno].Cells[20].Value.ToString();
                    txtTransporter.Tag = dataGridView1.Rows[rowno].Cells[21].Value.ToString();
                    if (dataGridView1.Rows[rowno].Cells[5].Value.ToString() != "")
                    {
                        ExitTime.Enabled = true;
                        txtSettlementAmount.Enabled = true;
                        ExitTime.Value = Convert.ToDateTime(dataGridView1.Rows[rowno].Cells[5].Value.ToString());
                        lblBillAmount.Text = dataGridView1.Rows[rowno].Cells[14].Value.ToString();
                        txtSettlementAmount.Text = dataGridView1.Rows[rowno].Cells[14].Value.ToString();
                    }
                    else
                    {
                        ExitTime.Enabled = false;
                        lblBillAmount.Text = "0";
                        txtSettlementAmount.Enabled = false;
                        txtSettlementAmount.Text = "0";
                    }
                    Driver.Text = dataGridView1.Rows[rowno].Cells[16].Value.ToString();
                    Phone.Text = dataGridView1.Rows[rowno].Cells[17].Value.ToString();
                    TransporterView.Visible = false;

                }
                else if (Connections.Instance.user_type == "Administrator" && item.Name == "Cancellation" && dataGridView1.Rows[rowno].Cells[18].Value.ToString() == "A")
                {
                    groupBoxCancel.Left = dataGridView1.Width / 3;
                    groupBoxCancel.Visible = true;
                    Remarks.Tag = dataGridView1.Rows[rowno].Cells[0].Value.ToString();
                    Remarks.Focus();

                }
                else if (item.Name == "RePrint" && dataGridView1.Rows[rowno].Cells[18].Value.ToString() == "A" && optOut.Checked == true)
                {


                    DialogResult dialogResult;


                    dialogResult = MessageBox.Show("Do you want to print the receipt?", "Yard Entry", MessageBoxButtons.YesNo);
                    if (dialogResult == DialogResult.Yes)
                    {
                        string reportFileName = System.Configuration.ConfigurationSettings.AppSettings["ReceiptSlip"];
                        SqlCommand cmd = new SqlCommand();
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.CommandText = "Get_Bill";

                        cmd.Parameters.Add("@ID", SqlDbType.Int).Value = dataGridView1.Rows[rowno].Cells[0].Value.ToString(); ;

                        cmd.Parameters.Add("@GST_Bill_No", SqlDbType.Int);
                        cmd.Parameters["@GST_Bill_No"].Direction = ParameterDirection.Output;

                        cmd.Parameters.Add("@Is_Credit_Payment", SqlDbType.Char,1);
                        cmd.Parameters["@Is_Credit_Payment"].Direction = ParameterDirection.Output;

                        cmd.Parameters.Add("@VehicleNumber", SqlDbType.VarChar, 20);
                        cmd.Parameters["@VehicleNumber"].Direction = ParameterDirection.Output;

                        cmd.Parameters.Add("@EntryTime", SqlDbType.DateTime);
                        cmd.Parameters["@EntryTime"].Direction = ParameterDirection.Output;

                        cmd.Parameters.Add("@ExitTime", SqlDbType.DateTime);
                        cmd.Parameters["@ExitTime"].Direction = ParameterDirection.Output;

                        cmd.Parameters.Add("@TotalTime", SqlDbType.VarChar, 100);
                        cmd.Parameters["@TotalTime"].Direction = ParameterDirection.Output;

                        cmd.Parameters.Add("@User", SqlDbType.VarChar, 100);
                        cmd.Parameters["@User"].Direction = ParameterDirection.Output;

                        cmd.Parameters.Add("@Bill_Date", SqlDbType.DateTime);
                        cmd.Parameters["@Bill_Date"].Direction = ParameterDirection.Output;

                        cmd.Parameters.Add("@Transporter", SqlDbType.VarChar, 100);
                        cmd.Parameters["@Transporter"].Direction = ParameterDirection.Output;

                        SqlParameter Additional_Amount = new SqlParameter("@AdditionalAmount", SqlDbType.Decimal);
                        Additional_Amount.Precision = 8;
                        Additional_Amount.Scale = 3;
                        Additional_Amount.Direction = ParameterDirection.Output;
                        cmd.Parameters.Add(Additional_Amount);

                        SqlParameter Base_Amount = new SqlParameter("@BaseAmount", SqlDbType.Decimal);
                        Base_Amount.Precision = 8;
                        Base_Amount.Scale = 3;
                        Base_Amount.Direction = ParameterDirection.Output;
                        cmd.Parameters.Add(Base_Amount);

                        SqlParameter SGST_Parameter = new SqlParameter("@SGST", SqlDbType.Decimal);
                        SGST_Parameter.Precision = 7;
                        SGST_Parameter.Scale = 3;
                        SGST_Parameter.Direction = ParameterDirection.Output;
                        cmd.Parameters.Add(SGST_Parameter);

                        SqlParameter CGST_Parameter = new SqlParameter("@CGST", SqlDbType.Decimal);
                        CGST_Parameter.Precision = 7;
                        CGST_Parameter.Scale = 3;
                        CGST_Parameter.Direction = ParameterDirection.Output;
                        cmd.Parameters.Add(CGST_Parameter);

                        SqlParameter GST_Parameter = new SqlParameter("@GST", SqlDbType.Decimal);
                        GST_Parameter.Precision = 7;
                        GST_Parameter.Scale = 3;
                        GST_Parameter.Direction = ParameterDirection.Output;
                        cmd.Parameters.Add(GST_Parameter);

                        SqlParameter CESS_Parameter = new SqlParameter("@CESS", SqlDbType.Decimal);
                        CESS_Parameter.Precision = 7;
                        CESS_Parameter.Scale = 3;
                        CESS_Parameter.Direction = ParameterDirection.Output;
                        cmd.Parameters.Add(CESS_Parameter);

                        SqlParameter GST_Total_Parameter = new SqlParameter("@GST_Total", SqlDbType.Decimal);
                        GST_Total_Parameter.Precision = 7;
                        GST_Total_Parameter.Scale = 3;
                        GST_Total_Parameter.Direction = ParameterDirection.Output;
                        cmd.Parameters.Add(GST_Total_Parameter);

                        SqlParameter TotalAmount_Parameter = new SqlParameter("@TotalAmount", SqlDbType.Decimal);
                        TotalAmount_Parameter.Precision = 8;
                        TotalAmount_Parameter.Scale = 3;
                        TotalAmount_Parameter.Direction = ParameterDirection.Output;
                        cmd.Parameters.Add(TotalAmount_Parameter);

                        Connections.Instance.OpenConection();
                        Connections.Instance.ExecuteProcedure(cmd);


                        System.Data.DataColumn GST_BillNo = new System.Data.DataColumn("GST_BillNo", typeof(System.String));
                        GST_BillNo.DefaultValue = cmd.Parameters["@gst_bill_no"].Value.ToString();

                        System.Data.DataColumn VehicleNumber = new System.Data.DataColumn("VehicleNumber", typeof(System.String));
                        VehicleNumber.DefaultValue = cmd.Parameters["@VehicleNumber"].Value.ToString();

                        System.Data.DataColumn EntryTime = new System.Data.DataColumn("EntryTime", typeof(System.String));
                        EntryTime.DefaultValue = cmd.Parameters["@EntryTime"].Value.ToString();

                        System.Data.DataColumn ExitTime = new System.Data.DataColumn("ExitTime", typeof(System.String));
                        ExitTime.DefaultValue = cmd.Parameters["@ExitTime"].Value.ToString();

                        System.Data.DataColumn TotalTime = new System.Data.DataColumn("TotalTime", typeof(System.String));
                        TotalTime.DefaultValue = cmd.Parameters["@TotalTime"].Value.ToString();

                        System.Data.DataColumn BaseAmount = new System.Data.DataColumn("BaseAmount", typeof(System.Double));
                        BaseAmount.DefaultValue = cmd.Parameters["@BaseAmount"].Value.ToString();

                        System.Data.DataColumn AdditionalAmount = new System.Data.DataColumn("AdditionalAmount", typeof(System.Double));
                        AdditionalAmount.DefaultValue = cmd.Parameters["@AdditionalAmount"].Value.ToString();

                        System.Data.DataColumn TotalAmount = new System.Data.DataColumn("TotalAmount", typeof(System.Double));
                        TotalAmount.DefaultValue = cmd.Parameters["@TotalAmount"].Value.ToString();

                        System.Data.DataColumn User = new System.Data.DataColumn("User", typeof(System.String));
                        User.DefaultValue = cmd.Parameters["@User"].Value.ToString();

                        System.Data.DataColumn SGST = new System.Data.DataColumn("SGST", typeof(System.Double));
                        SGST.DefaultValue = cmd.Parameters["@SGST"].Value.ToString();

                        System.Data.DataColumn CGST = new System.Data.DataColumn("CGST", typeof(System.Double));
                        CGST.DefaultValue = cmd.Parameters["@CGST"].Value.ToString();

                        System.Data.DataColumn GST = new System.Data.DataColumn("GST", typeof(System.Double));
                        GST.DefaultValue = cmd.Parameters["@GST"].Value.ToString();

                        System.Data.DataColumn CESS = new System.Data.DataColumn("CESS", typeof(System.Double));
                        CESS.DefaultValue = cmd.Parameters["@CESS"].Value.ToString();

                        System.Data.DataColumn GST_Total = new System.Data.DataColumn("GST_Total", typeof(System.Double));
                        GST_Total.DefaultValue = cmd.Parameters["@GST_Total"].Value.ToString();

                        System.Data.DataColumn Bill_Date = new System.Data.DataColumn("Bill_Date", typeof(System.String));
                        Bill_Date.DefaultValue = Convert.ToDateTime(cmd.Parameters["@Bill_Date"].Value).ToString("dd-MM-yyyy");

                        System.Data.DataColumn Transporter = new System.Data.DataColumn("Transporter", typeof(System.String));
                        Transporter.DefaultValue = cmd.Parameters["@Transporter"].Value.ToString();

                        DataTable dt = new DataTable();
                        dt.Columns.Add(Transporter);
                        dt.Columns.Add(SGST);
                        dt.Columns.Add(CGST);
                        dt.Columns.Add(GST);
                        dt.Columns.Add(GST_Total);
                        dt.Columns.Add(CESS);
                        dt.Columns.Add(GST_BillNo);
                        dt.Columns.Add(Bill_Date);
                        dt.Columns.Add(VehicleNumber);
                        dt.Columns.Add(EntryTime);
                        dt.Columns.Add(ExitTime);
                        dt.Columns.Add(TotalTime);
                        dt.Columns.Add(BaseAmount);
                        dt.Columns.Add(AdditionalAmount);
                        dt.Columns.Add(TotalAmount);
                        dt.Columns.Add(User);

                        DataRow toInsert = dt.NewRow();

                        // insert in the desired place
                        dt.Rows.InsertAt(toInsert, 0);


                        ds.Tables["Receipt"].Clear();
                        ds.Tables["Receipt"].Merge(dt);

                        string DetailreportFileName = System.Configuration.ConfigurationSettings.AppSettings["ReceiptDetails"];

                        if (cmd.Parameters["@Is_Credit_Payment"].Value.ToString() != "Y")
                        {
                            ReportDocument crpt = new ReportDocument();
                            crpt.Load(System.IO.Path.GetDirectoryName(Application.ExecutablePath).ToString() + reportFileName);
                            crpt.SetDataSource(ds);
                            crpt.Refresh();
                            crpt.PrintToPrinter(1, true, 0, 0);
                        }
                        else
                        {
                            ReportDocument crpt = new ReportDocument();
                            crpt.Load(System.IO.Path.GetDirectoryName(Application.ExecutablePath).ToString() + DetailreportFileName);
                            crpt.SetDataSource(ds);
                            crpt.Refresh();
                            crpt.PrintToPrinter(1, true, 0, 0);
                        }

                        Connections.Instance.CloseConnection();
                        cmd.Dispose();
                    }
                }


            }
        }
        private void btnShow_Click(object sender, EventArgs e)
        {
            crystalReportViewer1.Visible = false;
            groupBoxEdit.Left = dataGridView1.Width / 3;
            
            DataTable dt = new DataTable();

            SqlCommand cmd = new SqlCommand();
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = "Get_Entry_Details";

            if (cboTransporter.SelectedIndex >= 0 && cboTransporter.Text !="")
            {
                cmd.Parameters.Add("@Owner_Id", SqlDbType.Int).Value = cboTransporter.SelectedValue.ToString();
            }
            else
            {
                cmd.Parameters.Add("@Owner_Id", SqlDbType.Int).Value = null; 
            }
            if (cboVehicle.SelectedIndex >= 0 && cboVehicle.Text != "")
            {
                cmd.Parameters.Add("@Vehicle_Id", SqlDbType.Int).Value = cboVehicle.SelectedValue.ToString();
            }
            else
            {
                cmd.Parameters.Add("@Vehicle_Id", SqlDbType.Int).Value = null;
            }

            cmd.Parameters.Add("@Dt_From", SqlDbType.DateTime).Value = dtFrom.Value;
            cmd.Parameters.Add("@Dt_To", SqlDbType.DateTime).Value = dtTo.Value;
            if (OptAll.Checked == true)
            {
                cmd.Parameters.Add("@Entry_Type", SqlDbType.VarChar).Value = "ALL";
            }
            else if (optIn.Checked == true)
            {
                cmd.Parameters.Add("@Entry_Type", SqlDbType.VarChar).Value = "IN";
            }
            else
            {
                cmd.Parameters.Add("@Entry_Type", SqlDbType.VarChar).Value = "OUT";
            }

            if (chkCash.Checked == true && chkCredit.Checked == false)
            {
                cmd.Parameters.Add("@Credit_Type", SqlDbType.VarChar).Value = "N";
            }
            else if (chkCash.Checked == false && chkCredit.Checked == true)
            {
                cmd.Parameters.Add("@Credit_Type", SqlDbType.VarChar).Value = "Y";
            }
            else
            {
                cmd.Parameters.Add("@Credit_Type", SqlDbType.VarChar).Value = "ALL";
            }

            if (chkContract.Checked == true)
            {
                cmd.Parameters.Add("@Contract_Type", SqlDbType.TinyInt).Value = "1";
            }
            else
            {
                cmd.Parameters.Add("@Contract_Type", SqlDbType.TinyInt).Value = "0";
            }

            SqlParameter Collection_Amount = new SqlParameter("@Collection_Amount", SqlDbType.Decimal);
            Collection_Amount.Precision = 8;
            Collection_Amount.Scale = 2;
            Collection_Amount.Direction = ParameterDirection.Output;
            cmd.Parameters.Add(Collection_Amount);

            SqlParameter Credit_Amount = new SqlParameter("@Credit_Amount", SqlDbType.Decimal);
            Credit_Amount.Precision = 8;
            Credit_Amount.Scale = 2;
            Credit_Amount.Direction = ParameterDirection.Output;
            cmd.Parameters.Add(Credit_Amount);

            Connections.Instance.OpenConection();
            cmd.Connection = Connections.Instance.con;
            //Connections.Instance.ExecuteProcedure(cmd);

            dt.Load(cmd.ExecuteReader());
            dataGridView1.DataSource = dt;

            lblTotal.Text = "0";
            lblCredit.Text = "0";

            lblTotal.Text = cmd.Parameters["@Collection_Amount"].Value.ToString();
            lblCredit.Text = cmd.Parameters["@Credit_Amount"].Value.ToString();

            dt.Dispose();
            dataGridView1.Columns[0].Visible = false;
            dataGridView1.Columns[6].Visible = false;
            dataGridView1.Columns[7].Visible = false;
            dataGridView1.Columns[19].Visible = false;
            dataGridView1.Columns[20].Visible = false;
        }

        private void btnReset_Click(object sender, EventArgs e)
        {
            chkCash.Checked = false;
            chkCredit.Checked = false;
            cboTransporter.SelectedIndex = -1;
            cboTransporter.Text = "";
            cboVehicle.SelectedIndex = -1;
            cboVehicle.Text = "";

            crystalReportViewer1.Visible = false;
            groupBoxEdit.Visible = false;
            groupBoxCancel.Visible = false;
            dtFrom.Value = DateTime.Now;
            dtTo.Value = DateTime.Now;
            lblTotal.Text = "0";
            lblCredit.Text = "0";

            dataGridView1.DataSource = null;
            groupBoxCancel.Visible = false;
            groupBoxEdit.Visible = false;
        }

        private void EntryDetails_Load(object sender, EventArgs e)
        {
            yard_id = System.Configuration.ConfigurationSettings.AppSettings["Yard"];
            ds = new DataSet1();
            this.Top = 0;
 
            LoadTransporterList();

            LoadVehicleList(null);
            btnReset_Click(null, null);

        }
        private void LoadTransporterList()
        {
            cboTransporter.DataSource = null;
            string query = "SELECT Owner_Id,Transporter_Name FROM Owner ORDER BY 2";
            cboTransporter.DataSource = Connections.Instance.ShowDataInGridView(query);
            cboTransporter.DisplayMember = "Transporter_Name";
            cboTransporter.ValueMember = "Owner_Id";
            cboTransporter.SelectedIndex = -1;
            cboTransporter.Text = "";
        }
        private void LoadVehicleList(object Ownerid)
        {
            
            cboVehicle.DataSource = null;
            string query = "SELECT Vehicle_Id,Vehicle_Number+' ('+Vehicle_Type+')' AS Vehicle_Number FROM Vehicle ORDER BY 2";

            if (Ownerid != null)
            {
                query = "SELECT Vehicle_Id,Vehicle_Number+' ('+Vehicle_Type+')' AS Vehicle_Number FROM Vehicle WHERE Owner_Id='" + Convert.ToInt32(Ownerid) + "' ORDER BY 2";
            }
            cboVehicle.DataSource = Connections.Instance.ShowDataInGridView(query);
            cboVehicle.DisplayMember = "Vehicle_Number";
            cboVehicle.ValueMember = "Vehicle_Id";
            cboVehicle.SelectedIndex = -1;
            cboVehicle.Text = "";

        }
        private void btnPrint_Click(object sender, EventArgs e)
        {
            if (dataGridView1.Rows.Count==0)
            {
                MessageBox.Show("No records found to print");
                return;
            }
            //string Query = "SELECT ROW_NUMBER() OVER(ORDER BY (SELECT 1)) AS SlNo, v.Vehicle_Type,v.Vehicle_Number,y.Entry_Time,y.Exit_Time,y.Payment_start_time,y.payment_end_time,f.slab_name,CONVERT(DECIMAL(18,2),y.Base_Amount) AS Slab_Amount,CONVERT(DECIMAL(18,2),isnull(y.Additional_Amount,'0')) AS Additional_Amount,CONVERT(DECIMAL(18,2),(y.Base_Amount+y.Additional_Amount)) AS Total,CASE WHEN Reference_Id IS NOT NULL THEN 'Re-Entry' ELSE '' END AS Remarks FROM yard_entry y JOIN vehicle v on v.vehicle_id=y.vehicle_id JOIN Fee_Slab f on f.Fee_Slab_Id=y.Fee_Slab_Id WHERE y.exit_time>='" + dtFrom.Value.ToString("yyyy-MM-dd HH:mm:00") + "' and y.exit_time<='" + dtTo.Value.ToString("yyyy-MM-dd HH:mm:00") + "' AND y.yard_id=" + yard_id + "";
            crystalReportViewer1.Visible = true;
            crystalReportViewer1.ToolPanelView = ToolPanelViewType.None;
            crystalReportViewer1.Width = dataGridView1.Width;
            crystalReportViewer1.Height = dataGridView1.Height;
            crystalReportViewer1.Top = dataGridView1.Top;
            crystalReportViewer1.Left = dataGridView1.Left;

            DataTable dt = new DataTable();

            SqlCommand cmd = new SqlCommand();
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = "Get_Entry_Details";

            if (cboTransporter.SelectedIndex >= 0 && cboTransporter.Text != "")
            {
                cmd.Parameters.Add("@Owner_Id", SqlDbType.Int).Value = cboTransporter.SelectedValue.ToString();
            }
            else
            {
                cmd.Parameters.Add("@Owner_Id", SqlDbType.Int).Value = null;
            }
            if (cboVehicle.SelectedIndex >= 0 && cboVehicle.Text != "")
            {
                cmd.Parameters.Add("@Vehicle_Id", SqlDbType.Int).Value = cboVehicle.SelectedValue.ToString();
            }
            else
            {
                cmd.Parameters.Add("@Vehicle_Id", SqlDbType.Int).Value = null;
            }
            if (chkContract.Checked == true)
            {
                cmd.Parameters.Add("@Contract_Type", SqlDbType.TinyInt).Value = "1";
            }
            else
            {
                cmd.Parameters.Add("@Contract_Type", SqlDbType.TinyInt).Value = "0";
            }
            cmd.Parameters.Add("@Dt_From", SqlDbType.DateTime).Value = dtFrom.Value;
            cmd.Parameters.Add("@Dt_To", SqlDbType.DateTime).Value = dtTo.Value;
            if (OptAll.Checked == true)
            {
                cmd.Parameters.Add("@Entry_Type", SqlDbType.VarChar).Value = "ALL";
            }
            else if (optIn.Checked == true)
            {
                cmd.Parameters.Add("@Entry_Type", SqlDbType.VarChar).Value = "IN";
            }
            else
            {
                cmd.Parameters.Add("@Entry_Type", SqlDbType.VarChar).Value = "OUT";
            }

            if (chkCash.Checked == true && chkCredit.Checked == false)
            {
                cmd.Parameters.Add("@Credit_Type", SqlDbType.VarChar).Value = "N";
            }
            else if (chkCash.Checked == false && chkCredit.Checked == true)
            {
                cmd.Parameters.Add("@Credit_Type", SqlDbType.VarChar).Value = "Y";
            }
            else
            {
                cmd.Parameters.Add("@Credit_Type", SqlDbType.VarChar).Value = "ALL";
            }

            SqlParameter Collection_Amount = new SqlParameter("@Collection_Amount", SqlDbType.Decimal);
            Collection_Amount.Precision = 8;
            Collection_Amount.Scale = 2;
            Collection_Amount.Direction = ParameterDirection.Output;
            cmd.Parameters.Add(Collection_Amount);

            SqlParameter Credit_Amount = new SqlParameter("@Credit_Amount", SqlDbType.Decimal);
            Credit_Amount.Precision = 8;
            Credit_Amount.Scale = 2;
            Credit_Amount.Direction = ParameterDirection.Output;
            cmd.Parameters.Add(Credit_Amount);

            Connections.Instance.OpenConection();
            cmd.Connection = Connections.Instance.con;
            
            dt.Load(cmd.ExecuteReader());
                      
                        
            ds.Tables["EntryDetails"].Clear();
            ds.Tables["EntryDetails"].Merge(dt);
            string reportFileName = System.Configuration.ConfigurationSettings.AppSettings["EntryDetails"];
            ReportDocument cryRpt = new ReportDocument();
            cryRpt.Load(System.IO.Path.GetDirectoryName(Application.ExecutablePath).ToString() + reportFileName);
            if (cryRpt.DataDefinition.FormulaFields.Count > 0)
            {
                cryRpt.DataDefinition.FormulaFields[0].Text = "'" + dtFrom.Value + "'";
                cryRpt.DataDefinition.FormulaFields[1].Text = "'" + dtTo.Value + "'";
                if (lblTotal.Text == "")
                {
                    cryRpt.DataDefinition.FormulaFields[2].Text = "'0'";
                }
                else
                {
                    cryRpt.DataDefinition.FormulaFields[2].Text = "'" + Convert.ToDecimal(lblTotal.Text) + "'";
                }
                if (lblCredit.Text == "")
                {
                    cryRpt.DataDefinition.FormulaFields[3].Text = "'0'";
                }
                else
                {
                    cryRpt.DataDefinition.FormulaFields[3].Text = "'" + Convert.ToDecimal(lblCredit.Text) + "'";
                }
            }
            cryRpt.SetDataSource(ds);
            cryRpt.Refresh();
            //cryRpt.PrintToPrinter(1, true, 0, 0);
            
            crystalReportViewer1.ReportSource = cryRpt;
            crystalReportViewer1.Refresh();

        }

        private void OptAll_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            Remarks.Tag = "";
            Remarks.Text = "";
            groupBoxCancel.Visible = false;
        }

        private void RESET_Click(object sender, EventArgs e)
        {
            TruckNumber.Tag = "";
            TruckNumber.Text = "";
            VehicleType.Text = "";
            EntryTime.Value = DateTime.Now;
            ExitTime.Value = DateTime.Now;
            lblBillAmount.Text = "";
            txtSettlementAmount.Text = "";
            txtApproved.Text = "";
            groupBoxEdit.Visible = false;
            
        }
        private void Phone_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!(Char.IsDigit(e.KeyChar) || (e.KeyChar == (char)Keys.Back)))
                e.Handled = true;
        }
        private void SAVE_Click(object sender, EventArgs e)
        {
            if (txtSettlementAmount.Text != lblBillAmount.Text && txtApproved.Text.Trim()=="")
            {
                MessageBox.Show("Please enter the name of discount approved person");
                txtApproved.Focus();
                return;
            }
            if (txtTransporter.Tag == null || txtTransporter.Tag.ToString() == "")
            {
                MessageBox.Show("Please select a transporter");
                txtTransporter.Focus();
                return;
            }
            
            DialogResult dialogResult = MessageBox.Show("Do you want to update the entry?", "Yard Entry", MessageBoxButtons.YesNo);
            if (dialogResult == DialogResult.Yes)
            {

                SqlCommand cmd = new SqlCommand();
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "Yard_Entry_Edit";


                cmd.Parameters.Add("@ID", SqlDbType.Int).Value = TruckNumber.Tag.ToString();
                cmd.Parameters.Add("@Owner_Id", SqlDbType.Int).Value = txtTransporter.Tag;
                cmd.Parameters.Add("@Vehicle_Type", SqlDbType.VarChar).Value = VehicleType.Text;
                cmd.Parameters.Add("@Contact_Name", SqlDbType.VarChar).Value = Driver.Text.Trim().ToString();
                cmd.Parameters.Add("@Contact_Number", SqlDbType.VarChar).Value = Phone.Text.Trim().ToString();
                cmd.Parameters.Add("@User_Id", SqlDbType.Int).Value = Connections.Instance.user_id;
                cmd.Parameters.Add("@Is_Cancelled", SqlDbType.Char).Value = "N";
                cmd.Parameters.Add("@Remarks", SqlDbType.VarChar).Value = "";
                cmd.Parameters.Add("@Discount_Approved_By", SqlDbType.VarChar).Value = txtApproved.Text;
                if (txtSettlementAmount.Text == "")
                {
                    cmd.Parameters.Add("@Settlement_Amount", SqlDbType.Decimal).Value = lblBillAmount.Text;
                }
                else
                {
                    cmd.Parameters.Add("@Settlement_Amount", SqlDbType.Decimal).Value = txtSettlementAmount.Text;
                }

                cmd.Parameters.Add("@Entry_Time", SqlDbType.DateTime).Value = EntryTime.Value;
                cmd.Parameters.Add("@EXIT_Time", SqlDbType.DateTime).Value = ExitTime.Value;
                
                Connections.Instance.OpenConection();
                Connections.Instance.ExecuteProcedure(cmd);

                RESET_Click(null, null);
                btnShow_Click(null, null);
            }

        }

        private void optIn_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void btnCancellationSave_Click(object sender, EventArgs e)
        {
            if (Remarks.Text.Trim() == "")
            {
                MessageBox.Show("Please enter the reason for cancellation");
                Remarks.Focus();
                return;
            }

            DialogResult dialogResult = MessageBox.Show("Do you want to cancel the entry?", "Yard Entry", MessageBoxButtons.YesNo);
            if (dialogResult == DialogResult.Yes)
            {

                SqlCommand cmd = new SqlCommand();
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "Yard_Entry_Edit";


                cmd.Parameters.Add("@ID", SqlDbType.Int).Value = Remarks.Tag.ToString();
                cmd.Parameters.Add("@Vehicle_Type", SqlDbType.VarChar).Value = null;
                cmd.Parameters.Add("@Contact_Name", SqlDbType.VarChar).Value = null;
                cmd.Parameters.Add("@Contact_Number", SqlDbType.VarChar).Value = null;
                cmd.Parameters.Add("@User_Id", SqlDbType.Int).Value = Connections.Instance.user_id;
                cmd.Parameters.Add("@Is_Cancelled", SqlDbType.Char).Value = "Y";
                cmd.Parameters.Add("@Remarks", SqlDbType.VarChar).Value = Remarks.Text.Trim();
                cmd.Parameters.Add("@Discount_Approved_By", SqlDbType.VarChar).Value = null;
                cmd.Parameters.Add("@Settlement_Amount", SqlDbType.Int).Value = null;


                cmd.Parameters.Add("@Entry_Time", SqlDbType.DateTime).Value = null;
                cmd.Parameters.Add("@EXIT_Time", SqlDbType.DateTime).Value = null;

                Connections.Instance.OpenConection();
                Connections.Instance.ExecuteProcedure(cmd);

                btnExit_Click(null, null);
                btnShow_Click(null, null);
            }
        }

        private void dtTo_ValueChanged(object sender, EventArgs e)
        {

        }

        private void dtFrom_ValueChanged(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label9_Click(object sender, EventArgs e)
        {

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void lblTotal_Click(object sender, EventArgs e)
        {

        }

        private void optOut_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void Phone_TextChanged(object sender, EventArgs e)
        {

        }
        private void txtTransporter_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyData == Keys.Down && TransporterView.Rows.Count != 0 && txtTransporter.Text.Trim() != "")
            {
                TransporterView.Focus();
            }
            else if (e.KeyData == Keys.Enter)
            {
                TransporterView.Visible = false;
                VehicleType.Focus();
            }
            else if (e.KeyData == Keys.Escape)
            {
                TransporterView.Visible = false;
            }

        }
        private void txtTransporter_TextChanged(object sender, EventArgs e)
        {
            string Query = "SELECT Owner_ID,Transporter_Name FROM Owner WHERE Transporter_Name LIKE '%" + txtTransporter.Text + "%' ORDER BY 2";
            TransporterView.DataSource = Connections.Instance.ShowDataInGridView(Query);
            TransporterView.Columns[0].Visible = false;
            txtTransporter.Tag = "";
            if (TransporterView.Rows.Count == 0 || txtTransporter.Text.Trim() == "")
            {             
                TransporterView.Visible = false;
            }
            else
            {
                TransporterView.Visible = true;
            }
        }

        private void TransporterView_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            TransporterView_Show();
            TransporterView.Visible = false;
        }

        private void TransporterView_Show()
        {
            int r = TransporterView.CurrentRow.Index;
            txtTransporter.Text = TransporterView.Rows[r].Cells[1].Value.ToString();
            txtTransporter.Tag = TransporterView.Rows[r].Cells[0].Value.ToString();

        }
        private void TransporterView_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyData == Keys.Enter && TransporterView.Rows.Count > 0)
            {
                TransporterView_Show();
                TransporterView.Visible = false;
                VehicleType.Focus();
            }
            else if (e.KeyData == Keys.Escape)
            {
                TransporterView.Visible = false;
            }
        }

        private void cboTransporter_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cboTransporter.SelectedValue == null)
            {
                return;
            }
            int n;
            if (int.TryParse(cboTransporter.SelectedValue.ToString(), out n) == true)
            {
                LoadVehicleList(cboTransporter.SelectedValue);
            }
        }

        private void cboTransporter_TextChanged(object sender, EventArgs e)
        {
            if (cboTransporter.Text == "")
            {
                cboTransporter.SelectedIndex = -1;
                LoadVehicleList(cboTransporter.SelectedValue);
            }

        }

        private void crystalReportViewer1_Load(object sender, EventArgs e)
        {

        }

        
    }
}
