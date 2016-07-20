using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.OleDb;

namespace DataEntryToDB
{
    public partial class Form1 : Form
    {
        //create connection object
        OleDbConnection connection = new OleDbConnection();
        public Form1()
        {
            InitializeComponent();
            
            //connection string
            connection.ConnectionString = @"Provider=Microsoft.ACE.OLEDB.12.0;Data Source=C:;Persist Security Info=False";
            


        }

        private void Form1_Load(object sender, EventArgs e)
        {
            
        }

        private void btn_AddUser_Click(object sender, EventArgs e)
        {
            try
            {
 
                connection.Open();
                //each record to be added is equal to the content of the text boxes
                string dbName = txt_dbName.Text.ToString();
                string firstName = txt_FirstName.Text.ToString();
                string lastName = txt_LastName.Text.ToString();
                string userName = txt_UserName.Text.ToString();
                string passWord = txt_Password.Text.ToString();
                //our command to add records in
                OleDbCommand command = new OleDbCommand();
                command.CommandText = "INSERT INTO tUserInfo ([First Name],[Last Name],[Username],[Password]) VALUES('" + firstName + "','" + lastName + "','" + userName + "','" + passWord + "')";
                command.Connection = connection;
                //execute the command
                command.ExecuteNonQuery();
                MessageBox.Show(@"Data Saved Successfully to C:\Temp\" + dbName);
            }
            catch(Exception ex)
            {
                MessageBox.Show("Failed due to" + ex);
            }
            finally
            {
                connection.Close();
            }

                
        }

        private void btn_CheckFile_Click(object sender, EventArgs e)
        {
            string dbName = txt_dbName.Text;
            connection.ConnectionString = @"Provider = Microsoft.ACE.OLEDB.12.0; Data Source = C:\Temp\" + dbName + "; Persist Security Info=False";
            MessageBox.Show(@"Database selected: C:\Temp\" + dbName);
        }
    }
}
