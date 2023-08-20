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
    public partial class Login : Form
    {
        public MainMenu mnu;
        bool islogin;
        public Login()
        {
            InitializeComponent();
            islogin = false;
            this.FormClosing += Form_Closing;
        }

        private void Form_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            if (islogin == false)
            {
                Application.Exit();
            }
        }
        private void txtUsername_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
                txtPassword.Focus();
        }
        private void txtPassword_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
                btnLogin_Click(null, null);
        }
        private void btnLogin_Click(object sender, EventArgs e)
        {

            if (txtUserName.Text.Trim() == "")
            {
                MessageBox.Show("Please enter the user name");
                txtUserName.Focus();
                return;
            }
            if (txtPassword.Text.Trim() == "")
            {
                MessageBox.Show("Please enter the password");
                txtPassword.Focus();
                return;
            }

          
                SqlCommand cmd = new SqlCommand();
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "SP_User_Login";

            
                string Yard_Id = System.Configuration.ConfigurationSettings.AppSettings["Yard"];
                cmd.Parameters.Add("@Yard_Id", SqlDbType.Int).Value = Yard_Id;
                cmd.Parameters.Add("@UserName", SqlDbType.VarChar).Value = txtUserName.Text.Trim().ToString();
                cmd.Parameters.Add("@password", SqlDbType.VarChar).Value = txtPassword.Text.Trim().ToString();
               
                cmd.Parameters.Add("@message", SqlDbType.VarChar, 200);
                cmd.Parameters["@message"].Direction = ParameterDirection.Output;
                cmd.Parameters.Add("@message_code", SqlDbType.Int);
                cmd.Parameters["@message_code"].Direction = ParameterDirection.Output;

                cmd.Parameters.Add("@User_Id", SqlDbType.Int);
                cmd.Parameters["@User_Id"].Direction = ParameterDirection.Output;

                cmd.Parameters.Add("@User_Display_Name", SqlDbType.VarChar,30);
                cmd.Parameters["@User_Display_Name"].Direction = ParameterDirection.Output;

                cmd.Parameters.Add("@User_Type", SqlDbType.VarChar, 30);
                cmd.Parameters["@User_Type"].Direction = ParameterDirection.Output;

                Connections.Instance.OpenConection();
                Connections.Instance.ExecuteProcedure(cmd);
                if (Convert.ToUInt16(cmd.Parameters["@message_Code"].Value) == 100)
                {
                    mnu.User_Id = cmd.Parameters["@User_Id"].Value.ToString();
                    Connections.Instance.user_id = mnu.User_Id;
                    mnu.DisplayName = cmd.Parameters["@User_Display_Name"].Value.ToString();
                    Connections.Instance.user_name = mnu.DisplayName;
                    Connections.Instance.user_type = cmd.Parameters["@User_Type"].Value.ToString();
                    mnu.EnableButton();
                    Connections.Instance.CloseConnection();
                    cmd.Dispose();
                    islogin = true;
                    this.Close();
                }
                else
                {
                    MessageBox.Show((string)cmd.Parameters["@message"].Value);
                    Connections.Instance.CloseConnection();
                    cmd.Dispose();
                }

                
                
            
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void txtUserName_TextChanged(object sender, EventArgs e)
        {

        }

        private void Login_Load(object sender, EventArgs e)
        {

        }
    }
}
