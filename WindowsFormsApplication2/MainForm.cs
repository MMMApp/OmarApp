using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Configuration;
using System.Data.SqlClient;

using System.Web;


namespace WindowsFormsApplication2
{

    public partial class MainForm : Form
    {

        // --------------------------------------------------Class Access---------------------------------\\
        DataAccess DataAccess = new DataAccess();

        // --------------------------------------------------Class Access---------------------------------\\


        public MainForm()
        {

            InitializeComponent();
            AutotComplete_NewMoneyTGTAB();
            AutoComplete_SupplierLoanTab();
            AutoComplete_CustomerLoanTap();
            AutoComlete_Invoice_Product_ID();
            AutoComplete_Bank();
        }



        // --------------------------------------------------Customers and New Customer Tabs---------------------------------\\

        private void Customer_New_Click(object sender, EventArgs e)
        {
            MainTabs.SelectedIndex = 3;
        }







        private void Supplier_Cancel_Click(object sender, EventArgs e)
        {


            if (this.Product_list_Data_grideView.SelectedRows.Count == 1)
            {
                try
                {

                    DialogResult dialogResult = MessageBox.Show("آیا مخواهید مورد انتخاب شده را حذف نماید ", "حذف کردن", MessageBoxButtons.YesNo);
                    if (dialogResult == DialogResult.Yes)
                    {
                        DataGridViewRow dr = Product_list_Data_grideView.SelectedRows[0];
                        Delete_pro.Text = dr.Cells[0].Value.ToString();
                        // or simply use column name instead of index
                        //dr.Cells["id"].Value.ToString();
                        Delete_Product();
                        foreach (DataGridViewRow item in this.Product_list_Data_grideView.SelectedRows)
                        {
                            Product_list_Data_grideView.Rows.RemoveAt(item.Index);
                        }
                    }
                    else if (dialogResult == DialogResult.No)
                    {
                    }
                   
                }

                catch (Exception)
                {
                    MessageBox.Show("لطفا  روح را انتخاب کنید");
                }
            }
            else
            {
                MessageBox.Show("لطفا روح را انتخاب کنید");
            }



        }

        private void Customer_Remove_Click(object sender, EventArgs e)
        {
            if (this.D_G_V_Customer.SelectedRows.Count == 1)
            {
                try
                {

                    DialogResult dialogResult = MessageBox.Show("آیا مخواهید مورد انتخاب شده را حذف نماید ", "حذف کردن", MessageBoxButtons.YesNo);
                    if (dialogResult == DialogResult.Yes)
                    {
                        DataGridViewRow dr = D_G_V_Customer.SelectedRows[0];
                        Delete_C_ID.Text = dr.Cells[0].Value.ToString();
                        // or simply use column name instead of index
                        //dr.Cells["id"].Value.ToString();
                        Delete_Customer();
                        foreach (DataGridViewRow item in this.D_G_V_Customer.SelectedRows)
                        {
                            D_G_V_Customer.Rows.RemoveAt(item.Index);
                        }
                    }
                    else if (dialogResult == DialogResult.No)
                    {
                    }
                    DataAccess.RunQuery("Select C_ID As[آید مشتری], C_Name as [نام مشتری], C_Location as [آدرس], C_Phone as [شماره تماس] from Customer");
                    D_G_V_Customer.DataSource = DataAccess.Dataset.Tables[0];
                }

                catch (Exception)
                {
                    MessageBox.Show("لطفا  روح را انتخاب کنید");
                }
            }
            else
            {
                MessageBox.Show("لطفا روح را انتخاب کنید");
            }
        }


        private void Customers_Refresh_Click(object sender, EventArgs e)
        {
            DataAccess.RunQuery("Select C_ID As[آید مشتری], C_Name as [نام مشتری], C_Location as [آدرس], C_Phone as [شماره تماس] from Customer");
            D_G_V_Customer.DataSource = DataAccess.Dataset.Tables[0];
            Color clr = ColorTranslator.FromHtml("#f7fafc");
            Color fclr = ColorTranslator.FromHtml("#8d99a6");
            Color sclr = ColorTranslator.FromHtml("#f7fafc");
            D_G_V_Customer.ColumnHeadersDefaultCellStyle.BackColor = clr;
            D_G_V_Customer.ColumnHeadersDefaultCellStyle.ForeColor = fclr;

            D_G_V_Customer.EnableHeadersVisualStyles = false;
            D_G_V_Customer.ColumnHeadersDefaultCellStyle.Font = new Font("Adobe Arabic", 17F, FontStyle.Bold);
        }


        private void Back_Customers_Click(object sender, EventArgs e)
        {
            MainTabs.SelectedIndex = 1;
        }


        private void NewCustomer_Save_Click(object sender, EventArgs e)
        {

            if (string.IsNullOrWhiteSpace(N_C_Name.Text))
            {
                MessageBox.Show("جای نام مشتری خالی است");
            }

            else
            {
                AddNewCustomer();
                N_C_Name.Clear();
                N_C_Phone.Clear();
                N_C_Address.Clear();
                MessageBox.Show("ثبت موفق بود");

            }


        }


        private void NewCustomer_Cancel_Click(object sender, EventArgs e)
        {
            N_C_Name.Clear();
            N_C_Phone.Clear();
            N_C_Address.Clear();
        }


        private void Customer_Invoice_Click(object sender, EventArgs e)
        {
            AutoComplete_CustomerLoanTap();
            MainTabs.SelectedIndex = 5;
        }

        private void Back_NewCustomer_Click(object sender, EventArgs e)
        {
            AutoComplete_CustomerLoanTap();
            MainTabs.SelectedIndex = 2;
            DataAccess.RunQuery("Select C_ID As[آید مشتری], C_Name as [نام مشتری], C_Location as [آدرس], C_Phone as [شماره تماس] from Customer");
            D_G_V_Customer.DataSource = DataAccess.Dataset.Tables[0];
        }



        // -------------------------------------- Adding INTO Customers Method-------------------------------Function\\
   

        private void D_G_V_Customer_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void flowLayoutPanel6_Paint(object sender, PaintEventArgs e)
        {

        }

        static void D_G_V_Customer_CellContentClick_1(object sender, DataGridViewCellEventArgs e)
        {

        }

      
        // --------------------------------------------------Invoices And New Invoice Tabs---------------------------------\\

        private void Invoices_New_Click(object sender, EventArgs e)
        {


           

                get_last_ID();
            AutoComlete_Invoice_Product_ID();
            MainTabs.SelectedIndex = 5;


        }






        // ----------------------------------------------------------------------------Search Boxes-----------------------------------------------------------------\\


        private void SearchT_Customer_TextChanged(object sender, EventArgs e)
        {
            DataAccess.searchData("Select C_ID As[آید مشتری], C_Name as [نام مشتری], C_Location as [آدرس], C_Phone as [شماره تماس] from Customer", "[نام مشتری]", SearchT_Customer.Text);
            D_G_V_Customer.DataSource = DataAccess.DV;
        }

        private void SearchT_Invoice_TextChanged(object sender, EventArgs e)
        {
            DataAccess.searchData("Select C_ID As[آید مشتری], C_Name as [نام مشتری], C_Location as [آدرس], C_Phone as [شماره تماس] from Customer", "[نام مشتری]", SearchT_Invoice.Text);
            D_G_V_Customer.DataSource = DataAccess.DV;
        }

        private void SearchT_Employee_TextChanged(object sender, EventArgs e)
        {
            DataAccess.searchData("Select E_ID as [آیدی],E_Name As[نام], [F/Name] [نام پدر], E_Phone_1 as [نمبر تلیفون 1], E_Phone_2 as [نمبر تلیفون 2], E_Location as [آدرس],Income as [ماش] from Employee", "[نام]", SearchT_Employee.Text);
            D_G_V_Employee.DataSource = DataAccess.DV;
        }

        private void SearchT_Expenses_TextChanged(object sender, EventArgs e)
        {
            DataAccess.searchData("SELECT Ex_ID as[آید مصرف],[EX_Name] as [از درک ],Quantity[مقدار ], Date as[تاریخ] FROM [MobileData].[dbo].[Expenses]", "[از درک ]", SearchT_Expenses.Text);
            Expenses_Data_GrideView.DataSource = DataAccess.DV;
        }

        private void SearchT_Items_TextChanged(object sender, EventArgs e)
        {

            DataAccess.searchData("Select P_IDD AS [Me], P_ID As[آید جنس], P_Name as [نام جنس], P_Color as [رنگ], P_Made as [ساخت ] from Product", "[آید جنس]", SearchT_Items.Text);
            Product_list_Data_grideView.DataSource = DataAccess.DV;
        }

        private void SearchT_Suppliers_TextChanged(object sender, EventArgs e)
        {
            DataAccess.searchData("Select S_ID As[آید تهیه کننده], S_Name as [نام تهیه کننده], S_Location as [آدرس], S_Phone as [شماره تماس], S_E_Mail as [ایمل آدرس] from Supplier", "[نام تهیه کننده]", SearchT_Suppliers.Text);
            dataGridView1.DataSource = DataAccess.DV;
        }

        private void SearchT_Purchases_TextChanged(object sender, EventArgs e)
        {
            DataAccess.searchData("Select C_ID As[آید مشتری], C_Name as [نام مشتری], C_Location as [آدرس], C_Phone as [شماره تماس] from Customer", "[نام مشتری]", SearchT_Purchases.Text);
            dataGridView10.DataSource = DataAccess.DV;
        }

        private void SearchT_Banks_TextChanged(object sender, EventArgs e)
        {
            DataAccess.searchData("SELECT B_ID as [آیدی], B_Name as [نام بانک], B_Address [آدرس ], B_Phone as [شماره تماس 1], B_Phone1 as [شماره تماس 2], B_Note as[نوت]FROM Bank ", "[نام بانک]", SearchT_Banks.Text);
            Bank_DataGridView.DataSource = DataAccess.DV;
        }

        private void SearchT_OCL_TextChanged(object sender, EventArgs e)
        {
            DataAccess.searchData("SELECT P_T_C_ID as[آیدی],[C_Name] as [نام مشتری], MO.Quantity as [مقدار], MO.What_For as [از درک], Mo.Date as[تاریخ] FROM [MobileData].[dbo].[Customer] as C Join [MobileData].[dbo].[Money_On_Customer] as MO on MO.C_ID = c.C_ID", "[نام مشتری]", SearchT_OCL.Text);
            On_Customer_Money_Pay_DataGrideView.DataSource = DataAccess.DV;
        }

        private void SearchT_OSL_TextChanged(object sender, EventArgs e)
        {
            DataAccess.searchData("SELECT P_T_S_ID as[آیدی قرض],s.S_Name as [نام تهیه کننده], PTS.Quantity as [مقدار], PTS.What_For as [از درک], PTS.Date as[تاریخ] FROM [MobileData].[dbo].[Supplier] as s Join [MobileData].[dbo].[Pay_To_Supplier] as PTS on PTS.S_ID = S.S_ID", "[نام تهیه کننده]", SearchT_OSL.Text);
            Pay_To_Supplier_DataGriveView.DataSource = DataAccess.DV;
        }

        private void SearchT_TB_TextChanged(object sender, EventArgs e)
        {
            DataAccess.searchData("SELECT T.T_F_Bank_ID as [آید برداشت],B.B_Name[نام بانک],E.E_Name as [نام مشتری],T.Quantity[مقدار], T.What_For as [از درک],  T.Date as[تاریخ] FROM Employee as E Join Take_From_Bank as T on T.E_ID = E.E_ID Join Bank as B on T.B_ID = B.B_ID", "[نام مشتری]", SearchT_TB.Text);
            Take_From_Bank_DataGrideView.DataSource = DataAccess.DV;
        }

        private void SearchT_GB_TextChanged(object sender, EventArgs e)
        {
            DataAccess.searchData("SELECT P.P_T_Bank as[آید پرداخت],B.B_Name[نام بانک],E.E_Name as [نام مشتری],P.Quantity[مقدار], P.What_For as [از درک],  P.Date as[تاریخ] FROM Employee as E Join Pay_To_Bank as P on P.E_ID = E.E_ID Join Bank as B on P.B_ID = B.B_ID", "[نام مشتری]", SearchT_GB.Text);
            dataGridView4.DataSource = DataAccess.DV;
        }

        private void SearchT_CL_TextChanged(object sender, EventArgs e)
        {
            DataAccess.searchData("SELECT G_L_ID as[آید پرداخت],[C_Name] as [نام مشتری], G_Pay_Loan as [مقدار],  G_L_Date as[تاریخ] FROM [MobileData].[dbo].[Customer] as C Join [MobileData].[dbo].[Given_Loan] as G on G.C_ID = C.C_ID", "[نام مشتری]", SearchT_CL.Text);
            Given_loan_DataGrideView.DataSource = DataAccess.DV;
        }

        private void SearchT_SL_TextChanged(object sender, EventArgs e)
        {
            DataAccess.searchData("SELECT T_L_ID as[آید پرداخت],[S_Name] as [نام مشتری],PC_ID[بیل نمبر], T_Pay_Loan as [مقدار],  T_L_Date as[تاریخ] FROM [MobileData].[dbo].[Supplier] as S Join [MobileData].[dbo].[Taken_Loan] as T on T.S_ID = S.S_ID", "[نام مشتری]", SearchT_SL.Text);
            Taken_Loan_DataGrideView.DataSource = DataAccess.DV;
        }

        private void SearchT_EmployeeG_TextChanged(object sender, EventArgs e)
        {
            DataAccess.searchData("SELECT Paid_ID as[آید پرداخت],[E_Name] as [نام مشتری],Quantity[مقدار], What_For as [از درک],  Date as[تاریخ] FROM [MobileData].[dbo].[Employee] as E Join [MobileData].[dbo].[Paid_Money] as P on P.E_ID = E.E_ID", "[نام مشتری]", SearchT_EmployeeG.Text);
            Paid_Loan_DataGrideView.DataSource = DataAccess.DV;
        }

        private void SearchT_EmployeeT_TextChanged(object sender, EventArgs e)
        {
            DataAccess.searchData("SELECT W_ID as[آید برداشت],[E_Name] as [نام مشتری],Quantity[مقدار], What_For as [از درک],  Date as[تاریخ] FROM [MobileData].[dbo].[Employee] as E Join [MobileData].[dbo].[Withdraw] as W on W.E_ID = E.E_ID", "[نام مشتری]", SearchT_EmployeeT.Text);
            Taken_Money_DataGrideView.DataSource = DataAccess.DV;
        }






        // -------------------------------------- Back Buttons ------------------------------- \\

        private void button45_Click(object sender, EventArgs e)
        {
            MainTabs.SelectedIndex = 30;
        }

        private void button34_Click(object sender, EventArgs e)
        {
            MainTabs.SelectedIndex = 29;
        }

        private void button44_Click(object sender, EventArgs e)
        {
            MainTabs.SelectedIndex = 12;
        }

        private void button33_Click(object sender, EventArgs e)
        {
            MainTabs.SelectedIndex = 12;
        }

        private void button50_Click(object sender, EventArgs e)
        {
            MainTabs.SelectedIndex = 34;
        }

        private void button54_Click(object sender, EventArgs e)
        {
            MainTabs.SelectedIndex = 35;
        }

        private void button53_Click(object sender, EventArgs e)
        {
            MainTabs.SelectedIndex = 31;
        }

        private void button49_Click(object sender, EventArgs e)
        {
            MainTabs.SelectedIndex = 31;
        }

        private void button28_Click(object sender, EventArgs e)
        {
            MainTabs.SelectedIndex = 44;
        }

        private void button58_Click(object sender, EventArgs e)
        {
            MainTabs.SelectedIndex = 13;
        }

        private void button62_Click(object sender, EventArgs e)
        {
            MainTabs.SelectedIndex = 14;
        }

        private void button61_Click(object sender, EventArgs e)
        {
            MainTabs.SelectedIndex = 12;
        }

        private void button57_Click(object sender, EventArgs e)
        {
            MainTabs.SelectedIndex = 12;
        }
        private void Back_TGOptions_Click(object sender, EventArgs e)
        {
            MainTabs.SelectedIndex = 15;
        }

        private void Back_EGR_Click(object sender, EventArgs e)
        {
            MainTabs.SelectedIndex = 36;
        }

        private void Back_ETR_Click(object sender, EventArgs e)
        {
            MainTabs.SelectedIndex = 36;
        }

        private void BackItemReturn_Click_1(object sender, EventArgs e)
        {
            MainTabs.SelectedIndex = 1;
        }
        private void Back_BMgm_Click(object sender, EventArgs e)
        {
            MainTabs.SelectedIndex = 15;
        }

        private void Back_TGBank_Click(object sender, EventArgs e)
        {
            MainTabs.SelectedIndex = 31;
        }

        private void Back_NBank_Click(object sender, EventArgs e)
        {
            MainTabs.SelectedIndex = 32;
        }

        private void Back_TkBank_Click(object sender, EventArgs e)
        {
            MainTabs.SelectedIndex = 40;
        }

        private void Back_GVBank_Click(object sender, EventArgs e)
        {
            MainTabs.SelectedIndex = 41;
        }

        private void Back_Sales_Click(object sender, EventArgs e)
        {
            MainTabs.SelectedIndex = 0;
        }


        private void Back_NewInvoice_Click(object sender, EventArgs e)
        {
            MainTabs.SelectedIndex = 4;
        }


        private void Invoices_Back_Click(object sender, EventArgs e)
        {
            MainTabs.SelectedIndex = 1;
        }



        private void BackItemReturn_Click(object sender, EventArgs e)
        {
            MainTabs.SelectedIndex = 1;
        }


        private void BackLoanTab_Click(object sender, EventArgs e)
        {
            MainTabs.SelectedIndex = 0;
        }
        private void Back_Suppliers_Click(object sender, EventArgs e)
        {
            DataAccess.RunQuery("Select S_ID As[آید تهیه کننده], S_Name as [نام تهیه کننده], S_Location as [آدرس], S_Phone as [شماره تماس], S_E_Mail as [ایمل آدرس] from Supplier");
            dataGridView1.DataSource = DataAccess.Dataset.Tables[0];
            MainTabs.SelectedIndex = 7;
        }

        private void Back_PurchaseInvoice_Click(object sender, EventArgs e)
        {
            MainTabs.SelectedIndex = 7;
        }

        private void Back_OCL_Click(object sender, EventArgs e)
        {
            MainTabs.SelectedIndex = 38;
        }

        private void Back_OSL_Click(object sender, EventArgs e)
        {
            MainTabs.SelectedIndex = 39;
        }
        private void Back_CustomerLoanTab_Click(object sender, EventArgs e)
        {
            MainTabs.SelectedIndex = 42;
        }

        private void BackPurchaseItemReturn_Click(object sender, EventArgs e)
        {
            MainTabs.SelectedIndex = 7;
        }

        private void Back_SupplierLoanTab_Click(object sender, EventArgs e)
        {
            MainTabs.SelectedIndex = 43;
        }


        private void Back_NewEmployee_Click(object sender, EventArgs e)
        {
            MainTabs.SelectedIndex = 16;
        }


        private void Back_EmployeesTab_Click(object sender, EventArgs e)
        {
            MainTabs.SelectedIndex = 15;
        }

        private void Back_ManagementTab_Click(object sender, EventArgs e)
        {
            MainTabs.SelectedIndex = 0;
        }



        private void Back_ExpensesTab_Click(object sender, EventArgs e)
        {
            MainTabs.SelectedIndex = 15;
        }


        private void Back_NewMoneyTG_Click(object sender, EventArgs e)
        {
            MainTabs.SelectedIndex = 45;
        }


        private void Back_MoneyTGTab_Click(object sender, EventArgs e)
        {
            MainTabs.SelectedIndex = 15;
        }

        private void Back_NewExpense_Click(object sender, EventArgs e)
        {
            MainTabs.SelectedIndex = 18;
        }

        private void PurchasesReturn_Click(object sender, EventArgs e)
        {
            MainTabs.SelectedIndex = 0;
        }

        private void PurchaseInvoiceReturn_Click(object sender, EventArgs e)
        {
            MainTabs.SelectedIndex = 28;
        }

        private void Back_StockReports_Click(object sender, EventArgs e)
        {
            MainTabs.SelectedIndex = 0;
        }

        private void Back_LoandReports_Click(object sender, EventArgs e)
        {
            MainTabs.SelectedIndex = 0;
        }

        private void Back_PSReports_Click(object sender, EventArgs e)
        {
            MainTabs.SelectedIndex = 0;
        }

        private void Back_Supplier_Click(object sender, EventArgs e)
        {
            MainTabs.SelectedIndex = 7;
        }
        private void Back_GReport_Click(object sender, EventArgs e)
        {
            MainTabs.SelectedIndex = 0;
        }


        private void Back_ETR_MouseDown(object sender, MouseEventArgs e)
        {
            Back_ETR.BackgroundImage = Properties.Resources.BackS;
        }

        private void Back_ETR_MouseEnter(object sender, EventArgs e)
        {
            Back_ETR.BackgroundImage = Properties.Resources.BackH;
        }

        private void Back_ETR_MouseLeave(object sender, EventArgs e)
        {
            Back_ETR.BackgroundImage = Properties.Resources.Back;
        }

        private void Back_ETR_MouseUp(object sender, MouseEventArgs e)
        {
            Back_ETR.BackgroundImage = Properties.Resources.Back;
        }

        private void Back_EGR_MouseDown(object sender, MouseEventArgs e)
        {
            Back_EGR.BackgroundImage = Properties.Resources.BackS;
        }

        private void Back_EGR_MouseEnter(object sender, EventArgs e)
        {
            Back_EGR.BackgroundImage = Properties.Resources.BackH;
        }

        private void Back_EGR_MouseLeave(object sender, EventArgs e)
        {
            Back_EGR.BackgroundImage = Properties.Resources.Back;
        }

        private void Back_EGR_MouseUp(object sender, MouseEventArgs e)
        {
            Back_EGR.BackgroundImage = Properties.Resources.Back;
        }

        private void button61_MouseDown(object sender, MouseEventArgs e)
        {
            Back_SLR.BackgroundImage = Properties.Resources.BackS;
        }

        private void button61_MouseEnter(object sender, EventArgs e)
        {
            Back_SLR.BackgroundImage = Properties.Resources.BackH;
        }

        private void button61_MouseLeave(object sender, EventArgs e)
        {
            Back_SLR.BackgroundImage = Properties.Resources.Back;
        }

        private void button61_MouseUp(object sender, MouseEventArgs e)
        {
            Back_SLR.BackgroundImage = Properties.Resources.Back;
        }

        private void Back_CLR_MouseDown(object sender, MouseEventArgs e)
        {
            Back_CLR.BackgroundImage = Properties.Resources.BackS;
        }

        private void Back_CLR_MouseEnter(object sender, EventArgs e)
        {
            Back_CLR.BackgroundImage = Properties.Resources.BackH;
        }

        private void Back_CLR_MouseLeave(object sender, EventArgs e)
        {
            Back_CLR.BackgroundImage = Properties.Resources.Back;
        }

        private void Back_CLR_MouseUp(object sender, MouseEventArgs e)
        {
            Back_CLR.BackgroundImage = Properties.Resources.Back;
        }

        private void button53_MouseDown(object sender, MouseEventArgs e)
        {
            button53.BackgroundImage = Properties.Resources.BackS;
        }

        private void button53_MouseEnter(object sender, EventArgs e)
        {
            button53.BackgroundImage = Properties.Resources.BackH;
        }

        private void button53_MouseLeave(object sender, EventArgs e)
        {
            button53.BackgroundImage = Properties.Resources.Back;
        }

        private void button53_MouseUp(object sender, MouseEventArgs e)
        {
            button53.BackgroundImage = Properties.Resources.Back;
        }

        private void button49_MouseDown(object sender, MouseEventArgs e)
        {
            button49.BackgroundImage = Properties.Resources.BackS;
        }

        private void button49_MouseEnter(object sender, EventArgs e)
        {
            button49.BackgroundImage = Properties.Resources.BackH;
        }

        private void button49_MouseLeave(object sender, EventArgs e)
        {
            button49.BackgroundImage = Properties.Resources.Back;
        }

        private void button49_MouseUp(object sender, MouseEventArgs e)
        {
            button49.BackgroundImage = Properties.Resources.Back;
        }

        private void button44_MouseDown(object sender, MouseEventArgs e)
        {
            button44.BackgroundImage = Properties.Resources.BackS;
        }

        private void button44_MouseEnter(object sender, EventArgs e)
        {
            button44.BackgroundImage = Properties.Resources.BackH;
        }

        private void button44_MouseLeave(object sender, EventArgs e)
        {
            button44.BackgroundImage = Properties.Resources.Back;
        }

        private void button44_MouseUp(object sender, MouseEventArgs e)
        {
            button44.BackgroundImage = Properties.Resources.Back;
        }

        private void button33_MouseDown(object sender, MouseEventArgs e)
        {
            button33.BackgroundImage = Properties.Resources.BackS;
        }

        private void button33_MouseEnter(object sender, EventArgs e)
        {
            button33.BackgroundImage = Properties.Resources.BackH;
        }

        private void button33_MouseLeave(object sender, EventArgs e)
        {
            button33.BackgroundImage = Properties.Resources.Back;
        }

        private void button33_MouseUp(object sender, MouseEventArgs e)
        {
            button33.BackgroundImage = Properties.Resources.Back;
        }

        private void button28_MouseDown(object sender, MouseEventArgs e)
        {
            button28.BackgroundImage = Properties.Resources.BackS;
        }

        private void button28_MouseEnter(object sender, EventArgs e)
        {
            button28.BackgroundImage = Properties.Resources.BackH;
        }

        private void button28_MouseLeave(object sender, EventArgs e)
        {
            button28.BackgroundImage = Properties.Resources.Back;
        }

        private void button28_MouseUp(object sender, MouseEventArgs e)
        {
            button28.BackgroundImage = Properties.Resources.Back;
        }

        private void Back_TGOptions_MouseDown(object sender, MouseEventArgs e)
        {
            Back_TGOptions.BackgroundImage = Properties.Resources.BackS;
        }

        private void Back_TGOptions_MouseEnter(object sender, EventArgs e)
        {
            Back_TGOptions.BackgroundImage = Properties.Resources.BackH;
        }

        private void Back_TGOptions_MouseLeave(object sender, EventArgs e)
        {
            Back_TGOptions.BackgroundImage = Properties.Resources.Back;
        }

        private void Back_TGOptions_MouseUp(object sender, MouseEventArgs e)
        {
            Back_TGOptions.BackgroundImage = Properties.Resources.Back;
        }


        private void Back_Customers_MouseDown(object sender, MouseEventArgs e)
        {
            Back_Customers.BackgroundImage = Properties.Resources.BackS;
        }

        private void Back_Customers_MouseEnter(object sender, EventArgs e)
        {
            Back_Customers.BackgroundImage = Properties.Resources.BackH;
        }

        private void Back_Customers_MouseLeave(object sender, EventArgs e)
        {
            Back_Customers.BackgroundImage = Properties.Resources.Back;
        }

        private void Back_Customers_MouseUp(object sender, MouseEventArgs e)
        {
            Back_Customers.BackgroundImage = Properties.Resources.Back;
        }

        private void Back_NewCustomer_MouseDown(object sender, MouseEventArgs e)
        {
            Back_NewCustomer.BackgroundImage = Properties.Resources.BackS;
        }

        private void Back_NewCustomer_MouseEnter(object sender, EventArgs e)
        {
            Back_NewCustomer.BackgroundImage = Properties.Resources.BackH;
        }

        private void Back_NewCustomer_MouseLeave(object sender, EventArgs e)
        {
            Back_NewCustomer.BackgroundImage = Properties.Resources.Back;
        }

        private void Back_NewCustomer_MouseUp(object sender, MouseEventArgs e)
        {
            Back_NewCustomer.BackgroundImage = Properties.Resources.Back;
        }

        private void Invoices_Back_MouseDown(object sender, MouseEventArgs e)
        {
            Invoices_Back.BackgroundImage = Properties.Resources.BackS;
        }

        private void Invoices_Back_MouseEnter(object sender, EventArgs e)
        {
            Invoices_Back.BackgroundImage = Properties.Resources.BackH;
        }

        private void Invoices_Back_MouseLeave(object sender, EventArgs e)
        {
            Invoices_Back.BackgroundImage = Properties.Resources.Back;
        }

        private void Invoices_Back_MouseUp(object sender, MouseEventArgs e)
        {
            Invoices_Back.BackgroundImage = Properties.Resources.Back;
        }

        private void Back_NewInvoice_MouseDown(object sender, MouseEventArgs e)
        {
            Back_NewInvoice.BackgroundImage = Properties.Resources.BackS;
        }

        private void Back_NewInvoice_MouseEnter(object sender, EventArgs e)
        {
            Back_NewInvoice.BackgroundImage = Properties.Resources.BackH;
        }

        private void Back_NewInvoice_MouseLeave(object sender, EventArgs e)
        {
            Back_NewInvoice.BackgroundImage = Properties.Resources.Back;
        }

        private void Back_NewInvoice_MouseUp(object sender, MouseEventArgs e)
        {
            Back_NewInvoice.BackgroundImage = Properties.Resources.Back;
        }

        private void BackItemReturn_MouseDown(object sender, MouseEventArgs e)
        {
            BackItemReturn.BackgroundImage = Properties.Resources.BackS;
        }

        private void BackItemReturn_MouseEnter(object sender, EventArgs e)
        {
            BackItemReturn.BackgroundImage = Properties.Resources.BackH;
        }

        private void BackItemReturn_MouseLeave(object sender, EventArgs e)
        {
            BackItemReturn.BackgroundImage = Properties.Resources.Back;
        }

        private void BackItemReturn_MouseUp(object sender, MouseEventArgs e)
        {
            BackItemReturn.BackgroundImage = Properties.Resources.Back;
        }

        private void Back_Purchases_MouseDown(object sender, MouseEventArgs e)
        {
            Back_Purchases.BackgroundImage = Properties.Resources.BackS;
        }

        private void Back_Purchases_MouseEnter(object sender, EventArgs e)
        {
            Back_Purchases.BackgroundImage = Properties.Resources.BackH;
        }

        private void Back_Purchases_MouseLeave(object sender, EventArgs e)
        {
            Back_Purchases.BackgroundImage = Properties.Resources.Back;
        }

        private void Back_Purchases_MouseUp(object sender, MouseEventArgs e)
        {
            Back_Purchases.BackgroundImage = Properties.Resources.Back;
        }

        private void NewItemReturn_MouseDown(object sender, MouseEventArgs e)
        {
            NewItemReturn.BackgroundImage = Properties.Resources.BackS;
        }

        private void NewItemReturn_MouseEnter(object sender, EventArgs e)
        {
            NewItemReturn.BackgroundImage = Properties.Resources.BackH;
        }

        private void NewItemReturn_MouseLeave(object sender, EventArgs e)
        {
            NewItemReturn.BackgroundImage = Properties.Resources.Back;
        }

        private void NewItemReturn_MouseUp(object sender, MouseEventArgs e)
        {
            NewItemReturn.BackgroundImage = Properties.Resources.Back;
        }

        private void NewSupplierItem_MouseDown(object sender, MouseEventArgs e)
        {
            NewSupplierItem.BackgroundImage = Properties.Resources.BackS;
        }

        private void NewSupplierItem_MouseEnter(object sender, EventArgs e)
        {
            NewSupplierItem.BackgroundImage = Properties.Resources.BackH;
        }

        private void NewSupplierItem_MouseLeave(object sender, EventArgs e)
        {
            NewSupplierItem.BackgroundImage = Properties.Resources.Back;
        }

        private void NewSupplierItem_MouseUp(object sender, MouseEventArgs e)
        {
            NewSupplierItem.BackgroundImage = Properties.Resources.Back;
        }

        private void PurchaseInvoiceReturn_MouseDown(object sender, MouseEventArgs e)
        {
            PurchaseInvoiceReturn.BackgroundImage = Properties.Resources.BackS;
        }

        private void PurchaseInvoiceReturn_MouseEnter(object sender, EventArgs e)
        {
            PurchaseInvoiceReturn.BackgroundImage = Properties.Resources.BackH;
        }

        private void PurchaseInvoiceReturn_MouseLeave(object sender, EventArgs e)
        {
            PurchaseInvoiceReturn.BackgroundImage = Properties.Resources.Back;
        }

        private void PurchaseInvoiceReturn_MouseUp(object sender, MouseEventArgs e)
        {
            PurchaseInvoiceReturn.BackgroundImage = Properties.Resources.Back;
        }

        private void BackPurchaseItemReturn_MouseDown(object sender, MouseEventArgs e)
        {
            BackPurchaseItemReturn.BackgroundImage = Properties.Resources.BackS;
        }

        private void BackPurchaseItemReturn_MouseEnter(object sender, EventArgs e)
        {
            BackPurchaseItemReturn.BackgroundImage = Properties.Resources.BackH;
        }

        private void BackPurchaseItemReturn_MouseLeave(object sender, EventArgs e)
        {
            BackPurchaseItemReturn.BackgroundImage = Properties.Resources.Back;
        }

        private void BackPurchaseItemReturn_MouseUp(object sender, MouseEventArgs e)
        {
            BackPurchaseItemReturn.BackgroundImage = Properties.Resources.Back;
        }



        private void Back_LoansTab_MouseDown(object sender, MouseEventArgs e)
        {
            Back_LoansTab.BackgroundImage = Properties.Resources.BackS;
        }

        private void Back_LoansTab_MouseEnter(object sender, EventArgs e)
        {
            Back_LoansTab.BackgroundImage = Properties.Resources.BackH;
        }

        private void Back_LoansTab_MouseLeave(object sender, EventArgs e)
        {
            Back_LoansTab.BackgroundImage = Properties.Resources.Back;
        }

        private void Back_LoansTab_MouseUp(object sender, MouseEventArgs e)
        {
            Back_LoansTab.BackgroundImage = Properties.Resources.Back;
        }

        private void Back_SupplierLoanTab_MouseDown(object sender, MouseEventArgs e)
        {
            Back_SupplierLoanTab.BackgroundImage = Properties.Resources.BackS;
        }

        private void Back_SupplierLoanTab_MouseEnter(object sender, EventArgs e)
        {
            Back_SupplierLoanTab.BackgroundImage = Properties.Resources.BackH;
        }

        private void Back_SupplierLoanTab_MouseLeave(object sender, EventArgs e)
        {
            Back_SupplierLoanTab.BackgroundImage = Properties.Resources.Back;
        }

        private void Back_SupplierLoanTab_MouseUp(object sender, MouseEventArgs e)
        {
            Back_SupplierLoanTab.BackgroundImage = Properties.Resources.Back;
        }

        private void Back_ManagementTab_MouseDown(object sender, MouseEventArgs e)
        {
            Back_ManagementTab.BackgroundImage = Properties.Resources.BackS;
        }

        private void Back_ManagementTab_MouseEnter(object sender, EventArgs e)
        {
            Back_ManagementTab.BackgroundImage = Properties.Resources.BackH;
        }

        private void Back_ManagementTab_MouseLeave(object sender, EventArgs e)
        {
            Back_ManagementTab.BackgroundImage = Properties.Resources.Back;
        }

        private void Back_ManagementTab_MouseUp(object sender, MouseEventArgs e)
        {
            Back_ManagementTab.BackgroundImage = Properties.Resources.Back;
        }

        private void Back_EmployeesTab_MouseDown(object sender, MouseEventArgs e)
        {
            Back_EmployeesTab.BackgroundImage = Properties.Resources.BackS;
        }

        private void Back_EmployeesTab_MouseEnter(object sender, EventArgs e)
        {
            Back_EmployeesTab.BackgroundImage = Properties.Resources.BackH;
        }

        private void Back_EmployeesTab_MouseLeave(object sender, EventArgs e)
        {
            Back_EmployeesTab.BackgroundImage = Properties.Resources.Back;
        }

        private void Back_EmployeesTab_MouseUp(object sender, MouseEventArgs e)
        {
            Back_EmployeesTab.BackgroundImage = Properties.Resources.Back;
        }

        private void Back_NewEmployee_MouseDown(object sender, MouseEventArgs e)
        {
            Back_NewEmployee.BackgroundImage = Properties.Resources.BackS;
        }

        private void Back_NewEmployee_MouseEnter(object sender, EventArgs e)
        {
            Back_NewEmployee.BackgroundImage = Properties.Resources.BackH;
        }

        private void Back_NewEmployee_MouseLeave(object sender, EventArgs e)
        {
            Back_NewEmployee.BackgroundImage = Properties.Resources.Back;
        }

        private void Back_NewEmployee_MouseUp(object sender, MouseEventArgs e)
        {
            Back_NewEmployee.BackgroundImage = Properties.Resources.Back;
        }

        private void Back_ExpensesTab_MouseDown(object sender, MouseEventArgs e)
        {
            Back_ExpensesTab.BackgroundImage = Properties.Resources.BackS;
        }

        private void Back_ExpensesTab_MouseEnter(object sender, EventArgs e)
        {
            Back_ExpensesTab.BackgroundImage = Properties.Resources.BackH;
        }

        private void Back_ExpensesTab_MouseLeave(object sender, EventArgs e)
        {
            Back_ExpensesTab.BackgroundImage = Properties.Resources.Back;
        }

        private void Back_ExpensesTab_MouseUp(object sender, MouseEventArgs e)
        {
            Back_ExpensesTab.BackgroundImage = Properties.Resources.Back;
        }
        private void Back_Sales_MouseDown(object sender, MouseEventArgs e)
        {
            Back_Sales.BackgroundImage = Properties.Resources.BackS;
        }

        private void Back_Sales_MouseEnter(object sender, EventArgs e)
        {
            Back_Sales.BackgroundImage = Properties.Resources.BackH;
        }

        private void Back_Sales_MouseLeave(object sender, EventArgs e)
        {
            Back_Sales.BackgroundImage = Properties.Resources.Back;
        }
        private void Back_Sales_MouseUp(object sender, MouseEventArgs e)
        {
            Back_Sales.BackgroundImage = Properties.Resources.Back;
        }

        private void Back_CustomerLoanTab_MouseDown(object sender, MouseEventArgs e)
        {
            Back_CustomerLoanTab.BackgroundImage = Properties.Resources.BackS;
        }

        private void Back_CustomerLoanTab_MouseEnter(object sender, EventArgs e)
        {
            Back_CustomerLoanTab.BackgroundImage = Properties.Resources.BackH;
        }

        private void Back_CustomerLoanTab_MouseLeave(object sender, EventArgs e)
        {
            Back_CustomerLoanTab.BackgroundImage = Properties.Resources.Back;
        }

        private void Back_CustomerLoanTab_MouseUp(object sender, MouseEventArgs e)
        {
            Back_CustomerLoanTab.BackgroundImage = Properties.Resources.Back;
        }

        private void Back_NewExpense_MouseDown(object sender, MouseEventArgs e)
        {
            Back_NewExpense.BackgroundImage = Properties.Resources.BackS;
        }

        private void Back_NewExpense_MouseEnter(object sender, EventArgs e)
        {
            Back_NewExpense.BackgroundImage = Properties.Resources.BackH;
        }

        private void Back_NewExpense_MouseLeave(object sender, EventArgs e)
        {
            Back_NewExpense.BackgroundImage = Properties.Resources.Back;
        }

        private void Back_NewExpense_MouseUp(object sender, MouseEventArgs e)
        {
            Back_NewExpense.BackgroundImage = Properties.Resources.Back;
        }


        private void Back_NewMoneyTG_MouseDown(object sender, MouseEventArgs e)
        {
            Back_NewMoneyTG.BackgroundImage = Properties.Resources.BackS;
        }

        private void Back_NewMoneyTG_MouseEnter(object sender, EventArgs e)
        {
            Back_NewMoneyTG.BackgroundImage = Properties.Resources.BackH;
        }

        private void Back_NewMoneyTG_MouseLeave(object sender, EventArgs e)
        {
            Back_NewMoneyTG.BackgroundImage = Properties.Resources.Back;
        }

        private void Back_NewMoneyTG_MouseUp(object sender, MouseEventArgs e)
        {
            Back_NewMoneyTG.BackgroundImage = Properties.Resources.Back;
        }

        private void Back_StockReports_MouseDown(object sender, MouseEventArgs e)
        {
            Back_StockReports.BackgroundImage = Properties.Resources.BackS;
        }

        private void Back_StockReports_MouseEnter(object sender, EventArgs e)
        {
            Back_StockReports.BackgroundImage = Properties.Resources.BackH;
        }

        private void Back_StockReports_MouseLeave(object sender, EventArgs e)
        {
            Back_StockReports.BackgroundImage = Properties.Resources.Back;
        }

        private void Back_StockReports_MouseUp(object sender, MouseEventArgs e)
        {
            Back_StockReports.BackgroundImage = Properties.Resources.Back;
        }

        private void Back_LoandReports_MouseDown(object sender, MouseEventArgs e)
        {
            Back_LoandReports.BackgroundImage = Properties.Resources.BackS;
        }

        private void Back_LoandReports_MouseEnter(object sender, EventArgs e)
        {
            Back_LoandReports.BackgroundImage = Properties.Resources.BackH;
        }

        private void Back_LoandReports_MouseLeave(object sender, EventArgs e)
        {
            Back_LoandReports.BackgroundImage = Properties.Resources.Back;
        }

        private void Back_LoandReports_MouseUp(object sender, MouseEventArgs e)
        {
            Back_LoandReports.BackgroundImage = Properties.Resources.Back;
        }

        private void Back_PSReports_MouseDown(object sender, MouseEventArgs e)
        {
            Back_PSReports.BackgroundImage = Properties.Resources.BackS;
        }

        private void Back_PSReports_MouseEnter(object sender, EventArgs e)
        {
            Back_PSReports.BackgroundImage = Properties.Resources.BackH;
        }

        private void Back_PSReports_MouseLeave(object sender, EventArgs e)
        {
            Back_PSReports.BackgroundImage = Properties.Resources.Back;
        }

        private void Back_PSReports_MouseUp(object sender, MouseEventArgs e)
        {
            Back_PSReports.BackgroundImage = Properties.Resources.Back;
        }

        private void Back_Supplier_MouseDown(object sender, MouseEventArgs e)
        {
            Back_Supplier.BackgroundImage = Properties.Resources.BackS;
        }

        private void Back_Supplier_MouseEnter(object sender, EventArgs e)
        {
            Back_Supplier.BackgroundImage = Properties.Resources.BackH;
        }

        private void Back_Supplier_MouseLeave(object sender, EventArgs e)
        {
            Back_Supplier.BackgroundImage = Properties.Resources.Back;
        }

        private void Back_Supplier_MouseUp(object sender, MouseEventArgs e)
        {
            Back_Supplier.BackgroundImage = Properties.Resources.Back;
        }

        private void Back_GReport_MouseDown(object sender, MouseEventArgs e)
        {
            Back_GReport.BackgroundImage = Properties.Resources.BackS;
        }

        private void Back_GReport_MouseEnter(object sender, EventArgs e)
        {
            Back_GReport.BackgroundImage = Properties.Resources.BackH;
        }

        private void Back_GReport_MouseLeave(object sender, EventArgs e)
        {
            Back_GReport.BackgroundImage = Properties.Resources.Back;
        }

        private void Back_GReport_MouseUp(object sender, MouseEventArgs e)
        {
            Back_GReport.BackgroundImage = Properties.Resources.Back;
        }

        private void Back_OCL_MouseDown(object sender, MouseEventArgs e)
        {
            Back_OCL.BackgroundImage = Properties.Resources.BackS;
        }

        private void Back_OCL_MouseEnter(object sender, EventArgs e)
        {
            Back_OCL.BackgroundImage = Properties.Resources.BackH;
        }

        private void Back_OCL_MouseLeave(object sender, EventArgs e)
        {
            Back_OCL.BackgroundImage = Properties.Resources.Back;
        }

        private void Back_OCL_MouseUp(object sender, MouseEventArgs e)
        {
            Back_OCL.BackgroundImage = Properties.Resources.Back;
        }

        private void Back_OSL_MouseDown(object sender, MouseEventArgs e)
        {
            Back_OSL.BackgroundImage = Properties.Resources.BackS;
        }

        private void Back_OSL_MouseEnter(object sender, EventArgs e)
        {
            Back_OSL.BackgroundImage = Properties.Resources.BackH;
        }

        private void Back_OSL_MouseLeave(object sender, EventArgs e)
        {
            Back_OSL.BackgroundImage = Properties.Resources.Back;
        }

        private void Back_OSL_MouseUp(object sender, MouseEventArgs e)
        {
            Back_OSL.BackgroundImage = Properties.Resources.Back;
        }

        private void Back_BMgm_MouseDown(object sender, MouseEventArgs e)
        {
            Back_BMgm.BackgroundImage = Properties.Resources.BackS;
        }

        private void Back_BMgm_MouseEnter(object sender, EventArgs e)
        {
            Back_BMgm.BackgroundImage = Properties.Resources.BackH;
        }

        private void Back_BMgm_MouseLeave(object sender, EventArgs e)
        {
            Back_BMgm.BackgroundImage = Properties.Resources.Back;
        }

        private void Back_BMgm_MouseUp(object sender, MouseEventArgs e)
        {
            Back_BMgm.BackgroundImage = Properties.Resources.Back;
        }

        private void Back_TGBank_MouseDown(object sender, MouseEventArgs e)
        {
            Back_TGBank.BackgroundImage = Properties.Resources.BackS;
        }

        private void Back_TGBank_MouseEnter(object sender, EventArgs e)
        {
            Back_TGBank.BackgroundImage = Properties.Resources.BackH;
        }

        private void Back_TGBank_MouseLeave(object sender, EventArgs e)
        {
            Back_TGBank.BackgroundImage = Properties.Resources.Back;
        }

        private void Back_TGBank_MouseUp(object sender, MouseEventArgs e)
        {
            Back_TGBank.BackgroundImage = Properties.Resources.Back;
        }

        private void Back_NBank_MouseDown(object sender, MouseEventArgs e)
        {
            Back_NBank.BackgroundImage = Properties.Resources.BackS;
        }

        private void Back_NBank_MouseEnter(object sender, EventArgs e)
        {
            Back_NBank.BackgroundImage = Properties.Resources.BackH;
        }

        private void Back_NBank_MouseLeave(object sender, EventArgs e)
        {
            Back_NBank.BackgroundImage = Properties.Resources.Back;
        }

        private void Back_NBank_MouseUp(object sender, MouseEventArgs e)
        {
            Back_NBank.BackgroundImage = Properties.Resources.Back;
        }

        private void Back_TkBank_MouseDown(object sender, MouseEventArgs e)
        {
            Back_TkBank.BackgroundImage = Properties.Resources.BackS;
        }

        private void Back_TkBank_MouseEnter(object sender, EventArgs e)
        {
            Back_TkBank.BackgroundImage = Properties.Resources.BackH;
        }

        private void Back_TkBank_MouseLeave(object sender, EventArgs e)
        {
            Back_TkBank.BackgroundImage = Properties.Resources.Back;
        }

        private void Back_TkBank_MouseUp(object sender, MouseEventArgs e)
        {
            Back_TkBank.BackgroundImage = Properties.Resources.Back;
        }

        private void Back_GVBank_MouseDown(object sender, MouseEventArgs e)
        {
            Back_GVBank.BackgroundImage = Properties.Resources.BackS;
        }

        private void Back_GVBank_MouseEnter(object sender, EventArgs e)
        {
            Back_GVBank.BackgroundImage = Properties.Resources.BackH;
        }

        private void Back_GVBank_MouseLeave(object sender, EventArgs e)
        {
            Back_GVBank.BackgroundImage = Properties.Resources.Back;
        }

        private void Back_GVBank_MouseUp(object sender, MouseEventArgs e)
        {
            Back_GVBank.BackgroundImage = Properties.Resources.Back;
        }



        // --------------------------------------------------Sales Tab Buttons---------------------------------\\

        private void Customers_Click(object sender, EventArgs e)
        {
            MainTabs.SelectedIndex = 2;
            DataAccess.RunQuery("Select C_ID As[آید مشتری], C_Name as [نام مشتری], C_Location as [آدرس], C_Phone as [شماره تماس] from Customer");
            D_G_V_Customer.DataSource = DataAccess.Dataset.Tables[0];
        }

        private void Item_Return_Click(object sender, EventArgs e)
        {
            MainTabs.SelectedIndex = 6;
        }

        private void Invoices_Click(object sender, EventArgs e)
        {
            MainTabs.SelectedIndex = 4;
        }



        // --------------------------------------------------Purchases Tab Buttons---------------------------------\\

        private void Items_Click(object sender, EventArgs e)
        {
            MainTabs.SelectedIndex = 25;
            DataAccess.RunQuery("Select P_IDD AS [Me], P_ID As[آید جنس], P_Name as [نام جنس], P_Color as [رنگ], P_Made as [ساخت ] from Product");
            Product_list_Data_grideView.DataSource = DataAccess.Dataset.Tables[0];
            Product_list_Data_grideView.Columns[0].Visible = false;
        }

        private void Supplier_Click(object sender, EventArgs e)
        {
            DataAccess.RunQuery("Select S_ID As[آید تهیه کننده], S_Name as [نام تهیه کننده], S_Location as [آدرس], S_Phone as [شماره تماس], S_E_Mail as [ایمل آدرس] from Supplier");
            dataGridView1.DataSource = DataAccess.Dataset.Tables[0];
            MainTabs.SelectedIndex = 27;
        }


        private void PurchaseInvoice_Click(object sender, EventArgs e)
        {
            MainTabs.SelectedIndex = 28;
            
        }

        private void ReturnSuppliersItems_Click(object sender, EventArgs e)
        {
            MainTabs.SelectedIndex = 11;
        }
        private void Supplier_Add_Click(object sender, EventArgs e)
        {
            MainTabs.SelectedIndex = 8;
        }

        private void NewPurchaseInvoice_Click(object sender, EventArgs e)
        {
            MainTabs.SelectedIndex = 10;
            get_last_ID_Purchase();
        }
        // --------------------------------------------------ADD Buttons---------------------------------\\

        private void NewItemReturn_Click(object sender, EventArgs e)
        {
            MainTabs.SelectedIndex = 25;
        }

        private void NewSupplierItem_Click(object sender, EventArgs e)
        {
            DataAccess.RunQuery("Select S_ID As[آید تهیه کننده], S_Name as [نام تهیه کننده], S_Location as [آدرس], S_Phone as [شماره تماس], S_E_Mail as [ایمل آدرس] from Supplier");
            dataGridView1.DataSource = DataAccess.Dataset.Tables[0];
            MainTabs.SelectedIndex = 27;
        }

        private void NewEmployee_Click(object sender, EventArgs e)
        {
            MainTabs.SelectedIndex = 17;
        }

        private void NewExpenses_Click(object sender, EventArgs e)
        {
            MainTabs.SelectedIndex = 19;
        }

        private void NewMoneyTG_Click(object sender, EventArgs e)
        {
            MainTabs.SelectedIndex = 36;
        }

        private void Add_Supplier_Click(object sender, EventArgs e)
        {
            MainTabs.SelectedIndex = 9;
        }

        // --------------------------------------------------Loans Tabs Buttons---------------------------------\\

        private void CustomerLoan_Click(object sender, EventArgs e)
        {
            MainTabs.SelectedIndex = 42;

        }

        private void SupplierLoan_Click(object sender, EventArgs e)
        {
            MainTabs.SelectedIndex = 43;
        }

        private void OldCustomerLoan_Click(object sender, EventArgs e)
        {
            MainTabs.SelectedIndex = 38;
        }

        private void OldSupplierLoan_Click(object sender, EventArgs e)
        {
            MainTabs.SelectedIndex = 39;
        }

        // --------------------------------------------------Management Tab Buttons---------------------------------\\

        private void Employees_Click(object sender, EventArgs e)
        {
            MainTabs.SelectedIndex = 16;
            DataAccess.RunQuery("Select E_ID as [آیدی],E_Name As[نام], [F/Name] [نام پدر], E_Phone_1 as [نمبر تلیفون 1], E_Phone_2 as [نمبر تلیفون 2], E_Location as [آدرس],Income as [ماش] from Employee");
            D_G_V_Employee.DataSource = DataAccess.Dataset.Tables[0];
        }

        private void Expenses_Click(object sender, EventArgs e)
        {
            MainTabs.SelectedIndex = 18;
        }

        private void MoneyTG_Click(object sender, EventArgs e)
        {
            MainTabs.SelectedIndex = 36;
        }
        private void BankMGM_Click(object sender, EventArgs e)
        {
            MainTabs.SelectedIndex = 31;
        }

        private void Banks_Click(object sender, EventArgs e)
        {
            MainTabs.SelectedIndex = 32;
        }

        private void TkBank_Click(object sender, EventArgs e)
        {
            
            MainTabs.SelectedIndex = 40;
        }

        private void GVBank_Click(object sender, EventArgs e)
        {
            
            MainTabs.SelectedIndex = 41;
        }

        private void Add_Bank_Click(object sender, EventArgs e)
        {
            MainTabs.SelectedIndex = 33;
        }
        private void TKMoney_Click(object sender, EventArgs e)
        {
            MainTabs.SelectedIndex = 45;
        }

        private void GVMoney_Click(object sender, EventArgs e)
        {
            MainTabs.SelectedIndex = 44;
        }
        private void NewEG_Click(object sender, EventArgs e)
        {
            MainTabs.SelectedIndex = 37;
        }

        private void NewET_Click(object sender, EventArgs e)
        {
            MainTabs.SelectedIndex = 21;
        }

        // --------------------------------------------------MainPage Buttons---------------------------------\\

        private void Sales_MouseDown(object sender, MouseEventArgs e)
        {
            Sales.BackgroundImage = Properties.Resources.SalesS;
        }

        private void Sales_MouseEnter(object sender, EventArgs e)
        {
            Sales.BackgroundImage = Properties.Resources.SalesH;
        }

        private void Sales_MouseLeave(object sender, EventArgs e)
        {
            Sales.BackgroundImage = Properties.Resources.Sales;
        }

        private void Sales_MouseUp(object sender, MouseEventArgs e)
        {
            Sales.BackgroundImage = Properties.Resources.Sales;
        }

        private void Purchases_MouseDown(object sender, MouseEventArgs e)
        {
            Purchases.BackgroundImage = Properties.Resources.PurchasesS;
        }

        private void Purchases_MouseEnter(object sender, EventArgs e)
        {
            Purchases.BackgroundImage = Properties.Resources.PurchasesH;
        }

        private void Purchases_MouseLeave(object sender, EventArgs e)
        {
            Purchases.BackgroundImage = Properties.Resources.Purchases;
        }

        private void Purchases_MouseUp(object sender, MouseEventArgs e)
        {
            Purchases.BackgroundImage = Properties.Resources.Purchases;
        }

        private void Loans_MouseDown(object sender, MouseEventArgs e)
        {
            Loans.BackgroundImage = Properties.Resources.LoanS;
        }

        private void Loans_MouseEnter(object sender, EventArgs e)
        {
            Loans.BackgroundImage = Properties.Resources.LoanH;
        }

        private void Loans_MouseLeave(object sender, EventArgs e)
        {
            Loans.BackgroundImage = Properties.Resources.Loan;
        }

        private void Loans_MouseUp(object sender, MouseEventArgs e)
        {
            Loans.BackgroundImage = Properties.Resources.Loan;
        }

        private void Management_MouseDown(object sender, MouseEventArgs e)
        {
            Management.BackgroundImage = Properties.Resources.ManagementS;
        }

        private void Management_MouseEnter(object sender, EventArgs e)
        {
            Management.BackgroundImage = Properties.Resources.ManagementH;
        }

        private void Management_MouseLeave(object sender, EventArgs e)
        {
            Management.BackgroundImage = Properties.Resources.Management;
        }

        private void Management_MouseUp(object sender, MouseEventArgs e)
        {
            Management.BackgroundImage = Properties.Resources.Management;
        }

        private void StockReports_MouseDown(object sender, MouseEventArgs e)
        {
            StockReports.BackgroundImage = Properties.Resources.StockReportsS;
        }

        private void StockReports_MouseEnter(object sender, EventArgs e)
        {
            StockReports.BackgroundImage = Properties.Resources.StockReportsH;
        }

        private void StockReports_MouseLeave(object sender, EventArgs e)
        {
            StockReports.BackgroundImage = Properties.Resources.StockReports;
        }

        private void StockReports_MouseUp(object sender, MouseEventArgs e)
        {
            StockReports.BackgroundImage = Properties.Resources.StockReports;
        }

        private void LoanReports_MouseDown(object sender, MouseEventArgs e)
        {
            LoanReports.BackgroundImage = Properties.Resources.LoanReportsS;
        }

        private void LoanReports_MouseEnter(object sender, EventArgs e)
        {
            LoanReports.BackgroundImage = Properties.Resources.LoanReportsH;
        }

        private void LoanReports_MouseLeave(object sender, EventArgs e)
        {
            LoanReports.BackgroundImage = Properties.Resources.LoanReports;
        }

        private void LoanReports_MouseUp(object sender, MouseEventArgs e)
        {
            LoanReports.BackgroundImage = Properties.Resources.LoanReports;
        }

        private void SalesReports_MouseDown(object sender, MouseEventArgs e)
        {
            SalesReports.BackgroundImage = Properties.Resources.SalesReportS;
        }

        private void SalesReports_MouseEnter(object sender, EventArgs e)
        {
            SalesReports.BackgroundImage = Properties.Resources.SalesReportH;
        }

        private void SalesReports_MouseLeave(object sender, EventArgs e)
        {
            SalesReports.BackgroundImage = Properties.Resources.SalesReport;
        }

        private void SalesReports_MouseUp(object sender, MouseEventArgs e)
        {
            SalesReports.BackgroundImage = Properties.Resources.SalesReport;
        }

        private void GeneralReports_MouseDown(object sender, MouseEventArgs e)
        {
            GeneralReports.BackgroundImage = Properties.Resources.GeneralReportS;
        }

        private void GeneralReports_MouseEnter(object sender, EventArgs e)
        {
            GeneralReports.BackgroundImage = Properties.Resources.GeneralReportH;
        }

        private void GeneralReports_MouseLeave(object sender, EventArgs e)
        {
            GeneralReports.BackgroundImage = Properties.Resources.GeneralReport;
        }

        private void GeneralReports_MouseUp(object sender, MouseEventArgs e)
        {
            GeneralReports.BackgroundImage = Properties.Resources.GeneralReport;
        }
        private void Back_Suppliers_MouseDown(object sender, MouseEventArgs e)
        {
            Back_Suppliers.BackgroundImage = Properties.Resources.BackS;
        }

        private void Back_Suppliers_MouseEnter(object sender, EventArgs e)
        {
            Back_Suppliers.BackgroundImage = Properties.Resources.BackH;
        }

        private void Back_Suppliers_MouseLeave(object sender, EventArgs e)
        {
            Back_Suppliers.BackgroundImage = Properties.Resources.Back;
        }

        private void Back_Suppliers_MouseUp(object sender, MouseEventArgs e)
        {
            Back_Suppliers.BackgroundImage = Properties.Resources.Back;
        }

        private void Back_PurchaseInvoice_MouseDown(object sender, MouseEventArgs e)
        {
            Back_PurchaseInvoice.BackgroundImage = Properties.Resources.BackS;
        }

        private void Back_PurchaseInvoice_MouseEnter(object sender, EventArgs e)
        {
            Back_PurchaseInvoice.BackgroundImage = Properties.Resources.BackH;
        }

        private void Back_PurchaseInvoice_MouseLeave(object sender, EventArgs e)
        {
            Back_PurchaseInvoice.BackgroundImage = Properties.Resources.Back;
        }

        private void Back_PurchaseInvoice_MouseUp(object sender, MouseEventArgs e)
        {
            Back_PurchaseInvoice.BackgroundImage = Properties.Resources.Back;
        }

        private void Sales_Click(object sender, EventArgs e)
        {
            MainTabs.SelectedIndex = 1;
        }

        private void Purchases_Click(object sender, EventArgs e)
        {
            MainTabs.SelectedIndex = 7;
        }

        private void Loans_Click(object sender, EventArgs e)
        {
            MainTabs.SelectedIndex = 12;
        }

        private void Management_Click(object sender, EventArgs e)
        {
            MainTabs.SelectedIndex = 15;
        }

        private void StockReports_Click(object sender, EventArgs e)
        {
            MainTabs.SelectedIndex = 22;
        }

        private void LoanReports_Click(object sender, EventArgs e)
        {
            MainTabs.SelectedIndex = 23;
        }

        private void SalesReports_Click(object sender, EventArgs e)
        {
            MainTabs.SelectedIndex = 24;
        }

        private void GeneralReports_Click(object sender, EventArgs e)
        {
            MainTabs.SelectedIndex = 26;
        }



        // --------------------------------------------------









        // ------------------------------------------------------------=-------------------------- حذف  ------ classes---------------------------------------Function\\

        // -------------------------------------- حذف -----------------customer--------------Function\\
        public void Delete_Customer()
        {
            DataAccess.Delete_Customer(Delete_C_ID.Text);
        }
        // -------------------------------------- حذف میتود ------------------Expenses-------------Function\\
        public void Delete_Ex()
        {
            DataAccess.Delete_Expenses(Delete_Expenses_ID.Text);
        }
        // -------------------------------------- حذف میتود ------------------Employee-------------Function\\

        public void Delete_Employee()
        {
            DataAccess.Delete_Employee(Delete_T_Employee.Text);
        }
        // -------------------------------------- حذف میتود ------------------Employee-------------Function\\

        // -------------------------------------- حذف میتود ------------------product-------------Function\\
        public void Delete_Product()
        {
            DataAccess.Delete_Product(Delete_pro.Text);
        }

        // -------------------------------------- حذف میتود ------------------Invoice one item-------------Function\\

        public void Delete_New_Invoice_item()
        {
            DataAccess.Delete_Invoice_new_item(Delete_New_Invoice_Item.Text);
        }


        // -------------------------------------- حذف میتود ------------------Invoice all item-------------Function\\

        public void Delete_New_Invoice_Alitem()
        {
            DataAccess.Delete_Invoice_new_All_items(I_IDP_T_B_ID.Text);
        }



        public void Delete_Suppliers()
        {
            DataAccess.Delete_Supplier(Delete_Supplier_ID.Text);
        }


        public void Given_loan_Delete()
        {
            DataAccess.Delete_Given_Loan(Given_Loan_Delete_ID.Text);
        }
        public void Taken__loan_Delete()
        {
            DataAccess.Delete_Taken_Loan(Taken_Loan_Delete_ID.Text);
        }


        public void Taken_Past_Loan_Delete()
        {
            DataAccess.Delete_Past_Taken_Loan(Taken_PasT_Loan_Delete_ID.Text);
        }

        public void Delete_Pay_To_Supplier()
        {
            DataAccess.Delete_Pay_To_Supplier(Delete_Loan_Past_Delete_ID.Text);
        }


        public void Delete_Withrow()
        {
            DataAccess.Delete_Widrow(Withrow_Delete_ID.Text);
        }

        public void Delete_Paid_Money()
        {
            DataAccess.Delete_Paid_money(Paid_Delete_ID.Text);
        }
        public void Delete_Bank()
        {
            DataAccess.Delete_Bank(Bank_Delete_ID.Text);
        }
        public void Delete_payto_Bank()
        {
            DataAccess.Delete_Pay_To_Bank(Delete_Pay_To_Bank_ID.Text);
        }


        public void Delete_Take_From_Bank()
        {
            DataAccess.Delete_Take_From_Bank(Take_FromBank_ID.Text);
        }
        public void Delete_Purchase_Product()
        {
            DataAccess.Delete_Purchase_Product(Delete_Purchase_ID.Text);
        }

        // --------------------------------------------------Unsorted Buttons---------------------------------\\



        private void button18_Click(object sender, EventArgs e)
        {
            Form1 f1 = new Form1();
            f1.Show();
        }

        private void NewItemSave_Click(object sender, EventArgs e)
        {

            if (string.IsNullOrWhiteSpace(P_ID.Text))
            {
                MessageBox.Show("جای آیدی جنس  خالی است");
            }

            else if (string.IsNullOrWhiteSpace(P_Name.Text))
            {

                MessageBox.Show("جای آیدی جنس  خالی است");
               

            }
            else
            {
                New_Item();
                MessageBox.Show("ثبت موفق بود");
                P_ID.Clear();
                P_Name.Clear();
                P_Made.Clear();
                P_Color.Clear();
            }
        }

        private void NewItemCancel_Click(object sender, EventArgs e)
        {
            P_ID.Clear();
            P_Name.Clear();
            P_Made.Clear();
            P_Color.Clear();
        }




        // -----------------------------------------------------------------------adding Classes--------------------------------------------------------------\\

        public void AddNewCustomer()
        {
            DataAccess.Customer(N_C_Name.Text, N_C_Address.Text, N_C_Phone.Text);
        }

        public void TakingMoney()
        {
            string Date = Date_Money_Taking.Value.ToString("MM-dd-yyyy");
            // acs.Taking_Money(N_C_Name.Text, Quantity.Text, Date);
        }






        public void Expensess()

        {
            string Date = Date_Expenses.Value.ToShortDateString();
            DataAccess.Expense(Expenses_WhatFor.Text, EX_Quantity.Text, Date);
        }


        public void Employee()
        {
            DataAccess.Employee(E_T_Name.Text, E_T_Father_Name.Text, E_Phone_1.Text, E_Phone_2.Text, E_Address.Text, E_Payment.Text);
        }

        public void New_Supplier()
        {
            DataAccess.NewSupplier(S_Name.Text, S_Address.Text, S_Phone.Text, S_E_Mail.Text);
        }


        public void New_Item()
        {
            DataAccess.NewItem(P_ID.Text, P_Name.Text, P_Color.Text, P_Made.Text);

        }
        public void Withdraw()
        {
            string W_Date = Date_Money_Taking.Value.ToShortDateString();
            DataAccess.Withrow(W_ID.Text, Quantity.Text, Withrow_What_For.Text, W_Date);

        }
        public void Supplier_Loan()
        {
            string S_Date = Suplier_Date.Value.ToShortDateString();
            DataAccess.Supplier_Loan_Tab(Suplier_PC_ID.Text, S_L_ID.Text, S_Date, Suplier_pay_loan.Text);
        }
        public void Given_Loan()
        {
            string G_Date = Customer_Date.Value.ToShortDateString();
            DataAccess.Given_Loan(G_Loan_Invoice_ID.Text, Cutomer_Loan_ID.Text, G_Date, Given_pay_loan.Text);
        }

  
//--------------------------------------------------------------------------------Invoice Inerstion--------------------------------------------------------------------------
        public void Invoic_New()

        {
            try
            {
                //   int one = Convert.ToInt32(Invoice_Grand_Total.Text);
                //   int two = Convert.ToInt32(New_Invoice_TotalPaid.Text);
                // float balance = one - two;
                string Start_Date = New_invoice_Start_date.Value.ToShortDateString();
                string end_date = New_invoice_End_date.Value.ToShortDateString();
                DataAccess.New_Invoice(I_IDP_T_B_ID.Text, Customer_invoice_ID.Text, Start_Date, end_date);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }

        public void invoice_details()
        {

            DataAccess.New_Invoice_Datail(I_IDP_T_B_ID.Text, Invoice_Customer_Name_ID.Text, New_Invoice_quantity.Text, New_Invice_Price.Text, New_Invoice_TotalPrice.Text);
        }



        public void Invoice_Total_Amount()

        {
            try
            {
                int one = Convert.ToInt32(Invoice_Total_Grand.Text);
                  int two = Convert.ToInt32(New_Invoice_TotalPaid.Text);
                 float balance = one - two;
                
                DataAccess.New_Invoice_Amount(I_IDP_T_B_ID.Text, New_Invoice_TotalPaid.Text, balance, Invoice_Total_Grand.Text);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }





        /// <summary>
        /// /--------------------------------------------------Purchase Insertion Classes------------------------------------------------------------------------------------------
        /// </summary>
        public void Puchase_New()

        {
            try
            {
                //   int one = Convert.ToInt32(Invoice_Grand_Total.Text);
                //   int two = Convert.ToInt32(New_Invoice_TotalPaid.Text);
                // float balance = one - two;
                string Start_Date = Purchase_Start_Date.Value.ToShortDateString();
                string end_date = Purchase_End_Date.Value.ToShortDateString();
                DataAccess.New_Purchase(Puchase_ID.Text, Purchase_Selller_Name.Text, Start_Date, end_date);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }

        public void Puchase_details()
        {

            DataAccess.New_Purchase_Datail(Puchase_ID.Text, Purchase_Product_ID.Text, Purchase_Quantity.Text, Purchase_price.Text, Purchase_Total_price.Text);
        }



        public void Puchase_Total_Amount()

        {
            try
            {
                int one = Convert.ToInt32(Purchase_Total.Text);
                int two = Convert.ToInt32(purchase_Paid.Text);
                float balance = one - two;

                DataAccess.Purchase_Amount(Puchase_ID.Text, purchase_Paid.Text, balance, Purchase_Total.Text);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }

        //---------------------------------------------End oFFFFF-----Purchase Insertion Classes------------------------------------------------------------------------------------------




        public void Take_From_Bank()
        {
            string T_F_B_Date = Take_From_Bank_Date.Value.ToShortDateString();
            DataAccess.Take_From_Bank(T_F_B_ID.Text, T_F_B_E_ID.Text, T_F_B_What_For.Text, T_F_B_Quantity.Text, T_F_B_Date);
        }

        public void Bank()
        {
            
            DataAccess.Bank(B_Name.Text, B_Address.Text, B_Phone.Text, B_Phone1.Text, B_Note.Text);
        }

        public void Pay_To_Bank()
        {
            string P_T_B_Date = Take_From_Bank_Date.Value.ToShortDateString();
            DataAccess.Pay_To_Bank(P_T_B_ID.Text, P_T_B_E_ID.Text, P_T_B_What_For.Text, P_T_B_Quantity.Text, P_T_B_Date);
        }

        public void Paid_Money()
        {
            string P_M_Date = paid_Money_Date.Value.ToShortDateString();
            DataAccess.Paid_Money(P_M_ID.Text, P_M_Quantity.Text,P_M_What_For.Text, P_M_Date);
        }

        public void Pay_To_Supplier()
        {
            string P_T_S_Date = Pay_To_supplier_Date.Value.ToShortDateString();
            DataAccess.Pay_To_Supplier(P_T_S_ID.Text, P_T_S_What_For.Text, P_T_Quantity.Text, P_T_S_Date);
        }

        public void Money_on_Customer()
        {
            string O_C_Date = On_Customer_Date.Value.ToShortDateString();
            DataAccess.Money_On_Customer(O_C_ID.Text, O_C_What_For.Text, O_C_Quantity.Text, O_C_Date);
        }















        private void NewSupplierSave_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(S_Name.Text))
            {
                MessageBox.Show("جای اسم تهیه کننده خالی است");
            }

            else
            {
                New_Supplier();
                MessageBox.Show("ثبت موفق بود");
                S_Name.Clear();
                S_Phone.Clear();
                S_Address.Clear();
                S_E_Mail.Clear();

            }
        }

        private void CL_Save_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(Customer_Loan_Name.Text))
            {
                MessageBox.Show("جای اسم مشتری خالی است");
            }

            else
            {
                Given_Loan();
                MessageBox.Show("ثبت موفق بود");
                Customer_Loan_Name.Clear();
                G_Loan_Invoice_ID.Clear();
                Given_pay_loan.Clear();
               

            }
        }

        private void CL_Cancel_Click(object sender, EventArgs e)
        {
            Customer_Loan_Name.Clear();
            G_Loan_Invoice_ID.Clear();
            Given_pay_loan.Clear();
        }

        private void textBox51_TextChanged(object sender, EventArgs e)
        {

        }

        private void SL_Save_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(Supplier_Loan_Name.Text))
            {
                MessageBox.Show("جای اسم تهایه کننده خالی است");
            }

            else
            {
                Supplier_Loan();
                MessageBox.Show("ثبت موفق بود");
                Supplier_Loan_Name.Clear();
                S_L_ID.Clear();
                Suplier_PC_ID.Clear();
                Suplier_pay_loan.Clear();

            }
        }

        private void SL_Cancel_Click(object sender, EventArgs e)
        {
            Supplier_Loan_Name.Clear();
            S_L_ID.Clear();
            Suplier_PC_ID.Clear();
            Suplier_pay_loan.Clear();
        }




        private void button63_Click(object sender, EventArgs e)
        {

            if (this.Taken_Loan_DataGrideView.SelectedRows.Count == 1)
            {
                try
                {

                    DialogResult dialogResult = MessageBox.Show("آیا مخواهید مورد انتخاب شده را حذف نماید ", "حذف کردن", MessageBoxButtons.YesNo);
                    if (dialogResult == DialogResult.Yes)
                    {
                        DataGridViewRow dr = Taken_Loan_DataGrideView.SelectedRows[0];
                        Taken_Loan_Delete_ID.Text = dr.Cells[0].Value.ToString();
                        Taken__loan_Delete();
                        foreach (DataGridViewRow item in this.Taken_Loan_DataGrideView.SelectedRows)
                        {

                            Taken_Loan_DataGrideView.Rows.RemoveAt(item.Index);
                        }
                    }
                    else if (dialogResult == DialogResult.No)
                    {
                    }
                }

                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                    DataAccess.con.Close();
                    MessageBox.Show("لطفا  روح را انتخاب کنید");
                }
            }
            else
            {
                MessageBox.Show("لطفا روح را انتخاب کنید");

            }
            Taken_Loan_Delete_ID.Clear();
        }



        private void button59_Click(object sender, EventArgs e)
        {

            if (this.Given_loan_DataGrideView.SelectedRows.Count == 1)
            {
                try
                {

                    DialogResult dialogResult = MessageBox.Show("آیا مخواهید مورد انتخاب شده را حذف نماید ", "حذف کردن", MessageBoxButtons.YesNo);
                    if (dialogResult == DialogResult.Yes)
                    {
                        DataGridViewRow dr = Given_loan_DataGrideView.SelectedRows[0];
                        Given_Loan_Delete_ID.Text = dr.Cells[0].Value.ToString();
                        Given_loan_Delete();
                        foreach (DataGridViewRow item in this.Given_loan_DataGrideView.SelectedRows)
                        {

                            Given_loan_DataGrideView.Rows.RemoveAt(item.Index);
                        }
                    }
                    else if (dialogResult == DialogResult.No)
                    {
                    }
                }

                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                    DataAccess.con.Close();
                    MessageBox.Show("لطفا  روح را انتخاب کنید");
                }
            }
            else
            {
                MessageBox.Show("لطفا روح را انتخاب کنید");

            }
            Given_Loan_Delete_ID.Clear();
        }

        private void DeleteEmployee_Click(object sender, EventArgs e)
        {
            if (this.D_G_V_Employee.SelectedRows.Count == 1)
            {
                try
                {

                    DialogResult dialogResult = MessageBox.Show("آیا مخواهید مورد انتخاب شده را حذف نماید ", "حذف کردن", MessageBoxButtons.YesNo);
                    if (dialogResult == DialogResult.Yes)
                    {
                        DataGridViewRow dr = D_G_V_Employee.SelectedRows[0];
                        Delete_T_Employee.Text = dr.Cells[0].Value.ToString();
                        // or simply use column name instead of index
                        //dr.Cells["id"].Value.ToString();
                        Delete_Employee();
                        foreach (DataGridViewRow item in this.D_G_V_Employee.SelectedRows)
                        {
                            D_G_V_Employee.Rows.RemoveAt(item.Index);
                        }
                    }
                    else if (dialogResult == DialogResult.No)
                    {
                    }
                }

                catch (Exception)
                {
                    MessageBox.Show("لطفا  روح را انتخاب کنید");
                }
            }
            else
            {
                MessageBox.Show("لطفا روح را انتخاب کنید");
            }
        }

        private void RefreshEmployees_Click(object sender, EventArgs e)
        {
            DataAccess.RunQuery("Select E_ID as [آیدی],E_Name As[نام], [F/Name] [نام پدر], E_Phone_1 as [نمبر تلیفون 1], E_Phone_2 as [نمبر تلیفون 2], E_Location as [آدرس],Income as [ماش] from Employee");
            D_G_V_Employee.DataSource = DataAccess.Dataset.Tables[0];
        }

        private void NE_Save_Click(object sender, EventArgs e)
        {



            if (string.IsNullOrWhiteSpace(E_T_Name.Text))
            {
                MessageBox.Show("جای اسم مشتری خالی است");
            }

            else
            {
                Employee();
                MessageBox.Show("ثبت موفق بود");
                E_T_Father_Name.Clear();
                E_T_Name.Clear();
                E_Phone_1.Clear();
                E_Phone_2.Clear();
                E_Address.Clear();
                E_Payment.Clear();
            }
            AutotComplete_NewMoneyTGTAB();
        }
        
        private void NE_Cancel_Click(object sender, EventArgs e)
        {

        }

        private void NewExpense_Save_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(EX_Quantity.Text))
            {
                MessageBox.Show("جای مبلغ خالی است");
            }

            else
            {
                Expensess();
                MessageBox.Show("ثبت موفق بود");
                Expenses_WhatFor.Clear();
                EX_Quantity.Clear();
            }

        }

        private void D_G_V_Customer_CellContentClick_2(object sender, DataGridViewCellEventArgs e)
        {

        }



        // --------------------------------------------------Unsorted---------------------------------\\
        // --------------------------------------------------Unsorted---------------------------------\\
        // --------------------------------------------------Unsorted---------------------------------\\
        // --------------------------------------------------Unsorted---------------------------------\\
        // --------------------------------------------------Unsorted---------------------------------\\
        // --------------------------------------------------Unsorted---------------------------------\\
        // --------------------------------------------------Unsorted---------------------------------\\
        // --------------------------------------------------Unsorted---------------------------------\\

        // --------------------------------------------------Unsorted---------------------------------\\
        // --------------------------------------------------Unsorted---------------------------------\\

        // --------------------------------------------------Unsorted---------------------------------\\
        // --------------------------------------------------Unsorted---------------------------------\\

        // --------------------------------------------------Auto Complete Textbox---------------NewMoneyTGTAB------------------\\
        // --------------------------------------------------Auto Complete Textbox---------------NewMoneyTGTAB------------------\\
        // --------------------------------------------------Auto Complete Textbox---------------NewMoneyTGTAB------------------\\
        // --------------------------------------------------Auto Complete Textbox---------------NewMoneyTGTAB------------------\\
        // --------------------------------------------------Auto Complete Textbox---------------NewMoneyTGTAB------------------\\
        void AutotComplete_NewMoneyTGTAB()
        {
            string Query = "SELECT * FROM[MobileData].[dbo].[Employee]";
            Withrow_Name.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
            Withrow_Name.AutoCompleteSource = AutoCompleteSource.CustomSource;

            Paid_Money_Name.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
            Paid_Money_Name.AutoCompleteSource = AutoCompleteSource.CustomSource;


            Pay_to_Bank_emp_Name.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
            Pay_to_Bank_emp_Name.AutoCompleteSource = AutoCompleteSource.CustomSource;

            Take_F_B_Name.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
            Take_F_B_Name.AutoCompleteSource = AutoCompleteSource.CustomSource;
            AutoCompleteStringCollection coll = new AutoCompleteStringCollection();
            DataAccess.cmd = new SqlCommand(Query, DataAccess.con);





            DataView DV = new DataView(DataAccess.DT);
            DV.RowFilter = string.Format("E_Name LIKE '%N{0}%'", Withrow_Name.Text);
            DV.RowFilter = string.Format("E_Name LIKE '%N{0}%'", Paid_Money_Name.Text);
            DV.RowFilter = string.Format("E_Name LIKE '%N{0}%'", Pay_to_Bank_emp_Name.Text);
            DV.RowFilter = string.Format("E_Name LIKE '%N{0}%'", Take_F_B_Name.Text);
            try
            {
                DataAccess.con.Open();
               DataAccess.DR = DataAccess.cmd.ExecuteReader();

                while (DataAccess.DR.Read())
                {
                    string Name = Convert.ToString(DataAccess.DR["E_Name"]);
                    coll.Add(Name);
                }

                DataAccess.con.Close();
            }

            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                Withrow_Name.AutoCompleteCustomSource = coll;
                if (DataAccess.con.State == ConnectionState.Open)
                {
                    DataAccess.con.Close();
                }

            }

           
            Pay_to_Bank_emp_Name.AutoCompleteCustomSource = coll;
            Withrow_Name.AutoCompleteCustomSource = coll;
            Paid_Money_Name.AutoCompleteCustomSource = coll;
            Take_F_B_Name.AutoCompleteCustomSource = coll;
        }


        // --------------------------------------------------Auto Complete Textbox---------------SupplierLoanTab------------------\\

        void AutoComplete_SupplierLoanTab()
        {
            string Query = "SELECT * FROM[MobileData].[dbo].[Supplier]";
            Supplier_Loan_Name.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
            Supplier_Loan_Name.AutoCompleteSource = AutoCompleteSource.CustomSource;

            New_Supplier_Name.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
            New_Supplier_Name.AutoCompleteSource = AutoCompleteSource.CustomSource;

            Purchase_Item_Return_Name.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
            Purchase_Item_Return_Name.AutoCompleteSource = AutoCompleteSource.CustomSource;

            P_Supplier_name.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
            P_Supplier_name.AutoCompleteSource = AutoCompleteSource.CustomSource;


            AutoCompleteStringCollection coll = new AutoCompleteStringCollection();
            DataAccess.cmd = new SqlCommand(Query, DataAccess.con);

            DataView DV = new DataView(DataAccess.DT);
            DV.RowFilter = string.Format("S_Name LIKE '%N{0}%'", Supplier_Loan_Name.Text);
            DV.RowFilter = string.Format("S_Name LIKE '%N{0}%'", New_Supplier_Name.Text);
            DV.RowFilter = string.Format("S_Name LIKE '%N{0}%'", Purchase_Item_Return_Name.Text);
            DV.RowFilter = string.Format("S_Name LIKE '%N{0}%'", P_Supplier_name.Text);

            try
            {
                DataAccess.con.Open();
                DataAccess.DR = DataAccess.cmd.ExecuteReader();

                while (DataAccess.DR.Read())
                {
                    string Name = Convert.ToString(DataAccess.DR["S_Name"]);
                    coll.Add(Name);
                }

                DataAccess.con.Close();
            }

            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                Supplier_Loan_Name.AutoCompleteCustomSource = coll;
                New_Supplier_Name.AutoCompleteCustomSource = coll;
                Purchase_Item_Return_Name.AutoCompleteCustomSource = coll;
                if (DataAccess.con.State == ConnectionState.Open)
                {
                    DataAccess.con.Close();
                }

            }
            Supplier_Loan_Name.AutoCompleteCustomSource = coll;
            New_Supplier_Name.AutoCompleteCustomSource = coll;
            Purchase_Item_Return_Name.AutoCompleteCustomSource = coll;
            P_Supplier_name.AutoCompleteCustomSource = coll;
        }





        // --------------------------------------------------Auto Complete Textbox---------------Bank------------------\\
        // --------------------------------------------------Auto Complete Textbox---------------Bank------------------\\

        void AutoComplete_Bank()
        {
            string Query = "SELECT * FROM[MobileData].[dbo].[Bank]";
            Pay_To_Bank_Name.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
            Pay_To_Bank_Name.AutoCompleteSource = AutoCompleteSource.CustomSource;

            T_F_B_Name.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
            T_F_B_Name.AutoCompleteSource = AutoCompleteSource.CustomSource;

            AutoCompleteStringCollection coll = new AutoCompleteStringCollection();
            DataAccess.cmd = new SqlCommand(Query, DataAccess.con);

            DataView DV = new DataView(DataAccess.DT);
            DV.RowFilter = string.Format("B_Name LIKE '%N{0}%'", Pay_To_Bank_Name.Text);
            DV.RowFilter = string.Format("B_Name LIKE '%N{0}%'", T_F_B_Name.Text);


            try
            {
                DataAccess.con.Open();
                DataAccess.DR = DataAccess.cmd.ExecuteReader();

                while (DataAccess.DR.Read())
                {
                    string Name = Convert.ToString(DataAccess.DR["B_Name"]);
                    coll.Add(Name);
                }

                DataAccess.con.Close();
            }

            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                if (DataAccess.con.State == ConnectionState.Open)
                {
                    DataAccess.con.Close();
                }

            }
            Pay_To_Bank_Name.AutoCompleteCustomSource = coll;
            T_F_B_Name.AutoCompleteCustomSource = coll;
        }









        // --------------------------------------------------Auto Complete Textbox---------------CustomerLoanTap------------------\\
        // --------------------------------------------------Auto Complete Textbox---------------CustomerLoanTap------------------\\
        // --------------------------------------------------Auto Complete Textbox---------------CustomerLoanTap------------------\\

        void AutoComplete_CustomerLoanTap()
        {
            string Query = "SELECT * FROM[MobileData].[dbo].[Customer]";
            Customer_Loan_Name.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
            Customer_Loan_Name.AutoCompleteSource = AutoCompleteSource.CustomSource;

            New_Invoice_C_Name.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
            New_Invoice_C_Name.AutoCompleteSource = AutoCompleteSource.CustomSource;

            Item_return_Name.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
            Item_return_Name.AutoCompleteSource = AutoCompleteSource.CustomSource;


            T_F_C_Name.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
            T_F_C_Name.AutoCompleteSource = AutoCompleteSource.CustomSource;


            AutoCompleteStringCollection coll = new AutoCompleteStringCollection();
            DataAccess.cmd = new SqlCommand(Query, DataAccess.con);

            DataView DV = new DataView(DataAccess.DT);
            DV.RowFilter = string.Format("C_Name LIKE '%N{0}%'", Customer_Loan_Name.Text);
            DV.RowFilter = string.Format("C_Name LIKE '%N{0}%'", New_Invoice_C_Name.Text);
            DV.RowFilter = string.Format("C_Name LIKE '%N{0}%'", Item_return_Name.Text);
            DV.RowFilter = string.Format("C_Name LIKE '%N{0}%'", T_F_C_Name.Text);
            try
            {
                DataAccess.con.Open();
               DataAccess.DR = DataAccess.cmd.ExecuteReader();

                while (DataAccess.DR.Read())
                {
                    string Name = Convert.ToString(DataAccess.DR["C_Name"]);
                    coll.Add(Name);
                }

                DataAccess.con.Close();
            }

            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                Customer_Loan_Name.AutoCompleteCustomSource = coll;
                New_Invoice_C_Name.AutoCompleteCustomSource = coll;
                Item_return_Name.AutoCompleteCustomSource = coll;
                if (DataAccess.con.State == ConnectionState.Open)
                {
                    DataAccess.con.Close();
                }

            }
            Customer_Loan_Name.AutoCompleteCustomSource = coll;
            New_Invoice_C_Name.AutoCompleteCustomSource = coll;
            Item_return_Name.AutoCompleteCustomSource = coll;
            T_F_C_Name.AutoCompleteCustomSource = coll;
        }


        // --------------------------------------------------Auto Complete Textbox   New Invoice---------------Product------------------\\

        void AutoComlete_Invoice_Product_ID()
        {
            string Query = "SELECT * FROM[MobileData].[dbo].[Product]";
            Invoice_Product_Name.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
            Invoice_Product_Name.AutoCompleteSource = AutoCompleteSource.CustomSource;

            Products_Name.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
            Products_Name.AutoCompleteSource = AutoCompleteSource.CustomSource;


            AutoCompleteStringCollection coll = new AutoCompleteStringCollection();
            DataAccess.cmd = new SqlCommand(Query, DataAccess.con);

            DataView DV = new DataView(DataAccess.DT);
            DV.RowFilter = string.Format("P_ID LIKE '%N{0}%'", Invoice_Product_Name.Text);
            DV.RowFilter = string.Format("P_ID LIKE '%N{0}%'", Products_Name.Text);
            try
            {
                DataAccess.con.Open();
                DataAccess.DR = DataAccess.cmd.ExecuteReader();

                while (DataAccess.DR.Read())
                {
                    string Name = Convert.ToString(DataAccess.DR["P_ID"]);
                    coll.Add(Name);
                }

                DataAccess.con.Close();
            }

            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                Invoice_Product_Name.AutoCompleteCustomSource = coll;
                Products_Name.AutoCompleteCustomSource = coll;

                if (DataAccess.con.State == ConnectionState.Open)
                {
                    DataAccess.con.Close();
                }

            }
            Invoice_Product_Name.AutoCompleteCustomSource = coll;
            Products_Name.AutoCompleteCustomSource = coll;
            
        }
        // --------------------------------------------------Unsorted---------------------------------\\
        // --------------------------------------------------Unsorted---------------------------------\\

        public void Withrow_Name_TextChanged(object sender, EventArgs e)
        {
            DataView DV = new DataView(DataAccess.DT);
            DV.RowFilter = string.Format("C_Name LIKE '%{0}%'", Withrow_Name.Text);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                DataAccess.con.Open();
                MainTabs.SelectedIndex = 21;
                //     
                string str = "SELECT * FROM[MobileData].[dbo].[Customer] Where C_Name =   '" + Withrow_Name.Text + "'";
                SqlCommand cmd = new SqlCommand(str, DataAccess.con);
                DataAccess.DR = cmd.ExecuteReader();
                while (DataAccess.DR.Read())
                {
                    W_ID.Text = DataAccess.DR[0].ToString();

                }
                DataAccess.con.Close();
            }
            catch (Exception ex)
            {
                DataAccess.con.Close();
                MessageBox.Show(ex.Message);
            }
        }
        // --------------------------------------------------KEy-DOwn-----------------Name of Text-------Name of Tab---------------\\
        // --------------------------------------------------KEy-DOwn-----------------Name----------------------------------\\
        // --------------------------------------------------KEy-DOwn-----------------Name----------------------------------\\
        // --------------------------------------------------KEy-DOwn-----------------Name----------------------------------\\
        // --------------------------------------------------KEy-DOwn-----------------Name----------------------------------\\
        
        // --------------------------------------------------KEy-DOwn-----------------اسم----------------------NewMoneyTGTAB------------\\
      
     
        // --------------------------------------------------Click-Event-----------Name------------Tap- Name--------\\
        // --------------------------------------------------Click-Event------------------------------------------\\
        // --------------------------------------------------Click-Event------------------------------------------\\
        // --------------------------------------------------Click-Event------------------------------------------\\
        // --------------------------------------------------Click-Event------------------------------------------\\
        // --------------------------------------------------Click-Event------------------------------------------\\
        // --------------------------------------------------Click-Event------------------------------------------\\
        // --------------------------------------------------Click-Event------------------------------------------\\
       

     
       
     

        // -----------------------------------Products---------------Click-Event------------اسم--------------New Invoice Tap----------------\\
        // --------------------------------------------------Click-Event------------اسم--------------CustomerLoanTap----------------\\ 
        private void Customer_Loan_Name_Click_1(object sender, EventArgs e)
        {
            try
            {
                DataAccess.con.Open();
                //     
                string str = "SELECT * FROM[MobileData].[dbo].[Customer] Where C_Name =   '" + Customer_Loan_Name.Text + "'";
                SqlCommand cmd = new SqlCommand(str, DataAccess.con);
                DataAccess.DR = cmd.ExecuteReader();
                while (DataAccess.DR.Read())
                {
                    Cutomer_Loan_ID.Text = DataAccess.DR[0].ToString();

                }
                DataAccess.con.Close();
            }
            catch (Exception ex)
            {
                DataAccess.con.Close();
                MessageBox.Show(ex.Message);
            }
        }
        // --------------------------------------------------Auto Complete Textbox---------------CustomerLoanTap------------------\\
        // --------------------------------------------------Auto Complete Textbox---------------CustomerLoanTap------------------\\
        private void Customer_Loan_Name_KeyDown_1(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                try
                {
                    DataAccess.con.Open();
                    //     
                    string str = "SELECT * FROM[MobileData].[dbo].[Customer] Where C_Name =   '" + Customer_Loan_Name.Text + "'";
                    SqlCommand cmd = new SqlCommand(str, DataAccess.con);
                    DataAccess.DR = cmd.ExecuteReader();
                    while (DataAccess.DR.Read())
                    {
                        Cutomer_Loan_ID.Text = DataAccess.DR[0].ToString();

                    }
                    DataAccess.con.Close();
                }
                catch (Exception ex)
                {
                    DataAccess.con.Close();
                    MessageBox.Show(ex.Message);
                }
            }
        }
        // --------------------------------------------------KEy-DOwn-----------------اسم مشتری----------------------SupplierLoanTap------------\\
        private void Supplier_Loan_Name_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                try
                {
                    DataAccess.con.Open();
                    //     
                    string str = "SELECT * FROM[MobileData].[dbo].[Supplier] Where S_Name =   '" + Supplier_Loan_Name.Text + "'";
                    SqlCommand cmd = new SqlCommand(str, DataAccess.con);
                    DataAccess.DR = cmd.ExecuteReader();
                    while (DataAccess.DR.Read())
                    {
                        S_L_ID.Text = DataAccess.DR[0].ToString();

                    }
                    DataAccess.con.Close();
                }
                catch (Exception ex)
                {
                    DataAccess.con.Close();
                    MessageBox.Show(ex.Message);
                }
            }
        }
        // --------------------------------------------------Click-Event------------اسم مشتری--------------SupplierLoan Tap----------------\\
        private void Supplier_Loan_Name_Click(object sender, EventArgs e)
        {
            try
            {
                DataAccess.con.Open();

                //     
                string str = "SELECT * FROM[MobileData].[dbo].[Supplier] Where S_Name =   '" + Supplier_Loan_Name.Text + "'";
                SqlCommand cmd = new SqlCommand(str, DataAccess.con);
                DataAccess.DR = cmd.ExecuteReader();
                while (DataAccess.DR.Read())
                {
                    S_L_ID.Text = DataAccess.DR[0].ToString();

                }
                DataAccess.con.Close();
            }
            catch (Exception ex)
            {
                DataAccess.con.Close();
                MessageBox.Show(ex.Message);
            }

        }

        // --------------------------------------------------Click-Event------------------------------------------\\
        // --------------------------------------------------Click-Event------------اسم--------------NewMoneyTGTAB----------------\\

        private void Withrow_Name_Click_1(object sender, EventArgs e)
        {
            try
            {
                DataAccess.con.Open();
                MainTabs.SelectedIndex = 21;
                //     
                string str = "SELECT * FROM[MobileData].[dbo].[Employee] Where E_Name =   '" + Withrow_Name.Text + "'";
                SqlCommand cmd = new SqlCommand(str, DataAccess.con);
                DataAccess.DR = cmd.ExecuteReader();
                while (DataAccess.DR.Read())
                {
                    W_ID.Text = DataAccess.DR[0].ToString();

                }
                DataAccess.con.Close();
            }
            catch (Exception ex)
            {
                DataAccess.con.Close();
                MessageBox.Show(ex.Message);
            }
        }
        // --------------------------------------------------KEy-DOwn-----------------Name----------------------------------\\
        // --------------------------------------------------KEy-DOwn-----------------Name----------------------------------\\
        private void Withrow_Name_KeyDown_1(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                try
                {
                    DataAccess.con.Open();
                    MainTabs.SelectedIndex = 21;
                    //     
                    string str = "SELECT * FROM[MobileData].[dbo].[Employee] Where E_Name =   '" + Withrow_Name.Text + "'";
                    SqlCommand cmd = new SqlCommand(str, DataAccess.con);
                    DataAccess.DR = cmd.ExecuteReader();
                    while (DataAccess.DR.Read())
                    {
                        W_ID.Text = DataAccess.DR[0].ToString();

                    }
                    DataAccess.con.Close();
                }
                catch (Exception ex)
                {
                    DataAccess.con.Close();
                    MessageBox.Show(ex.Message);
                }
            }
        }

        

        private void NMTG_Save_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(Quantity.Text))
            {
                MessageBox.Show("جای مبلغ خالی است");
            }

            else
            {
                Withdraw();
                MessageBox.Show("ثبت موفق بود");
                Withrow_Name.Clear();
                Withrow_What_For.Clear();
                Quantity.Clear();
            }
            
        }

        private void MainForm_Load(object sender, EventArgs e)
        {

        }

        private void textBox7_TextChanged(object sender, EventArgs e)
        {

        }
        // --------------------------------------------------Click-----------------invoice- Name----------------------------------\\
        private void Invoice_Product_Name_Click(object sender, EventArgs e)
        {
            try
            {
                DataAccess.con.Open();
                //     
                string str = "SELECT * FROM[MobileData].[dbo].[Product] Where P_ID =   '" + New_Invoice_C_Name.Text + "'";
                SqlCommand cmd = new SqlCommand(str, DataAccess.con);
                DataAccess.DR = cmd.ExecuteReader();
                while (DataAccess.DR.Read())
                {
                    Invoice_Customer_Name_ID.Text = DataAccess.DR[1].ToString();

                }
                DataAccess.con.Close();
            }
            catch (Exception ex)
            {
                
                MessageBox.Show(ex.Message);
                DataAccess.con.Close();
            }
        }
        // --------------------------------------------------KEy-DOwn-----------------invoice- Name----------------------------------\\
        private void Invoice_Product_Name_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                try
                {
                    DataAccess.con.Open();
                    //     
                    string str = "SELECT * FROM[MobileData].[dbo].[Product] Where P_ID =   '" + Invoice_Product_Name.Text + "'";
                    SqlCommand cmd = new SqlCommand(str, DataAccess.con);
                    DataAccess.DR = cmd.ExecuteReader();
                    while (DataAccess.DR.Read())
                    {
                        Invoice_Customer_Name_ID.Text = DataAccess.DR[1].ToString();

                    }
                    DataAccess.con.Close();
                }
                catch (Exception ex)
                {
                    DataAccess.con.Close();
                    MessageBox.Show(ex.Message);
                }
            }
        }

        private void New_Invoice_C_Name_Click(object sender, EventArgs e)
        {
            try
            {
                DataAccess.con.Open();
                //     
                string str = "SELECT * FROM[MobileData].[dbo].[Customer] Where C_Name =   '" + New_Invoice_C_Name.Text + "'";
                SqlCommand cmd = new SqlCommand(str, DataAccess.con);
                DataAccess.DR = cmd.ExecuteReader();
                while (DataAccess.DR.Read())
                {
                    Customer_invoice_ID.Text = DataAccess.DR[0].ToString();

                }
                DataAccess.con.Close();
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
                DataAccess.con.Close();
            }


            
        }

        private void New_Invoice_C_Name_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                try
                {
                    DataAccess.con.Open();
                    //     
                    string str = "SELECT * FROM[MobileData].[dbo].[Customer] Where C_Name =   '" + New_Invoice_C_Name.Text + "'";
                    SqlCommand cmd = new SqlCommand(str, DataAccess.con);
                    DataAccess.DR = cmd.ExecuteReader();
                    while (DataAccess.DR.Read())
                    {
                        Customer_invoice_ID.Text = DataAccess.DR[0].ToString();

                    }
                    DataAccess.con.Close();
                }
                catch (Exception ex)
                {
                    DataAccess.con.Close();
                    MessageBox.Show(ex.Message);
                }
            }
        }

        private void textBox6_TextChanged(object sender, EventArgs e)
        {
            
        }

        private void NewInvoice_Cancel_Click(object sender, EventArgs e)
        {
            try
            {

                DialogResult dialogResult = MessageBox.Show("آیا مخواهید بیل را لغو کنید  ", "حذف کردن", MessageBoxButtons.YesNo);
                if (dialogResult == DialogResult.Yes)
                {

                    Delete_New_Invoice_Alitem();
                   // I_ID.Clear();
                   //   New_Invoice_C_Name.Clear();
                   // Customer_invoice_ID.Clear();
                   // invoice_Chackup.Clear();
                   //  Invoice_Total_Grand.Clear();
                   // New_Invoice_TotalPaid.Clear();
                   // Invoice_Customer_Name_ID.Clear();
                   // New_invoice_DataGrideView.DataSource = null;
                }
                else if (dialogResult == DialogResult.No)
                {
                }
            }

            catch (Exception)
            {
                DataAccess.con.Close();
                
            }
        }






        public void Multiply_Purchase()
        {
            int a, b;

            bool isAValid = int.TryParse(Purchase_Quantity.Text, out a);
            bool isBValid = int.TryParse(Purchase_price.Text, out b);

            if (isAValid && isBValid)
                Purchase_Total_price.Text = (a * b).ToString();

            else
                Purchase_Total_price.Text = "لطفا نمبر وارد کنید ";
        }





        public void Multiply_Invoice()
        {
            int a, b;

            bool isAValid = int.TryParse(New_Invoice_quantity.Text, out a);
            bool isBValid = int.TryParse(New_Invice_Price.Text, out b);

            if (isAValid && isBValid)
                New_Invoice_TotalPrice.Text = (a * b).ToString();

            else
                New_Invoice_TotalPrice.Text = "لطفا نمبر وارد کنید ";
        }

        private void New_Invoice_quantity_TextChanged(object sender, EventArgs e)
        {
            Multiply_Invoice();
        }

        private void New_Invice_Price_TextChanged(object sender, EventArgs e)
        {
            Multiply_Invoice();
        }



        // --------------------------------------------------Menu Bar ----------------------------------\\


        private void خروچToolStripMenuItem_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start("calc");
        }

        private void ViewToolStripMenuItem_DropDownOpened_1(object sender, EventArgs e)
        {
            ToolStripMenuItem TSMI = sender as ToolStripMenuItem;
            TSMI.ForeColor = Color.Black;

            string hex = "#5c5daa";
            Color hexx = System.Drawing.ColorTranslator.FromHtml(hex);
            View1ToolStripMenuItem.BackColor = hexx;
            View2ToolStripMenuItem.BackColor = hexx;
            View1ToolStripMenuItem.ForeColor = Color.OldLace;
            View2ToolStripMenuItem.ForeColor = Color.OldLace;

        }

        private void ViewToolStripMenuItem_DropDownClosed_1(object sender, EventArgs e)
        {
            ToolStripMenuItem TSMI = sender as ToolStripMenuItem;
            TSMI.ForeColor = Color.White;
        }

        private void FileToolStripMenuItem_DropDownOpened(object sender, EventArgs e)
        {
            ToolStripMenuItem TSMI = sender as ToolStripMenuItem;
            TSMI.ForeColor = Color.Black;

            string hex = "#5c5daa";
            Color hexx = System.Drawing.ColorTranslator.FromHtml(hex);
            CalToolStripMenuItem.BackColor = hexx;
            ExitToolStripMenuItem.BackColor = hexx;
            CalToolStripMenuItem.ForeColor = Color.OldLace;
            ExitToolStripMenuItem.ForeColor = Color.OldLace;
        }

        private void FileToolStripMenuItem_DropDownClosed(object sender, EventArgs e)
        {
            ToolStripMenuItem TSMI = sender as ToolStripMenuItem;
            TSMI.ForeColor = Color.White;
        }

        private void SysMgmToolStripMenuItem1_DropDownOpened(object sender, EventArgs e)
        {
            ToolStripMenuItem TSMI = sender as ToolStripMenuItem;
            TSMI.ForeColor = Color.Black;

            string hex = "#5c5daa";
            Color hexx = System.Drawing.ColorTranslator.FromHtml(hex);
            backupToolStripMenuItem.BackColor = hexx;
            restoreToolStripMenuItem.BackColor = hexx;
            backupToolStripMenuItem.ForeColor = Color.OldLace;
            restoreToolStripMenuItem.ForeColor = Color.OldLace;
        }

        private void SysMgmToolStripMenuItem1_DropDownClosed(object sender, EventArgs e)
        {
            ToolStripMenuItem TSMI = sender as ToolStripMenuItem;
            TSMI.ForeColor = Color.White;
        }

        private void HelpToolStripMenuItem_DropDownOpened(object sender, EventArgs e)
        {
            ToolStripMenuItem TSMI = sender as ToolStripMenuItem;
            TSMI.ForeColor = Color.Black;

            string hex = "#5c5daa";
            Color hexx = System.Drawing.ColorTranslator.FromHtml(hex);
            BuiltInToolStripMenuItem1.BackColor = hexx;
            OnlineToolStripMenuItem.BackColor = hexx;
            PhoneHelpToolStripMenuItem.BackColor = hexx;
            BuiltInToolStripMenuItem1.ForeColor = Color.OldLace;
            OnlineToolStripMenuItem.ForeColor = Color.OldLace;
            PhoneHelpToolStripMenuItem.ForeColor = Color.OldLace;
        }

        private void HelpToolStripMenuItem_DropDownClosed(object sender, EventArgs e)
        {
            ToolStripMenuItem TSMI = sender as ToolStripMenuItem;
            TSMI.ForeColor = Color.White;
        }
        /// <summary>
        /// ///////////unsorted///////////////////////////////////
        /// /// ///////////unsorted///////////////////////////////////
        /// /// ///////////unsorted///////////////////////////////////
        /// /// ///////////unsorted///////////////////////////////////
        /// /// ///////////unsorted///////////////////////////////////
        /// ///////////unsorted///////////////////////////////////
        /// /// ///////////unsorted///////////////////////////////////
        /// /// ///////////unsorted///////////////////////////////////
      
        /// ///////////unsorted///////////////////////////////////

        /// /// ///////////unsorted///////////////////////////////////
        /// </summary>

        public void get_last_ID()
        {
            try
            {
                DataAccess.con.Open();
                //     
                string str = "SELECT MAX(I_ID) FROM [MobileData].[dbo].[Invoice] ";

                SqlCommand cmd = new SqlCommand(str, DataAccess.con);
                DataAccess.DR = cmd.ExecuteReader();
                while (DataAccess.DR.Read())
                {
                    string one = DataAccess.DR[0].ToString();
                    int total = Convert.ToInt32(one);

                    total = total + 1;
                    I_IDP_T_B_ID.Text = total.ToString();

                }
                DataAccess.con.Close();
            }
            catch (Exception ex)
            {
                DataAccess.con.Close();
                MessageBox.Show(ex.Message);
            }
        }



        public void get_last_ID_Purchase()
        {
            try
            {
                DataAccess.con.Open();
                //     
                string str = "SELECT MAX(PC_ID) FROM [MobileData].[dbo].[Purchase] ";

                SqlCommand cmd = new SqlCommand(str, DataAccess.con);
                DataAccess.DR = cmd.ExecuteReader();
                while (DataAccess.DR.Read())
                {
                    string one = DataAccess.DR[0].ToString();
                    int total = Convert.ToInt32(one);

                    total = total + 1;
                    Puchase_ID.Text = total.ToString();

                }
                DataAccess.con.Close();
            }
            catch (Exception ex)
            {
                DataAccess.con.Close();
                MessageBox.Show(ex.Message);
            }
        }




        void total_Purchess()
        {
            try
            {

                //     
                string str = "SELECT  Sum(Total_Price) from [MobileData].[dbo].[Purchase_Details] where PC_ID = '" + Puchase_ID.Text + "'";
                DataAccess.con.Open();
                SqlCommand cmd = new SqlCommand(str, DataAccess.con);
                DataAccess.DR = cmd.ExecuteReader();
                while (DataAccess.DR.Read())
                {

                    string one = DataAccess.DR[0].ToString();
                    Purchase_Total.Text = one;

                }
                DataAccess.con.Close();
            }
            catch (Exception ex)
            {
                DataAccess.con.Close();
                MessageBox.Show(ex.Message);
            }
        }




        void total_Invoie()
        {
            try
            {
                
                //     
                string str = "SELECT  Sum(Total_amount) from [MobileData].[dbo].[Invoice_Details] where I_ID = '" + I_IDP_T_B_ID.Text + "'";
                DataAccess.con.Open();
                SqlCommand cmd = new SqlCommand(str, DataAccess.con);
                DataAccess.DR = cmd.ExecuteReader();
                while (DataAccess.DR.Read())
                {
                    
                    string one = DataAccess.DR[0].ToString();
                    Invoice_Total_Grand.Text = one;
                    
                }
                DataAccess.con.Close();
            }
            catch (Exception ex)
            {
                DataAccess.con.Close();
                MessageBox.Show(ex.Message);
            }
        }



    







        private void AddInvoiceItem_Click(object sender, EventArgs e)
        {

            if (string.IsNullOrWhiteSpace(Invoice_Product_Name.Text))
            {
                MessageBox.Show("جای نام جنس یا از مشتری خالی است");
            }

            else {
                if (radioButton1.Checked)
                {
                    if (invoice_Chackup.Text != I_IDP_T_B_ID.Text)
                    {
                        Invoic_New();
                        invoice_Chackup.Text = I_IDP_T_B_ID.Text;
                    }

                    invoice_details();

                    DataAccess.RunQuery("Select * from Invoice_Details Where I_ID ='" + I_IDP_T_B_ID.Text + "'");
                    New_invoice_DataGrideView.DataSource = DataAccess.Dataset.Tables[0];



                    total_Invoie();
                    Invoice_Product_Name.Clear();
                    New_Invoice_quantity.Clear();
                    New_Invice_Price.Clear();
                    New_Invoice_TotalPrice.Clear();
                    Invoice_Customer_Name_ID.Clear();
                }
                else
                {
                    MessageBox.Show("Chack RadioButton");
                }



            }
          







        }

        private void tableLayoutPanel106_Paint(object sender, PaintEventArgs e)
        {

        }

        private void Invoice_Total_Grand_TextChanged(object sender, EventArgs e)
        {
           
        }

        private void NewInvoice_Save_Click(object sender, EventArgs e)
        {
            

            if (string.IsNullOrWhiteSpace(New_Invoice_C_Name.Text))
            {
                MessageBox.Show("جای نام مشتری خالی است");
            }

            else
            {

                if (radioButton1.Checked)
                {
                    Invoice_Total_Amount();
                    I_IDP_T_B_ID.Clear();
                    New_Invoice_C_Name.Clear();
                    Customer_invoice_ID.Clear();
                    invoice_Chackup.Clear();
                    Invoice_Total_Grand.Clear();
                    New_Invoice_TotalPaid.Clear();
                    Invoice_Customer_Name_ID.Clear();
                    New_invoice_DataGrideView.DataSource = null;
                    MessageBox.Show("ثبت موفق بود");
                }

                else
                {
                    MessageBox.Show("Chose radio Button 1");
                }

            }


            

        }

        private void button4_Click(object sender, EventArgs e)
        {
            if (this.New_invoice_DataGrideView.SelectedRows.Count == 1)
            {
                try
                {

                    DialogResult dialogResult = MessageBox.Show("آیا مخواهید مورد انتخاب شده را حذف نماید ", "حذف کردن", MessageBoxButtons.YesNo);
                    if (dialogResult == DialogResult.Yes)
                    {
                        DataGridViewRow dr = New_invoice_DataGrideView.SelectedRows[0];
                        Delete_New_Invoice_Item.Text = dr.Cells[0].Value.ToString();
                        // or simply use column name instead of index
                        //dr.Cells["id"].Value.ToString();
                        Delete_New_Invoice_item();
                        total_Invoie();
                        foreach (DataGridViewRow item in this.New_invoice_DataGrideView.SelectedRows)
                        {
                            New_invoice_DataGrideView.Rows.RemoveAt(item.Index);
                        }
                    }
                    else if (dialogResult == DialogResult.No)
                    {
                    }
                }

                catch (Exception)
                {
                    DataAccess.con.Close();
                    MessageBox.Show("لطفا  روح را انتخاب کنید");
                }
            }
            else
            {
                MessageBox.Show("لطفا روح را انتخاب کنید");

            }
            Delete_New_Invoice_Item.Clear();
        }






        private void Delete_Supplier_Click(object sender, EventArgs e)
        {

            if (this.dataGridView1.SelectedRows.Count == 1)
            {
                try
                {

                    DialogResult dialogResult = MessageBox.Show("آیا مخواهید مورد انتخاب شده را حذف نماید ", "حذف کردن", MessageBoxButtons.YesNo);
                    if (dialogResult == DialogResult.Yes)
                    {
                        DataGridViewRow dr = dataGridView1.SelectedRows[0];
                        Delete_Supplier_ID.Text = dr.Cells[0].Value.ToString();
                        Delete_Suppliers();
                        foreach (DataGridViewRow item in this.dataGridView1.SelectedRows)
                        {
                            
                            dataGridView1.Rows.RemoveAt(item.Index);
                        }
                    }
                    else if (dialogResult == DialogResult.No)
                    {
                    }
                }

                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                    DataAccess.con.Close();
                    MessageBox.Show("لطفا  روح را انتخاب کنید");
                }
            }
            else
            {
                MessageBox.Show("لطفا روح را انتخاب کنید");

            }
            Delete_New_Invoice_Item.Clear();
        }

        private void button25_Click(object sender, EventArgs e)
        {
            DataAccess.RunQuery("Select P_IDD AS[Me], P_ID As[آید جنس], P_Name as [نام جنس], P_Color as [رنگ], P_Made as [ساخت ] from Product");
            Product_list_Data_grideView.DataSource = DataAccess.Dataset.Tables[0];
            Product_list_Data_grideView.Columns[0].Visible = false;
        }

        private void button31_Click(object sender, EventArgs e)
        {
            DataAccess.RunQuery("Select S_ID As[آید تهیه کننده], S_Name as [نام تهیه کننده], S_Location as [آدرس], S_Phone as [شماره تماس], S_E_Mail as [ایمل آدرس] from Supplier");
            dataGridView1.DataSource = DataAccess.Dataset.Tables[0];
        }



        private void button38_Click(object sender, EventArgs e)
        {
            if (this.On_Customer_Money_Pay_DataGrideView.SelectedRows.Count == 1)
            {
                try
                {

                    DialogResult dialogResult = MessageBox.Show("آیا مخواهید مورد انتخاب شده را حذف نماید ", "حذف کردن", MessageBoxButtons.YesNo);
                    if (dialogResult == DialogResult.Yes)
                    {
                        DataGridViewRow dr = On_Customer_Money_Pay_DataGrideView.SelectedRows[0];
                        Taken_PasT_Loan_Delete_ID.Text = dr.Cells[0].Value.ToString();
                        // or simply use column name instead of index
                        //dr.Cells["id"].Value.ToString();
                        Taken_Past_Loan_Delete();


                        foreach (DataGridViewRow item in this.On_Customer_Money_Pay_DataGrideView.SelectedRows)
                        {
                            On_Customer_Money_Pay_DataGrideView.Rows.RemoveAt(item.Index);
                        }
                    }
                    else if (dialogResult == DialogResult.No)
                    {
                    }
                }

                catch (Exception)
                {
                    MessageBox.Show("لطفا  روح را انتخاب کنید");
                }
            }
            else
            {
                MessageBox.Show("لطفا روح را انتخاب کنید");
            }
            Taken_PasT_Loan_Delete_ID.Clear();
        }

        private void button41_Click(object sender, EventArgs e)
        {
            DataAccess.RunQuery("SELECT P_T_C_ID as[آیدی],[C_Name] as [نام مشتری], MO.Quantity as [مقدار], MO.What_For as [از درک], Mo.Date as[تاریخ] FROM [MobileData].[dbo].[Customer] as C Join [MobileData].[dbo].[Money_On_Customer] as MO on MO.C_ID = c.C_ID");
            On_Customer_Money_Pay_DataGrideView.DataSource = DataAccess.Dataset.Tables[0];
        }

        private void button29_Click(object sender, EventArgs e)
        {

            if (string.IsNullOrWhiteSpace(Paid_Money_Name.Text))
            {
                MessageBox.Show("جای اسم  خالی است");
            }

            else
            {
                Paid_Money();
                MessageBox.Show("ثبت موفق بود");
               
            }
            Paid_Money_Name.Clear();
            P_M_What_For.Clear();
            P_M_Quantity.Clear();
            P_M_ID.Clear();
        }
//--------------------------------------------------------------------------------------Click And KEyDown Event------------PaidMoney---------------------------------------------------
        private void Paid_Money_Name_Click(object sender, EventArgs e)
        {

           
                try
                {
                    DataAccess.con.Open();
                    //     
                    string str = "SELECT * FROM[MobileData].[dbo].[Employee] Where E_Name =   '" + Paid_Money_Name.Text + "'";
                    SqlCommand cmd = new SqlCommand(str, DataAccess.con);
                    DataAccess.DR = cmd.ExecuteReader();
                    while (DataAccess.DR.Read())
                    {
                    P_M_ID.Text = DataAccess.DR[0].ToString();

                    }
                    DataAccess.con.Close();
                }
                catch (Exception ex)
                {
                    DataAccess.con.Close();
                    MessageBox.Show(ex.Message);
                }
            
        }

        private void Paid_Money_Name_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                try
                {
                    DataAccess.con.Open();
                    //     
                    string str = "SELECT * FROM[MobileData].[dbo].[Employee] Where E_Name =   '" + Paid_Money_Name.Text + "'";
                    SqlCommand cmd = new SqlCommand(str, DataAccess.con);
                    DataAccess.DR = cmd.ExecuteReader();
                    while (DataAccess.DR.Read())
                    {
                        P_M_ID.Text = DataAccess.DR[0].ToString();

                    }
                    DataAccess.con.Close();
                }
                catch (Exception ex)
                {
                    DataAccess.con.Close();
                    MessageBox.Show(ex.Message);
                }
            }
        }
        //---------------------------------------------------------------------------------------End---------------------------------------------------------------

        private void button42_Click(object sender, EventArgs e)
        {

            if (string.IsNullOrWhiteSpace(Pay_To_Bank_Name.Text))
            {
                MessageBox.Show("جای اسم  خالی است");
            }

            else
            {
                Pay_To_Bank();
                MessageBox.Show("ثبت موفق بود");

            }
        }
        //--------------------------------------------------------------------------------------Click And KEyDown Event-----------------------------Pay to Bank----------------------------------
        private void Pay_To_Bank_Name_KeyDown(object sender, KeyEventArgs e)
        {


            if (e.KeyCode == Keys.Enter)
            {
                try
                {
                    DataAccess.con.Open();
                    //     
                    string str = "SELECT * FROM[MobileData].[dbo].[Bank] Where B_Name =   '" + Pay_To_Bank_Name.Text + "'";
                    SqlCommand cmd = new SqlCommand(str, DataAccess.con);
                    DataAccess.DR = cmd.ExecuteReader();
                    while (DataAccess.DR.Read())
                    {
                        P_T_B_ID.Text = DataAccess.DR[0].ToString();

                    }
                    DataAccess.con.Close();
                }
                catch (Exception ex)
                {
                    DataAccess.con.Close();
                    MessageBox.Show(ex.Message);
                }
            }



           
        }

        private void Pay_To_Bank_Name_Click(object sender, EventArgs e)
        {
            try
            {
                DataAccess.con.Open();
                //     
                string str = "SELECT * FROM[MobileData].[dbo].[Bank] Where B_Name =   '" + Pay_To_Bank_Name.Text + "'";
                SqlCommand cmd = new SqlCommand(str, DataAccess.con);
                DataAccess.DR = cmd.ExecuteReader();
                while (DataAccess.DR.Read())
                {
                    P_T_B_ID.Text = DataAccess.DR[0].ToString();

                }
                DataAccess.con.Close();
            }
            catch (Exception ex)
            {
                DataAccess.con.Close();
                MessageBox.Show(ex.Message);
            }
        }



       

        private void Pay_to_Bank_emp_Name_Click(object sender, EventArgs e)
        {
            try
            {
                DataAccess.con.Open();
                //     
                string str = "SELECT * FROM[MobileData].[dbo].[Employee] Where E_Name =   '" + Pay_to_Bank_emp_Name.Text + "'";
                SqlCommand cmd = new SqlCommand(str, DataAccess.con);
                DataAccess.DR = cmd.ExecuteReader();
                while (DataAccess.DR.Read())
                {
                    P_T_B_E_ID.Text = DataAccess.DR[0].ToString();

                }
                DataAccess.con.Close();
            }
            catch (Exception ex)
            {
                DataAccess.con.Close();
                MessageBox.Show(ex.Message);
            }
        }

        private void Pay_to_Bank_emp_Name_KeyDown(object sender, KeyEventArgs e)
        {

            if (e.KeyCode == Keys.Enter)
            {
                try
                {
                    DataAccess.con.Open();
                    //     
                    string str = "SELECT * FROM[MobileData].[dbo].[Employee] Where E_Name =   '" + Pay_to_Bank_emp_Name.Text + "'";
                    SqlCommand cmd = new SqlCommand(str, DataAccess.con);
                    DataAccess.DR = cmd.ExecuteReader();
                    while (DataAccess.DR.Read())
                    {
                        P_T_B_E_ID.Text = DataAccess.DR[0].ToString();

                    }
                    DataAccess.con.Close();
                }
                catch (Exception ex)
                {
                    DataAccess.con.Close();
                    MessageBox.Show(ex.Message);
                }
            }


        }

        private void button36_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(B_Name.Text))
            {
                MessageBox.Show("جای اسم  خالی است");
            }

            else
            {
                Bank();
                MessageBox.Show("ثبت موفق بود");

            }

            B_Name.Clear();
            B_Address.Clear();
            B_Phone.Clear();
            B_Phone1.Clear();
            B_Note.Clear();
        }

        private void button39_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(T_F_B_Name.Text))
            {
                MessageBox.Show("جای اسم  خالی است");
            }

            else
            {
                Take_From_Bank();
                MessageBox.Show("ثبت موفق بود");

            }
        }
        //--------------------------------------------------------------------------------------End-----------------------------Pay to Bank----------------------------------
        //--------------------------------------------------------------------------------------End-----------------------------Pay to Bank----------------------------------
        //--------------------------------------------------------------------------------------End-----------------------------Pay to Bank----------------------------------

        private void Take_F_B_Name_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                try
                {
                    DataAccess.con.Open();
                    //     
                    string str = "SELECT * FROM[MobileData].[dbo].[Employee] Where E_Name =   '" + Take_F_B_Name.Text + "'";
                    SqlCommand cmd = new SqlCommand(str, DataAccess.con);
                    DataAccess.DR = cmd.ExecuteReader();
                    while (DataAccess.DR.Read())
                    {
                        T_F_B_E_ID.Text = DataAccess.DR[0].ToString();

                    }
                    DataAccess.con.Close();
                }
                catch (Exception ex)
                {
                    DataAccess.con.Close();
                    MessageBox.Show(ex.Message);
                }
            }
        }

        private void Take_F_B_Name_Click(object sender, EventArgs e)
        {
            try
            {
                DataAccess.con.Open();
                //     
                string str = "SELECT * FROM[MobileData].[dbo].[Employee] Where E_Name =   '" + Take_F_B_Name.Text + "'";
                SqlCommand cmd = new SqlCommand(str, DataAccess.con);
                DataAccess.DR = cmd.ExecuteReader();
                while (DataAccess.DR.Read())
                {
                    T_F_B_E_ID.Text = DataAccess.DR[0].ToString();

                }
                DataAccess.con.Close();
            }
            catch (Exception ex)
            {
                DataAccess.con.Close();
                MessageBox.Show(ex.Message);
            }
        }

        private void T_F_B_Name_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                try
                {
                    DataAccess.con.Open();
                    //     
                    string str = "SELECT * FROM[MobileData].[dbo].[Bank] Where B_Name =   '" + T_F_B_Name.Text + "'";
                    SqlCommand cmd = new SqlCommand(str, DataAccess.con);
                    DataAccess.DR = cmd.ExecuteReader();
                    while (DataAccess.DR.Read())
                    {
                        T_F_B_ID.Text = DataAccess.DR[0].ToString();

                    }
                    DataAccess.con.Close();
                }
                catch (Exception ex)
                {
                    DataAccess.con.Close();
                    MessageBox.Show(ex.Message);
                }
            }
        }

        private void T_F_B_Name_Click(object sender, EventArgs e)
        {
            try
            {
                DataAccess.con.Open();
                //     
                string str = "SELECT * FROM[MobileData].[dbo].[Bank] Where B_Name =   '" + T_F_B_Name.Text + "'";
                SqlCommand cmd = new SqlCommand(str, DataAccess.con);
                DataAccess.DR = cmd.ExecuteReader();
                while (DataAccess.DR.Read())
                {
                    T_F_B_ID.Text = DataAccess.DR[0].ToString();

                }
                DataAccess.con.Close();
            }
            catch (Exception ex)
            {
                DataAccess.con.Close();
                MessageBox.Show(ex.Message);
            }
        }

        private void Save_OSL_Click(object sender, EventArgs e)
        {

            if (string.IsNullOrWhiteSpace(P_Supplier_name.Text))
            {
                MessageBox.Show("جای اسم  خالی است");
            }

            else
            {
                Pay_To_Supplier();
                MessageBox.Show("ثبت موفق بود");

            }

            P_Supplier_name.Clear();
            P_T_S_What_For.Clear();
            P_T_Quantity.Clear();
            P_T_S_ID.Clear();
        }


        //----------------------------------------------------------------------Click-And KEyDown-Event----------------Pay To Supplier---------------------------------------------------------------
        private void P_Supplier_name_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                try
                {
                    DataAccess.con.Open();
                    //     
                    string str = "SELECT * FROM[MobileData].[dbo].[Supplier] Where S_Name =   '" + P_Supplier_name.Text + "'";
                    SqlCommand cmd = new SqlCommand(str, DataAccess.con);
                    DataAccess.DR = cmd.ExecuteReader();
                    while (DataAccess.DR.Read())
                    {
                        P_T_S_ID.Text = DataAccess.DR[0].ToString();

                    }
                    DataAccess.con.Close();
                }
                catch (Exception ex)
                {
                    DataAccess.con.Close();
                    MessageBox.Show(ex.Message);
                }
            }
        }

        private void P_Supplier_name_Click(object sender, EventArgs e)
        {

            try
            {
                DataAccess.con.Open();
                //     
                string str = "SELECT * FROM[MobileData].[dbo].[Supplier] Where S_Name =   '" + P_Supplier_name.Text + "'";
                SqlCommand cmd = new SqlCommand(str, DataAccess.con);
                DataAccess.DR = cmd.ExecuteReader();
                while (DataAccess.DR.Read())
                {
                    P_T_S_ID.Text = DataAccess.DR[0].ToString();

                }
                DataAccess.con.Close();
            }
            catch (Exception ex)
            {
                DataAccess.con.Close();
                MessageBox.Show(ex.Message);
            }
        }
        //--------------------------------------------------------------------------------------End-----------------------------Pay to Supplier----------------------------------



        //--------------------------------------------------------------------------------------Take_From Customer-----------------------------Pay to Bank----------------------------------
        private void T_F_C_Name_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                try
                {
                    DataAccess.con.Open();
                    //     
                    string str = "SELECT * FROM[MobileData].[dbo].[Customer] Where C_Name =   '" + T_F_C_Name.Text + "'";
                    SqlCommand cmd = new SqlCommand(str, DataAccess.con);
                    DataAccess.DR = cmd.ExecuteReader();
                    while (DataAccess.DR.Read())
                    {
                        O_C_ID.Text = DataAccess.DR[0].ToString();

                    }
                    DataAccess.con.Close();
                }
                catch (Exception ex)
                {
                    DataAccess.con.Close();
                    MessageBox.Show(ex.Message);
                }
            }
        }

        private void T_F_C_Name_Click(object sender, EventArgs e)
        {
            try
            {
                DataAccess.con.Open();
                //     
                string str = "SELECT * FROM[MobileData].[dbo].[Customer] Where C_Name =   '" + T_F_C_Name.Text + "'";
                SqlCommand cmd = new SqlCommand(str, DataAccess.con);
                DataAccess.DR = cmd.ExecuteReader();
                while (DataAccess.DR.Read())
                {
                    O_C_ID.Text = DataAccess.DR[0].ToString();

                }
                DataAccess.con.Close();
            }
            catch (Exception ex)
            {
                DataAccess.con.Close();
                MessageBox.Show(ex.Message);
            }
        }

        private void Save_OCL_Click(object sender, EventArgs e)
        {

            if (string.IsNullOrWhiteSpace(T_F_C_Name.Text))
            {
                MessageBox.Show("جای اسم  خالی است");
            }

            else
            {
               
                MessageBox.Show("ثبت موفق بود");
                Money_on_Customer();
            }
            T_F_C_Name.Clear();
            O_C_What_For.Clear();
            O_C_Quantity.Clear();
            O_C_ID.Clear();
        }

        private void button48_Click(object sender, EventArgs e)
        {
            DataAccess.RunQuery("SELECT P_T_S_ID as[آیدی قرض],s.S_Name as [نام تهیه کننده], PTS.Quantity as [مقدار], PTS.What_For as [از درک], PTS.Date as[تاریخ] FROM [MobileData].[dbo].[Supplier] as s Join [MobileData].[dbo].[Pay_To_Supplier] as PTS on PTS.S_ID = S.S_ID");
            Pay_To_Supplier_DataGriveView.DataSource = DataAccess.Dataset.Tables[0];
        }

     
        private void button52_Click(object sender, EventArgs e)
        {
            DataAccess.RunQuery("SELECT T.T_F_Bank_ID as [آید برداشت],B.B_Name[نام بانک],E.E_Name as [نام مشتری],T.Quantity[مقدار], T.What_For as [از درک],  T.Date as[تاریخ] FROM Employee as E Join Take_From_Bank as T on T.E_ID = E.E_ID Join Bank as B on T.B_ID = B.B_ID");
            Take_From_Bank_DataGrideView.DataSource = DataAccess.Dataset.Tables[0];
        }

        private void button56_Click(object sender, EventArgs e)
        {
            DataAccess.RunQuery("SELECT P.P_T_Bank as[آید پرداخت],B.B_Name[نام بانک],E.E_Name as [نام مشتری],P.Quantity[مقدار], P.What_For as [از درک],  P.Date as[تاریخ] FROM Employee as E Join Pay_To_Bank as P on P.E_ID = E.E_ID Join Bank as B on P.B_ID = B.B_ID");
            dataGridView4.DataSource = DataAccess.Dataset.Tables[0];
            
        }
       

        private void button60_Click(object sender, EventArgs e)
        {
            DataAccess.RunQuery("SELECT G_L_ID as[آید پرداخت],[C_Name] as [نام مشتری], G_Pay_Loan as [مقدار],  G_L_Date as[تاریخ] FROM [MobileData].[dbo].[Customer] as C Join [MobileData].[dbo].[Given_Loan] as G on G.C_ID = C.C_ID");
           Given_loan_DataGrideView.DataSource = DataAccess.Dataset.Tables[0];
        }

        private void button68_Click(object sender, EventArgs e)
        {
            DataAccess.RunQuery("SELECT Paid_ID as[آید پرداخت],[E_Name] as [نام مشتری],Quantity[مقدار], What_For as [از درک],  Date as[تاریخ] FROM [MobileData].[dbo].[Employee] as E Join [MobileData].[dbo].[Paid_Money] as P on P.E_ID = E.E_ID");
            Paid_Loan_DataGrideView.DataSource = DataAccess.Dataset.Tables[0];
        }

        private void button64_Click(object sender, EventArgs e)
        {
            DataAccess.RunQuery("SELECT T_L_ID as[آید پرداخت],[S_Name] as [نام مشتری],PC_ID[بیل نمبر], T_Pay_Loan as [مقدار],  T_L_Date as[تاریخ] FROM [MobileData].[dbo].[Supplier] as S Join [MobileData].[dbo].[Taken_Loan] as T on T.S_ID = S.S_ID");
            Taken_Loan_DataGrideView.DataSource = DataAccess.Dataset.Tables[0];
        }

        private void Invoice_Product_Name_TextChanged(object sender, EventArgs e)
        {

        }

      

        private void DeleteBank_Click(object sender, EventArgs e)
        {
            if (this.Bank_DataGridView.SelectedRows.Count == 1)
            {
                try
                {

                    DialogResult dialogResult = MessageBox.Show("آیا مخواهید مورد انتخاب شده را حذف نماید ", "حذف کردن", MessageBoxButtons.YesNo);
                    if (dialogResult == DialogResult.Yes)
                    {
                        DataGridViewRow dr = Bank_DataGridView.SelectedRows[0];
                        Bank_Delete_ID.Text = dr.Cells[0].Value.ToString();
                        Delete_Bank();


                        foreach (DataGridViewRow item in this.Bank_DataGridView.SelectedRows)
                        {
                            Bank_DataGridView.Rows.RemoveAt(item.Index);
                        }
                    }
                    else if (dialogResult == DialogResult.No)
                    {
                    }
                }

                catch (Exception)
                {
                    MessageBox.Show("لطفا  روح را انتخاب کنید");
                }
            }
            else
            {
                MessageBox.Show("لطفا روح را انتخاب کنید");
            }
            Bank_Delete_ID.Clear();
        }

        private void NewExpenseCancel_Click(object sender, EventArgs e)
        {
            if (this.Expenses_Data_GrideView.SelectedRows.Count == 1)
            {
                try
                {

                    DialogResult dialogResult = MessageBox.Show("آیا مخواهید مورد انتخاب شده را حذف نماید ", "حذف کردن", MessageBoxButtons.YesNo);
                    if (dialogResult == DialogResult.Yes)
                    {
                        DataGridViewRow dr = Expenses_Data_GrideView.SelectedRows[0];
                        Delete_Expenses_ID.Text = dr.Cells[0].Value.ToString();
                        // or simply use column name instead of index
                        //dr.Cells["id"].Value.ToString();
                        Delete_Ex();


                        foreach (DataGridViewRow item in this.Expenses_Data_GrideView.SelectedRows)
                        {
                            Expenses_Data_GrideView.Rows.RemoveAt(item.Index);
                        }
                    }
                    else if (dialogResult == DialogResult.No)
                    {
                    }
                }

                catch (Exception)
                {
                    MessageBox.Show("لطفا  روح را انتخاب کنید");
                }
            }
            else
            {
                MessageBox.Show("لطفا روح را انتخاب کنید");
            }
            Delete_Loan_Past_Delete_ID.Clear();
        }

        private void P_T_Quantity_TextChanged(object sender, EventArgs e)
        {

        }

        private void button46_Click(object sender, EventArgs e)
        {
            if (this.Pay_To_Supplier_DataGriveView.SelectedRows.Count == 1)
            {
                try
                {

                    DialogResult dialogResult = MessageBox.Show("آیا مخواهید مورد انتخاب شده را حذف نماید ", "حذف کردن", MessageBoxButtons.YesNo);
                    if (dialogResult == DialogResult.Yes)
                    {
                        DataGridViewRow dr = Pay_To_Supplier_DataGriveView.SelectedRows[0];
                        Delete_Loan_Past_Delete_ID.Text = dr.Cells[0].Value.ToString();

                        Delete_Pay_To_Supplier();


                        foreach (DataGridViewRow item in this.Pay_To_Supplier_DataGriveView.SelectedRows)
                        {
                            Pay_To_Supplier_DataGriveView.Rows.RemoveAt(item.Index);
                        }
                    }
                    else if (dialogResult == DialogResult.No)
                    {
                    }
                }

                catch (Exception)
                {
                    MessageBox.Show("لطفا  روح را انتخاب کنید");
                }
            }
            else
            {
                MessageBox.Show("لطفا روح را انتخاب کنید");
            }
            Delete_Loan_Past_Delete_ID.Clear();
        }

        private void RefreshExp_Click(object sender, EventArgs e)
        {
            DataAccess.RunQuery("SELECT Ex_ID as[آید مصرف],[EX_Name] as [از درک ],Quantity[مقدار ], Date as[تاریخ] FROM [MobileData].[dbo].[Expenses]");
            Expenses_Data_GrideView.DataSource = DataAccess.Dataset.Tables[0];
        }

        private void AboutCustToolStripMenuItem_Click(object sender, EventArgs e)
        {
            StartUp Start = new StartUp();
            Start.Show();
        }



        private void textBox73_Click(object sender, MouseEventArgs e)
        {
            SearchT_Invoice.Text = "";
            SearchT_Invoice.ReadOnly = false;
        }

        private void textBox73_Leave(object sender, EventArgs e)
        {
            SearchT_Invoice.Text = "جستجو";
            SearchT_Invoice.ReadOnly = true;
        }

        private void button71_Click(object sender, EventArgs e)
        {

            if (this.Taken_Money_DataGrideView.SelectedRows.Count == 1)
            {
                try
                {

                    DialogResult dialogResult = MessageBox.Show("آیا مخواهید مورد انتخاب شده را حذف نماید ", "حذف کردن", MessageBoxButtons.YesNo);
                    if (dialogResult == DialogResult.Yes)
                    {
                        DataGridViewRow dr = Taken_Money_DataGrideView.SelectedRows[0];
                        Withrow_Delete_ID.Text = dr.Cells[0].Value.ToString();

                        Delete_Withrow();


                        foreach (DataGridViewRow item in this.Taken_Money_DataGrideView.SelectedRows)
                        {
                            Taken_Money_DataGrideView.Rows.RemoveAt(item.Index);
                        }
                    }
                    else if (dialogResult == DialogResult.No)
                    {
                    }
                }

                catch (Exception)
                {
                    MessageBox.Show("لطفا  روح را انتخاب کنید");
                }
            }
            else
            {
                MessageBox.Show("لطفا روح را انتخاب کنید");
            }
            Withrow_Delete_ID.Clear();
        }

        private void button67_Click(object sender, EventArgs e)
        {
            if (this.Paid_Loan_DataGrideView.SelectedRows.Count == 1)
            {
                try
                {

                    DialogResult dialogResult = MessageBox.Show("آیا مخواهید مورد انتخاب شده را حذف نماید ", "حذف کردن", MessageBoxButtons.YesNo);
                    if (dialogResult == DialogResult.Yes)
                    {
                        DataGridViewRow dr = Paid_Loan_DataGrideView.SelectedRows[0];
                        Paid_Delete_ID.Text = dr.Cells[0].Value.ToString();
                        Delete_Paid_Money();
                        foreach (DataGridViewRow item in this.Paid_Loan_DataGrideView.SelectedRows)
                        {
                            Paid_Loan_DataGrideView.Rows.RemoveAt(item.Index);
                        }
                    }
                    else if (dialogResult == DialogResult.No)
                    {
                    }
                }

                catch (Exception)
                {
                    MessageBox.Show("لطفا  روح را انتخاب کنید");
                }
            }
            else
            {
                MessageBox.Show("لطفا روح را انتخاب کنید");
            }
           
        }

        private void button72_Click(object sender, EventArgs e)
        {
            DataAccess.RunQuery("SELECT W_ID as[آید برداشت],[E_Name] as [نام مشتری],Quantity[مقدار], What_For as [از درک],  Date as[تاریخ] FROM [MobileData].[dbo].[Employee] as E Join [MobileData].[dbo].[Withdraw] as W on W.E_ID = E.E_ID");
            Taken_Money_DataGrideView.DataSource = DataAccess.Dataset.Tables[0];
        }

        private void button47_Click(object sender, EventArgs e)
        {
            DataAccess.RunQuery("SELECT B_ID as [آیدی], B_Name as [نام بانک], B_Address [آدرس ], B_Phone as [شماره تماس 1], B_Phone1 as [شماره تماس 2], B_Note as[نوت]FROM Bank ");
            Bank_DataGridView.DataSource = DataAccess.Dataset.Tables[0];
        }

        private void button51_Click(object sender, EventArgs e)
        {

            if (this.Take_From_Bank_DataGrideView.SelectedRows.Count == 1)
            {
                try
                {

                    DialogResult dialogResult = MessageBox.Show("آیا مخواهید مورد انتخاب شده را حذف نماید ", "حذف کردن", MessageBoxButtons.YesNo);
                    if (dialogResult == DialogResult.Yes)
                    {
                        DataGridViewRow dr = Take_From_Bank_DataGrideView.SelectedRows[0];
                        Take_FromBank_ID.Text = dr.Cells[0].Value.ToString();
                        Delete_Take_From_Bank();
                        foreach (DataGridViewRow item in this.Take_From_Bank_DataGrideView.SelectedRows)
                        {

                            Take_From_Bank_DataGrideView.Rows.RemoveAt(item.Index);
                        }
                    }
                    else if (dialogResult == DialogResult.No)
                    {
                    }
                }

                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                    DataAccess.con.Close();
                    MessageBox.Show("لطفا  روح را انتخاب کنید");
                }
            }
            else
            {
                MessageBox.Show("لطفا روح را انتخاب کنید");

            }
            Take_FromBank_ID.Clear();
        }












        private void button55_Click(object sender, EventArgs e)
        {

            if (this.dataGridView4.SelectedRows.Count == 1)
            {
                try
                {

                    DialogResult dialogResult = MessageBox.Show("آیا مخواهید مورد انتخاب شده را حذف نماید ", "حذف کردن", MessageBoxButtons.YesNo);
                    if (dialogResult == DialogResult.Yes)
                    {
                        DataGridViewRow dr = dataGridView4.SelectedRows[0];
                        Delete_Pay_To_Bank_ID.Text = dr.Cells[0].Value.ToString();
                        Delete_payto_Bank();
                        foreach (DataGridViewRow item in this.dataGridView4.SelectedRows)
                        {

                            dataGridView4.Rows.RemoveAt(item.Index);
                        }
                    }
                    else if (dialogResult == DialogResult.No)
                    {
                    }
                }

                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                    DataAccess.con.Close();
                    MessageBox.Show("لطفا  روح را انتخاب کنید");
                }
            }
            else
            {
                MessageBox.Show("لطفا روح را انتخاب کنید");

            }
            Delete_Pay_To_Bank_ID.Clear();
        }

        private void tableLayoutPanel175_Paint(object sender, PaintEventArgs e)
        {

        }

        private void Invoice_Total_Grand_TextChanged_1(object sender, EventArgs e)
        {

        }

        private void button14_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(New_Supplier_Name.Text))
            {
                MessageBox.Show("جای نام جنس یا از تهیه کننده خالی است");
            }

            else {
                if (Purches_ChackUp.Text != Puchase_ID.Text)
                    {
                        Puchase_New();
                        Purches_ChackUp.Text = Puchase_ID.Text;
                    }

                    Puchase_details();

                    DataAccess.RunQuery("Select * from Purchase_Details Where PC_ID ='" + Purches_ChackUp.Text + "'");
                    Purchase_DataGrideView.DataSource = DataAccess.Dataset.Tables[0];


                total_Purchess();

                Products_Name.Clear();
                Purchase_Quantity.Clear();
                Purchase_price.Clear();
                Purchase_Total_price.Clear();
                Purchase_Selller_Name.Clear();

                Purchase_DataGrideView.Columns[0].Visible = false;
                Purchase_DataGrideView.Columns[1].Visible = false;

            }

        }

        private void flowLayoutPanel19_Paint(object sender, PaintEventArgs e)
        {

        }

        private void Purchase_End_Date_ValueChanged(object sender, EventArgs e)
        {

        }

        private void New_Supplier_Name_Click(object sender, EventArgs e)
        {
           try
                {
                    DataAccess.con.Open();
                    //     
                    string str = "SELECT * FROM[MobileData].[dbo].[Supplier] Where S_Name =   '" + New_Supplier_Name.Text + "'";
                    SqlCommand cmd = new SqlCommand(str, DataAccess.con);
                    DataAccess.DR = cmd.ExecuteReader();
                    while (DataAccess.DR.Read())
                    {
                    Purchase_Selller_Name.Text = DataAccess.DR[0].ToString();

                    }
                    DataAccess.con.Close();
                }
                catch (Exception ex)
                {
                    DataAccess.con.Close();
                    MessageBox.Show(ex.Message);
                }
            }

        private void New_Supplier_Name_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                try
                {
                    DataAccess.con.Open();
                    //     
                    string str = "SELECT * FROM[MobileData].[dbo].[Supplier] Where S_Name =   '" + New_Supplier_Name.Text + "'";
                    SqlCommand cmd = new SqlCommand(str, DataAccess.con);
                    DataAccess.DR = cmd.ExecuteReader();
                    while (DataAccess.DR.Read())
                    {
                        Purchase_Selller_Name.Text = DataAccess.DR[0].ToString();

                    }
                    DataAccess.con.Close();
                }
                catch (Exception ex)
                {
                    DataAccess.con.Close();
                    MessageBox.Show(ex.Message);
                }
            }
        }

        private void Products_Name_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                try
                {
                    DataAccess.con.Open();
                    //     
                    string str = "SELECT * FROM[MobileData].[dbo].[Product] Where P_Name =   '" + Products_Name.Text + "'";
                    SqlCommand cmd = new SqlCommand(str, DataAccess.con);
                    DataAccess.DR = cmd.ExecuteReader();
                    while (DataAccess.DR.Read())
                    {
                        Purchase_Product_ID.Text = DataAccess.DR[1].ToString();

                    }
                    DataAccess.con.Close();
                }
                catch (Exception ex)
                {
                    DataAccess.con.Close();
                    MessageBox.Show(ex.Message);
                }
            }
        }

        private void Products_Name_Click(object sender, EventArgs e)
        {

            try
            {
                DataAccess.con.Open();
                //     
                string str = "SELECT * FROM[MobileData].[dbo].[Product] Where P_Name =   '" + Products_Name.Text + "'";
                SqlCommand cmd = new SqlCommand(str, DataAccess.con);
                DataAccess.DR = cmd.ExecuteReader();
                while (DataAccess.DR.Read())
                {
                    Purchase_Product_ID.Text = DataAccess.DR[1].ToString();

                }
                DataAccess.con.Close();
            }
            catch (Exception ex)
            {
                DataAccess.con.Close();
                MessageBox.Show(ex.Message);
            }
        }

        private void Purchase_Quantity_TextChanged(object sender, EventArgs e)
        {
            Multiply_Purchase();
        }

        private void Purchase_price_TextChanged(object sender, EventArgs e)
        {
            Multiply_Purchase();
        }

        private void Product_list_Data_grideView_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void button15_Click(object sender, EventArgs e)
        {
            if (this.Purchase_DataGrideView.SelectedRows.Count == 1)
            {
                try
                {

                    DialogResult dialogResult = MessageBox.Show("آیا مخواهید مورد انتخاب شده را حذف نماید ", "حذف کردن", MessageBoxButtons.YesNo);
                    if (dialogResult == DialogResult.Yes)
                    {
                        DataGridViewRow dr = Purchase_DataGrideView.SelectedRows[0];
                        Delete_Purchase_ID.Text = dr.Cells[0].Value.ToString();
                        // or simply use column name instead of index
                        //dr.Cells["id"].Value.ToString();
                        Delete_Purchase_Product();
                        total_Purchess();
                        foreach (DataGridViewRow item in this.Purchase_DataGrideView.SelectedRows)
                        {
                            Purchase_DataGrideView.Rows.RemoveAt(item.Index);
                        }
                    }
                    else if (dialogResult == DialogResult.No)
                    {
                    }
                }

                catch (Exception)
                {
                    DataAccess.con.Close();
                    MessageBox.Show("لطفا  روح را انتخاب کنید");
                }
            }
            else
            {
                MessageBox.Show("لطفا روح را انتخاب کنید");

            }
            Delete_Purchase_ID.Clear();
        }

        private void PurchaseInvoiceSave_Click(object sender, EventArgs e)
        {

            if (string.IsNullOrWhiteSpace(New_Supplier_Name.Text))
            {
                MessageBox.Show("جای نام مشتری خالی است");
            }

            else
            {
                Puchase_Total_Amount();

                Puchase_ID.Clear();
                New_Supplier_Name.Clear();
                Purches_ChackUp.Clear();
                Purchase_Selller_Name.Clear();
                Purchase_Product_ID.Clear();
                Delete_Purchase_ID.Clear();
                Purchase_Total.Clear();
                purchase_Paid.Clear();
                Purchase_DataGrideView.DataSource = null;
                    MessageBox.Show("ثبت موفق بود");
                

            }


        }




    }




        //--------------------------------------------------------------------------------------Take_From Customer-----------------------------Pay to Bank----------------------------------





    }






