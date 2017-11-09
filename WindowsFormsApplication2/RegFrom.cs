using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Windows.Forms;
using AesEncDec;
using System.IO;
using System.Security.Cryptography;

namespace WindowsFormsApplication2
{
    public partial class RegFrom : Form
    {


        DataAccess DataAccess = new DataAccess();
        Login_System_Encrypted lf = new Login_System_Encrypted();

        public RegFrom()
        {
            InitializeComponent();
        }



        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button2_Click_1(object sender, EventArgs e)
        {
            if (usrTxt.Text.Length < 3 || passTxt.Text.Length < 5)
            {
                MessageBox.Show("نام کاربر یا رمز عبور اشتباه یا کوتاه است");
            }
            else
            {


                string encusr = AesCrypt.Encrypt(usrTxt.Text);
                string encpass = AesCrypt.Encrypt(passTxt.Text);

                DataAccess.cmd = new SqlCommand("select * from Operators where Username = @username", DataAccess.con);
                DataAccess.cmd.Parameters.AddWithValue("@username", encusr);
                DataAccess.con.Open();

                DataAccess.Dataset = new DataSet();
                DataAccess.SQLDA = new SqlDataAdapter(DataAccess.cmd);
                DataAccess.SQLDA.Fill(DataAccess.Dataset);
                DataAccess.con.Close();


                bool loginSuccessful = ((DataAccess.Dataset.Tables.Count > 0) && (DataAccess.Dataset.Tables[0].Rows.Count > 0));

                if (loginSuccessful == false)
                {
                    string AddEmployee = "Insert Into Operators(Username,Password) Values('" + encusr + "','" + encpass + "');";
                    DataAccess.con.Open();
                    DataAccess.cmd = new SqlCommand(AddEmployee, DataAccess.con);
                    DataAccess.cmd.ExecuteNonQuery();
                    DataAccess.con.Close();

                    MessageBox.Show( "موفقانه ثبت شد " + usrTxt.Text + " کاربز ");
                    this.Close();
                    
                }
                else
                {
                    MessageBox.Show("کاربر "+ usrTxt.Text + "از قبل موجود است ");
                }



            }
        }

    }
}
