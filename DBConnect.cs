using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace Employee_Project
{
    public class DBConnect
    {
        public MySqlConnection connection;
        private string server;
        private string database;
        private string uid;
        private string password;
        //Constructor
        public DBConnect()
        {
            Initialize();
        }

        #region Initialize values and connecting to server
        private void Initialize()
        {// The database, uid and password can be replaced to ur options, just make sure u have already created the database and and tables before.
            server = "localhost";
            database = "project_db";
            uid = "root";
            password = "243913634";
            string connectionString;
            connectionString = "SERVER=" + server + ";" + "DATABASE=" +
            database + ";" + "UID=" + uid + ";" + "PASSWORD=" + password + ";";
            connection = new MySqlConnection(connectionString); 
        }
        #endregion

        #region Checks if the connection succeed
        public bool IsConnectedSuccessfully(string username, string password)
        {
            bool result = false;
            try
            {
                string sql = "SELECT * FROM userdata WHERE Username=@user AND Password=@password";
                MySqlCommand cmd = new MySqlCommand(sql, connection);
                cmd.Parameters.AddWithValue("@user", username);
                cmd.Parameters.AddWithValue("@password", password);
                MySqlDataReader reader = cmd.ExecuteReader();
                if (reader.HasRows)
                {
                    MessageBox.Show("Login executed successfully - Wellcome\n");
                    result = true;
                }
                else
                    throw new Exception("Details are invalid or do not exist - Please Try again");
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
                result = false;
            }
            return result;
        }
        #endregion
    }
}