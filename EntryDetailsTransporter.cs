using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using CrystalDecisions.Windows.Forms;
using FleetStalk_Yard.DataSet;
using CrystalDecisions.CrystalReports.Engine;

namespace FleetStalk_Yard
{
    public partial class EntryDetailsTransporter : Form
    {
        DataSet1 ds;
        string yard_id;
        public EntryDetailsTransporter()
        {
            InitializeComponent();
        }

        private void optIn_CheckedChanged(object sender, EventArgs e)
        {
            if (optIn.Checked == true)
            {
                chkCreditPayment.Visible = false;
            }
        }

        private void EntryDetailsTransporter_Load(object sender, EventArgs e)
        {
            ds = new DataSet1();
            yard_id = System.Configuration.ConfigurationSettings.AppSettings["Yard"];
            this.Top = 60;
            LoadTransporterList();
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

        private void btnReset_Click(object sender, EventArgs e)
        {
            crystalReportViewer1.Visible = false;
            LoadTransporterList();
            OptAll.Checked = true;
            chkCreditPayment.Visible = false;
            lblTotal.Text = "0";
            dtFrom.Value = DateTime.Now;
            dtTo.Value = DateTime.Now;
            chkCreditPayment.Checked = false;
            dataGridView1.DataSource = null;
            cboTransporter.Focus();
        }

        private void optOut_CheckedChanged(object sender, EventArgs e)
        {
            if (optOut.Checked == true)
            {
                chkCreditPayment.Visible = true;
            }
        }

        private void OptAll_CheckedChanged(object sender, EventArgs e)
        {
            if (OptAll.Checked == true)
            {
                chkCreditPayment.Visible = false;
            }
        }

        private void btnShow_Click(object sender, EventArgs e)
        {
            crystalReportViewer1.Visible = false;
            if (cboTransporter.SelectedIndex == -1)
            {
                MessageBox.Show("Please select a transporter");
                cboTransporter.Focus();
                return;
            }
            string Query;
            DataTable dt = new DataTable();
            if (OptAll.Checked == true)
            {
                Query = "SELECT ID,ROW_NUMBER() OVER(ORDER BY (SELECT 1)) AS SlNo, v.Vehicle_Type,v.Vehicle_Number,y.Entry_Time,y.Exit_Time,y.Payment_start_time,y.payment_end_time,f.slab_name,y.Base_Amount AS Slab_Amount,y.Additional_Amount,ISNULL(Discount_Amount,0) Discount_Amount,(y.Base_Amount+y.Additional_Amount-Discount_Amount)AS Total,CASE WHEN y.Status='C' OR CONVERT(INT,ISNULL(Discount_Amount,0))!=0 THEN Y.Remarks WHEN Reference_Id IS NOT NULL THEN 'Re-Entry' ELSE '' END AS Remarks,y.Contact_Name,y.Contact_Number,y.Status,CASE WHEN ISNULL(Y.Is_Credit_Payment,'')='Y' THEN 'Yes' ELSE '' END AS Credit_Payment FROM yard_entry y JOIN vehicle v on v.vehicle_id=y.vehicle_id LEFT JOIN Fee_Slab f on f.Fee_Slab_Id=y.Fee_Slab_Id WHERE (y.Entry_time BETWEEN '" + dtFrom.Value.ToString("yyyy-MM-dd HH:mm:00") + "' AND '" + dtTo.Value.ToString("yyyy-MM-dd HH:mm:00") + "' OR y.Exit_time BETWEEN '" + dtFrom.Value.ToString("yyyy-MM-dd HH:mm:00") + "' AND '" + dtTo.Value.ToString("yyyy-MM-dd HH:mm:00") + "') AND y.yard_id=" + yard_id + " AND V.Owner_Id='"+ cboTransporter.SelectedValue +"' ORDER BY Entry_time";
                dataGridView1.DataSource = Connections.Instance.ShowDataInGridView(Query);
                Query = "SELECT SUM(y.Base_Amount+y.Additional_Amount-ISNULL(Discount_Amount,0))AS Total FROM yard_entry y JOIN vehicle v on v.vehicle_id=y.vehicle_id LEFT JOIN Fee_Slab f on f.Fee_Slab_Id=y.Fee_Slab_Id WHERE y.Entry_time>='" + dtFrom.Value.ToString("yyyy-MM-dd HH:mm:00") + "' and y.Entry_time<='" + dtTo.Value.ToString("yyyy-MM-dd HH:mm:00") + "' AND y.yard_id=" + yard_id + " AND V.Owner_Id='" + cboTransporter.SelectedValue + "' AND y.Status!='C'";
                dt = (DataTable)Connections.Instance.ShowDataInGridView(Query);
                if (dt.Rows.Count > 0)
                {
                    lblTotal.Text = dt.Rows[0][0].ToString();
                }
            }
            else if (optIn.Checked == true)
            {
                Query = "SELECT ID,ROW_NUMBER() OVER(ORDER BY (SELECT 1)) AS SlNo, v.Vehicle_Type,v.Vehicle_Number,y.Entry_Time,y.Exit_Time,y.Payment_start_time,y.payment_end_time,f.slab_name,y.Base_Amount AS Slab_Amount,y.Additional_Amount,ISNULL(Discount_Amount,0) Discount_Amount,(y.Base_Amount+y.Additional_Amount-Discount_Amount)AS Total,CASE WHEN y.Status='C' OR CONVERT(INT,ISNULL(Discount_Amount,0))!=0 THEN Y.Remarks WHEN Reference_Id IS NOT NULL THEN 'Re-Entry' ELSE '' END AS Remarks,y.Contact_Name,y.Contact_Number,y.Status,'' AS Credit_Payment FROM yard_entry y JOIN vehicle v on v.vehicle_id=y.vehicle_id LEFT JOIN Fee_Slab f on f.Fee_Slab_Id=y.Fee_Slab_Id WHERE y.entry_time>='" + dtFrom.Value.ToString("yyyy-MM-dd HH:mm:00") + "' and y.entry_time<='" + dtTo.Value.ToString("yyyy-MM-dd HH:mm:00") + "' AND Exit_Time IS NULL AND y.yard_id=" + yard_id + " AND V.Owner_Id='" + cboTransporter.SelectedValue + "' ORDER BY entry_time";
                dataGridView1.DataSource = Connections.Instance.ShowDataInGridView(Query);

                lblTotal.Text = "0";

            }
            else
            {
                if (chkCreditPayment.Checked == true)
                {
                    Query = "SELECT ID,ROW_NUMBER() OVER(ORDER BY (SELECT 1)) AS SlNo, v.Vehicle_Type,v.Vehicle_Number,y.Entry_Time,y.Exit_Time,y.Payment_start_time,y.payment_end_time,f.slab_name,y.Base_Amount AS Slab_Amount,y.Additional_Amount,ISNULL(Discount_Amount,0) Discount_Amount,(y.Base_Amount+y.Additional_Amount-Discount_Amount)AS Total,CASE WHEN y.Status='C' OR CONVERT(INT,ISNULL(Discount_Amount,0))!=0 THEN Y.Remarks WHEN Reference_Id IS NOT NULL THEN 'Re-Entry' ELSE '' END AS Remarks,y.Contact_Name,y.Contact_Number,y.Status,CASE WHEN ISNULL(Y.Is_Credit_Payment,'No')='Y' THEN 'Yes' ELSE 'No' END AS Credit_Payment FROM yard_entry y JOIN vehicle v on v.vehicle_id=y.vehicle_id LEFT JOIN Fee_Slab f on f.Fee_Slab_Id=y.Fee_Slab_Id WHERE y.exit_time>='" + dtFrom.Value.ToString("yyyy-MM-dd HH:mm:00") + "' and y.exit_time<='" + dtTo.Value.ToString("yyyy-MM-dd HH:mm:00") + "' AND Is_Credit_Payment='Y' AND y.yard_id=" + yard_id + " AND V.Owner_Id='" + cboTransporter.SelectedValue + "' ORDER BY Exit_Time";
                    dataGridView1.DataSource = Connections.Instance.ShowDataInGridView(Query);
                    Query = "SELECT SUM(y.Base_Amount+y.Additional_Amount-ISNULL(Discount_Amount,0))AS Total FROM yard_entry y JOIN vehicle v on v.vehicle_id=y.vehicle_id LEFT JOIN Fee_Slab f on f.Fee_Slab_Id=y.Fee_Slab_Id WHERE y.exit_time>='" + dtFrom.Value.ToString("yyyy-MM-dd HH:mm:00") + "' and y.exit_time<='" + dtTo.Value.ToString("yyyy-MM-dd HH:mm:00") + "'  AND Is_Credit_Payment='Y'  AND y.yard_id=" + yard_id + "  AND V.Owner_Id='" + cboTransporter.SelectedValue + "'  AND y.Status!='C'";
                    dt.Rows.Clear();
                    dt = (DataTable)Connections.Instance.ShowDataInGridView(Query);
                
                }
                else
                {
                    Query = "SELECT ID,ROW_NUMBER() OVER(ORDER BY (SELECT 1)) AS SlNo, v.Vehicle_Type,v.Vehicle_Number,y.Entry_Time,y.Exit_Time,y.Payment_start_time,y.payment_end_time,f.slab_name,y.Base_Amount AS Slab_Amount,y.Additional_Amount,ISNULL(Discount_Amount,0) Discount_Amount,(y.Base_Amount+y.Additional_Amount-Discount_Amount)AS Total,CASE WHEN y.Status='C' OR CONVERT(INT,ISNULL(Discount_Amount,0))!=0 THEN Y.Remarks WHEN Reference_Id IS NOT NULL THEN 'Re-Entry' ELSE '' END AS Remarks,y.Contact_Name,y.Contact_Number,y.Status,CASE WHEN ISNULL(Y.Is_Credit_Payment,'No')='Y' THEN 'Yes' ELSE 'No' END AS Credit_Payment FROM yard_entry y JOIN vehicle v on v.vehicle_id=y.vehicle_id LEFT JOIN Fee_Slab f on f.Fee_Slab_Id=y.Fee_Slab_Id WHERE y.exit_time>='" + dtFrom.Value.ToString("yyyy-MM-dd HH:mm:00") + "' and y.exit_time<='" + dtTo.Value.ToString("yyyy-MM-dd HH:mm:00") + "' AND y.yard_id=" + yard_id + " AND V.Owner_Id='" + cboTransporter.SelectedValue + "' ORDER BY Exit_Time";
                    dataGridView1.DataSource = Connections.Instance.ShowDataInGridView(Query);

                    Query = "SELECT SUM(y.Base_Amount+y.Additional_Amount-ISNULL(Discount_Amount,0))AS Total FROM yard_entry y JOIN vehicle v on v.vehicle_id=y.vehicle_id LEFT JOIN Fee_Slab f on f.Fee_Slab_Id=y.Fee_Slab_Id WHERE y.exit_time>='" + dtFrom.Value.ToString("yyyy-MM-dd HH:mm:00") + "' and y.exit_time<='" + dtTo.Value.ToString("yyyy-MM-dd HH:mm:00") + "' AND y.yard_id=" + yard_id + "  AND V.Owner_Id='" + cboTransporter.SelectedValue + "' AND y.Status!='C'";
                    dt.Rows.Clear();
                    dt = (DataTable)Connections.Instance.ShowDataInGridView(Query);
                }
                if (dt.Rows.Count > 0)
                {
                    lblTotal.Text = dt.Rows[0][0].ToString();
                }
            }
            dt.Dispose();
            dataGridView1.Columns[0].Visible = false;
        }

        private void btnPrint_Click(object sender, EventArgs e)
        {
            crystalReportViewer1.Visible = true;
            crystalReportViewer1.ToolPanelView = ToolPanelViewType.None;
            crystalReportViewer1.Width = dataGridView1.Width;
            crystalReportViewer1.Height = dataGridView1.Height;
            crystalReportViewer1.Top = dataGridView1.Top;
            crystalReportViewer1.Left = dataGridView1.Left;

            if (dataGridView1.Rows.Count == 0)
            {
                MessageBox.Show("No records found to print");
                return;
            }
            
            string Query;
            DataTable dt = new DataTable();
            if (OptAll.Checked == true)
            {
                Query = "SELECT ROW_NUMBER() OVER(ORDER BY (SELECT 1)) AS SlNo, v.Vehicle_Type,v.Vehicle_Number,y.Entry_Time,y.Exit_Time,y.Payment_start_time,y.payment_end_time,f.slab_name,CONVERT(DECIMAL(18,2),y.Base_Amount) AS Slab_Amount,CONVERT(DECIMAL(18,2),isnull(y.Additional_Amount,'0')) AS Additional_Amount,CONVERT(DECIMAL(18,2),isnull(y.Discount_Amount,'0')) AS Discount_Amount,CONVERT(DECIMAL(18,2),(y.Base_Amount+y.Additional_Amount-Discount_Amount)) AS Total,CASE WHEN y.Status='C' OR CONVERT(INT,ISNULL(Discount_Amount,0))!=0 THEN Y.Remarks WHEN Reference_Id IS NOT NULL THEN 'Re-Entry' ELSE '' END AS Remarks FROM yard_entry y JOIN vehicle v on v.vehicle_id=y.vehicle_id LEFT JOIN Fee_Slab f on f.Fee_Slab_Id=y.Fee_Slab_Id WHERE (y.Entry_time BETWEEN '" + dtFrom.Value.ToString("yyyy-MM-dd HH:mm:00") + "' AND '" + dtTo.Value.ToString("yyyy-MM-dd HH:mm:00") + "' OR y.Exit_time BETWEEN '" + dtFrom.Value.ToString("yyyy-MM-dd HH:mm:00") + "' AND '" + dtTo.Value.ToString("yyyy-MM-dd HH:mm:00") + "') AND y.yard_id=" + yard_id + " AND V.Owner_Id='" + cboTransporter.SelectedValue + "' ORDER BY Entry_time";
                dt = (DataTable)Connections.Instance.ShowDataInGridView(Query);

            }
            else if (optIn.Checked == true)
            {
                Query = "SELECT ROW_NUMBER() OVER(ORDER BY (SELECT 1)) AS SlNo, v.Vehicle_Type,v.Vehicle_Number,y.Entry_Time,y.Exit_Time,y.Payment_start_time,y.payment_end_time,f.slab_name,CONVERT(DECIMAL(18,2),y.Base_Amount) AS Slab_Amount,CONVERT(DECIMAL(18,2),isnull(y.Additional_Amount,'0')) AS Additional_Amount,CONVERT(DECIMAL(18,2),isnull(y.Discount_Amount,'0')) AS Discount_Amount,CONVERT(DECIMAL(18,2),(y.Base_Amount+y.Additional_Amount-Discount_Amount)) AS Total,CASE WHEN y.Status='C' OR CONVERT(INT,ISNULL(Discount_Amount,0))!=0 THEN Y.Remarks WHEN Reference_Id IS NOT NULL THEN 'Re-Entry' ELSE '' END AS Remarks FROM yard_entry y JOIN vehicle v on v.vehicle_id=y.vehicle_id LEFT JOIN Fee_Slab f on f.Fee_Slab_Id=y.Fee_Slab_Id WHERE y.entry_time>='" + dtFrom.Value.ToString("yyyy-MM-dd HH:mm:00") + "' and y.entry_time<='" + dtTo.Value.ToString("yyyy-MM-dd HH:mm:00") + "' AND Exit_Time IS NULL AND y.yard_id=" + yard_id + " AND V.Owner_Id='" + cboTransporter.SelectedValue + "'  ORDER BY entry_time";
                dt = (DataTable)Connections.Instance.ShowDataInGridView(Query);

            }
            else
            {

                if (chkCreditPayment.Checked == true)
                {
                    Query = "SELECT ROW_NUMBER() OVER(ORDER BY (SELECT 1)) AS SlNo, v.Vehicle_Type,v.Vehicle_Number,y.Entry_Time,y.Exit_Time,y.Payment_start_time,y.payment_end_time,f.slab_name,CONVERT(DECIMAL(18,2),y.Base_Amount) AS Slab_Amount,CONVERT(DECIMAL(18,2),isnull(y.Additional_Amount,'0')) AS Additional_Amount,CONVERT(DECIMAL(18,2),isnull(y.Discount_Amount,'0')) AS Discount_Amount,CONVERT(DECIMAL(18,2),(y.Base_Amount+y.Additional_Amount-CONVERT(DECIMAL(18,2),isnull(y.Discount_Amount,'0'))) AS Total,CASE WHEN y.Status='C' OR CONVERT(INT,ISNULL(Discount_Amount,0))!=0 THEN Y.Remarks WHEN Reference_Id IS NOT NULL THEN 'Re-Entry' ELSE '' END AS Remarks FROM yard_entry y JOIN vehicle v on v.vehicle_id=y.vehicle_id LEFT JOIN Fee_Slab f on f.Fee_Slab_Id=y.Fee_Slab_Id WHERE y.exit_time>='" + dtFrom.Value.ToString("yyyy-MM-dd HH:mm:00") + "' and y.exit_time<='" + dtTo.Value.ToString("yyyy-MM-dd HH:mm:00") + "' AND y.yard_id=" + yard_id + " AND Is_Credit_Payment='Y'  AND V.Owner_Id='" + cboTransporter.SelectedValue + "'   ORDER BY Exit_Time";
                    dt = (DataTable)Connections.Instance.ShowDataInGridView(Query);
                    
                }
                else
                {
                    Query = "SELECT ROW_NUMBER() OVER(ORDER BY (SELECT 1)) AS SlNo, v.Vehicle_Type,v.Vehicle_Number,y.Entry_Time,y.Exit_Time,y.Payment_start_time,y.payment_end_time,f.slab_name,CONVERT(DECIMAL(18,2),y.Base_Amount) AS Slab_Amount,CONVERT(DECIMAL(18,2),isnull(y.Additional_Amount,'0')) AS Additional_Amount,CONVERT(DECIMAL(18,2),isnull(y.Discount_Amount,'0')) AS Discount_Amount,CONVERT(DECIMAL(18,2),(y.Base_Amount+y.Additional_Amount-CONVERT(DECIMAL(18,2),isnull(y.Discount_Amount,'0'))) AS Total,CASE WHEN y.Status='C' OR CONVERT(INT,ISNULL(Discount_Amount,0))!=0 THEN Y.Remarks WHEN Reference_Id IS NOT NULL THEN 'Re-Entry' ELSE '' END AS Remarks FROM yard_entry y JOIN vehicle v on v.vehicle_id=y.vehicle_id LEFT JOIN Fee_Slab f on f.Fee_Slab_Id=y.Fee_Slab_Id WHERE y.exit_time>='" + dtFrom.Value.ToString("yyyy-MM-dd HH:mm:00") + "' and y.exit_time<='" + dtTo.Value.ToString("yyyy-MM-dd HH:mm:00") + "' AND y.yard_id=" + yard_id + " AND V.Owner_Id='" + cboTransporter.SelectedValue + "'   ORDER BY Exit_Time";
                    dt = (DataTable)Connections.Instance.ShowDataInGridView(Query);
                }
            }

            //dt = (DataTable)Connections.Instance.ShowDataInGridView(Query);


            ds.Tables["EntryDetails"].Clear();
            ds.Tables["EntryDetails"].Merge(dt);
            string reportFileName = System.Configuration.ConfigurationSettings.AppSettings["EntryDetailsTransporter"];
            ReportDocument cryRpt = new ReportDocument();
            cryRpt.Load(System.IO.Path.GetDirectoryName(Application.ExecutablePath).ToString() + reportFileName);
            if (cryRpt.DataDefinition.FormulaFields.Count > 0)
            {
                cryRpt.DataDefinition.FormulaFields[0].Text = "'" + dtFrom.Value + "'";
                cryRpt.DataDefinition.FormulaFields[1].Text = "'" + dtTo.Value + "'";
                cryRpt.DataDefinition.FormulaFields[3].Text = "'" + cboTransporter.Text + "'";
            }
            cryRpt.SetDataSource(ds);
            cryRpt.Refresh();
            //cryRpt.PrintToPrinter(1, true, 0, 0);

            crystalReportViewer1.ReportSource = cryRpt;
            crystalReportViewer1.Refresh();

        }
    }
}
