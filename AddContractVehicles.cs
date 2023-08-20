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
    public partial class AddContractVehicles : Form
    {
        public AddContractVehicles()
        {
            InitializeComponent();
        }

        private void AddContractVehicles_Load(object sender, EventArgs e)
        {

        }

        private void txtTransporter_TextChanged(object sender, EventArgs e)
        {

            string Query = "SELECT O.Owner_ID,O.Transporter_Name FROM Owner O JOIN Parking_Pass P ON P.Owner_ID=O.Owner_ID WHERE P.Status='A' AND P.Valid_From<=GETDATE() AND Valid_To>=GETDATE() AND O.Transporter_Name LIKE '%" + txtTransporter.Text + "%' ORDER BY 2";
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
        private void txtTransporter_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyData == Keys.Down && TransporterView.Rows.Count != 0 && txtTransporter.Text.Trim() != "")
            {
                TransporterView.Focus();
            }
            else if (e.KeyData == Keys.Enter)
            {
                TransporterView.Visible = false;
                txtVehicle.Focus();
            }
            else if (e.KeyData == Keys.Escape)
            {
                TransporterView.Visible = false;
            }

        }
        private void txtTransporter_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
                txtVehicle.Focus();

        }

        private void TransporterView_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
        private void TransporterView_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            TransporterView_Show();
            TransporterView.Visible = false;
            txtVehicle.Focus();
        }
        private void TransporterView_Show()
        {
            int r = TransporterView.CurrentRow.Index;
            txtTransporter.Tag = TransporterView.Rows[r].Cells[0].Value.ToString();
            txtTransporter.Text = TransporterView.Rows[r].Cells[1].Value.ToString();
        }
        private void TransporterView_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyData == Keys.Enter && TransporterView.Rows.Count > 0)
            {
                TransporterView_Show();
                TransporterView.Visible = false;
                txtVehicle.Focus();
            }
            else if (e.KeyData == Keys.Escape)
            {
                TransporterView.Visible = false;
            }
        }
        private void txtVehicle_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyData == Keys.Down && VehicleView.Rows.Count != 0 && txtVehicle.Text.Trim() != "")
            {
                VehicleView.Focus();
            }
            else if (e.KeyData == Keys.Enter)
            {
                VehicleView.Visible = false;
                VehicleType.Focus();
            }
            else if (e.KeyData == Keys.Escape)
            {
                VehicleView.Visible = false;
            }

        }
        private void txtVehicle_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
                VehicleType.Focus();

        }


        private void txtVehicle_TextChanged(object sender, EventArgs e)
        {
            if (txtTransporter.Tag == null || txtTransporter.Tag.ToString() == "")
            {
                MessageBox.Show("Please select a transporter");
                txtTransporter.Focus();
                return;

            }
            if (txtVehicle.Text.Trim() == "")
            {
                txtVehicle.Tag = null;
            }

            string Query = "select vehicle_Id,Vehicle_Number,Vehicle_Type from Vehicle WHERE Vehicle_number LIKE '%"+ txtVehicle.Text +"%' AND Owner_Id='" + txtTransporter.Tag.ToString() + "' ORDER BY 2";
            VehicleView.DataSource = Connections.Instance.ShowDataInGridView(Query);
            VehicleView.Columns[0].Visible = false;
            VehicleView.Columns[2].Visible = false;
            if (VehicleView.Rows.Count == 0 || txtVehicle.Text.Trim() == "")
            {
                VehicleView.Visible = false;
            }
            else
            {
                VehicleView.Visible = true;
            }
        }

        private void VehicleView_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
        private void VehicleView_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            VehicleView_Show();
            VehicleView.Visible = false;
            VehicleType.Focus();
        }
        private void VehicleView_Show()
        {
            int r = VehicleView.CurrentRow.Index;
            txtVehicle.Tag = VehicleView.Rows[r].Cells[0].Value.ToString();
            VehicleType.Text = VehicleView.Rows[r].Cells[2].Value.ToString();
            txtVehicle.Text = VehicleView.Rows[r].Cells[1].Value.ToString();
        }
        private void VehicleView_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyData == Keys.Enter && VehicleView.Rows.Count > 0)
            {
                VehicleView_Show();
                VehicleView.Visible = false;
                VehicleType.Focus();
            }
            else if (e.KeyData == Keys.Escape)
            {
                VehicleView.Visible = false;
            }
        }

        private void RESET_Click(object sender, EventArgs e)
        {
            VehicleType.Text = "";
            txtVehicle.Tag = null;
            txtVehicle.Text = "";
            txtTransporter.Tag = null;
            txtTransporter.Text = "";
            VehicleView.Visible = false;
            TransporterView.Visible = false;
            txtTransporter.Focus();
        }

        private void SAVE_Click(object sender, EventArgs e)
        {
            if (txtTransporter.Tag == null || txtTransporter.Tag.ToString() == "")
            {
                MessageBox.Show("Please select a transporter");
                txtTransporter.Focus();
                return;

            }
            if (VehicleType.Text.Trim() == "")
            {
                MessageBox.Show("Please select a type");
                VehicleType.Focus();
                return;
            }
            if (txtVehicle.Text.Trim() == "")
            {
                MessageBox.Show("Please enter the vehicle number");
                txtVehicle.Focus();
                return;
            }

            if (VehicleType.Text.Trim() != "20FT" && VehicleType.Text.Trim() != "40FT")
            {
                MessageBox.Show("Please select a proper type");
                VehicleType.Focus();
                return;
            }

            DialogResult dialogResult = MessageBox.Show("Do you want to save the entry?", "Yard Entry", MessageBoxButtons.YesNo);
            if (dialogResult == DialogResult.Yes)
            {

                SqlCommand cmd = new SqlCommand();
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "Add_Contract_Vehicle";


                string truck_number = txtVehicle.Text.Trim().ToString();
                cmd.Parameters.Add("@Vehicle_Number", SqlDbType.VarChar).Value = truck_number;
                cmd.Parameters.Add("@Vehicle_Type", SqlDbType.VarChar).Value = VehicleType.Text;
                if (txtVehicle.Tag == null || txtVehicle.Tag.ToString() == "")
                {
                    cmd.Parameters.Add("@Vehicle_Id", SqlDbType.Int).Value = null;
                }
                else
                {
                    cmd.Parameters.Add("@Vehicle_Id", SqlDbType.Int).Value = txtVehicle.Tag.ToString();
                }
                cmd.Parameters.Add("@Owner_Id", SqlDbType.Int).Value = txtTransporter.Tag.ToString();
                cmd.Parameters.Add("@Yard_Id", SqlDbType.Int).Value = Connections.Instance.Yard_Id;
                cmd.Parameters.Add("@User_Id", SqlDbType.Int).Value = Connections.Instance.user_id;

                cmd.Parameters.Add("@message", SqlDbType.VarChar, 200);
                cmd.Parameters["@message"].Direction = ParameterDirection.Output;
                cmd.Parameters.Add("@message_code", SqlDbType.Int);
                cmd.Parameters["@message_code"].Direction = ParameterDirection.Output;

                Connections.Instance.OpenConection();
                Connections.Instance.ExecuteProcedure(cmd);

                if (Convert.ToUInt16(cmd.Parameters["@message_Code"].Value) != 100)
                {
                    MessageBox.Show((string)cmd.Parameters["@message"].Value);
                }
                else
                {
                    RESET_Click(null, null);
                }
                Connections.Instance.CloseConnection();
                cmd.Dispose();
            }
        }

    }
}
