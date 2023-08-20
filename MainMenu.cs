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
    public partial class MainMenu : Form
    {
        public string DisplayName;
        public string User_Id;

        public MainMenu()
        {
            InitializeComponent();
            this.FormClosing += Menu_Closing;
        }

        private void Menu_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            // Determine if text has changed in the textbox by comparing to original text.
            try
            {
                if (Logout() == 0)
                {
                    e.Cancel = true;
                }
            }
            catch (Exception ex)
            { }

        }
        private int Logout()
        { 
            SqlCommand cmd = new SqlCommand();
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = "SP_Logout";

            cmd.Parameters.Add("@User_Id", SqlDbType.Int).Value = User_Id;

            cmd.Parameters.Add("@message", SqlDbType.VarChar, 200);
            cmd.Parameters["@message"].Direction = ParameterDirection.Output;
            cmd.Parameters.Add("@message_code", SqlDbType.Int);
            cmd.Parameters["@message_code"].Direction = ParameterDirection.Output;

            Connections.Instance.OpenConection();
            Connections.Instance.ExecuteProcedure(cmd);

            if (Convert.ToUInt16(cmd.Parameters["@message_Code"].Value) != 100)
            {
                return 0;
            }

            Connections.Instance.CloseConnection();
            cmd.Dispose();
            return 1;
        }

        private void MainMenu_Load(object sender, EventArgs e)
        {
            Login frm = new Login();
            frm.mnu = this;
            frm.ShowDialog();
        }
        public void EnableButton()
        {
            lblUser.Text = DisplayName;
            btnLogout.Enabled = true;

            if (Connections.Instance.user_type == "TollOperator")
            {
                btnTollEntry.Enabled = true;
                btnTollReport.Enabled = false;
                AddContractVehicles.Enabled = false;
                btnYardEntry.Enabled = false;
                EntryDetails.Enabled = false;
                EntryDetailsTransporter.Enabled = false;
                btnRemoveContractVehicle.Enabled = false;
            }
            else if (Connections.Instance.user_type == "TollAdmin")
            {
                btnTollEntry.Enabled = true;
                btnTollReport.Enabled = true;
                AddContractVehicles.Enabled = false;
                btnYardEntry.Enabled = false;
                EntryDetails.Enabled = false;
                EntryDetailsTransporter.Enabled = false;
                btnRemoveContractVehicle.Enabled = false;
            }
            else
            {
                btnTollEntry.Enabled = false;
                btnTollReport.Enabled = false;
                AddContractVehicles.Enabled = true;
                btnYardEntry.Enabled = true;
                EntryDetails.Enabled = true;
                EntryDetailsTransporter.Enabled = true;
                btnRemoveContractVehicle.Enabled = true;
            }
            

        }
        private void timer1_Tick(object sender, EventArgs e)
        {
            TimeLabel.Text = DateTime.Now.ToString();
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            
            Menu frm = new Menu();
            frm.DisplayName = DisplayName;
            frm.User_Id = User_Id;
            frm.MdiParent=this;
            frm.Show();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (Logout() == 1)
            {
                btnYardEntry.Enabled = false;
                btnLogout.Enabled = false;
                lblUser.Text = "";
                Login frm = new Login();
                frm.mnu = this;
                frm.ShowDialog();
            }
            
        }

        private void EntryDetails_Click(object sender, EventArgs e)
        {

            EntryDetails frm = new EntryDetails();
            frm.MdiParent = this;
            frm.Show();
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            if (Connections.Instance.user_type == "Administrator")
            {
                AddContract frm = new AddContract();
                frm.ShowDialog();
            }
        }

        private void AddContractVehicles_Click(object sender, EventArgs e)
        {
            if (Connections.Instance.user_type == "Administrator")
            {
                AddContractVehicles frm = new AddContractVehicles();
                frm.ShowDialog();
            }
        }

        private void btnRemoveContractVehicle_Click(object sender, EventArgs e)
        {
            if (Connections.Instance.user_type == "Administrator")
            {
                RemoveContractVehicles frm = new RemoveContractVehicles();
                frm.ShowDialog();
            }
        }

        private void timer2_Tick(object sender, EventArgs e)
        {
            if (System.Configuration.ConfigurationSettings.AppSettings["External_Bill"].ToString() == "1")
            {
                SqlCommand cmd = new SqlCommand();
                //cmd.CommandType = CommandType.StoredProcedure;
                //cmd.CommandText = "SP_Pre_Billing";
                //Connections.Instance.OpenConection();
                //Connections.Instance.ExecuteProcedure(cmd);
                cmd.Dispose();
            }
        }

        private void btnTollEntry_Click(object sender, EventArgs e)
        {
            TollEntry frm = new TollEntry();
            frm.DisplayName = DisplayName;
            frm.User_Id = User_Id;
            frm.MdiParent = this;
            frm.Show();
        }

        private void btnTollReport_Click(object sender, EventArgs e)
        {
            TollEntryDetails frm = new TollEntryDetails();
            frm.DisplayName = DisplayName;
            frm.User_Id = User_Id;
            frm.MdiParent = this;
            frm.Show();
        }

        private void lblUser_Click(object sender, EventArgs e)
        {

        }

        private void TimeLabel_Click(object sender, EventArgs e)
        {

        }
    }
}
