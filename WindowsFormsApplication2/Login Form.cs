using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using AesEncDec;
using System.IO;
using System.Data.SqlClient;
using System.Management;
using System.Xml;
using System.Configuration;

namespace WindowsFormsApplication2
{
    public partial class Login_System_Encrypted : Form
    {

        DataAccess DataAccess = new DataAccess();

        string decusr;
        string decpass;
        bool chkup;


        public Login_System_Encrypted()
        {
            InitializeComponent();



        }


        private void button2_Click_1(object sender, EventArgs e)
        {

            DataAccess.cmd = new SqlCommand("select * from Operators", DataAccess.con);
            DataAccess.con.Open();

            DataAccess.Dataset = new DataSet();
            DataAccess.SQLDA = new SqlDataAdapter(DataAccess.cmd);
            DataAccess.SQLDA.Fill(DataAccess.Dataset);
            DataAccess.con.Close();


            bool loginSuccessful = ((DataAccess.Dataset.Tables.Count > 0) && (DataAccess.Dataset.Tables[0].Rows.Count > 0));

            if (loginSuccessful == false)
            {
                RegFrom rf = new RegFrom();
                rf.Show();
            }
            else
            {
                MessageBox.Show("لطفاً برای اضافه نمودن کاربر داخل سیستم شوید");
            }

        }

        private void button1_Click_1(object sender, EventArgs e)
        {


            if (usrTxt.Text.Length < 3 || passTxt.Text.Length < 5)
            {
                MessageBox.Show("نام کاربر یا رمز عبور اشتباه یا کوتاه است");
            }
            else
            {

                string usrchk = AesCrypt.Encrypt(usrTxt.Text);
                string passchk = AesCrypt.Encrypt(passTxt.Text);
                DataAccess.RunQuery("Select * From Operators where Username= '" + usrchk + "'");
                int i = DataAccess.Dataset.Tables[0].Rows.Count;


                string dir = usrTxt.Text;


                if (i <= 0)
                    MessageBox.Show(" در سیستم موجود نیست "  + dir + " کاربر");
                else
                {






                    DataAccess.cmd = new SqlCommand("select * from Operators where Username = @username and Password = @password", DataAccess.con);
                    DataAccess.cmd.Parameters.AddWithValue("@username", usrchk);
                    DataAccess.cmd.Parameters.AddWithValue("@password", passchk);
                    DataAccess.con.Open();

                    DataAccess.Dataset = new DataSet();
                    DataAccess.SQLDA = new SqlDataAdapter(DataAccess.cmd);
                    DataAccess.SQLDA.Fill(DataAccess.Dataset);
                    DataAccess.con.Close();


                    bool loginSuccessful = ((DataAccess.Dataset.Tables.Count > 0) && (DataAccess.Dataset.Tables[0].Rows.Count > 0));

                    if (loginSuccessful == true)
                    {
                        decusr = AesCrypt.Decrypt(usrchk);
                        decpass = AesCrypt.Decrypt(passchk);
                    }



                    if (decusr == usrTxt.Text && decpass == passTxt.Text)
                    {
                        DataAccess.con.Close();
                        MessageBox.Show("خوش آمدید" + " داخل سیستم " + decusr);

                        chkup = true;
                    }
                    else
                    {
                        MessageBox.Show("نام کاربر یا رمز عبور اشتباه است");
                    }
                    if (chkup == true) {
                        MainForm MF = new MainForm();
                        MF.Show();
                        Login_System_Encrypted lf = new Login_System_Encrypted();
                        this.Visible = false;
                    

                    
                    }
                }
            }

        }
        public bool IsServerConnected()
        {
            using (var l_oConnection = new SqlConnection(ConfigurationManager.ConnectionStrings["dbx"].ConnectionString))
            {
                try
                {
                    l_oConnection.Open();
                    return true;
                }
                catch (SqlException)
                {
                    return false;

                }

               
            }
        }

        private void Login_System_Encrypted_Load(object sender, EventArgs e)
        {
            if (IsServerConnected() == false)
            {
                
            }
            else
            {
                button3.Visible = false;
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Settings set = new Settings();
            set.Show();
        }
    }
}
