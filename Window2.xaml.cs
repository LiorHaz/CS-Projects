using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
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
using System.Windows.Threading;

namespace Employee_Project
{
    /// <summary>
    /// Interaction logic for Window2.xaml
    /// </summary>
    public partial class Window2 : Window
    {
        //login window
        private MainWindow mw;
        //flags for update and search 
        private bool flag1 = false, flag2 = false, flag3 = false, flag4 = false;
        //string to make sure id is unchangable
        private string tmpid;
        //constructor
        public Window2(MainWindow window)
        {
            InitializeComponent();
            //ComboBox Options
            DataContext = new ComboBoxOptions();
            //Login window
            mw = window;
            //Start running the clock
            StartClock();
        }
        #region Current Date and Time
        /// <summary>
        /// Display cuurent date and time
        /// </summary>
        public void StartClock()
        {
            DispatcherTimer timer = new DispatcherTimer();
            timer.Interval = TimeSpan.FromSeconds(1);
            timer.Tick += tickevent;
            timer.Start(); 
        }
        private void tickevent(object sender, EventArgs e)
        {
            dtime.Text =DateTime.Now.ToString();   
        }
        #endregion
        #region Checkboxes
        //Client CheckBox
        private void ClientMale_Click(object sender, RoutedEventArgs e)
        {
            if (ClientMale.IsChecked == true)
            {
                ClientMale.IsChecked = true;
                ClientFemale.IsChecked = false;
            }

        }
        private void ClientFemale_Click(object sender, RoutedEventArgs e)
        {
            if (ClientFemale.IsChecked == true)
            {
                ClientMale.IsChecked = false;
                ClientFemale.IsChecked = true;
            }

        }
        //Worker CheckBox
        private void WorkerMale_Click(object sender, RoutedEventArgs e)
        {

            if (WorkerMale.IsChecked == true)
            {
                WorkerMale.IsChecked = true;
                WorkerFemale.IsChecked = false;
            }
        }
        private void WorkerFemale_Click(object sender, RoutedEventArgs e)
        {

            if (WorkerFemale.IsChecked == true)
            {
                WorkerMale.IsChecked = false;
                WorkerFemale.IsChecked = true;
            }

        }

        #endregion
        #region Add Worker/Client/Spa/Transaction
        /// <summary>
        /// Add records to the database
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void AddBtn_Click(object sender, RoutedEventArgs e)
        {
            //Add Employee
            if (TabCtl.SelectedIndex == 0)
            {
                #region Checks if All Fields are Filled
                foreach (var txt in EGrid.Children)
                    if (txt is TextBox)
                    {
                        TextBox t = (TextBox)txt;
                        if (t.Text == "")
                        {
                            MessageBox.Show("Details are missing - Please fill all the fields");
                            return;
                        }
                    }
                if (WorkerSpeciality.Text == "")
                {
                    MessageBox.Show("Details are missing - Please fill all the fields");
                    return;
                }
                else if (WorkerMale.IsChecked == false && WorkerFemale.IsChecked == false)
                {
                    MessageBox.Show("Details are missing - Please fill all the empty fields");
                    return;
                }
                #endregion
                #region Checks ID isn't exist,Spa ID exist and Age,salary,and seniority are realistic
                if (Convert.ToInt32(WorkerAge.Text) < 18 || Convert.ToInt32(WorkerAge.Text) > 67)
                {
                    MessageBox.Show("Age is not realistic - Please Insert another age");
                    return;
                }
                if (Convert.ToInt32(WorkerSalary.Text) < 2000 || Convert.ToInt32(WorkerSalary.Text) > 50000)
                {
                    MessageBox.Show("Salary is not realistic - Please Insert Salary Again");
                    return;
                }
                if (Convert.ToInt32(WorkerSeniority.Text) < 0 || Convert.ToInt32(WorkerSeniority.Text) > 50)
                {
                    MessageBox.Show("Seniority is not realistic - Please Insert Seniority Again");
                    return;
                }
                //check ID
                DBConnect conn = new DBConnect();
                conn.connection.Open();
                try
                {
                    string query = "SELECT * FROM workers WHERE ID=@Id";
                    MySqlCommand cmd = new MySqlCommand(query, conn.connection);
                    cmd.Parameters.AddWithValue("@Id", WorkerId.Text);
                    MySqlDataReader reader = cmd.ExecuteReader();
                    if (reader.HasRows)
                        throw new Exception($"ID {WorkerId.Text} is already exist - Please Choose another ID number");
                }
                catch (Exception t)
                {
                    MessageBox.Show(t.Message);
                    return;
                }
                conn.connection.Close();
                //Check Spa ID
                conn.connection.Open();
                try
                {
                    string query = "SELECT * FROM workers WHERE Spa=@SpaId";
                    MySqlCommand cmd = new MySqlCommand(query, conn.connection);
                    cmd.Parameters.AddWithValue("@SpaId", WorkerSpaID.Text);
                    MySqlDataReader reader = cmd.ExecuteReader();
                    if (reader.HasRows == false)
                        throw new Exception($"Spa ID {WorkerSpaID.Text} does not exist - Please Choose an existing Spa ID number");
                }
                catch (Exception t)
                {
                    MessageBox.Show(t.Message);
                    return;
                }
                conn.connection.Close();
                #endregion
                #region Add to the DataBase
                conn.connection.Open();
                string s;
                if (WorkerMale.IsChecked == true)
                    s = "Male";
                else
                    s = "Female";
                try
                {
                    string query2 = "INSERT INTO workers (ID, FirstName, LastName, Sex, City, Specialty, Seniority, Salary, Spa, Age) VALUES (@Id,@FirstName,@LastName,@sex,@city,@Speciality,@Seniority,@Salary,@SpaID,@Age)";
                    MySqlCommand cmd2 = new MySqlCommand(query2, conn.connection);
                    cmd2.Parameters.AddWithValue("@Id", WorkerId.Text);
                    cmd2.Parameters.AddWithValue("@FirstName", WorkerFirstName.Text);
                    cmd2.Parameters.AddWithValue("@LastName", WorkerLastName.Text);
                    cmd2.Parameters.AddWithValue("@sex", s);
                    cmd2.Parameters.AddWithValue("@city", WorkerCity.Text);
                    cmd2.Parameters.AddWithValue("@Speciality", WorkerSpeciality.Text);
                    cmd2.Parameters.AddWithValue("@Seniority", WorkerSeniority.Text);
                    cmd2.Parameters.AddWithValue("@Salary", WorkerSalary.Text);
                    cmd2.Parameters.AddWithValue("@SpaID", WorkerSpaID.Text);
                    cmd2.Parameters.AddWithValue("@Age", WorkerAge.Text);
                    if (MessageBox.Show("Are you sure you want to add worker ID "+WorkerId.Text+"?", "Add", MessageBoxButton.YesNo, MessageBoxImage.Warning) == MessageBoxResult.No)
                    {
                        return;
                    }
                    int a = cmd2.ExecuteNonQuery();
                    if (a == 1)
                        MessageBox.Show("Worker Was Added Successfully");

                    conn.connection.Close();
                }
                catch (Exception t)
                {
                    MessageBox.Show(t.Message);
                }
                finally
                {
                    Load_Client_table_Click(sender, e);
                }
                #endregion
            }
            //Add Client
            else if (TabCtl.SelectedIndex == 1)
            {

                #region Checks if All Fields are Filled
                foreach (var txt in CGrid.Children)
                    if (txt is TextBox)
                    {
                        TextBox t = (TextBox)txt;
                        if (t.Text == "")
                        {
                            MessageBox.Show("Details are missing - Please fill all the fields");
                            return;
                        }
                    }
                if (ClientMale.IsChecked == false && ClientFemale.IsChecked == false)
                {
                    MessageBox.Show("Details are missing - Please fill all the empty fields");
                    return;
                }
                #endregion
                #region Checks ID isn't exist and if Age is realistic
                if (Convert.ToInt32(ClientAge.Text) < 18 || Convert.ToInt32(ClientAge.Text) > 67)
                {
                    MessageBox.Show("Age is not realistic - Please Insert another age");
                    return;
                }
                //check ID
                DBConnect conn = new DBConnect();
                conn.connection.Open();
                try
                {
                    string query = "SELECT * FROM clients WHERE ClientID=@Id";
                    MySqlCommand cmd = new MySqlCommand(query, conn.connection);
                    cmd.Parameters.AddWithValue("@Id", ClientId.Text);
                    MySqlDataReader reader = cmd.ExecuteReader();
                    if (reader.HasRows)
                        throw new Exception($"ID {ClientId.Text} is already exist - Please Choose another ID number");
                }
                catch (Exception t)
                {
                    MessageBox.Show(t.Message);
                    return;
                }
                conn.connection.Close();
                #endregion
                #region Add to the DataBase
                conn.connection.Open();
                string s;
                if (ClientMale.IsChecked == true)
                    s = "Male";
                else
                    s = "Female";
                try
                {
                    string query2 = "INSERT INTO clients (ClientID, FirstName, LastName, Sex, City, Age) VALUES (@Id,@FirstName,@LastName,@sex,@city,@Age)";
                    MySqlCommand cmd2 = new MySqlCommand(query2, conn.connection);
                    cmd2.Parameters.AddWithValue("@Id", ClientId.Text);
                    cmd2.Parameters.AddWithValue("@FirstName", ClientFirstName.Text);
                    cmd2.Parameters.AddWithValue("@LastName", ClientLastName.Text);
                    cmd2.Parameters.AddWithValue("@sex", s);
                    cmd2.Parameters.AddWithValue("@city", ClientCity.Text);
                    cmd2.Parameters.AddWithValue("@Age", ClientAge.Text);
                    if (MessageBox.Show("Are you sure you want to add client ID "+ClientId.Text+"?", "Add", MessageBoxButton.YesNo, MessageBoxImage.Warning) == MessageBoxResult.No)
                    {
                        return;
                    }
                    int a = cmd2.ExecuteNonQuery();
                    if (a == 1)
                        MessageBox.Show("Client Was Added Successfully");
                    conn.connection.Close();
                }
                catch (Exception t)
                {
                    MessageBox.Show(t.Message);
                }
                finally
                {
                    Load_Client_table_Click(sender, e);
                }
                #endregion
            }
            //Add Spa
            else if (TabCtl.SelectedIndex == 2)
            {

                #region Checks if All Fields are Filled
                foreach (var txt in SGrid.Children)
                    if (txt is TextBox)
                    {
                        TextBox t = (TextBox)txt;
                        if (t.Text == "")
                        {
                            MessageBox.Show("Details are missing - Please fill all the fields");
                            return;
                        }
                    }
                if (SpaRegion.Text == "" || SpaRate.Text == "")
                {
                    MessageBox.Show("Details are missing - Please fill all the fields");
                    return;
                }
                #endregion
                #region Checks Spa ID isn't exist
                //check ID
                DBConnect conn = new DBConnect();
                conn.connection.Open();
                try
                {
                    string query = "SELECT * FROM spa WHERE SpaID=@Id";
                    MySqlCommand cmd = new MySqlCommand(query, conn.connection);
                    cmd.Parameters.AddWithValue("@Id", SpaId.Text);
                    MySqlDataReader reader = cmd.ExecuteReader();
                    if (reader.HasRows)
                        throw new Exception($"ID {SpaId.Text} is already exist - Please Choose another ID number");
                }
                catch (Exception t)
                {
                    MessageBox.Show(t.Message);
                    return;
                }
                conn.connection.Close();
                #endregion
                #region Add to the DataBase
                conn.connection.Open();
                try
                {
                    string query2 = "INSERT INTO spa (SpaID, SpaName, Region, City, PhoneNumber, Rating) VALUES (@Id,@Name,@Region,@City,@PhoneNumber,@Rate)";
                    MySqlCommand cmd2 = new MySqlCommand(query2, conn.connection);
                    cmd2.Parameters.AddWithValue("@Id", SpaId.Text);
                    cmd2.Parameters.AddWithValue("@Name", SpaName.Text);
                    cmd2.Parameters.AddWithValue("@Region", SpaRegion.Text);
                    cmd2.Parameters.AddWithValue("@City", SpaCity.Text);
                    cmd2.Parameters.AddWithValue("@PhoneNumber", PhoneNumber.Text);
                    cmd2.Parameters.AddWithValue("@Rate", SpaRate.Text);
                    if (MessageBox.Show("Are you sure you want to add spa ID "+SpaId.Text+"?", "Add", MessageBoxButton.YesNo, MessageBoxImage.Warning) == MessageBoxResult.No)
                    {
                        return;
                    }
                    int a = cmd2.ExecuteNonQuery();
                    if (a == 1)
                        MessageBox.Show("Spa Was Added Successfully");
                    conn.connection.Close();
                }
                catch (Exception t)
                {
                    MessageBox.Show(t.Message);
                }
                finally
                {
                    Load_Spa_table_Click(sender, e);
                }
                #endregion
            }
            //Add Transaction
            else if (TabCtl.SelectedIndex == 3)
            {
                #region Checks if All Fields are Filled
                foreach (var txt in TGrid.Children)
                    if (txt is TextBox)
                    {
                        TextBox t = (TextBox)txt;
                        if (t.Text == "")
                        {
                            MessageBox.Show("Details are missing - Please fill all the fields");
                            return;
                        }
                    }
                if (TherapyType.Text == "" || Date.Text == "" || Payment.Text == "")
                {
                    MessageBox.Show("Details are missing - Please fill all the fields");
                    return;
                }
                #endregion
                #region Checks Transaction ID isn't exist,Spa ID,Client ID and Worker ID exist and Time, Date and Price are realistic
                if (Convert.ToInt32(TherapyTime.Text) < 30 || Convert.ToInt32(TherapyTime.Text) > 180)
                {//Time check
                    MessageBox.Show("Therapy Time is not realistic - Please Insert another time");
                    return;
                }
                if (Convert.ToInt32(TherapyPrice.Text) < 100 || Convert.ToInt32(TherapyPrice.Text) > 900)
                {//Price Check
                    MessageBox.Show("Price is not realistic - Please Insert another Price");
                    return;
                }
                //check Transaction ID
                DBConnect conn = new DBConnect();
                conn.connection.Open();
                try
                {
                    string query = "SELECT * FROM therapy  WHERE TransactionID=@Id";
                    MySqlCommand cmd = new MySqlCommand(query, conn.connection);
                    cmd.Parameters.AddWithValue("@Id", TransactionId.Text);
                    MySqlDataReader reader = cmd.ExecuteReader();
                    if (reader.HasRows)
                        throw new Exception($"ID {TransactionId.Text} is already exist - Please Choose another Transaction ID number");
                }
                catch (Exception t)
                {
                    MessageBox.Show(t.Message);
                    return;
                }
                conn.connection.Close();
                //Check Client ID
                conn.connection.Open();
                try
                {
                    string query = "SELECT * FROM clients WHERE ClientID=@ClientId";
                    MySqlCommand cmd = new MySqlCommand(query, conn.connection);
                    cmd.Parameters.AddWithValue("@ClientId", ClientID.Text);
                    MySqlDataReader reader = cmd.ExecuteReader();
                    if (reader.HasRows == false)
                        throw new Exception($"Client ID {ClientID.Text} does not exist - Please Choose an existing Client ID number");
                }
                catch (Exception t)
                {
                    MessageBox.Show(t.Message);
                    return;
                }
                conn.connection.Close();
                //Check Spa ID
                conn.connection.Open();
                try
                {
                    string query = "SELECT * FROM spa WHERE SpaID=@SpaId";
                    MySqlCommand cmd = new MySqlCommand(query, conn.connection);
                    cmd.Parameters.AddWithValue("@SpaId", SpaID.Text);
                    MySqlDataReader reader = cmd.ExecuteReader();
                    if (reader.HasRows == false)
                        throw new Exception($"Spa ID {SpaID.Text} does not exist - Please Choose an existing Spa ID number");
                }
                catch (Exception t)
                {
                    MessageBox.Show(t.Message);
                    return;
                }
                conn.connection.Close();
                //Check Worker ID
                conn.connection.Open();
                try
                {
                    string query = "SELECT * FROM workers WHERE ID=@WorkerId";
                    MySqlCommand cmd = new MySqlCommand(query, conn.connection);
                    cmd.Parameters.AddWithValue("@WorkerId", WorkerID.Text);
                    MySqlDataReader reader = cmd.ExecuteReader();
                    if (reader.HasRows == false)
                        throw new Exception($"Worker ID {WorkerID.Text} does not exist - Please Choose an existing Worker ID number");
                }
                catch (Exception t)
                {
                    MessageBox.Show(t.Message);
                    return;
                }
                conn.connection.Close();
                #endregion
                #region Add to the DataBase
                conn.connection.Open();
                try
                {
                    string query2 = "INSERT INTO project_db.therapy (TransactionID, ClientID, WorkerID, SpaID, TherapyType, TherapyTime, TherapyDate, Price, Payment) VALUES ('" + TransactionId.Text + "','" + ClientID.Text + "','" + WorkerID.Text + "','" + SpaID.Text + "','" + TherapyType.Text + "','" + TherapyTime.Text + "','" + Date.Text + "','" + TherapyPrice.Text + "','" + Payment.Text + "')";
                    MySqlCommand cmd2 = new MySqlCommand(query2, conn.connection);
                    MySqlDataReader MyReader2;
                    if (MessageBox.Show("Are you sure you want to add transaction ID "+TransactionId.Text+"?", "Add", MessageBoxButton.YesNo, MessageBoxImage.Warning) == MessageBoxResult.No)
                    {
                        return;
                    }
                    MyReader2 = cmd2.ExecuteReader();
                    while (MyReader2.Read())
                    {
                    }
                    MessageBox.Show("Transaction Was Added Successfully");
                    conn.connection.Close();
                }
                catch (Exception t)
                {
                    MessageBox.Show(t.Message);
                }
                finally
                {
                    Load_Transaction_table_Click(sender, e);
                }
                #endregion
            }
        }
        #endregion
        #region Update Details
        /// <summary>
        /// Update records in the database
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void UpdateBtn_Click(object sender, RoutedEventArgs e)
        {      
            DBConnect conn = new DBConnect();
            #region Worker
            if (TabCtl.SelectedIndex == 0)
            {   //checks if id is inserted
                if (WorkerId.Text == "")
                {
                    MessageBox.Show("Pleae insert worker ID and then click 'Update' again");
                    return;
                }
                #region checks if ID is valid
                conn.connection.Open();
                try
                {
                    string query = "SELECT * FROM workers WHERE ID=@Id";
                    MySqlCommand cmd = new MySqlCommand(query, conn.connection);
                    cmd.Parameters.AddWithValue("@Id", WorkerId.Text);
                    MySqlDataReader reader = cmd.ExecuteReader();
                    if (reader.HasRows == false)
                    { MessageBox.Show($"ID {WorkerId.Text} is not exist - Please Choose another ID number"); return; }
                }
                catch (MySqlException ex)
                {
                    MessageBox.Show(ex.Message);
                }
                finally
                {
                    conn.connection.Close();
                }
                #endregion
                try
                {
                    
                    #region Bringing records to update from database by ID
                    if (!flag1)
                    {
                        conn.connection.Open();
                        string query = "select * from project_db.workers where ID=@WorkerID";
                        
                        MySqlCommand cmd = new MySqlCommand(query, conn.connection);
                        cmd.Parameters.AddWithValue("@WorkerID", WorkerId.Text);
                        MySqlDataReader reader = cmd.ExecuteReader();
                        if (reader.Read())
                        {
                            tmpid=WorkerId.Text = reader["ID"].ToString();
                            WorkerFirstName.Text = reader["FirstName"].ToString();
                            WorkerLastName.Text = reader["LastName"].ToString();
                            if (reader["Sex"].ToString() == "Male")
                                WorkerMale.IsChecked = true;
                            else
                                WorkerFemale.IsChecked = true;
                            WorkerCity.Text = reader["City"].ToString();
                            WorkerSpeciality.Text = reader["Specialty"].ToString();
                            WorkerSeniority.Text = reader["Seniority"].ToString();
                            WorkerSalary.Text = reader["Salary"].ToString();
                            WorkerSpaID.Text = reader["Spa"].ToString();
                            WorkerAge.Text = reader["Age"].ToString();
                            flag1 = true;
                            MessageBox.Show("Change the demanded details and then click 'Update' again");
                        }
                    }
                    #endregion
                    #region Check data and update
                    else
                    {
                        conn.connection.Open();
                        #region check if data are valid 
                        //check age
                        if (Convert.ToInt32(WorkerAge.Text) < 18 || Convert.ToInt32(WorkerAge.Text) > 67)
                        {
                            MessageBox.Show("Age is not realistic - Please Insert another age");
                            return;
                        }
                        //check salary
                        if (Convert.ToInt32(WorkerSalary.Text) < 2000 || Convert.ToInt32(WorkerSalary.Text) > 50000)
                        {
                            MessageBox.Show("Salary is not realistic - Please Insert Salary Again");
                            return;
                        }
                        //check seniority 
                        if (Convert.ToInt32(WorkerSeniority.Text) < 0 || Convert.ToInt32(WorkerSeniority.Text) > 50)
                        {
                            MessageBox.Show("Seniority is not realistic - Please Insert Seniority Again");
                            return;
                        }
                        #region check if spa id is ok
                        try
                        {
                            string query1 = "SELECT * FROM workers WHERE Spa=@SpaId";
                            MySqlCommand cmd1 = new MySqlCommand(query1, conn.connection);
                            cmd1.Parameters.AddWithValue("@SpaId", WorkerSpaID.Text);
                            MySqlDataReader reader = cmd1.ExecuteReader();
                            if (reader.HasRows == false)
                            { MessageBox.Show($"Spa ID {WorkerSpaID.Text} does not exist - Please Choose an existing Spa ID number"); return; }
                            conn.connection.Close();
                        }
                        catch (MySqlException ex)
                        {
                            MessageBox.Show(ex.Message);
                        }
                        #endregion
                        #endregion
                        #region Update data in database
                        conn.connection.Open();
                        if (WorkerId.Text != tmpid) { MessageBox.Show("ID is not changeable"); WorkerId.Text = tmpid; return; }
                        string query = "update project_db.workers set ID='" + WorkerId.Text + "',FirstName='" + WorkerFirstName.Text + "',LastName='" + WorkerLastName.Text + "',City='" + WorkerCity.Text + "' ,Specialty='" + WorkerSpeciality.Text + "',Seniority='" + WorkerSeniority.Text + "',Salary='" + WorkerSalary.Text + "',Spa='" + WorkerSpaID.Text + "',Age='" + WorkerAge.Text + "' where ID=@WorkerID;";
                        MySqlCommand cmd = new MySqlCommand(query, conn.connection);
                        cmd.Parameters.AddWithValue("@WorkerID", WorkerId.Text);
                        if (MessageBox.Show("Are you sure you want to update?", "Update", MessageBoxButton.YesNo, MessageBoxImage.Warning) == MessageBoxResult.No)
                        {
                            return;
                        }
                        MySqlDataReader MyReader2 = cmd.ExecuteReader();
                        while (MyReader2.Read())
                        {
                        }
                        MessageBox.Show($"Worker ID {WorkerId.Text} was updated successfully");
                        flag1 = false;
                        #endregion
                    }
                    #endregion
                }
                catch (MySqlException ex)
                {
                    MessageBox.Show(ex.Message);
                }
                finally
                {
                    conn.connection.Close();
                    Load_Employee_table_Click(sender, e);
                }

            }
            #endregion
            #region Client
            if (TabCtl.SelectedIndex == 1)
            {
                //checks if id is inserted
                if (ClientId.Text == "")
                {
                    MessageBox.Show("Pleae insert client ID and then click 'Update' again");
                    return;
                }
                #region checks if ID is valid
                conn.connection.Open();
                try
                {
                    string query = "SELECT * FROM clients WHERE ClientID=@Id";
                    MySqlCommand cmd = new MySqlCommand(query, conn.connection);
                    cmd.Parameters.AddWithValue("@Id", ClientId.Text);
                    MySqlDataReader reader = cmd.ExecuteReader();
                    if (reader.HasRows == false)
                    { MessageBox.Show($"ID {ClientId.Text} is not exist - Please Choose another ID number");return; }
                }
                catch (MySqlException ex)
                {
                    MessageBox.Show(ex.Message);
                }
                finally
                {
                    conn.connection.Close();
                }
                #endregion
                try
                {                
                    #region Bringing records to update from database by ID
                    if (!flag2)
                    {
                        conn.connection.Open();
                        string query = "select * from project_db.clients where ClientID=@ID"; 
                        MySqlCommand cmd = new MySqlCommand(query, conn.connection);
                        cmd.Parameters.AddWithValue("@ID", ClientId.Text);
                        tmpid=ClientId.Text;
                        MySqlDataReader reader = cmd.ExecuteReader();
                        if (reader.Read())
                        {
                            tmpid=ClientId.Text = reader["ClientID"].ToString();
                            ClientFirstName.Text = reader["FirstName"].ToString();
                            ClientLastName.Text = reader["LastName"].ToString();
                            if (reader["Sex"].ToString() == "Male")
                                ClientMale.IsChecked = true;
                            else
                                ClientFemale.IsChecked = true;
                            ClientCity.Text = reader["City"].ToString();
                            ClientAge.Text = reader["Age"].ToString();
                            flag2 = true;
                            MessageBox.Show("Change the demanded details and then click 'Update' again");
                            conn.connection.Close();
                        }
                    }
                    #endregion
                    #region Check data and update
                    else
                    {
                        #region check if data are valid 
                        //check age
                        if (Convert.ToInt32(ClientAge.Text) < 18 || Convert.ToInt32(ClientAge.Text) > 67)
                        {
                            MessageBox.Show("Age is not realistic - Please Insert another age");
                            return;
                        }
                        #endregion
                        #region Update data in database
                        conn.connection.Open();                                    
                        string query = "update project_db.clients set ClientID='" + ClientId.Text + "',FirstName='" + ClientFirstName.Text + "',LastName='" + ClientLastName.Text + "',City='" + ClientCity.Text + "',Age='" + ClientAge.Text + "' where ClientID=@ID;";
                        if (ClientId.Text != tmpid) { MessageBox.Show("ID is not changeable"); ClientId.Text = tmpid; return; }
                        MySqlCommand cmd = new MySqlCommand(query, conn.connection);
                        cmd.Parameters.AddWithValue("@ID",ClientId.Text);
                        if (MessageBox.Show("Are you sure you want to update?", "Update", MessageBoxButton.YesNo, MessageBoxImage.Warning) == MessageBoxResult.No)
                        {
                            return;
                        }
                        MySqlDataReader MyReader2 = cmd.ExecuteReader();
                        while (MyReader2.Read())
                        {
                        }
                        MessageBox.Show($"Client ID {ClientId.Text} was updated successfully");
                        flag2 = false;
                        #endregion
                    }
                    #endregion
                }
                catch (MySqlException ex)
                {
                    MessageBox.Show(ex.Message);
                }
                finally
                {
                    conn.connection.Close();
                    Load_Client_table_Click(sender, e);
                }
            }
            #endregion
            #region Spa
            if(TabCtl.SelectedIndex==2)
            {
                //checks if id is inserted
                if (SpaId.Text == "")
                {
                    MessageBox.Show("Pleae insert Spa ID and then click 'Update' again");
                    return;
                }
                #region checks if ID is valid
                conn.connection.Open();
                try
                {
                    string query = "SELECT * FROM spa WHERE SpaID=@Id";
                    MySqlCommand cmd = new MySqlCommand(query, conn.connection);
                    cmd.Parameters.AddWithValue("@Id", SpaId.Text);
                    MySqlDataReader reader = cmd.ExecuteReader();
                    if (reader.HasRows == false)
                    { MessageBox.Show($"ID {SpaId.Text} is not exist - Please Choose another ID number"); return; }
                }
                catch (MySqlException ex)
                {
                    MessageBox.Show(ex.Message);
                }
                finally
                {
                    conn.connection.Close();
                }
                #endregion
                try
                {
                    
                    #region Bringing records to update from database by ID
                    if (!flag3)
                    {
                        conn.connection.Open();
                        string query = "select * from project_db.spa where SpaID=@ID";

                        MySqlCommand cmd = new MySqlCommand(query, conn.connection);
                        cmd.Parameters.AddWithValue("@ID", SpaId.Text);
                        MySqlDataReader reader = cmd.ExecuteReader();
                        if (reader.Read())
                        {
                            tmpid=SpaId.Text = reader["SpaID"].ToString();
                            SpaName.Text = reader["SpaName"].ToString();
                            SpaRegion.Text = reader["Region"].ToString();
                            SpaCity.Text = reader["City"].ToString();
                            PhoneNumber.Text = reader["PhoneNumber"].ToString();
                           SpaRate.Text = reader["Rating"].ToString();
                            flag3 = true;
                            MessageBox.Show("Change the demanded details and then click 'Update' again");
                        }
                    }
                    #endregion
                    #region Check data and update
                    else
                    {
                        conn.connection.Open();
                        #region check if data are valid 
                        #region check if spa id is ok
                        try
                        {
                            string query1 = "SELECT * FROM spa WHERE SpaID=@SpaId";
                            MySqlCommand cmd1 = new MySqlCommand(query1, conn.connection);
                            cmd1.Parameters.AddWithValue("@SpaId", SpaId.Text);
                            MySqlDataReader reader = cmd1.ExecuteReader();
                            if (reader.HasRows == false)
                            { MessageBox.Show($"Spa ID {SpaId.Text} does not exist - Please Choose an existing Spa ID number"); return; }
                            conn.connection.Close();
                        }
                        catch (MySqlException ex)
                        {
                            MessageBox.Show(ex.Message);
                        }
                        finally
                        {
                            conn.connection.Close();
                        }
                        #endregion
                        #endregion
                        #region Update data in database
                        conn.connection.Open();
                        if (SpaId.Text != tmpid) { MessageBox.Show("ID is not changeable");SpaId.Text = tmpid; return; }
                        string query = "update project_db.spa set SpaID='" + SpaId.Text + "',SpaName='" + SpaName.Text + "',Region='" + SpaRegion.Text + "',City='" + SpaCity.Text + "' ,PhoneNumber='" + PhoneNumber.Text + "',Rating='" + SpaRate.Text + "' where SpaID=@ID;";
                        MySqlCommand cmd = new MySqlCommand(query, conn.connection);
                        cmd.Parameters.AddWithValue("@ID", SpaId.Text);
                        if (MessageBox.Show("Are you sure you want to update?", "Update", MessageBoxButton.YesNo, MessageBoxImage.Warning) == MessageBoxResult.No)
                        {
                            return;
                        }
                        MySqlDataReader MyReader2 = cmd.ExecuteReader();
                        while (MyReader2.Read())
                        {
                        }
                        MessageBox.Show($"Worker ID {WorkerId.Text} was updated successfully");
                        flag3 = false;
                        #endregion
                    }
                    #endregion
                }
                catch (MySqlException ex)
                {
                    MessageBox.Show(ex.Message);
                }
                finally
                {
                    conn.connection.Close();
                    Load_Spa_table_Click(sender, e);
                }
            }
            #endregion
            #region Transaction
            if(TabCtl.SelectedIndex==3)
            {
                //checks if id is inserted
                if (TransactionId.Text == "")
                {
                    MessageBox.Show("Pleae insert transaction ID and then click 'Update' again");
                    return;
                }
                #region checks if ID is valid
                conn.connection.Open();
                try
                {
                    string query = "SELECT * FROM therapy WHERE TransactionID=@Id";
                    MySqlCommand cmd = new MySqlCommand(query, conn.connection);
                    cmd.Parameters.AddWithValue("@Id", TransactionId.Text);
                    MySqlDataReader reader = cmd.ExecuteReader();
                    if (reader.HasRows == false)
                    { MessageBox.Show($"ID {TransactionId.Text} is not exist - Please Choose another ID number"); return; }
                }
                catch (MySqlException ex)
                {
                    MessageBox.Show(ex.Message);
                }
                finally
                {
                    conn.connection.Close();
                }
                #endregion
                try
                {
                    #region Bringing records to update from database by ID
                    if (!flag4)
                    {
                        conn.connection.Open();
                        string query = "select * from project_db.therapy where TransactionID=@ID";

                        MySqlCommand cmd = new MySqlCommand(query, conn.connection);
                        cmd.Parameters.AddWithValue("@ID", TransactionId.Text);
                        MySqlDataReader reader = cmd.ExecuteReader();
                        if (reader.Read())
                        {
                            tmpid = TransactionId.Text = reader["TransactionID"].ToString();
                            ClientID.Text = reader["ClientID"].ToString();
                            WorkerID.Text = reader["WorkerID"].ToString();
                            SpaID.Text = reader["SpaID"].ToString();
                            TherapyType.Text = reader["TherapyType"].ToString();
                            TherapyTime.Text = reader["TherapyTime"].ToString();
                            Date.Text= reader["TherapyDate"].ToString();
                            TherapyPrice.Text = reader["Price"].ToString();
                            Payment.Text = reader["Payment"].ToString();
                            flag4 = true;
                            MessageBox.Show("Change the demanded details and then click 'Update' again");
                        }
                    }
                    #endregion
                    #region Check data and update
                    else
                    {
                        conn.connection.Open();
                        #region check if spa id is ok
                        try
                        {
                            string query1 = "SELECT * FROM spa WHERE SpaID=@SpaId";
                            MySqlCommand cmd1 = new MySqlCommand(query1, conn.connection);
                            cmd1.Parameters.AddWithValue("@SpaId", SpaID.Text);
                            MySqlDataReader reader = cmd1.ExecuteReader();
                            if (reader.HasRows == false)
                            { MessageBox.Show($"Spa ID {SpaID.Text} does not exist - Please Choose an existing Spa ID number"); return; }
                            conn.connection.Close();
                        }
                        catch (MySqlException ex)
                        {
                            MessageBox.Show(ex.Message);
                        }
                        finally
                        {
                            conn.connection.Close();
                        }
                        #endregion
                        #region Update data in database
                        conn.connection.Open();                                                                                                    
                        if (TransactionId.Text != tmpid) { MessageBox.Show("ID is not changeable"); TransactionId.Text = tmpid; return; }
                        string query = "update project_db.therapy set TransactionID='" + TransactionId.Text + "',ClientID='" + ClientID.Text + "',WorkerID='" + WorkerID.Text + "',SpaID='" + SpaID.Text + "' ,TherapyType='" + TherapyType.Text + "',TherapyTime='" + TherapyTime.Text + "',TherapyDate='" + Date.Text + "',Price='" + TherapyPrice.Text + "',Payment='" + Payment.Text + "' where TransactionID=@ID;";
                        MySqlCommand cmd = new MySqlCommand(query, conn.connection);
                        cmd.Parameters.AddWithValue("@ID", TransactionId.Text);
                        if (MessageBox.Show("Are you sure you want to update?", "Update", MessageBoxButton.YesNo, MessageBoxImage.Warning) == MessageBoxResult.No)
                        {
                            return;
                        }
                        MySqlDataReader MyReader2 = cmd.ExecuteReader();
                        while (MyReader2.Read())
                        {
                        }
                        MessageBox.Show($"Transaction ID {TransactionId.Text} was updated successfully");
                        flag4 = false;
                        #endregion
                    }
                    #endregion
                }
                catch (MySqlException ex)
                {
                    MessageBox.Show(ex.Message);
                }
                finally
                {
                    conn.connection.Close();
                    Load_Transaction_table_Click(sender, e);
                }
            }
            #endregion   
        }
        #endregion
        #region Delete Details
        /// <summary>
        /// Delete records from database
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void DeleteBtn_Click(object sender, RoutedEventArgs e)
        {
            #region Workers
            if (TabCtl.SelectedIndex == 0)
            {
                DBConnect conn = new DBConnect();
                try
                {
                    if(WorkerId.Text=="")
                    {
                        MessageBox.Show("Insert worker ID and click 'Delete' again");
                        return;
                    }
                    #region check ID is valid
                    try
                    {
                        conn.connection.Open();
                        string q = "SELECT * FROM workers WHERE ID=@Id";
                        MySqlCommand c = new MySqlCommand(q, conn.connection);
                        c.Parameters.AddWithValue("@Id", WorkerId.Text);
                        MySqlDataReader reader = c.ExecuteReader();
                        if (reader.HasRows == false)
                        { MessageBox.Show($"ID {WorkerId.Text} is not exist - Please Choose another ID number"); return; }
                    }
                    catch(MySqlException ex)
                    {
                        MessageBox.Show(ex.Message);
                    }
                    finally
                    {
                        conn.connection.Close();
                    }
                    #endregion
                    #region Delete from database
                    conn.connection.Open();
                    string query = "delete from project_db.workers where ID=@ID;";
                    MySqlCommand cmd = new MySqlCommand(query, conn.connection);
                    if (MessageBox.Show("Are you sure you want delete worker ID "+WorkerId.Text+"?", "Delete", MessageBoxButton.YesNo, MessageBoxImage.Warning) == MessageBoxResult.No)
                        return;
                    cmd.Parameters.AddWithValue("@ID", WorkerId.Text);
                    MySqlDataReader MyReader2 = cmd.ExecuteReader();
                    while (MyReader2.Read())
                    {
                    }
                    MessageBox.Show($"Worker ID {WorkerId.Text} was deleted successfully");
                    #endregion
                }
                catch (MySqlException ex)
                {
                    MessageBox.Show(ex.Message);
                }
                finally
                {
                    conn.connection.Close();
                    Load_Employee_table_Click(sender, e);                    
                }
            }
            #endregion
            #region Clients
            if (TabCtl.SelectedIndex == 1)
            {

                DBConnect conn = new DBConnect();
                try
                {
                    if (ClientId.Text == "")
                    {
                        MessageBox.Show("Insert client ID and click 'Delete' again");
                        return;
                    }
                    #region check ID is valid
                    try
                    {
                        conn.connection.Open();
                        string q = "SELECT * FROM clients WHERE ClientID=@Id";
                        MySqlCommand c = new MySqlCommand(q, conn.connection);
                        c.Parameters.AddWithValue("@Id", ClientId.Text);
                        MySqlDataReader reader = c.ExecuteReader();
                        if (reader.HasRows == false)
                        { MessageBox.Show($"ID {ClientId.Text} is not exist - Please Choose another ID number"); return; }
                    }
                    catch (MySqlException ex)
                    {
                        MessageBox.Show(ex.Message);
                    }
                    finally
                    {
                        conn.connection.Close();
                    }
                    #endregion
                    #region Delete from database
                    conn.connection.Open();
                    string query = "delete from project_db.clients where ClientID=@ID;";
                    MySqlCommand cmd = new MySqlCommand(query, conn.connection);
                    if (MessageBox.Show("Are you sure you want delete client ID " + ClientId.Text + "?", "Delete", MessageBoxButton.YesNo, MessageBoxImage.Warning) == MessageBoxResult.No)
                        return;
                    cmd.Parameters.AddWithValue("@ID",ClientId.Text);
                    MySqlDataReader MyReader2 = cmd.ExecuteReader();
                    while (MyReader2.Read())
                    {
                    }
                    MessageBox.Show($"Client ID {ClientId.Text} was deleted successfully");
                    #endregion
                }
                catch (MySqlException ex)
                {
                    MessageBox.Show(ex.Message);
                }
                finally
                {
                    conn.connection.Close();
                    Load_Client_table_Click(sender, e);
                }
            }
            #endregion
            #region Spa
            if (TabCtl.SelectedIndex == 2)
            {
                
                DBConnect conn = new DBConnect();
                try
                {
                    if (SpaId.Text=="")
                    {
                        MessageBox.Show("Insert spa ID and click 'Delete' again");
                        return;
                    }
                    #region check ID is valid
                    try
                    {
                        conn.connection.Open();
                        string q = "SELECT * FROM spa WHERE SpaID=@Id";
                        MySqlCommand c = new MySqlCommand(q, conn.connection);
                        c.Parameters.AddWithValue("@Id", SpaId.Text);
                        MySqlDataReader reader = c.ExecuteReader();
                        if (reader.HasRows == false)
                        { MessageBox.Show($"ID {SpaId.Text} is not exist - Please Choose another ID number"); return; }
                    }
                    catch(MySqlException ex)
                    {
                        MessageBox.Show(ex.Message);
                    }
                    finally
                    {
                        conn.connection.Close();
                    }
                    #endregion
                    #region Delete from database
                    conn.connection.Open();
                    string query = "delete from project_db.spa where SpaID=@ID;";
                    MySqlCommand cmd = new MySqlCommand(query, conn.connection);
                    if (MessageBox.Show("Are you sure you want delete spa ID "+SpaId.Text+"?", "Delete", MessageBoxButton.YesNo, MessageBoxImage.Warning) == MessageBoxResult.No)
                        return;
                    cmd.Parameters.AddWithValue("@ID", SpaId.Text);
                    MySqlDataReader MyReader2 = cmd.ExecuteReader();
                    while (MyReader2.Read())
                    {
                    }
                    MessageBox.Show($"Spa ID {SpaId.Text} was deleted successfully");
                    #endregion
                }
                catch (MySqlException ex)
                {
                    MessageBox.Show(ex.Message);
                }
                finally
                {
                    conn.connection.Close();
                    Load_Spa_table_Click(sender, e);                    
                }
            }
            #endregion
            #region Transaction
            if (TabCtl.SelectedIndex == 3)
            {
                DBConnect conn = new DBConnect();
                try
                {
                    if (TransactionId.Text == "")
                    {
                        MessageBox.Show("Insert transaction ID and click 'Delete' again");
                        return;
                    }
                    #region check ID is valid
                    try
                    {
                        conn.connection.Open();
                        string q = "SELECT * FROM therapy WHERE TransactionID=@Id";
                        MySqlCommand c = new MySqlCommand(q, conn.connection);
                        c.Parameters.AddWithValue("@Id", TransactionId.Text);
                        MySqlDataReader reader = c.ExecuteReader();
                        if (reader.HasRows == false)
                        { MessageBox.Show($"ID {TransactionId.Text} is not exist - Please Choose another ID number"); return; }
                    }
                    catch (MySqlException ex)
                    {
                        MessageBox.Show(ex.Message);
                    }
                    finally
                    {
                        conn.connection.Close();
                    }
                    #endregion
                    #region Delete from database
                    conn.connection.Open();
                    string query = "delete from project_db.therapy where TransactionID=@ID;";
                    MySqlCommand cmd = new MySqlCommand(query, conn.connection);
                    if (MessageBox.Show("Are you sure you want delete transaction ID " + TransactionId.Text + "?", "Delete", MessageBoxButton.YesNo, MessageBoxImage.Warning) == MessageBoxResult.No)
                        return;
                    cmd.Parameters.AddWithValue("@ID", TransactionId.Text);
                    MySqlDataReader MyReader2 = cmd.ExecuteReader();
                    while (MyReader2.Read())
                    {
                    }
                    MessageBox.Show($"Transaction ID {TransactionId.Text} was deleted successfully");
                    #endregion
                }
                catch (MySqlException ex)
                {
                    MessageBox.Show(ex.Message);
                }
                finally
                {
                    conn.connection.Close();
                    Load_Transaction_table_Click(sender, e);
                }
            }
            #endregion
        }
        #endregion
        #region Search For Details
        /// <summary>
        /// Search records in the database
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void SearchBtn_Click(object sender, RoutedEventArgs e)
        {

            #region Workers
            if (TabCtl.SelectedIndex == 0)
            {
                DBConnect conn = new DBConnect();
                try
                {
                    conn.connection.Open();
                    string s;
                    MySqlCommand c;
                    if (WorkerMale.IsChecked == true)
                        s = "select * from workers where ID='" + WorkerId.Text + "' or Sex='Male' or FirstName='" + WorkerFirstName.Text + "' or LastName='" + WorkerLastName.Text + "' or City='" + WorkerCity.Text + "' or Specialty='" + WorkerSpeciality.Text + "' or Seniority='" + WorkerSeniority.Text + "' or Salary='" + WorkerSalary.Text + "' or Spa='" + WorkerSpaID.Text + "' or Age='" + WorkerAge.Text + "';";                    
                    else if(WorkerFemale.IsChecked==true)
                        s = "select * from workers where ID='" + WorkerId.Text + "' or Sex='Female' or FirstName='" + WorkerFirstName.Text + "' or LastName='" + WorkerLastName.Text + "' or City='" + WorkerCity.Text + "' or Specialty='" + WorkerSpeciality.Text + "' or Seniority='" + WorkerSeniority.Text + "' or Salary='" + WorkerSalary.Text + "' or Spa='" + WorkerSpaID.Text + "' or Age='" + WorkerAge.Text + "';";                    
                    else
                        s = "select * from workers where ID='" + WorkerId.Text + "' or FirstName='" + WorkerFirstName.Text + "' or LastName='" + WorkerLastName.Text + "' or City='" + WorkerCity.Text + "' or Specialty='" + WorkerSpeciality.Text + "' or Seniority='" + WorkerSeniority.Text + "' or Salary='" + WorkerSalary.Text + "' or Spa='" + WorkerSpaID.Text + "' or Age='" + WorkerAge.Text + "';";
                    c = new MySqlCommand(s, conn.connection);
                    MySqlDataAdapter adp= new MySqlDataAdapter(c);
                    DataTable dt = new DataTable("workers");
                    adp.Fill(dt);
                    EmployeeDT.ItemsSource = dt.DefaultView;
                    adp.Update(dt);
                }
                catch(MySqlException ex)
                {
                    MessageBox.Show(ex.Message);
                }
                finally
                {
                    conn.connection.Close();
                }
            }
            #endregion
            #region Clients
            if (TabCtl.SelectedIndex == 1)
            {
                DBConnect conn = new DBConnect();
                try
                {
                    conn.connection.Open();
                    string s;
                    MySqlCommand c;
                    if (ClientMale.IsChecked == true)
                        s = "select * from clients where ClientID='" + ClientId.Text + "' or Sex='Male' or FirstName='" + ClientFirstName.Text + "' or LastName='" + ClientLastName.Text + "' or City='" + ClientCity.Text + "' or Age='" + ClientAge.Text + "'";
                    else if (ClientFemale.IsChecked == true)
                        s = "select * from clients where ClientID='" + ClientId.Text + "' or Sex='Female' or FirstName='" + ClientFirstName.Text + "' or LastName='" + ClientLastName.Text + "' or City='" + ClientCity.Text + "' or Age='" + ClientAge.Text + "'";
                    else
                        s = "select * from clients where ClientID='" + ClientId.Text + "' or  FirstName='" + ClientFirstName.Text + "' or LastName='" + ClientLastName.Text + "' or City='" + ClientCity.Text + "' or Age='" + ClientAge.Text + "'";
                    c = new MySqlCommand(s, conn.connection);
                    MySqlDataAdapter adp = new MySqlDataAdapter(c);
                    DataTable dt = new DataTable("clients");
                    adp.Fill(dt);
                    ClientDT.ItemsSource = dt.DefaultView;
                    adp.Update(dt);
                }
                catch (MySqlException ex)
                {
                    MessageBox.Show(ex.Message);
                }
                finally
                {
                    conn.connection.Close();
                }
            }
            #endregion
            #region Spa
            if (TabCtl.SelectedIndex == 2)
            {

                DBConnect conn = new DBConnect();
                try
                {
                    conn.connection.Open();
                    string s = "select * from spa where SpaID='" + SpaId.Text + "' or SpaName='" + SpaName.Text + "' or Region='" + SpaRegion.Text + "' or City='" + SpaCity.Text + "'  or PhoneNumber='" + PhoneNumber.Text + "' or Rating='" + SpaRate.Text + "'";
                    MySqlCommand c = new MySqlCommand(s, conn.connection);
                    MySqlDataAdapter adp = new MySqlDataAdapter(c);
                    DataTable dt = new DataTable("spa");
                    adp.Fill(dt);
                    SpaDT.ItemsSource = dt.DefaultView;
                    adp.Update(dt);
                }
                catch (MySqlException ex)
                {
                    MessageBox.Show(ex.Message);
                }
                finally
                {
                    conn.connection.Close();
                }
            }
            #endregion
            #region Transaction
            if (TabCtl.SelectedIndex == 3)
            {

                DBConnect conn = new DBConnect();
                try
                {
                    conn.connection.Open();
                    string s = "select * from therapy where TransactionID='" + TransactionId.Text + "' or ClientID='" + ClientID.Text + "' or WorkerID='" + WorkerID.Text + "' or SpaID='" + SpaID.Text + "' or TherapyType='" + TherapyType.Text + "' or TherapyTime='" + TherapyTime.Text + "' or TherapyDate='" + Date.Text + "' or Price='" + TherapyPrice.Text + "' or Payment='" + Payment.Text + "'";
                    MySqlCommand c = new MySqlCommand(s, conn.connection);
                    MySqlDataAdapter adp = new MySqlDataAdapter(c);
                    DataTable dt = new DataTable("therapy");
                    adp.Fill(dt);
                    TransactionDT.ItemsSource = dt.DefaultView;
                    adp.Update(dt);
                }
                catch (MySqlException ex)
                {
                    MessageBox.Show(ex.Message);
                }
                finally
                {
                    conn.connection.Close();
                }
            }
            #endregion
        }
        #endregion
        #region LogOut 
        private void LogOutBtn_Click(object sender, RoutedEventArgs e)
        {
            if (MessageBox.Show("Are you sure you want to log out?", "Log Out", MessageBoxButton.YesNo, MessageBoxImage.Warning) == MessageBoxResult.No)
            {
                return;
            }
            else
            {
                //Open the log in window again
                mw.Show();
                this.Close();
            }


        }
        #endregion
        #region Exit
        private void ExitBtn_Click(object sender, RoutedEventArgs e)
        {
            if (MessageBox.Show("Are you sure you want to exit?", "Exit", MessageBoxButton.YesNo, MessageBoxImage.Warning) == MessageBoxResult.No)
            {
                return;
            }
            else
            {
                this.Close();
            }

        }
        #endregion
        #region Employee Reset And Load Table
        private void Load_Employee_table_Click(object sender, RoutedEventArgs e)
        {
            DBConnect conn = new DBConnect();
            try
            {
                conn.connection.Open();
                string query = "select * from project_db.workers";
                MySqlCommand cmd = new MySqlCommand(query, conn.connection);
                MySqlDataAdapter adp = new MySqlDataAdapter(cmd);
                DataTable dt = new DataTable("workers");
                adp.Fill(dt);
                EmployeeDT.ItemsSource = dt.DefaultView;
                adp.Update(dt);
            }
            catch (MySqlException ex)
            {
                MessageBox.Show(ex.ToString());
            }
            finally
            {
                conn.connection.Close();
              
            }

        }

        private void Reset_Employee_Details_Click(object sender, RoutedEventArgs e)
        {
            WorkerId.Text = "";
            WorkerFirstName.Text = "";
            WorkerLastName.Text = "";
            WorkerCity.Text = "";
            WorkerSpeciality.Text = "";
            WorkerMale.IsChecked = false;
            WorkerFemale.IsChecked = false;
            WorkerSeniority.Text = "";
            WorkerSalary.Text = "";
            WorkerSpaID.Text = "";
            WorkerAge.Text = "";
            flag1 = false;
        }
        #endregion
        #region Client Reset And Load Table
        private void Load_Client_table_Click(object sender, RoutedEventArgs e)
        {
            DBConnect conn = new DBConnect();
            try
            {
                conn.connection.Open();
                string query = "select * from project_db.clients";
                MySqlCommand cmd = new MySqlCommand(query, conn.connection);
                MySqlDataAdapter adp = new MySqlDataAdapter(cmd);
                DataTable dt = new DataTable("clients");
                adp.Fill(dt);
                ClientDT.ItemsSource = dt.DefaultView;
                adp.Update(dt);
            }
            catch (MySqlException ex)
            {
                MessageBox.Show(ex.ToString());
            }
            finally
            {
                conn.connection.Close();
            }
        }

        private void Reset_Clients_Details_Click(object sender, RoutedEventArgs e)
        {
            ClientId.Text = "";
            ClientFirstName.Text = "";
            ClientLastName.Text = "";
            ClientMale.IsChecked = false;
            ClientFemale.IsChecked = false;
            ClientCity.Text = "";
            ClientAge.Text = "";
            flag2 = false;
        }
        #endregion
        #region Spa Reset And Load Table
        private void Load_Spa_table_Click(object sender, RoutedEventArgs e)
        {
            DBConnect conn = new DBConnect();
            try
            {
                conn.connection.Open();
                string query = "select * from project_db.spa";
                MySqlCommand cmd = new MySqlCommand(query, conn.connection);
                MySqlDataAdapter adp = new MySqlDataAdapter(cmd);
                DataTable dt = new DataTable("spa");
                adp.Fill(dt);
                SpaDT.ItemsSource = dt.DefaultView;
                adp.Update(dt);
            }
            catch (MySqlException ex)
            {
                MessageBox.Show(ex.ToString());
            }
            finally
            {
                conn.connection.Close();
            }
        }
        private void Reset_Spa_Details_Click(object sender, RoutedEventArgs e)
        {
            SpaId.Text = "";
            SpaName.Text = "";
            SpaRegion.Text = "";
            SpaRate.Text = "";
            SpaCity.Text = "";
            PhoneNumber.Text = "";
            flag3 = false;
        }
        #endregion
        #region Transaction Reset And Load Table
        private void Load_Transaction_table_Click(object sender, RoutedEventArgs e)
        {
            DBConnect conn = new DBConnect();
            try
            {
                conn.connection.Open();
                string query = "select * from project_db.therapy";
                MySqlCommand cmd = new MySqlCommand(query, conn.connection);
                MySqlDataAdapter adp = new MySqlDataAdapter(cmd);
                DataTable dt = new DataTable("therapy");
                adp.Fill(dt);
                TransactionDT.ItemsSource = dt.DefaultView;
                adp.Update(dt);
            }
            catch (MySqlException ex)
            {
                MessageBox.Show(ex.ToString());
            }
            finally
            {
                conn.connection.Close();
            }
        }

        private void Reset_Transaction_Details_Click(object sender, RoutedEventArgs e)
        {
            TransactionId.Text = "";
            ClientID.Text = "";
            SpaID.Text = "";
            WorkerID.Text = "";
            TherapyType.Text = "";
            TherapyTime.Text = "";
            TherapyPrice.Text = "";
            Date.Text = "";
            Payment.Text = "";
            flag4 = false;
        }
        #endregion
    }
}
