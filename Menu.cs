using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;
using FleetStalk_Yard.DataSet;
using CrystalDecisions.CrystalReports.Engine;

namespace FleetStalk_Yard
{
    
    public partial class Menu : Form
    {
        DataSet1 ds;
        public bool Starting;
        public bool EntryStarting;
        public string DisplayName;
        public string User_Id;


        public Menu()
        {
            InitializeComponent();
        }

        private void Entry_RESET_Click(object sender, EventArgs e)
        {
            EntryStarting = true;
            cboVehicle.DataSource = null;
            cboVehicle.Tag = "";
            cboVehicle.Text = "";
            txtTransporter.Text = "";
            txtBillNoIn.Text = "";
            TransporterView.Visible = false;
            txtTransporter.Enabled = true;
            HourSlot.SelectedIndex = -1;
            VehicleLast4.Text = "";
            TruckNumber1.Text = "";
            TruckNumber2.Text = "";
            TruckNumber3.Text = "";
            TruckNumber4.Text = "";
            Driver.Text = "";
            Phone.Text = "";
            VehicleType.Text  = "";
            GetAvailableSlot();
            //LoadExitVehicle();
            VehicleLast4.Focus();


        }

        private void SAVE_Click(object sender, EventArgs e)
        {
            if (TruckNumber4.Text.Trim() == "")
            {
                MessageBox.Show("Please enter the vehicle number properly");
                TruckNumber4.Focus();
                return;
            }
            if (VehicleType.Text.Trim() == "")
            {
                MessageBox.Show("Please select a type");
                VehicleType.Focus();
                return;
            }
            if (txtTransporter.Text.Trim() == "")
            {
                MessageBox.Show("Please enter the transporter name");
                txtTransporter.Focus();
                return;
            }
            if (VehicleType.Text.Trim() != "20FT" && VehicleType.Text.Trim() != "40FT")
            {
                MessageBox.Show("Please select a proper type");
                VehicleType.Focus();
                return;
            }
            if (Phone.Text.Trim() == "")
            {
                MessageBox.Show("Please enter the phone number");
                Phone.Focus();
                return;
            }
            if (Phone.Text.Length != 10)
            {
                MessageBox.Show("Please enter a valid phone number");
                Phone.Focus();
                return;
            }
            if (Driver.Text.Trim() == "")
            {
                MessageBox.Show("Please enter the contact name");
                Driver.Focus();
                return;
            }
            

            DialogResult dialogResult = MessageBox.Show("Do you want to save the entry?", "Yard Entry", MessageBoxButtons.YesNo);
            if (dialogResult == DialogResult.Yes)
            {

                SqlCommand cmd = new SqlCommand();
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "SP_Yard_Entry";
                           

                string truck_number = TruckNumber1.Text.Trim().ToString() + "-" + TruckNumber2.Text.Trim().ToString() + "-" + TruckNumber3.Text.Trim().ToString() + "-" + TruckNumber4.Text.Trim().ToString();
                cmd.Parameters.Add("@Vehicle_Number", SqlDbType.VarChar).Value = truck_number;
                cmd.Parameters.Add("@Vehicle_Type", SqlDbType.VarChar).Value = VehicleType.Text;
                cmd.Parameters.Add("@Contact_Name", SqlDbType.VarChar).Value = Driver.Text.Trim().ToString();
                cmd.Parameters.Add("@Contact_Number", SqlDbType.VarChar).Value = Phone.Text.Trim().ToString();
                cmd.Parameters.Add("@User_Id", SqlDbType.Int).Value = lblUserId.Text.ToString();
                cmd.Parameters.Add("@Yard_Id", SqlDbType.Int).Value = lblYardId.Text.ToString();
                cmd.Parameters.Add("@External_Bill_No", SqlDbType.VarChar).Value = txtBillNoIn.Text.Trim().ToString();
                
                if (HourSlot.SelectedIndex >= 0)
                {
                    cmd.Parameters.Add("@Fee_Slab_Id", SqlDbType.Int).Value = HourSlot.SelectedValue.ToString();

                }
                else
                {
                    cmd.Parameters.Add("@Fee_Slab_Id", SqlDbType.Int).Value = null;

                }
                cmd.Parameters.Add("@Transporter_Name", SqlDbType.VarChar).Value = txtTransporter.Text.Trim().ToString();
                
                cmd.Parameters.Add("@message", SqlDbType.VarChar,200);  
                cmd.Parameters["@message"].Direction = ParameterDirection.Output;
                cmd.Parameters.Add("@message_code", SqlDbType.Int);
                cmd.Parameters["@message_code"].Direction = ParameterDirection.Output;

                cmd.Parameters.Add("@ID", SqlDbType.Int);
                cmd.Parameters["@ID"].Direction = ParameterDirection.Output;

                cmd.Parameters.Add("@EntryTime", SqlDbType.DateTime);
                cmd.Parameters["@EntryTime"].Direction = ParameterDirection.Output;


                Connections.Instance.OpenConection();
                Connections.Instance.ExecuteProcedure(cmd);

                if (Convert.ToUInt16(cmd.Parameters["@message_Code"].Value) == 100)
                {

                    dialogResult = MessageBox.Show("Do you want to print the slip?", "Yard Entry", MessageBoxButtons.YesNo);
                    if (dialogResult == DialogResult.Yes)
                    {
                        try
                        {
                            string reportFileName = System.Configuration.ConfigurationSettings.AppSettings["YardEntrySlip"];
                            System.Data.DataColumn VehicleNumber = new System.Data.DataColumn("VehicleNumber", typeof(System.String));
                            VehicleNumber.DefaultValue = truck_number + " (" + VehicleType.Text + ")";
                            System.Data.DataColumn EntryTime = new System.Data.DataColumn("EntryTime", typeof(System.String));
                            EntryTime.DefaultValue = Convert.ToDateTime(cmd.Parameters["@EntryTime"].Value);

                            System.Data.DataColumn User = new System.Data.DataColumn("User", typeof(System.String));
                            User.DefaultValue = lblUserDisplayName.Text;




                            DataTable dt = new DataTable();
                            dt.Columns.Add(VehicleNumber);
                            dt.Columns.Add(EntryTime);
                            dt.Columns.Add(User);

                            DataRow toInsert = dt.NewRow();

                            // insert in the desired place
                            dt.Rows.InsertAt(toInsert, 0);


                            ds.Tables["YardEntry"].Clear();
                            ds.Tables["YardEntry"].Merge(dt);

                            //MessageBox.Show("Test");
                            ReportDocument cryRpt = new ReportDocument();
                            cryRpt.Load(System.IO.Path.GetDirectoryName(Application.ExecutablePath).ToString() + reportFileName);
                            cryRpt.SetDataSource(ds);
                            cryRpt.Refresh();
                            cryRpt.PrintToPrinter(1, true, 0, 0);
                        }
                        catch (Exception ex)
                        {
                            //MessageBox.Show(ex.Message);
                        }
                    }
                    Entry_RESET_Click(null, null);
                }
                else
                {
                    MessageBox.Show((string)cmd.Parameters["@message"].Value);
 
                }
                Connections.Instance.CloseConnection();
                cmd.Dispose();
            }
                
        }

        private void Menu_Load(object sender, EventArgs e)
        {
            this.Top = 0;

            if (System.Configuration.ConfigurationSettings.AppSettings["External_Bill"].ToString() == "0")
            {
                txtBillNoIn.Enabled = false;
                txtBillNoOut.Enabled = false;
            }
            else
            {
                txtBillNoIn.Enabled = true;
                txtBillNoOut.Enabled = true;
            }
            ds = new DataSet1();
            lblYardId.Text =System.Configuration.ConfigurationSettings.AppSettings["Yard"];
            HourSlotLoad();
            //LoadExitVehicle();
            lblUserId.Text = User_Id;
            lblUserDisplayName.Text = DisplayName;
            GetAvailableSlot();
            GetServiceContracts();
        }
        private void GetServiceContracts()
        {
            cboService.DataSource = null;
            string query = "select Contract_ID,Contractor_Name from Additional_Contract WHERE Status='A' AND Valid_From<=GETDATE() AND Valid_To>=GETDATE() ORDER BY 2";
            cboService.DataSource = Connections.Instance.ShowDataInGridView(query);
            cboService.DisplayMember = "Contractor_Name";
            cboService.ValueMember = "Contract_ID";
            cboService.SelectedIndex = -1;
        }

        private void GetAvailableSlot()
        {
            DataTable dt = new DataTable();            
            string Query = "SELECT COUNT(1) FROM Slot  WHERE STATUS='E' AND Slot_Type='20FT'";
            dt = (DataTable)Connections.Instance.ShowDataInGridView(Query);
            if (dt.Rows.Count > 0)
            {
                lbl20FTSlot.Text = dt.Rows[0][0].ToString();
            }
            dt.Clear();
            Query = "SELECT COUNT(1) FROM Slot  WHERE STATUS='E' AND Slot_Type='40FT'";
            dt = (DataTable)Connections.Instance.ShowDataInGridView(Query);
            if (dt.Rows.Count > 0)
            {
                lbl40FTSlot.Text = dt.Rows[0][0].ToString();
            }
            dt.Clear();
            Query = "SELECT COUNT(1) FROM Slot  WHERE STATUS='A' AND Slot_Type='20FT'";
            dt = (DataTable)Connections.Instance.ShowDataInGridView(Query);
            if (dt.Rows.Count > 0)
            {
                lblFilledSlot20.Text = dt.Rows[0][0].ToString();
            }
            dt.Clear();
            Query = "SELECT COUNT(1) FROM Slot  WHERE STATUS='A' AND Slot_Type='40FT'";
            dt = (DataTable)Connections.Instance.ShowDataInGridView(Query);
            if (dt.Rows.Count > 0)
            {
                lblFilledSlot40.Text = dt.Rows[0][0].ToString();
            }
            
            dt.Dispose();
        }
        private void LoadExitVehicle()
        {
            Starting = true;
            ExitVehicle.DataSource = null;
            string query = "select y.ID,v.Vehicle_Id,v.Vehicle_Number+' ('+v.vehicle_Type+')' AS Vehicle_Number from Yard_Entry y JOIN Vehicle v on y.Vehicle_Id=v.Vehicle_Id  WHERE v.Vehicle_Number like '%-"+ VehicleLast4Exit.Text.Trim()+"' AND y.Status='A' AND Exit_time IS NULL ORDER BY Entry_Time";
            ExitVehicle.DataSource = Connections.Instance.ShowDataInGridView(query);
            ExitVehicle.DisplayMember = "Vehicle_Number";
            ExitVehicle.ValueMember = "ID";

            if (ExitVehicle.Items.Count>1 || ExitVehicle.Items.Count==0)
            {
                ExitVehicle.SelectedIndex = -1;
                ExitVehicle.Text = "";
            }
            else
            {
                Starting = false;
                ExitVehicle.SelectedIndex=0;
                ExitVehicle_SelectedIndexChanged(null, null);
            }

            Starting = false;

        }
        private void HourSlotLoad()
        {
            HourSlot.DataSource = null;
            string Vehicle_type="";


                Vehicle_type=VehicleType.Text ;


            string query = "select Fee_Slab_Id,Slab_Name from Fee_Slab WHERE Vehicle_Type='" + Vehicle_type + "' order By 2";
            HourSlot.DataSource = Connections.Instance.ShowDataInGridView(query);
            HourSlot.DisplayMember = "Slab_Name";
            HourSlot.ValueMember = "Fee_Slab_Id";
            HourSlot.SelectedIndex = -1;
            HourSlot.Text = "";
        }

        

        private void TruckNumber2_Enter(object sender, EventArgs e)
        {
            ((TextBox)sender).SelectAll();
        }

        private void TruckNumber3_Enter(object sender, EventArgs e)
        {
            ((TextBox)sender).SelectAll();
        }
        private void TruckNumber2_TextChanged(object sender, EventArgs e)
        {

        }

        private void TruckNumber4_Enter(object sender, EventArgs e)
        {
            ((TextBox)sender).SelectAll();
        }

        private void TruckNumber4_KeyPress(object sender, KeyPressEventArgs e)
        {

            if (e.KeyChar == 13)
                txtTransporter.Focus();
            else if (!(Char.IsDigit(e.KeyChar) || (e.KeyChar == (char)Keys.Back)))
                e.Handled = true;
        }
        private void VehicleType_KeyPress(object sender, KeyPressEventArgs e)
        {

            if (e.KeyChar == 13)
                Phone.Focus();
        }
        private void Phone_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
                Driver.Focus();
            else if (!(Char.IsDigit(e.KeyChar) || (e.KeyChar == (char)Keys.Back)))
                e.Handled = true;
        }
        private void Driver_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
                SAVE_Click(null, null);
           
        }
        private void TruckNumber1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
                TruckNumber2.Focus();

        }
        private void TruckNumber2_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
                TruckNumber3.Focus();
            else if (!(Char.IsDigit(e.KeyChar) || (e.KeyChar == (char)Keys.Back)))
                e.Handled = true;

        }
        private void TruckNumber3_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
                TruckNumber4.Focus();

        }
        private void VehicleType_KeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
        {


            if (e.KeyCode == Keys.Enter)
                Phone.Focus();

        }
        private void HourSlot_KeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
        {
          

            if (e.KeyCode==Keys.Enter)
                SAVE_Click(null, null);

        }

        private void TruckNumber4_Leave(object sender, EventArgs e)
        {
            if (TruckNumber4.Text.Trim()!="")
            {
               string truck_number = TruckNumber1.Text.Trim().ToString() + "-" + TruckNumber2.Text.Trim().ToString() + "-" + TruckNumber3.Text.Trim().ToString() + "-" + TruckNumber4.Text.Trim().ToString();
               string Query = "SELECT v.Contact_Name,v.Contact_Number,v.Vehicle_Type,ISNULL(o.Transporter_Name,'') Transporter_Name FROM Vehicle v LEFT JOIN Owner O ON O.Owner_Id=v.Owner_id WHERE v.Vehicle_Number='" + truck_number + "'";
               DataTable dt=new DataTable();
               dt = (DataTable)Connections.Instance.ShowDataInGridView(Query);
               if (dt.Rows.Count > 0)
               {

                   Driver.Text = dt.Rows[0][0].ToString();
                   Phone.Text = dt.Rows[0][1].ToString();
                   //VehicleType.Text =dt.Rows[0][2].ToString();
                   
               }


            }
        }

        private void TruckNumber1_Enter(object sender, EventArgs e)
        {
            ((TextBox)sender).SelectAll();
        }


        private void RB20_CheckedChanged(object sender, EventArgs e)
        {
            HourSlotLoad();
        }

        private void ExitVehicle_Leave(object sender, EventArgs e)
        {

            
        }

        private void ExitReset_Click(object sender, EventArgs e)
        {
            chkCreditPayment.Checked = false;
            chkCreditPayment.Visible = false;
            VehicleLast4Exit.Text = "";
            lblCess.Text = "";
            lblTransporter.Text = "";
            ExitVehicle.SelectedIndex = -1;
            ExitVehicle.Text = "";
            lblHour.Text = "";
            lblMinutes.Text = "";
            lblAddMinutes.Text = "";
            lblAddAmount.Text = "";
            lblAmount.Text = "";
            lblSlabId.Text = "";
            lblReentry.Text = "";
            lblPaymentStartTime.Text = "";
            lblEntryTime.Text = "";
            lblHourSlot.Text = "";
            lblTotalAmount.Text = "";
            lblTotalTime.Text = "";
            GetAvailableSlot();
            Cash.Text = "";
            lblBalance.Text="";
            lblBillableDuration.Text = "";
            lblExitTime.Text = "";
            lblGST.Text = "";
            lblSGST.Text = "";
            lblCGST.Text = "";
            //LoadExitVehicle();
            VehicleLast4Exit.Focus();
            GetServiceContracts();
        }

        private void ExitVehicle_SelectedIndexChanged(object sender, EventArgs e)
        {
            chkCreditPayment.Checked = false;
            if (ExitVehicle.SelectedIndex == -1 || Starting==true)
            {
                return;
            }

            try
            {
                string Query = "SELECT 1 FROM Payment_Exception_Vehicle P JOIN Yard_Entry y On y.Vehicle_Id=P.Vehicle_Id WHERE P.Status='A' AND y.ID='" + ExitVehicle.SelectedValue + "'";
                DataTable dt = new DataTable();
                dt = (DataTable)Connections.Instance.ShowDataInGridView(Query);
                
                if (dt.Rows.Count > 0)
                {
                    chkCreditPayment.Checked = true;
                    chkCreditPayment.Visible = true;
                }
                else
                { 
                    chkCreditPayment.Visible = false;
                    Query = "SELECT ISNULL(PP.GST_Type,'B2C') FROM Parking_Pass_Detail P JOIN Parking_Pass PP ON PP.Parking_Pass_Id=P.Parking_Pass_Id JOIN Yard_Entry y On y.Vehicle_Id=P.Vehicle_Id WHERE PP.Status='A' AND PP.Valid_From<=GETDATE() AND PP.Valid_To>=GETDATE() AND y.ID='" + ExitVehicle.SelectedValue + "'";
                    dt.Clear();
                    dt = (DataTable)Connections.Instance.ShowDataInGridView(Query);

                    if (dt.Rows.Count > 0)
                    {
                        chkCreditPayment.Checked = true;
                        chkCreditPayment.Visible = true;
                        if (dt.Rows[0][0].ToString() == "B2C")
                        {
                            optB2C.Checked = true;
                        }
                        else
                        {
                            optB2B.Checked = true;
                        }
                    }
                    else
                    {
                        optB2C.Checked = true;
                    }
                    
                
                }


                SqlCommand cmd = new SqlCommand();
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "GET_Fee";

                cmd.Parameters.Add("@ID", SqlDbType.Int).Value = ExitVehicle.SelectedValue;
                cmd.Parameters.Add("@Hour_Slab", SqlDbType.VarChar, 30);
                cmd.Parameters["@Hour_Slab"].Direction = ParameterDirection.Output;
                cmd.Parameters.Add("@Entry_Time", SqlDbType.DateTime);
                cmd.Parameters["@Entry_Time"].Direction = ParameterDirection.Output;
                cmd.Parameters.Add("@Hour", SqlDbType.Int);
                cmd.Parameters["@Hour"].Direction = ParameterDirection.Output;
                cmd.Parameters.Add("@Minutes", SqlDbType.Int);
                cmd.Parameters["@Minutes"].Direction = ParameterDirection.Output;
                cmd.Parameters.Add("@External_Bill_No", SqlDbType.VarChar,20);
                cmd.Parameters["@External_Bill_No"].Direction = ParameterDirection.Output;
                //cmd.Parameters.Add("@Amount", SqlDbType.Decimal);

                SqlParameter Amount = new SqlParameter("@Amount", SqlDbType.Decimal);
                Amount.Precision = 7;
                Amount.Scale = 3;
                Amount.Direction = ParameterDirection.Output;
                cmd.Parameters.Add(Amount);

                SqlParameter Cess = new SqlParameter("@CESS", SqlDbType.Decimal);
                Cess.Precision = 7;
                Cess.Scale = 3;
                Cess.Direction = ParameterDirection.Output;
                cmd.Parameters.Add(Cess);

                //cmd.Parameters.Add("@Additional_Amount", SqlDbType.Decimal);

                SqlParameter Additional_Amount = new SqlParameter("@Additional_Amount", SqlDbType.Decimal);
                Additional_Amount.Precision = 7;
                Additional_Amount.Scale = 3;
                Additional_Amount.Direction = ParameterDirection.Output;
                cmd.Parameters.Add(Additional_Amount);

                cmd.Parameters.Add("@Slab_Id", SqlDbType.Int);
                cmd.Parameters["@Slab_Id"].Direction = ParameterDirection.Output;
                cmd.Parameters.Add("@Additional_Minutes", SqlDbType.Int);
                cmd.Parameters["@Additional_Minutes"].Direction = ParameterDirection.Output;

                cmd.Parameters.Add("@Is_Reentry", SqlDbType.Char,1);
                cmd.Parameters["@Is_Reentry"].Direction = ParameterDirection.Output;
                cmd.Parameters.Add("@Payment_Start_Time", SqlDbType.DateTime);
                cmd.Parameters["@Payment_Start_Time"].Direction = ParameterDirection.Output;
                cmd.Parameters.Add("@Exit_Time", SqlDbType.DateTime);
                cmd.Parameters["@Exit_Time"].Direction = ParameterDirection.Output;
                cmd.Parameters.Add("@Transporter", SqlDbType.VarChar, 30);
                cmd.Parameters["@Transporter"].Direction = ParameterDirection.Output;
                SqlParameter SGST = new SqlParameter("@SGST", SqlDbType.Decimal);
                SGST.Precision = 7;
                SGST.Scale = 3;
                SGST.Direction = ParameterDirection.Output;
                cmd.Parameters.Add(SGST);

                SqlParameter CGST = new SqlParameter("@CGST", SqlDbType.Decimal);
                CGST.Precision = 7;
                CGST.Scale = 3;
                CGST.Direction = ParameterDirection.Output;
                cmd.Parameters.Add(CGST);

                SqlParameter GST = new SqlParameter("@GST", SqlDbType.Decimal);
                GST.Precision = 7;
                GST.Scale = 3;
                GST.Direction = ParameterDirection.Output;
                cmd.Parameters.Add(GST);
                       
                Connections.Instance.OpenConection();
                Connections.Instance.ExecuteProcedure(cmd);

                if (cmd.Parameters["@Is_Reentry"].Value.ToString() == "Y")
                {
                    lblReentry.Text = "YES";
                }
                else
                {
                    lblReentry.Text = "NO";
                    lblBillableDuration.Text = cmd.Parameters["@Entry_Time"].Value.ToString();
                }

                string Total_Days = Math.Floor(Convert.ToDecimal(cmd.Parameters["@Hour"].Value) / 24).ToString();
                string Hours = (Convert.ToDecimal(cmd.Parameters["@Hour"].Value)-(Convert.ToInt32(Total_Days)*24)).ToString();
                Int64 mins = Convert.ToInt64(cmd.Parameters["@Minutes"].Value);

                txtBillNoOut.Text = cmd.Parameters["@External_Bill_No"].Value.ToString();

                lblTransporter.Text = cmd.Parameters["@Transporter"].Value.ToString();
                lblAddMinutes.Text = cmd.Parameters["@Additional_Minutes"].Value.ToString();
                lblPaymentStartTime.Text = cmd.Parameters["@Payment_Start_Time"].Value.ToString();
                lblExitTime.Text = cmd.Parameters["@Exit_Time"].Value.ToString();
                lblHourSlot.Text = cmd.Parameters["@Hour_Slab"].Value.ToString();
                lblEntryTime.Text = cmd.Parameters["@Entry_Time"].Value.ToString();
                lblTotalTime.Text = Total_Days + " Days " + Hours + " Hours " + (Convert.ToInt32(cmd.Parameters["@Minutes"].Value) % 60).ToString() + " Mins";
                //lblTotalTime.Text = cmd.Parameters["@Hour"].Value.ToString() + " Hour " + (Convert.ToInt32(cmd.Parameters["@Minutes"].Value) % 60).ToString() + " Minutes";
                
                lblAmount.Text = cmd.Parameters["@Amount"].Value.ToString();
                lblCess.Text = cmd.Parameters["@CESS"].Value.ToString();
                lblAddAmount.Text = cmd.Parameters["@Additional_Amount"].Value.ToString();
                lblGST.Text=cmd.Parameters["@GST"].Value.ToString();
                lblSGST.Text = cmd.Parameters["@SGST"].Value.ToString();
                lblCGST.Text = cmd.Parameters["@CGST"].Value.ToString();
                lblHour.Text = cmd.Parameters["@Hour"].Value.ToString();
                lblMinutes.Text = cmd.Parameters["@Minutes"].Value.ToString();
                lblSlabId.Text = cmd.Parameters["@Slab_Id"].Value.ToString();


                lblTotalAmount.Text = Math.Round((Convert.ToDecimal(lblAmount.Text) + Convert.ToDecimal(lblAddAmount.Text) + Convert.ToDecimal(lblGST.Text) + Convert.ToDecimal(lblCess.Text))).ToString();
                Connections.Instance.CloseConnection();
                cmd.Dispose();
            }
            catch (Exception ex)
            { }
        }

        private void ExitSubmit_Click(object sender, EventArgs e)
        {
            if (ExitVehicle.Text.Trim() == "")
            {
                MessageBox.Show("Please select the vehicle");
                VehicleLast4Exit.Focus();
                return;
            }

            if (cboService.SelectedIndex != -1)
            {
                try
                {
                    string Query = "SELECT Contract_Available_Minutes FROM  Additional_Contract WHERE Contract_ID='" + Convert.ToInt64(cboService.SelectedValue) + "'";
                    DataTable dt = new DataTable();
                    dt = (DataTable)Connections.Instance.ShowDataInGridView(Query);
                    if (dt.Rows.Count > 0 && lblMinutes.Text.Trim() != "")
                    {
                        if (Convert.ToInt64(lblMinutes.Text) > Convert.ToInt64(dt.Rows[0][0]))
                        {
                            MessageBox.Show("Service contract time exceeded. Please verify.");
                            //cboService.SelectedIndex = -1;
                            //return;
                        }
                    }
                }
                catch (Exception ex)
                { }
            }

            if (optB2B.Checked == true)
            {
                MessageBox.Show("GST bill type B2B selected. Please make sure");
            }

            DialogResult dialogResult;
            

            dialogResult = MessageBox.Show("Do you want to save the entry?", "Yard Entry", MessageBoxButtons.YesNo);
            if (dialogResult == DialogResult.Yes)
            {
                Starting = false;
                //ExitVehicle_SelectedIndexChanged(null, null);

                SqlCommand cmd = new SqlCommand();
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "SP_Yard_Exit";
                
                cmd.Parameters.Add("@ID", SqlDbType.Int).Value = ExitVehicle.SelectedValue;
                cmd.Parameters.Add("@User_Id", SqlDbType.Int).Value = lblUserId.Text.ToString();
                DateTime entrytime=Convert.ToDateTime(lblEntryTime.Text);
                cmd.Parameters.Add("@Entry_Time", SqlDbType.DateTime).Value = entrytime;
                cmd.Parameters.Add("@Hour", SqlDbType.Int).Value = lblHour.Text;

                cmd.Parameters.Add("@Minutes", SqlDbType.Int).Value = lblMinutes.Text;
                //cmd.Parameters.Add("@Amount", SqlDbType.Decimal).Value = lblAmount.Text;
                if (optB2C.Checked == true)
                {
                    cmd.Parameters.Add("@GST_Type", SqlDbType.VarChar).Value = "B2C";
                }
                else
                {
                    cmd.Parameters.Add("@GST_Type", SqlDbType.VarChar).Value = "B2B"; 
                }
                cmd.Parameters.Add("@External_Bill_No", SqlDbType.VarChar).Value = txtBillNoOut.Text.Trim();
                SqlParameter Amount = new SqlParameter("@Amount", SqlDbType.Decimal);
                Amount.Precision = 7;
                Amount.Scale = 3;
                Amount.Value = lblAmount.Text;
                cmd.Parameters.Add(Amount);


                cmd.Parameters.Add("@Additional_Minutes", SqlDbType.Int).Value = lblAddMinutes.Text;
                //cmd.Parameters.Add("@Additional_Amount", SqlDbType.Decimal).Value = lblAddAmount.Text;

                SqlParameter Additional_Amount = new SqlParameter("@Additional_Amount", SqlDbType.Decimal);
                Additional_Amount.Precision = 7;
                Additional_Amount.Scale = 3;
                Additional_Amount.Value = lblAddAmount.Text;
                cmd.Parameters.Add(Additional_Amount);

                //cmd.Parameters.Add("@SGST", SqlDbType.Decimal).Value = lblSGST.Text;

                SqlParameter SGST_Param = new SqlParameter("@SGST", SqlDbType.Decimal);
                SGST_Param.Precision = 7;
                SGST_Param.Scale = 3;
                SGST_Param.Value = lblSGST.Text;
                cmd.Parameters.Add(SGST_Param);

                //cmd.Parameters.Add("@CGST", SqlDbType.Decimal).Value = lblCGST.Text;

                SqlParameter CGST_Param = new SqlParameter("@CGST", SqlDbType.Decimal);
                CGST_Param.Precision = 7;
                CGST_Param.Scale = 3;
                CGST_Param.Value = lblCGST.Text;
                cmd.Parameters.Add(CGST_Param);

                //cmd.Parameters.Add("@GST", SqlDbType.Decimal).Value = lblGST.Text;

                SqlParameter GST_Param = new SqlParameter("@GST", SqlDbType.Decimal);
                GST_Param.Precision = 7;
                GST_Param.Scale = 3;
                GST_Param.Value = lblGST.Text;
                cmd.Parameters.Add(GST_Param);

                SqlParameter CESS = new SqlParameter("@CESS", SqlDbType.Decimal);
                CESS.Precision = 7;
                CESS.Scale = 3;
                CESS.Value = lblCess.Text;
                cmd.Parameters.Add(CESS);

                DateTime pmtStartTime=Convert.ToDateTime(lblPaymentStartTime.Text);
                cmd.Parameters.Add("@Payment_Start_Time", SqlDbType.DateTime).Value = pmtStartTime;
                if (lblSlabId.Text=="")
                    cmd.Parameters.Add("@Slab_Id", SqlDbType.Int).Value = 0;
                else
                    cmd.Parameters.Add("@Slab_Id", SqlDbType.Int).Value = lblSlabId.Text;

                if (chkCreditPayment.Checked == true || cboService.SelectedIndex != -1)
                {
                    cmd.Parameters.Add("@Is_Credit_Payment", SqlDbType.Char).Value = "Y";
                    if (cboService.SelectedIndex != -1)
                    {
                        cmd.Parameters.Add("@Additional_Contract_Id", SqlDbType.Int).Value = cboService.SelectedValue;
                    }
                }
                else
                {
                    cmd.Parameters.Add("@Is_Credit_Payment", SqlDbType.Char).Value = "N";
                }
                DateTime VehicleExitTime=Convert.ToDateTime(lblExitTime.Text);
                cmd.Parameters.Add("@Exit_Time", SqlDbType.DateTime).Value = VehicleExitTime;
                 
                if (lblReentry.Text == "YES")
                {
                    cmd.Parameters.Add("@Is_Reentry", SqlDbType.Char).Value = "Y";
                }
                else
                {
                    cmd.Parameters.Add("@Is_Reentry", SqlDbType.Char).Value = "N";
                }

                string gst_bill_no;
                
                cmd.Parameters.Add("@message", SqlDbType.VarChar, 200);
                cmd.Parameters["@message"].Direction = ParameterDirection.Output;
                cmd.Parameters.Add("@message_code", SqlDbType.Int);
                cmd.Parameters["@message_code"].Direction = ParameterDirection.Output;

                cmd.Parameters.Add("@GST_Bill_No", SqlDbType.Int);
                cmd.Parameters["@GST_Bill_No"].Direction = ParameterDirection.Output;

                if (chkCreditPayment.Checked == true)
                {
                    dialogResult = MessageBox.Show("Credit entry enabled. Do you want to continue?", "Yard Entry", MessageBoxButtons.YesNo);
                    if (dialogResult == DialogResult.No)
                    {
                        return;
                    }
                }

                Connections.Instance.OpenConection();
                Connections.Instance.ExecuteProcedure(cmd);

                gst_bill_no = cmd.Parameters["@gst_bill_no"].Value.ToString();

                if (Convert.ToUInt16(cmd.Parameters["@message_Code"].Value) == 100)
                {
                                        
                    string reportFileName = System.Configuration.ConfigurationSettings.AppSettings["ReceiptSlip"];
                    string DetailreportFileName = System.Configuration.ConfigurationSettings.AppSettings["ReceiptDetails"];
                    System.Data.DataColumn VehicleNumber = new System.Data.DataColumn("VehicleNumber", typeof(System.String));
                    VehicleNumber.DefaultValue = ExitVehicle.Text;

                    System.Data.DataColumn EntryTime = new System.Data.DataColumn("EntryTime", typeof(System.String));
                    EntryTime.DefaultValue = lblEntryTime.Text;

                    System.Data.DataColumn ExitTime = new System.Data.DataColumn("ExitTime", typeof(System.String));
                    ExitTime.DefaultValue = lblExitTime.Text;

                    System.Data.DataColumn TotalTime = new System.Data.DataColumn("TotalTime", typeof(System.String));
                    TotalTime.DefaultValue = lblTotalTime.Text;

                    //System.Data.DataColumn BaseAmount = new System.Data.DataColumn("BaseAmount", typeof(System.Decimal));
                    System.Data.DataColumn BaseAmount = new System.Data.DataColumn("BaseAmount", typeof(System.Double));                    
                    BaseAmount.DefaultValue = lblAmount.Text;

                    System.Data.DataColumn AdditionalAmount = new System.Data.DataColumn("AdditionalAmount", typeof(System.Double));
                    AdditionalAmount.DefaultValue = lblAddAmount.Text;

                    System.Data.DataColumn TotalAmount = new System.Data.DataColumn("TotalAmount", typeof(System.Double));
                    TotalAmount.DefaultValue = (Convert.ToDouble(lblAddAmount.Text) + Convert.ToDouble(lblAmount.Text));

                    System.Data.DataColumn User = new System.Data.DataColumn("User", typeof(System.String));
                    User.DefaultValue = lblUserDisplayName.Text;

                    System.Data.DataColumn SGST = new System.Data.DataColumn("SGST", typeof(System.Double));
                    SGST.DefaultValue = lblSGST.Text;

                    System.Data.DataColumn CGST = new System.Data.DataColumn("CGST", typeof(System.Double));
                    CGST.DefaultValue = lblSGST.Text;

                    System.Data.DataColumn GST = new System.Data.DataColumn("GST", typeof(System.Double));
                    GST.DefaultValue = lblGST.Text;

                    System.Data.DataColumn CESS_Param = new System.Data.DataColumn("CESS", typeof(System.Double));
                    CESS_Param.DefaultValue = lblCess.Text;

                    System.Data.DataColumn GST_Total = new System.Data.DataColumn("GST_Total", typeof(System.Double));
                    GST_Total.DefaultValue = lblTotalAmount.Text;

                    System.Data.DataColumn GST_BillNo = new System.Data.DataColumn("GST_BillNo", typeof(System.String));
                    GST_BillNo.DefaultValue = gst_bill_no;

                    System.Data.DataColumn Bill_Date = new System.Data.DataColumn("Bill_Date", typeof(System.String));
                    Bill_Date.DefaultValue = System.DateTime.Today.Date.ToString("dd-MM-yyyy");

                    System.Data.DataColumn Transporter = new System.Data.DataColumn("Transporter", typeof(System.String));
                    Transporter.DefaultValue = lblTransporter.Text;
                    
                    
                    DataTable dt = new DataTable();
                    dt.Columns.Add(Transporter);
                    dt.Columns.Add(SGST);
                    dt.Columns.Add(CGST);
                    dt.Columns.Add(GST);
                    dt.Columns.Add(CESS_Param);
                    dt.Columns.Add(GST_Total);
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
                    //if (cboService.SelectedIndex == -1)
                    //{
                        dialogResult = MessageBox.Show("Do you want to print receipt?", "Yard Entry", MessageBoxButtons.YesNo);
                        if (dialogResult == DialogResult.Yes)
                        {


                            if (chkCreditPayment.Checked == false && optB2C.Checked==true)
                            {
                                ReportDocument cryRpt = new ReportDocument();
                                cryRpt.Load(System.IO.Path.GetDirectoryName(Application.ExecutablePath).ToString() + reportFileName);
                                cryRpt.SetDataSource(ds);
                                cryRpt.Refresh();
                                cryRpt.PrintToPrinter(1, true, 0, 0);
                            }
                            else
                            {
                                ReportDocument crpt1 = new ReportDocument();
                                crpt1.Load(System.IO.Path.GetDirectoryName(Application.ExecutablePath).ToString() + DetailreportFileName);
                                crpt1.SetDataSource(ds);
                                crpt1.Refresh();
                                crpt1.PrintToPrinter(1, true, 0, 0);

                                ReportDocument crpt2 = new ReportDocument();
                                crpt2.Load(System.IO.Path.GetDirectoryName(Application.ExecutablePath).ToString() + DetailreportFileName);
                                crpt2.SetDataSource(ds);
                                crpt2.Refresh();
                                crpt2.PrintToPrinter(1, true, 0, 0);
                            }
                        }
                  //  }
                    ExitReset_Click(null, null);
                }
                else
                {
                    MessageBox.Show((string)cmd.Parameters["@message"].Value);
                }
                Connections.Instance.CloseConnection();
                cmd.Dispose();
            }
        }



        private void lblUserDisplayName_Click(object sender, EventArgs e)
        {

        }

        private void TruckNumber4_TextChanged(object sender, EventArgs e)
        {

        }

        private void HourSlot_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void VehicleLast4Exit_Leave(object sender, EventArgs e)
        {
            
            LoadExitVehicle();
        }
        private void LoadVehicle()
        {
            EntryStarting = true;
            cboVehicle.DataSource = null;
            string query = "SELECT Vehicle_Id,Vehicle_Number from Vehicle WHERE Vehicle_Number like '%-" + VehicleLast4.Text.Trim() + "' ORDER BY Modified_On DESC";
            cboVehicle.DataSource = Connections.Instance.ShowDataInGridView(query);
            cboVehicle.ValueMember = "Vehicle_Id";
            cboVehicle.DisplayMember = "Vehicle_Number";
            EntryStarting = false;
            if (cboVehicle.Items.Count == 1)
            {
                cboVehicle.SelectedIndex = 0;
                cboVehicle_SelectedIndexChanged(null, null);
            }
        }
        private void VehicleLast4_Leave(object sender, EventArgs e)
        {
            if (VehicleLast4.Text.Trim() != "")
            {

                txtTransporter.Text = "";
                TransporterView.Visible = false;
                TruckNumber2.Text = "";
                TruckNumber3.Text = "";
                TruckNumber4.Text = "";
                Driver.Text = "";
                Phone.Text = "";
                VehicleType.Text = "";
                
                LoadVehicle();

                
            }
        }
        private void VehicleLast4_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
                TruckNumber1.Focus();

        }
        private void VehicleLast4Exit_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
                ExitVehicle.Focus();

        }
        private void VehicleLast4_TextChanged1(object sender, EventArgs e)
        {

        }

        private void VehicleLast4Exit_TextChanged(object sender, EventArgs e)
        {

        }
        
        private void Driver_TextChanged(object sender, EventArgs e)
        {

        }

        private void timer2_Tick(object sender, EventArgs e)
        {
            if (ExitVehicle.SelectedIndex != -1)
            {
                ExitVehicle_SelectedIndexChanged(null, null);
            }
        }

        private void Cash_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
                ExitSubmit_Click(null,null);
            else if (!((Char.IsDigit(e.KeyChar)||e.KeyChar==46) || (e.KeyChar == (char)Keys.Back)))
                e.Handled = true;
        }

        private void Cash_TextChanged(object sender, EventArgs e)
        {
            try
            {
                string amount = Cash.Text.Trim();
                if (amount=="")
                {
                    amount="0";
                }
                lblBalance.Text = (Convert.ToDecimal(lblTotalAmount.Text.Trim()) - Convert.ToDecimal(amount)).ToString();
                
            }
            catch (Exception ex)
            { lblBalance.Text = ""; }
        }

        private void TruckNumber3_TextChanged(object sender, EventArgs e)
        {

        }

        private void VehicleType_SelectedIndexChanged(object sender, EventArgs e)
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
        private void txtTransporter_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
                VehicleType.Focus();

        }
        private void txtTransporter_TextChanged(object sender, EventArgs e)
        {
            
            string Query = "SELECT Owner_ID,Transporter_Name FROM Owner WHERE Transporter_Name LIKE '%"+ txtTransporter.Text +"%' ORDER BY 2";
            TransporterView.DataSource = Connections.Instance.ShowDataInGridView(Query);
            TransporterView.Columns[0].Visible = false;
            if (TransporterView.Rows.Count == 0 || txtTransporter.Text.Trim() == "")
            {
                TransporterView.Visible = false;
            }
            else
            {
                TransporterView.Visible = true;
            }
                
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

        private void TransporterView_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            TransporterView_Show();
            TransporterView.Visible = false;
            VehicleType.Focus();
        }
        private void TransporterView_Show()
        {
            int r = TransporterView.CurrentRow.Index;
            txtTransporter.Tag = TransporterView.Rows[r].Cells[0].Value.ToString();
            txtTransporter.Text = TransporterView.Rows[r].Cells[1].Value.ToString();
        }

        private void TransporterView_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void cboService_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cboService.SelectedIndex != -1)
            {
                //optB2B.Checked = true;
                try
                {
                    string Query = "SELECT Contract_Available_Minutes FROM  Additional_Contract WHERE Contract_ID='" + Convert.ToInt64(cboService.SelectedValue) + "'";
                    DataTable dt = new DataTable();
                    dt = (DataTable)Connections.Instance.ShowDataInGridView(Query);
                    if (dt.Rows.Count > 0 && lblMinutes.Text.Trim() != "")
                    {
                        chkCreditPayment.Visible = true;
                        chkCreditPayment.Checked = true;

                        if (Convert.ToInt64(lblMinutes.Text) > Convert.ToInt64(dt.Rows[0][0]))
                        {
                            MessageBox.Show("Service contract time exceeded.  Please verify.");
                            //cboService.SelectedIndex = -1;
                        }
                    }
                }
                catch (Exception ex)
                { }
            }
           
        }

        private void cboVehicle_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cboVehicle.SelectedIndex == -1 || EntryStarting == true)
            {
                return;
            }
            string Query = "SELECT TOP 1 v.Contact_Name,v.Contact_Number,v.Vehicle_Type,v.Vehicle_Number,ISNULL(o.Transporter_Name,'') Transporter_Name,CASE WHEN PD.Vehicle_Id IS NULL THEN 0 ELSE 1 END AS Is_Contract FROM Vehicle v LEFT JOIN Owner O ON O.Owner_Id=v.Owner_id LEFT JOIN Parking_Pass_Detail PD ON PD.Vehicle_Id=V.Vehicle_Id WHERE v.vehicle_id='" + cboVehicle.SelectedValue.ToString() + "'";
            DataTable dt = new DataTable();
            dt = (DataTable)Connections.Instance.ShowDataInGridView(Query);
            if (dt.Rows.Count > 0)
            {
                TruckNumber1.Text = dt.Rows[0][3].ToString().Split('-').ElementAt(0).ToString();
                TruckNumber2.Text = dt.Rows[0][3].ToString().Split('-').ElementAt(1).ToString();
                TruckNumber3.Text = dt.Rows[0][3].ToString().Split('-').ElementAt(2).ToString();
                TruckNumber4.Text = dt.Rows[0][3].ToString().Split('-').ElementAt(3).ToString();
                Driver.Text = dt.Rows[0][0].ToString();
                Phone.Text = dt.Rows[0][1].ToString();
                VehicleType.Text = "";
                //VehicleType.Text = dt.Rows[0][2].ToString();
                txtTransporter.Text = dt.Rows[0][4].ToString();
                TransporterView.Visible = false;
                if (dt.Rows[0][5].ToString() == "1")
                {
                    txtTransporter.Enabled = false;
                }
                else
                {
                    txtTransporter.Enabled = true;
                }
            }
            dt.Dispose();
        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }
        

     

       
        
    }
}
