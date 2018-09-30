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
using System.Windows.Navigation;
using System.Windows.Shapes;
//Location of database files=> C:\ProgramData\MySQL\MySQL Server 5.7
namespace Employee_Project
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            //Window2 main = new Window2(this);
            //main.Show();
            InitializeComponent();
        } 
        public void Submitbtn_Click(object sender, RoutedEventArgs e)
        {
            //Connect to the database and check if the login was executed successfully
            DBConnect db = new DBConnect();
            db.connection.Open();
            if (db.IsConnectedSuccessfully(Usertxt.Text, Passwordtxt.Password))
            {
                db.connection.Close();
                Window2 main = new Window2(this);
                main.Show();
                this.Hide();
            }
            else
                return;
            Usertxt.Text = "";
            Passwordtxt.Password = "";
        }
        private void Signupbtn_Click(object sender, RoutedEventArgs e)
        {
            SignUp su = new SignUp(this);
            su.Show();
            this.Hide();
        }
    }
}
