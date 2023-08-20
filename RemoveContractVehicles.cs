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
    public partial class RemoveContractVehicles : Form
    {
        public RemoveContractVehicles()
        {
            InitializeComponent();
        }

        private void RemoveContractVehicles_Load(object sender, EventArgs e)
        {
            LoadContractList();
        }
        private void LoadContractList()
        {

            cboTransporter.DataSource = null;
            string query = "SELECT	p.parking_pass_id,o.Transporter_Name FROM	Owner o JOIN Parking_Pass p on p.owner_id=o.owner_id WHERE	p.Owner_Id=o.Owner_Id ORDER BY 2";

            cboTransporter.DataSource = Connections.Instance.ShowDataInGridView(query);
            cboTransporter.DisplayMember = "Transporter_Name";
            cboTransporter.ValueMember = "parking_pass_id";
            cboTransporter.SelectedIndex = -1;
            cboTransporter.Text = "";

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

        private void LoadVehicleList(object parking_pass_id)
        {

            cboVehicle.DataSource = null;
            string query = "SELECT pd.Vehicle_Id,Vehicle_Number+' ('+Vehicle_Type+')' AS Vehicle_Number FROM  Parking_Pass P JOIN Parking_Pass_Detail pd ON P.parking_pass_id=pd.parking_pass_id JOIN Vehicle V ON V.Vehicle_Id=pd.Vehicle_Id  WHERE p.parking_pass_id='" + Convert.ToInt32(parking_pass_id) + "' ORDER BY 2";

            cboVehicle.DataSource = Connections.Instance.ShowDataInGridView(query);
            cboVehicle.DisplayMember = "Vehicle_Number";
            cboVehicle.ValueMember = "Vehicle_Id";
            cboVehicle.SelectedIndex = -1;
            cboVehicle.Text = "";

        }

        private void RESET_Click(object sender, EventArgs e)
        {
            cboTransporter.SelectedIndex = -1;
            cboTransporter.Text = "";
            cboVehicle.DataSource = null;
            cboVehicle.Focus();
        }

        private void SAVE_Click(object sender, EventArgs e)
        {
            if (cboTransporter.SelectedIndex < 0)
            {
                MessageBox.Show("Please select a transporter");
                cboTransporter.Focus();
                return;
            }
            if (cboVehicle.SelectedIndex < 0)
            {
                MessageBox.Show("Please select a vehcile");
                cboVehicle.Focus();
                return;
            }
            DialogResult dialogResult = MessageBox.Show("Do you want to remove the vehicle?", "Yard Entry", MessageBoxButtons.YesNo);
            if (dialogResult == DialogResult.Yes)
            {

                SqlCommand cmd = new SqlCommand();
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "Remove_Contract_Vehicle";

                cmd.Parameters.Add("@Vehicle_Id", SqlDbType.Int).Value = cboVehicle.SelectedValue;

                Connections.Instance.OpenConection();
                Connections.Instance.ExecuteProcedure(cmd);

                RESET_Click(null, null);

                Connections.Instance.CloseConnection();
                cmd.Dispose();
            }

        }
    }
}
