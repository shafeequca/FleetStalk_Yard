using FleetStalk_Yard.DataSet;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace FleetStalk_Yard
{
    public partial class TollEntryDetails : Form
    {
        public string DisplayName;
        public string User_Id;

        private double _TotalAmount;
        private double _SGST;
        private double _CGST;
        private double _NonGSTAmount;
        private double _CommissionAmount;
        private double _CommissionSGST;
        private double _CommissionCGST;
        private double _TotalCommission;

        public TollEntryDetails()
        {
            InitializeComponent();
        }

        private void TollEntryDetails_Load(object sender, EventArgs e)
        {
            btnShow_Click(null, null);
            
        }



        private void btnShow_Click(object sender, EventArgs e)
        {
            crystalReportViewer1.Visible = false;
            GridView.Visible = true;
            DataTable dt = new DataTable();

            SqlCommand cmd = new SqlCommand();
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = "Get_Toll_report";

            cmd.Parameters.Add("@Dt_From", SqlDbType.Date).Value = dtFrom.Value.ToString("yyyy-MM-dd");
            cmd.Parameters.Add("@Dt_To", SqlDbType.Date).Value = dtTo.Value.ToString("yyyy-MM-dd");

            SqlParameter CommissionPercentage = new SqlParameter("@CommissionPercentage", SqlDbType.Decimal);
            CommissionPercentage.Precision = 18;
            CommissionPercentage.Scale = 2;
            CommissionPercentage.Direction = ParameterDirection.Input;
            CommissionPercentage.Value = txtCommissionPer.Text;
            cmd.Parameters.Add(CommissionPercentage);

            if (chkCommissionFlag.Checked == true)
                cmd.Parameters.Add("@CommissionFlag", SqlDbType.TinyInt).Value = 1;
            else
                cmd.Parameters.Add("@CommissionFlag", SqlDbType.TinyInt).Value = 0;

            SqlParameter TotalAmount = new SqlParameter("@TotalAmount", SqlDbType.Decimal);
            TotalAmount.Precision = 18;
            TotalAmount.Scale = 2;
            TotalAmount.Direction = ParameterDirection.Output;
            cmd.Parameters.Add(TotalAmount);

            SqlParameter SGST = new SqlParameter("@SGST", SqlDbType.Decimal);
            SGST.Precision = 18;
            SGST.Scale = 2;
            SGST.Direction = ParameterDirection.Output;
            cmd.Parameters.Add(SGST);

            SqlParameter CGST = new SqlParameter("@CGST", SqlDbType.Decimal);
            CGST.Precision = 18;
            CGST.Scale = 2;
            CGST.Direction = ParameterDirection.Output;
            cmd.Parameters.Add(CGST);

            SqlParameter NonGSTAmount = new SqlParameter("@NonGSTAmount", SqlDbType.Decimal);
            NonGSTAmount.Precision = 18;
            NonGSTAmount.Scale = 2;
            NonGSTAmount.Direction = ParameterDirection.Output;
            cmd.Parameters.Add(NonGSTAmount);

            SqlParameter CommissionAmount = new SqlParameter("@CommissionAmount", SqlDbType.Decimal);
            CommissionAmount.Precision = 18;
            CommissionAmount.Scale = 2;
            CommissionAmount.Direction = ParameterDirection.Output;
            cmd.Parameters.Add(CommissionAmount);

            SqlParameter CommissionSGST = new SqlParameter("@CommissionSGST", SqlDbType.Decimal);
            CommissionSGST.Precision = 18;
            CommissionSGST.Scale = 2;
            CommissionSGST.Direction = ParameterDirection.Output;
            cmd.Parameters.Add(CommissionSGST);

            SqlParameter CommissionCGST = new SqlParameter("@CommissionCGST", SqlDbType.Decimal);
            CommissionCGST.Precision = 18;
            CommissionCGST.Scale = 2;
            CommissionCGST.Direction = ParameterDirection.Output;
            cmd.Parameters.Add(CommissionCGST);

            SqlParameter TotalCommission = new SqlParameter("@TotalCommission", SqlDbType.Decimal);
            TotalCommission.Precision = 18;
            TotalCommission.Scale = 2;
            TotalCommission.Direction = ParameterDirection.Output;
            cmd.Parameters.Add(TotalCommission);
            

            Connections.Instance.OpenConection();
            cmd.Connection = Connections.Instance.con;
            //Connections.Instance.ExecuteProcedure(cmd);

            dt.Load(cmd.ExecuteReader());

            _TotalAmount = Convert.ToDouble(cmd.Parameters["@TotalAmount"].Value.ToString());
            _SGST = Convert.ToDouble(cmd.Parameters["@SGST"].Value.ToString());
            _CGST = Convert.ToDouble(cmd.Parameters["@CGST"].Value.ToString());
            _NonGSTAmount = Convert.ToDouble(cmd.Parameters["@NonGSTAmount"].Value.ToString());
            _CommissionAmount = Convert.ToDouble(cmd.Parameters["@CommissionAmount"].Value.ToString());
            _CommissionSGST = Convert.ToDouble(cmd.Parameters["@CommissionSGST"].Value.ToString());
            _CommissionCGST = Convert.ToDouble(cmd.Parameters["@CommissionCGST"].Value.ToString());
            _TotalCommission = Convert.ToDouble(cmd.Parameters["@TotalCommission"].Value.ToString());

            GridView.DataSource = dt;

            dt.Dispose();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            btnShow_Click(null, null);

            crystalReportViewer1.Visible = true;
            GridView.Visible = false;

            DataSet1 ds = new DataSet1();
            DataTable dt = new DataTable();
            //SqlCommand cmd = new SqlCommand();
            //cmd.CommandType = CommandType.StoredProcedure;
            //cmd.CommandText = "Get_Visit_report";

            //Connections.Instance.OpenConection();
            //cmd.Connection = Connections.Instance.con;
            //Connections.Instance.ExecuteProcedure(cmd);

            dt.Merge((DataTable)GridView.DataSource);

            ds.Tables["TollDetails"].Clear();
            ds.Tables["TollDetails"].Merge(dt);

            CrystalDecisions.CrystalReports.Engine.ReportDocument cryRpt = new CrystalDecisions.CrystalReports.Engine.ReportDocument();

            string ReportName = System.Configuration.ConfigurationSettings.AppSettings["TollReport"].ToString();
            cryRpt.Load(System.IO.Path.GetDirectoryName(Application.ExecutablePath).ToString() + ReportName);

            cryRpt.SetDataSource(ds);

            cryRpt.DataDefinition.FormulaFields["InvoiceDate"].Text = "'" + dtInvoiceDate.Value.ToString("dd-MM-yyyy") + "'";
            cryRpt.DataDefinition.FormulaFields["InvoiceNo"].Text = "'" + txtInvoiceNo.Text + "'";
            cryRpt.DataDefinition.FormulaFields["TotalAmount"].Text = "'" + string.Format("{0:N2}", _TotalAmount) + "'";
            cryRpt.DataDefinition.FormulaFields["SGST"].Text = "'" + string.Format("{0:N2}", _SGST) + "'";
            cryRpt.DataDefinition.FormulaFields["CGST"].Text = "'" + string.Format("{0:N2}", _CGST) + "'";
            cryRpt.DataDefinition.FormulaFields["WithoutGST"].Text = "'" + string.Format("{0:N2}", _NonGSTAmount) + "'";
            cryRpt.DataDefinition.FormulaFields["CommissionAmount"].Text = "'" + string.Format("{0:N2}", _CommissionAmount) + "'";
            cryRpt.DataDefinition.FormulaFields["CommSGST"].Text = "'" + string.Format("{0:N2}", _CommissionSGST) + "'";
            cryRpt.DataDefinition.FormulaFields["CommCGST"].Text = "'" + string.Format("{0:N2}", _CommissionCGST) + "'";
            cryRpt.DataDefinition.FormulaFields["TotalCommission"].Text = "'" + string.Format("{0:N2}", _TotalCommission) + "'";

            //cryRpt.DataDefinition.FormulaFields[1].Text = "'" + dtTo.Value.ToString("dd-MM-yy hh:mmtt") + "'";

            cryRpt.Refresh();

            //cryRpt.PrintToPrinter(1, true, 0, 0);

            CrystalDecisions.CrystalReports.Engine.ReportDocument rpt = new CrystalDecisions.CrystalReports.Engine.ReportDocument();
            crystalReportViewer1.ReportSource = cryRpt;
        }

        private void btnReset_Click(object sender, EventArgs e)
        {
            dtFrom.Value = DateTime.Now;
            dtTo.Value = DateTime.Now;
            dtInvoiceDate.Value = DateTime.Now;
            txtCommissionPer.Text = "0.00";
            txtInvoiceNo.Text = "";

            _TotalAmount = 0;
            _SGST = 0;
            _CGST = 0;
            _NonGSTAmount = 0;
            _CommissionAmount = 0;
            _CommissionSGST = 0;
            _CommissionCGST = 0;
            _TotalCommission = 0;

            crystalReportViewer1.Visible = false;
            GridView.Visible = true;
        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void label5_Click(object sender, EventArgs e)
        {

        }
    }
}
