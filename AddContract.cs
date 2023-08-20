using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace FleetStalk_Yard
{
    public partial class AddContract : Form
    {
        public AddContract()
        {
            InitializeComponent();
        }

        private void AddContract_Load(object sender, EventArgs e)
        {

            LoadTransporterList();
            LoadContractList();

        }
        private void LoadTransporterList()
        {
            cboTransporter.DataSource = null;
            string query = "SELECT Owner_Id,Transporter_Name FROM Owner o WHERE NOT EXISTS(SELECT 1 FROM Parking_Pass p WHERE p.Owner_Id=o.Owner_Id) ORDER BY 2";
            cboTransporter.DataSource = Connections.Instance.ShowDataInGridView(query);
            cboTransporter.DisplayMember = "Transporter_Name";
            cboTransporter.ValueMember = "Owner_Id";
            cboTransporter.SelectedIndex = -1;
            cboTransporter.Text = "";
        }
        private void LoadContractList()
        {

            cboContract.DataSource = null;
            string query = "SELECT	p.parking_pass_id,o.Transporter_Name FROM	Owner o JOIN Parking_Pass p on p.owner_id=o.owner_id WHERE	p.Owner_Id=o.Owner_Id ORDER BY 2";

            cboContract.DataSource = Connections.Instance.ShowDataInGridView(query);
            cboContract.DisplayMember = "Transporter_Name";
            cboContract.ValueMember = "parking_pass_id";
            cboContract.SelectedIndex = -1;
            cboContract.Text = "";

        }

        private void optGeneral_CheckedChanged(object sender, EventArgs e)
        {
            cboContract.Enabled = false;
            cboContract.SelectedIndex = -1;
        }

        private void optOther_CheckedChanged(object sender, EventArgs e)
        {
            cboContract.Enabled = true;
        }

        private void RESET_Click(object sender, EventArgs e)
        {
            cboContract.SelectedIndex = -1;
            cboContract.Text = "";
            cboContract.Enabled = false;
            optGeneral.Checked = true;
            cboTransporter.SelectedIndex = -1;
            cboTransporter.Text = "";
            dtFrom.Value = DateTime.Now;
            dtTo.Value = DateTime.Now;
            cboGSTType.Text = "";
            LoadTransporterList();
            LoadContractList();
            cboTransporter.Focus();
        }

        private void SAVE_Click(object sender, EventArgs e)
        {
            if (cboTransporter.SelectedIndex < 0)
            {
                MessageBox.Show("Please select a transporter");
                cboTransporter.Focus();
                return;
            }
            if (optOther.Checked == true && cboContract.SelectedIndex < 0)
            {
                MessageBox.Show("Please select a fee slab from the list");
                cboContract.Focus();
                return;
            }
            if (cboGSTType.Text == "")
            {
                MessageBox.Show("Please select a GST Type");
                cboGSTType.Focus();
                return;
            }

            DialogResult dialogResult = MessageBox.Show("Do you want to save the entry?", "Yard Entry", MessageBoxButtons.YesNo);
            if (dialogResult == DialogResult.Yes)
            {

                SqlCommand cmd = new SqlCommand();
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "Add_Contract";

                cmd.Parameters.Add("@Owner_Id", SqlDbType.Int).Value = cboTransporter.SelectedValue;

                if (optGeneral.Checked == true)
                {
                    cmd.Parameters.Add("@Parking_Pass_Id", SqlDbType.Int).Value = null;
                }
                else
                {
                    cmd.Parameters.Add("@Parking_Pass_Id", SqlDbType.Int).Value = cboContract.SelectedValue;
                }
                cmd.Parameters.Add("@Valid_From", SqlDbType.DateTime).Value = dtFrom.Value;
                cmd.Parameters.Add("@Valid_To", SqlDbType.DateTime).Value = dtTo.Value;
                cmd.Parameters.Add("@User_Id", SqlDbType.Int).Value = Connections.Instance.user_id;

                cmd.Parameters.Add("@GST_Type", SqlDbType.VarChar).Value = cboGSTType.Text;
                cmd.Parameters.Add("@GST_Value_Type", SqlDbType.VarChar).Value = "INCLUSIVE";

                Connections.Instance.OpenConection();
                Connections.Instance.ExecuteProcedure(cmd);

                RESET_Click(null, null);

                Connections.Instance.CloseConnection();
                cmd.Dispose();

            }
        }
    }
}
