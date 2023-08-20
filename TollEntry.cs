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
    public partial class TollEntry : Form
    {
        public string DisplayName;
        public string User_Id;
        public TollEntry()
        {
            InitializeComponent();
        }

        private void TollEntry_Load(object sender, EventArgs e)
        {
            DtDate.Tag = "";
            getGridView(DateTime.Now.ToString("yyyy-MM-dd"),0);

        }
        private void getGridView(string SearchDate,int DateSearch)
        {

            GridView.DataSource = null;
            DataTable dt = new DataTable();

            SqlCommand cmd = new SqlCommand();
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = "Get_Toll_Details";
            cmd.Parameters.Add("@Date", SqlDbType.Date).Value = SearchDate;
            if (DateSearch == 1)
            {
                cmd.Parameters.Add("@DateSearch", SqlDbType.Int).Value = 1;
            }
            else
            {
                cmd.Parameters.Add("@DateSearch", SqlDbType.Int).Value = 0;
            }
            Connections.Instance.OpenConection();
            cmd.Connection = Connections.Instance.con;
            //Connections.Instance.ExecuteProcedure(cmd);

            dt.Load(cmd.ExecuteReader());
            GridView.DataSource = dt;
            dt.Dispose();
            GridView.Columns[0].Visible = false;
            cmd.Dispose();
            Connections.Instance.CloseConnection();
        }
        private void btnClear_Click(object sender, EventArgs e)
        {
            DtDate.Value = DateTime.Now;
            DtSearch.Value = DateTime.Now;
            txtAmount.Text = "";
            DtDate.Tag = "";
            getGridView(DateTime.Now.ToString("yyyy-MM-dd"),0);
            txtAmount.Focus();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            float Amount = 0;
            bool result = float.TryParse(txtAmount.Text, out Amount); 

            if (txtAmount.Text == "")
            {
                MessageBox.Show("Please enter the amount");
                txtAmount.Focus();
            }
            else if (result==false)
            {
                MessageBox.Show("Please enter valid amount");
                txtAmount.Focus();
            }

            DialogResult dialogResult = MessageBox.Show("Do you want to save the entry?", "Toll Entry", MessageBoxButtons.YesNo);
            if (dialogResult == DialogResult.Yes)
            {

                SqlCommand cmd = new SqlCommand();
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "SP_Toll_Entry";
                cmd.Parameters.Add("@Date", SqlDbType.Date).Value = DtDate.Value.ToString("yyyy-MM-dd");
                cmd.Parameters.Add("@Amount", SqlDbType.Float).Value = Amount;
                cmd.Parameters.Add("@User_Id", SqlDbType.Int).Value = Connections.Instance.user_id;
                if (DtDate.Tag.ToString() == "")
                {
                    cmd.Parameters.Add("@EntryType", SqlDbType.VarChar).Value = "INSERT";
                }
                else
                {
                    cmd.Parameters.Add("@Id", SqlDbType.Int).Value = DtDate.Tag.ToString();
                    cmd.Parameters.Add("@EntryType", SqlDbType.VarChar).Value = "EDIT";
                }
                cmd.Parameters.Add("@message", SqlDbType.VarChar, 200);
                cmd.Parameters["@message"].Direction = ParameterDirection.Output;
                cmd.Parameters.Add("@message_code", SqlDbType.Int);
                cmd.Parameters["@message_code"].Direction = ParameterDirection.Output;
                Connections.Instance.OpenConection();
                Connections.Instance.ExecuteProcedure(cmd);

                if (Convert.ToUInt16(cmd.Parameters["@message_Code"].Value) == 100)
                {
                    MessageBox.Show("Successfully saved");
                    btnClear_Click(null, null);
                }
                else
                {
                    MessageBox.Show((string)cmd.Parameters["@message"].Value);

                }
                Connections.Instance.CloseConnection();
                cmd.Dispose();
            }
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            getGridView(DtSearch.Value.ToString("yyyy-MM-dd"),1);
        }

        private void GridView_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int rowno = e.RowIndex;
            DtDate.Tag = GridView.Rows[rowno].Cells[0].Value.ToString();
            DtDate.Value = Convert.ToDateTime(GridView.Rows[rowno].Cells[1].Value.ToString());
            txtAmount.Text = GridView.Rows[rowno].Cells[2].Value.ToString();
            txtAmount.Focus();
        }

        private void GridView_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (DtDate.Tag.ToString() == "")
            {
                MessageBox.Show("Please select valid record");
                return;
            }

            DialogResult dialogResult = MessageBox.Show("Do you want to delete the entry?", "Toll Entry", MessageBoxButtons.YesNo);
            if (dialogResult == DialogResult.Yes)
            {

                SqlCommand cmd = new SqlCommand();
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "SP_Toll_Entry";
                cmd.Parameters.Add("@Date", SqlDbType.Date).Value = DtDate.Value.ToString("yyyy-MM-dd");
                cmd.Parameters.Add("@Amount", SqlDbType.Float).Value = 0;
                cmd.Parameters.Add("@User_Id", SqlDbType.Int).Value = Connections.Instance.user_id;
                cmd.Parameters.Add("@Id", SqlDbType.Int).Value = DtDate.Tag.ToString();
                cmd.Parameters.Add("@EntryType", SqlDbType.VarChar).Value = "DELETE";
               
                cmd.Parameters.Add("@message", SqlDbType.VarChar, 200);
                cmd.Parameters["@message"].Direction = ParameterDirection.Output;
                cmd.Parameters.Add("@message_code", SqlDbType.Int);
                cmd.Parameters["@message_code"].Direction = ParameterDirection.Output;
                Connections.Instance.OpenConection();
                Connections.Instance.ExecuteProcedure(cmd);

                if (Convert.ToUInt16(cmd.Parameters["@message_Code"].Value) == 100)
                {
                    MessageBox.Show("Successfully deleted");
                    btnClear_Click(null, null);
                }
                else
                {
                    MessageBox.Show((string)cmd.Parameters["@message"].Value);

                }
                Connections.Instance.CloseConnection();
                cmd.Dispose();
            }
        }
    }
}
