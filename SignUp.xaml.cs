using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace Employee_Project
{
    /// <summary>
    /// Interaction logic for SignUp.xaml
    /// </summary>
    public partial class SignUp : Window
    {
        //Login Window
        private MainWindow mw;
        //Flag to determine if user can be signed up
        private bool flag = false;
        //Constructor
        public SignUp(MainWindow w)
        {
            InitializeComponent();
            mw = w;
        }
        /// <summary>
        /// Sign Up a new Username
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void SignUpbtn_Click(object sender, RoutedEventArgs e)
        {
            DBConnect conn = new DBConnect();
            #region Make sure Username is not taken
            try
            {
                conn.connection.Open();
                if (NewUsertxt.Text==""||NewPasswordtxt.Password=="")
                {
                    MessageBox.Show("Details are missing - Please fill all fields");
                    return;
                }
                string sql = "SELECT * FROM userdata WHERE Username=@user;";
                MySqlCommand cmd = new MySqlCommand(sql, conn.connection);
                cmd.Parameters.AddWithValue("@user", NewUsertxt.Text);
                MySqlDataReader reader = cmd.ExecuteReader();
                if (reader.HasRows)
                    throw new Exception("Username is already taken - Please insert another username instead");
                flag = true;
            }
            #endregion
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                #region Sign Up new Username
                if (flag)
                {
                    try
                    {
                        conn.connection.Close();
                        conn.connection.Open();
                        MySqlCommand cmd = new MySqlCommand("insert into userdata (UserName,Password) values (@Username,@Password)", conn.connection);
                        cmd.Parameters.AddWithValue("@Username", NewUsertxt.Text);
                        cmd.Parameters.AddWithValue("@Password", NewPasswordtxt.Password);
                        MySqlDataReader MyReader = cmd.ExecuteReader();
                        while (MyReader.Read())
                        {
                        }
                        MessageBox.Show("Username "+NewUsertxt.Text+" Was Added Successfully");
                        NewUsertxt.Text = "";
                        NewPasswordtxt.Password = "";
                    }
                    #endregion
                    catch (MySqlException ex)
                    {
                        MessageBox.Show(ex.Message);
                    }
                }
                conn.connection.Close();
            }
        }
        /// <summary>
        /// Back to Login Window
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BackToLogin_Click(object sender, RoutedEventArgs e)
        {
            mw.Show();
            this.Close();
        }
    }
}
