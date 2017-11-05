using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.Sql;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace WindowsFormsApplication2
{

    public class DataAccess
    {


        // Server=tcp:MASOUD-PC,1433\\MOBILESQL;Database=MobileData;User Id = sa; Password = hodaka;
        //MOZAMEL-OFFICE
        //MBP-WIN-M\SQLEXPRESS
        // Server=ABDULRAUF-MASOU;Database=MobileData;Trusted_Connection=True

        public static SqlConnection con = new SqlConnection(" Server=tcp:MASOUD-PC,1433\\MOBILESQL;Database=MobileData;User Id = sa; Password = hodaka");

        public SqlCommand cmd;
        public SqlDataAdapter SQLDA;
        public DataTable DT;
        public DataSet Dataset = new DataSet();
        public DataView DV;
        public SqlDataReader DR;
        public SqlDataAdapter DA;
        public DataTable dbdataset;

        // ---------------------------------- Adding IN TO Products-------------------------------Function
        public string textaa;
        public void RunQuery(string Query)
        {
            try
            {
                con.Open();
                cmd = new SqlCommand(Query, con);
                SQLDA = new SqlDataAdapter(cmd);
                Dataset = new DataSet();
                SQLDA.Fill(Dataset);
                con.Close();

            }
            catch (Exception e)
            {
                if (con.State == ConnectionState.Open)

                {
                    con.Close();
                }
                MessageBox.Show(e.Message);

            }

        }



        public void RunQuery2(string Query,string textbox)
        {
            try
            {
                con.Open();
                cmd = new SqlCommand(Query, con);
                SQLDA = new SqlDataAdapter(cmd);
                dbdataset = new DataTable();
                SQLDA.Fill(dbdataset);
                DataView DV = new DataView(dbdataset);

                con.Close();

            }
            catch (Exception e)
            {
                if (con.State == ConnectionState.Open)

                {
                    con.Close();
                }
                MessageBox.Show(e.Message);

            }

        }


        public void RunQuery_1(string Query)
        {
            MainForm main = new MainForm();
            try
            {
                con.Open();
                cmd = new SqlCommand(Query, con);
                DR = cmd.ExecuteReader();
                if (DR.Read())
                {
                    textaa = (DR["E_ID"].ToString());
                }
                con.Close();

            }
            catch (Exception e)
            {
                if (con.State == ConnectionState.Open)

                {
                    con.Close();
                }
                MessageBox.Show(e.Message);

            }

        }




        // --------------------------------------------------Classes---------------------------------Function\\


        // ------------------------------------------------------------------------------------------ Adding------------------------------------------------------------------------------------Function\\

        // -------------------------------------- Adding IN TO Employee-------------------------------Function\\
        public void Employee(string Name, string F_Name, string PhoneNumber1, string phoneNumber2, string Address, string payment)
        {
            try
            {
                string AddEmployee = "Insert Into Employee(E_Name,[F/Name],E_Phone_1,E_Phone_2,E_Location,Income) Values('" + Name + "','" + F_Name + "','" + PhoneNumber1 + "','" + phoneNumber2 + "','" + Address + "','" + payment + "');";
                con.Open();
                cmd = new SqlCommand(AddEmployee, con);
                cmd.ExecuteNonQuery();
                con.Close();


            }

            catch (Exception ex)

            {
                MessageBox.Show(ex.Message);
                if (con.State == ConnectionState.Open)
                {

                    con.Close();
                }

            }

        }






        // -------------------------------------- Adding IN TO Customers-------------------------------Function\\
        public void Customer(string Name, string Address, string PhoneNumber)
        {
            try
            {
                string AddNewCustomer = "Insert Into Customer(C_Name,C_Location,C_Phone) Values('" + Name + "','" + Address + "','" + PhoneNumber + "');";
                con.Open();
                cmd = new SqlCommand(AddNewCustomer, con);
                cmd.ExecuteNonQuery();
                con.Close();
            }

            catch
            {
                if (con.State == ConnectionState.Open)
                {
                    con.Close();
                }

            }

        }







        // -------------------------------------- Adding IN TO Expense-------------------------------Function\\
        public void Expense(string What_For, string Quantity, string date)
        {


            try
            {
                string expense = "Insert Into Expenses(Ex_Name,Quantity,Date) Values('" + What_For + "','" + Quantity + "','" + date + "');";
                con.Open();
                cmd = new SqlCommand(expense, con);
                cmd.ExecuteNonQuery();
                con.Close();
            }

            catch
            {
                if (con.State == ConnectionState.Open)
                {
                    con.Close();
                }

            }

        }



        // --------------------------------------Adding IN  Taking Money-------------------------------Function\\
        public void Withrow(string Name, string What_For, int Quantity, string date)
        {

            try
            {
                string Withrow = "Insert Into Withdraw(E_ID,Quantity,What_For,Date) Values('" + Name + "','" + Quantity + "','" + What_For + "','" + date + "');";
                con.Open();
                cmd = new SqlCommand(Withrow, con);
                cmd.ExecuteNonQuery();
                con.Close();
            }

            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                if (con.State == ConnectionState.Open)
                {
                    con.Close();
                }

            }

        }

        //-------------------------------------Adding IN  NewSupplier-------------------------------Function\\
        public void NewSupplier(string Name, string Location, string Phone, string E_mail)
        {
            try
            {
                string New_supplier = "Insert Into Supplier(S_Name,S_Location,S_Phone,S_E_Mail) Values('" + Name + "','" + Location + "','" + Phone + "','" + E_mail + "');";
                con.Open();
                cmd = new SqlCommand(New_supplier, con);
                cmd.ExecuteNonQuery();
                con.Close();
            }

            catch
            {
                if (con.State == ConnectionState.Open)
                {
                    con.Close();
                }

            }

        }

        // --------------------------------------Adding IN  NewItems-------------------------------Function\\
        public void NewItem(string P_ID, string P_NAME, string P_Color, string P_Made)
        {
            try
            {
                string New_Item = "Insert Into Product(P_ID,P_Name,P_Color,P_Made) Values('" + P_ID + "','" + P_NAME + "','" + P_Color + "','" + P_Made + "');";
                con.Open();
                cmd = new SqlCommand(New_Item, con);
                cmd.ExecuteNonQuery();
                con.Close();
            }

            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                if (con.State == ConnectionState.Open)
                {
                    con.Close();
                }

            }

        }
        // --------------------------------------Adding IN  Withrow-------------------------------Function\\

        public void Withrow(string E_ID, string Quantity, string What_for, string Date)
        {
            try
            {
                string New_Item = "Insert Into Withdraw(E_ID,Quantity,What_For,Date) Values('" + E_ID + "','" + Quantity + "','" + What_for + "','" + Date + "');";
                con.Open();
                cmd = new SqlCommand(New_Item, con);
                cmd.ExecuteNonQuery();
                con.Close();
            }

            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                if (con.State == ConnectionState.Open)
                {
                    con.Close();
                }

            }

        }

        // --------------------------------------Adding IN  SupplierLoan-------------------------------Function\\
        public void Supplier_Loan_Tab(string PC_ID, string S_ID, string Date, string T_pay)
        {
            try
            {
                string New_Item = "Insert Into Taken_loan(PC_ID,S_ID,T_L_Date,T_Pay_Loan) Values('" + PC_ID + "','" + S_ID + "','" + Date + "','" + T_pay + "');";
                con.Open();
                cmd = new SqlCommand(New_Item, con);
                cmd.ExecuteNonQuery();
                con.Close();
            }

            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                if (con.State == ConnectionState.Open)
                {
                    con.Close();
                }

            }

        }
        // --------------------------------------Adding IN  CustomerLoan-------------------------------Function\\
        public void Given_Loan(string I_ID, string C_ID, string Date, string G_pay)
        {
            try
            {
                string New_Item = "Insert Into Given_Loan(I_ID,C_ID,G_L_Date,G_Pay_Loan) Values('" + I_ID + "','" + C_ID + "','" + Date + "','" + G_pay + "');";
                con.Open();
                cmd = new SqlCommand(New_Item, con);
                cmd.ExecuteNonQuery();
                con.Close();
            }

            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                if (con.State == ConnectionState.Open)
                {
                    con.Close();
                }

            }

        }
        // --------------------------------------New_Invoice -------------------------------Function\\
        public void New_Invoice(string I_ID, string C_ID, string Date, string end_date)
        {
            try
            {
                string New_Item = "Insert Into Invoice(I_ID,C_ID,Date, End_Date) Values('" + I_ID + "','" + C_ID + "','" + Date + "','" + end_date + "');";
                con.Open();
                cmd = new SqlCommand(New_Item, con);
                cmd.ExecuteNonQuery();
                con.Close();
            }

            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                if (con.State == ConnectionState.Open)
                {
                    con.Close();
                }

            }

        }
        // --------------------------------------New_Invoice_Details -------------------------------Function\\
        public void New_Invoice_Datail(string I_ID, string P_ID, string Quantity, string Sell_Price, string Total_Amount)
        {
            try
            {
                string New_Item = "Insert Into Invoice_Details(I_ID,P_ID,Quantity,Sell_Price,Total_amount) Values('" + I_ID + "','" + P_ID + "','" + Quantity + "','" + Sell_Price + "','" + Total_Amount + "');";
                con.Open();
                cmd = new SqlCommand(New_Item, con);
                cmd.ExecuteNonQuery();
                con.Close();
            }

            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                if (con.State == ConnectionState.Open)
                {
                    con.Close();
                }

            }

        }


        public void New_Invoice_Amount(string I_ID, string Total_paid, float Balance, string Grand_Total)
        {
            try
            {
                string New_Item = "Insert Into Invoice_Amount(I_ID,Total_Paid,Balance, Grand_Total) Values('" + I_ID + "','" + Total_paid + "','" + Balance + "','" + Grand_Total + "');";
                con.Open();
                cmd = new SqlCommand(New_Item, con);
                cmd.ExecuteNonQuery();
                con.Close();
            }

            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                if (con.State == ConnectionState.Open)
                {
                    con.Close();
                }

            }

        }







        public void New_Purchase(string P_ID, string S_ID, string Date, string end_date)
        {
            try
            {
                string New_Item = "Insert Into Purchase(PC_ID,S_ID,Date, End_Date) Values('" + P_ID + "','" + S_ID + "','" + Date + "','" + end_date + "');";
                con.Open();
                cmd = new SqlCommand(New_Item, con);
                cmd.ExecuteNonQuery();
                    con.Close();
                }

            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                if (con.State == ConnectionState.Open)
                {
                    con.Close();
            }

        }

        }




        public void New_Purchase_Datail(string PC_ID, string P_ID, string Quantity, string Buy_Price, string Total_Amount)
        {
            try
            {
                string New_Item = "Insert Into Purchase_Details(PC_ID,P_ID,Quantity,Buy_Price,Total_Price) Values('" + PC_ID + "','" + P_ID + "','" + Quantity + "','" + Buy_Price + "','" + Total_Amount + "');";
                con.Open();
                cmd = new SqlCommand(New_Item, con);
                cmd.ExecuteNonQuery();
                con.Close();
            }

            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                if (con.State == ConnectionState.Open)
                {
                    con.Close();
                }

            }

        }


        public void Purchase_Amount(string PC_ID, string Total_paid, float Balance, string Grand_Total)
        {
            try
            {
                string New_Item = "Insert Into Purchase_Amount(PC_ID,Total_Paid,Balance, Grand_Total) Values('" + PC_ID + "','" + Total_paid + "','" + Balance + "','" + Grand_Total + "');";
                con.Open();
                cmd = new SqlCommand(New_Item, con);
                cmd.ExecuteNonQuery();
                con.Close();
            }

            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                if (con.State == ConnectionState.Open)
                {
                    con.Close();
                }

            }

        }












        public void Bank( string B_Name, string B_Address,string B_Phone,string Phone1, string B_Note)
        {


            try
            {
                string expense = "Insert Into Bank(B_Name,B_Address,B_Phone,B_Phone1,B_Note) Values('" + B_Name + "','" + B_Address + "','" + B_Phone + "','" + Phone1 + "','" + B_Note + "');";
                con.Open();
                cmd = new SqlCommand(expense, con);
                cmd.ExecuteNonQuery();
                con.Close();
            }

            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
                if (con.State == ConnectionState.Open)
                {
                    con.Close();
                }

            }

        }


        public void Take_From_Bank(string B_ID, string E_ID, string What_For, string Quantity, string Date)
        {


            try
            {
                string expense = "Insert Into [Take_From_Bank]([B_ID],[E_ID],[What_For],[Quantity],[Date]) Values('" + B_ID + "','" + E_ID + "','" + What_For + "','" + Quantity + "','" + Date + "');";
                con.Open();
                cmd = new SqlCommand(expense, con);
                cmd.ExecuteNonQuery();
                con.Close();
            }

            catch
            {
                if (con.State == ConnectionState.Open)
                {
                    con.Close();
                }

            }

        }

        public void Pay_To_Bank(string B_ID, string E_ID, string What_For, string Quantity, string Date)
        {


            try
            {
                string expense = "Insert Into [Pay_To_Bank]([B_ID],[E_ID],[What_For],[Quantity],[Date]) Values('" + B_ID + "','" + E_ID + "','" + What_For + "','" + Quantity + "','" + Date + "');";
                con.Open();
                cmd = new SqlCommand(expense, con);
                cmd.ExecuteNonQuery();
                con.Close();
            }

            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
                if (con.State == ConnectionState.Open)
                {
                    con.Close();
                }

            }

        }



        public void Paid_Money(string E_ID, string Quantity, string What_For,  string Date)
        {


            try
            {
                string expense = "Insert Into [Paid_Money]([E_ID],[Quantity],[What_For],[Date]) Values('" + E_ID + "','" + Quantity + "','" + What_For + "','" + Date + "');";
                con.Open();
                cmd = new SqlCommand(expense, con);
                cmd.ExecuteNonQuery();
                con.Close();
            }
            
            catch(Exception ex)
            {

                MessageBox.Show(ex.Message);
                if (con.State == ConnectionState.Open)
                {
                    con.Close();
                }

            }

        }


        public void Pay_To_Supplier(string S_ID, string What_For, string Quantity, string Date)
        {


            try
            {
                string expense = "Insert Into [Pay_To_Supplier]([S_ID],[What_For],[Quantity],[Date]) Values('" + S_ID + "','" + What_For + "','" + Quantity + "','" + Date + "');";
                con.Open();
                cmd = new SqlCommand(expense, con);
                cmd.ExecuteNonQuery();
                con.Close();
            }

            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
                if (con.State == ConnectionState.Open)
                {
                    con.Close();
                }

            }

        }

        public void Money_On_Customer(string C_ID, string What_For, string Quantity, string Date)
        {


            try
            {
                string expense = "Insert Into [Money_On_Customer]([C_ID],[What_For],[Quantity],[Date]) Values('" + C_ID + "','" + What_For + "','" + Quantity + "','" + Date + "');";
                con.Open();
                cmd = new SqlCommand(expense, con);
                cmd.ExecuteNonQuery();
                con.Close();
            }

            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
                if (con.State == ConnectionState.Open)
                {
                    con.Close();
                }

            }

        }

















        // -----------------------------------------------حذف------------------------------------------------- Deleting------------------------------------------------------------------------------Function\\



        // -------------------------------------- Deleting New Customer Data-------------------------------Function\\
        public void Delete_Customer(string Delete_ID)
        {
            try
            {
                string AddNewCustomer = "Delete From Customer where C_ID =  " + Delete_ID;
                con.Open();
                cmd = new SqlCommand(AddNewCustomer, con);
                cmd.ExecuteNonQuery();
                con.Close();
            }

            catch
            {
                if (con.State == ConnectionState.Open)
                {
                    con.Close();
                }

            }

        }

        // ------------------------------حذف-------- Deleting Employee-------------------------------Function\\
        public void Delete_Employee(string Delete_ID)
        {
            try
            {
                string Delete_employee = "Delete From Employee where E_ID =  " + Delete_ID;
                con.Open();
                cmd = new SqlCommand(Delete_employee, con);
                cmd.ExecuteNonQuery();
                con.Close();
            }

            catch
            {
                if (con.State == ConnectionState.Open)
                {
                    con.Close();
                }

            }

        }
        // ------------------------------حذف-------- Deleting Expenses-------------------------------Function\\
        public void Delete_Expenses(string Delete_ID)
        {
            try
            {
                string Delete = "Delete From Expenses where Ex_ID =  " + Delete_ID;
                con.Open();
                cmd = new SqlCommand(Delete, con);
                cmd.ExecuteNonQuery();
                con.Close();
            }

            catch
            {
                if (con.State == ConnectionState.Open)
                {
                    con.Close();
                }

            }

        }

        public void Delete_Invoice_new_item(string Delete_ID)
        {
            try
            {
                string Delete = "Delete From Invoice_Details where I_D_ID =  " + Delete_ID;
                con.Open();
                cmd = new SqlCommand(Delete, con);
                cmd.ExecuteNonQuery();
                con.Close();
            }

            catch
            {
                if (con.State == ConnectionState.Open)
                {
                    con.Close();
                }

            }

        }

        public void Delete_Invoice_new_All_items(string Delete_ID)
        {
            try
            {
                string Delete = "DELETE FROM Invoice_Details WHERE I_ID IN (SELECT I_D FROM somewhere_else) =" + Delete_ID;
                con.Open();
                cmd = new SqlCommand(Delete, con);
                cmd.ExecuteNonQuery();
                con.Close();
            }

            catch
            {
                if (con.State == ConnectionState.Open)
                {
                    con.Close();
                }

            }

        }


        public void Delete_Product(string Delete_AddedProducts)
        {
            try
            {
                string Delete1 = "Delete FROM Product where P_IDD = "+Delete_AddedProducts;
                con.Open();
                cmd = new SqlCommand(Delete1, con);
                cmd.ExecuteNonQuery();
                con.Close();
            }

            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
                if (con.State == ConnectionState.Open)
                {
                    con.Close();
                }

            }
        }


        public void Delete_Supplier(string Delete_Supplier)
        {
            try
            {
                string Delete = "Delete From Supplier where S_ID =" + Delete_Supplier;
                con.Open();
                cmd = new SqlCommand(Delete, con);
                cmd.ExecuteNonQuery();
                con.Close();
            }

            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                if (con.State == ConnectionState.Open)
                {
                    con.Close();
                }

            }
        }

        public void Delete_Given_Loan(string Delete_Products)
        {
            try
            {
                string AddNewCustomer = "Delete From Given_Loan where G_L_ID =  " + Delete_Products;
                con.Open();
                cmd = new SqlCommand(AddNewCustomer, con);
                cmd.ExecuteNonQuery();
                con.Close();
            }

            catch
            {
                if (con.State == ConnectionState.Open)
                {
                    con.Close();
                }

            }
        }


        public void Delete_Taken_Loan(string Delete_Products)
        {
            try
            {
                string AddNewCustomer = "Delete From Taken_loan where T_L_ID =  " + Delete_Products;
                con.Open();
                cmd = new SqlCommand(AddNewCustomer, con);
                cmd.ExecuteNonQuery();
                con.Close();
            }

            catch
            {
                if (con.State == ConnectionState.Open)
                {
                    con.Close();
                }

            }
        }

        public void Delete_Pay_To_Supplier(string Delete_Products)
        {
            try
            {
                string AddNewCustomer = "Delete From Pay_To_Supplier where P_T_S_ID =  " + Delete_Products;
                con.Open();
                cmd = new SqlCommand(AddNewCustomer, con);
                cmd.ExecuteNonQuery();
                con.Close();
            }

            catch
            {
                if (con.State == ConnectionState.Open)
                {
                    con.Close();
                }

            }
        }

        public void Delete_Past_Taken_Loan(string Delete_Products)
        {
            try
            {
                string AddNewCustomer = "Delete From Money_On_Customer where P_T_C_ID =  " + Delete_Products;
                con.Open();
                cmd = new SqlCommand(AddNewCustomer, con);
                cmd.ExecuteNonQuery();
                con.Close();
            }

            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                if (con.State == ConnectionState.Open)
                {
                    con.Close();
                }

            }
        }


        public void Delete_Widrow(string Delete_Products)
        {
            try
            {
                string AddNewCustomer = "Delete From Withdraw where W_ID =  " + Delete_Products;
                con.Open();
                cmd = new SqlCommand(AddNewCustomer, con);
                cmd.ExecuteNonQuery();
                con.Close();
            }

            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                if (con.State == ConnectionState.Open)
                {
                    con.Close();
                }

            }
        }



        public void Delete_Paid_money(string Delete_Products)
        {
            try
            {
                string AddNewCustomer = "Delete From Paid_Money where Paid_ID =  " + Delete_Products;
                con.Open();
                cmd = new SqlCommand(AddNewCustomer, con);
                cmd.ExecuteNonQuery();
                con.Close();
            }

            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                if (con.State == ConnectionState.Open)
                {
                    con.Close();
                }

            }
        }



    public void Delete_Bank(string Delete_Products)
        {
            try
            {
                string AddNewCustomer = "Delete From Bank where B_ID =  " + Delete_Products;
                con.Open();
                cmd = new SqlCommand(AddNewCustomer, con);
                cmd.ExecuteNonQuery();
                con.Close();
            }

            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                if (con.State == ConnectionState.Open)
                {
                    con.Close();
                }

            }
        }

        public void Delete_Pay_To_Bank(string Delete_Products)
        {
            try
            {
                string AddNewCustomer = "Delete From Pay_To_Bank where P_T_Bank =  " + Delete_Products;
                con.Open();
                cmd = new SqlCommand(AddNewCustomer, con);
                cmd.ExecuteNonQuery();
                con.Close();
            }

            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                if (con.State == ConnectionState.Open)
                {
                    con.Close();
                }

            }
        }


        public void Delete_Take_From_Bank(string Delete_Products)
        {
            try
            {
                string AddNewCustomer = "Delete From Take_From_Bank where T_F_Bank_ID =  " + Delete_Products;
                con.Open();
                cmd = new SqlCommand(AddNewCustomer, con);
                cmd.ExecuteNonQuery();
                con.Close();
            }

            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                if (con.State == ConnectionState.Open)
                {
                    con.Close();
                }

            }
        }



        public void Delete_Purchase_Product(string Delete_Products)
        {
       
            try
            {
                string Delete = "Delete From Purchase_Details where P_D_ID =  " + Delete_Products;
                con.Open();
                cmd = new SqlCommand(Delete, con);
                cmd.ExecuteNonQuery();
                con.Close();
            }

            catch
            {
                if (con.State == ConnectionState.Open)
                {
                    con.Close();
                }

            }

        
    }


        // ------------------------------------------------------------------------------------------------ Searching------------------------------------------------------------------------------Function\\


        // ------------------------------------------------------------------------------ DataGridView Search Box------------------------------------------------------Function\\
        public void searchData(String Path, String Field, String SearchT)
        {
            string query = "Select * from " + Path;
            cmd = new SqlCommand(query, con);
            SQLDA = new SqlDataAdapter(cmd);
            DT = new DataTable();
            SQLDA.Fill(DT);
            DV = new DataView(DT);
            DV.RowFilter = string.Format(Field + " LIKE '%{0}%'", SearchT);

        }











    }
}
