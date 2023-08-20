using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;
using System.Data;
using System.Configuration;

namespace FleetStalk_Yard
{
    public sealed class Connections
    {
        private static Connections instance = null;
        string ConnectionString = @"Data Source=" + System.Configuration.ConfigurationSettings.AppSettings["Server"] + ";Initial Catalog=FleetStalk_Yard;Integrated Security=True;";
        string App_Type = System.Configuration.ConfigurationSettings.AppSettings["App_Type"];

        //string ConnectionString = @"Data Source=tcp:192.168.100.12;Initial Catalog=Inventory_GST;User ID=sa;Password=INS";

        //string ConnectionString = @"Data Source=USER-PC;Initial Catalog=Inventory;Integrated Security=True;";
        public SqlConnection con;
        public string user_type;
        public string user_id;
        public string user_name;
        public string Yard_Id = System.Configuration.ConfigurationSettings.AppSettings["Yard"];
        public static Connections Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new Connections();
                }
                return instance;
            }
        }
        public void OpenConection()
        {
            if (App_Type == "Client")
            {
                ConnectionString = @"Data Source=" + System.Configuration.ConfigurationSettings.AppSettings["Server"] + ";Initial Catalog=Inventory_GST;User ID=sa;Password=" + System.Configuration.ConfigurationSettings.AppSettings["psd"];
            }
            con = new SqlConnection(ConnectionString);
            con.Open();
        }


        public void CloseConnection()
        {
            con.Close();
        }

        public void ExecuteProcedure(SqlCommand SqlCmd)
        {

            SqlCmd.Connection = con;
            SqlCmd.ExecuteNonQuery();
        }


        public void ExecuteQueries(string Query_)
        {
            SqlCommand cmd = new SqlCommand(Query_, con);
            cmd.ExecuteNonQuery();
        }

        public Int32 ExuecuteQueryWithReturn(string Query_)
        {
            using (SqlCommand cmd = new SqlCommand(Query_, con))
            {
                int modified = (int)cmd.ExecuteScalar();
                return modified;
            }

        }

        public SqlDataReader DataReader(string Query_)
        {
            SqlCommand cmd = new SqlCommand(Query_, con);
            SqlDataReader dr = cmd.ExecuteReader();
            return dr;
        }
      
        public object ShowDataInGridView(string Query_)
        {
            SqlDataAdapter dr = new SqlDataAdapter(Query_, ConnectionString);
            System.Data.DataSet ds = new System.Data.DataSet();
            dr.Fill(ds);
            object dataum = ds.Tables[0];
            return dataum;
        }
    }
}
