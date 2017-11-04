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




namespace WindowsFormsApplication2
{
    public partial class Form1 : Form
    {

public Form1()
        {

            InitializeComponent();
        }


        private void button9_Click(object sender, EventArgs e)
        {
            MainTabs.SelectedIndex = 1;
        }

        private void button5_Click(object sender, EventArgs e)
        {
            MainTabs.SelectedIndex = 1;
        }

        private void button14_Click(object sender, EventArgs e)
        {
            MainTabs.SelectedIndex = 0;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            MainTabs.SelectedIndex = 2;
        }

        private void button21_Click(object sender, EventArgs e)
        {
            MainTabs.SelectedIndex = 3;
        }

        private void button6_Click(object sender, EventArgs e)
        {
            MainTabs.SelectedIndex = 4;
        }

        private void button25_Click(object sender, EventArgs e)
        {
            MainTabs.SelectedIndex = 5;
        }

        private void tableLayoutPanel5_Paint_1(object sender, PaintEventArgs e)
        {

        }

        private void button11_Click_1(object sender, EventArgs e)
        {
           
        }

        private void Form1_Load(object sender, EventArgs e)
        {
           

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void customerBindingSource_CurrentChanged(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged_1(object sender, EventArgs e)
        {
           
        }

        private void button9_Click_1(object sender, EventArgs e)
        {
            MainTabs.SelectedIndex = 3;
        }

        private void button12_Click(object sender, EventArgs e)
        {
            MainTabs.SelectedIndex = 0;
        }

        private void textBox14_TextChanged(object sender, EventArgs e)
        {

        }

        private void dataGridView2_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void tableLayoutPanel20_Paint(object sender, PaintEventArgs e)
        {

        }



        private void tableLayoutPanel13_Paint(object sender, PaintEventArgs e)
        {

        }


        private void button32_Click(object sender, EventArgs e)
        {
            MainTabs.SelectedIndex = 5;
        }

        private void button23_Click(object sender, EventArgs e)
        {
            MainTabs.SelectedIndex = 5;
        }

        private void button5_Click_1(object sender, EventArgs e)
        {
            MainTabs.SelectedIndex = 1;
        }

        private void tableLayoutPanel9_Paint(object sender, PaintEventArgs e)
        {

        }

        private void tableLayoutPanel24_Paint(object sender, PaintEventArgs e)
        {

        }

        private void label26_Click(object sender, EventArgs e)
        {

        }

        private void tableLayoutPanel29_Paint(object sender, PaintEventArgs e)
        {

        }

        private void Inv_Customer_TextChanged(object sender, EventArgs e)
        {
            
        }

        private void tableLayoutPanel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void Sales_Click(object sender, EventArgs e)
        {
            MainTabs.SelectedIndex = 1;
        }

        private void Customers_Click(object sender, EventArgs e)
        {
            MainTabs.SelectedIndex = 2;
        }

        private void Item_Return_Click(object sender, EventArgs e)
        {
            MainTabs.SelectedIndex = 6;
        }

        private void Invoices_Click(object sender, EventArgs e)
        {
            MainTabs.SelectedIndex = 4;
        }

        private void Back_Sales_Click(object sender, EventArgs e)
        {
            MainTabs.SelectedIndex = 0;
        }

        private void Back_Customers_Click(object sender, EventArgs e)
        {
            MainTabs.SelectedIndex = 1;
        }

        private void Customer_New_Click(object sender, EventArgs e)
        {
            MainTabs.SelectedIndex = 3;
        }

        private void Customer_Remove_Click(object sender, EventArgs e)
        {

        }

        private void Customers_Refresh_Click(object sender, EventArgs e)
        {

        }

        private void Back_NewCustomer_Click(object sender, EventArgs e)
        {
            MainTabs.SelectedIndex = 2;
        }

        private void Invoices_Back_Click(object sender, EventArgs e)
        {
            MainTabs.SelectedIndex = 1;
        }

        private void Invoices_New_Click(object sender, EventArgs e)
        {
            MainTabs.SelectedIndex = 5;
        }

        private void Back_NewInvoice_Click(object sender, EventArgs e)
        {
            MainTabs.SelectedIndex = 4;
        }

        private void Customer_Invoice_Click(object sender, EventArgs e)
        {
            MainTabs.SelectedIndex = 5;
        }
        

        private void Purchases_Click(object sender, EventArgs e)
        {
            MainTabs.SelectedIndex = 7;
        }

        private void Items_Click(object sender, EventArgs e)
        {
            MainTabs.SelectedIndex = 8;
        }

        private void Supplier_Click(object sender, EventArgs e)
        {
            MainTabs.SelectedIndex = 9;
        }

        private void PurchasesReturn_Click(object sender, EventArgs e)
        {
            MainTabs.SelectedIndex = 0;
        }

        private void NewItemReturn_Click(object sender, EventArgs e)
        {
            MainTabs.SelectedIndex = 7;
        }

        private void NewSupplierItem_Click(object sender, EventArgs e)
        {
            MainTabs.SelectedIndex = 7;
        }

        private void PurchaseInvoiceReturn_Click(object sender, EventArgs e)
        {
            MainTabs.SelectedIndex = 7;
        }

        private void PurchaseInvoice_Click(object sender, EventArgs e)
        {
            MainTabs.SelectedIndex = 10;
        }

        private void BackItemReturn_Click(object sender, EventArgs e)
        {
            MainTabs.SelectedIndex = 1;
        }

        private void BackPurchaseItemReturn_Click(object sender, EventArgs e)
        {
            MainTabs.SelectedIndex = 7;
        }

        private void Loans_Click(object sender, EventArgs e)
        {
            MainTabs.SelectedIndex = 12;
        }

        private void CustomerLoan_Click(object sender, EventArgs e)
        {
            MainTabs.SelectedIndex = 13;
        }

        private void SupplierLoan_Click(object sender, EventArgs e)
        {
            MainTabs.SelectedIndex = 14;
        }

        private void BackLoanTab_Click(object sender, EventArgs e)
        {
            MainTabs.SelectedIndex = 0;
        }

        private void Back_CustomerLoanTab_Click(object sender, EventArgs e)
        {
            MainTabs.SelectedIndex = 12;
        }

        private void Back_SupplierLoanTab_Click(object sender, EventArgs e)
        {
            MainTabs.SelectedIndex = 12;
        }

        private void ReturnSuppliersItems_Click(object sender, EventArgs e)
        {
            MainTabs.SelectedIndex = 11;
        }

        private void Management_Click(object sender, EventArgs e)
        {
            MainTabs.SelectedIndex = 15;
        }

        private void Back_ManagementTab_Click(object sender, EventArgs e)
        {
            MainTabs.SelectedIndex = 0;
        }

        private void Employees_Click(object sender, EventArgs e)
        {
            MainTabs.SelectedIndex = 16;
        }

        private void Expenses_Click(object sender, EventArgs e)
        {
            MainTabs.SelectedIndex = 18;
        }

        private void MoneyTG_Click(object sender, EventArgs e)
        {
            MainTabs.SelectedIndex = 20;
        }

        private void Back_EmployeesTab_Click(object sender, EventArgs e)
        {
            MainTabs.SelectedIndex = 15;
        }

        private void NewEmployee_Click(object sender, EventArgs e)
        {
            MainTabs.SelectedIndex = 17;
        }

        private void Back_NewEmployee_Click(object sender, EventArgs e)
        {
            MainTabs.SelectedIndex = 16;
        }

        private void Back_ExpensesTab_Click(object sender, EventArgs e)
        {
            MainTabs.SelectedIndex = 15;
        }

        private void NewExpenses_Click(object sender, EventArgs e)
        {
            MainTabs.SelectedIndex = 19;
        }

        private void Back_MoneyTGTab_Click(object sender, EventArgs e)
        {
            MainTabs.SelectedIndex = 15;
        }

        private void NewMoneyTG_Click(object sender, EventArgs e)
        {
            MainTabs.SelectedIndex = 21;
        }

        private void Back_NewMoneyTG_Click(object sender, EventArgs e)
        {
            MainTabs.SelectedIndex = 20;
        }

        private void Back_NewExpense_Click(object sender, EventArgs e)
        {
            MainTabs.SelectedIndex = 18;
        }
    }
}
