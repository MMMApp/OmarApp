using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApplication2
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        db dblayer = new db();
        private void Form1_Load(object sender, EventArgs e)
        {
            List<InvoiceDetail> _List = new List<InvoiceDetail>();
            DataSet ds = dblayer.Invoice_product(1);
            foreach(DataRow dr in ds.Tables[0].Rows)
            {
                _List.Add(new InvoiceDetail
                {
                    ProductName = dr["P_ID"].ToString(),
                    Quantity = dr["Quantity"].ToString(),
                    Amount = dr["Sell_Price"].ToString(),
                    ProductID = dr["Total_amount"].ToString(),
                });
            }


            DataSet ds2 = dblayer.Customer_info(3062);
            foreach(DataRow dr in ds2.Tables[0].Rows)
            {
                salesInvoice1.SetDataSource(_List);
                salesInvoice1.SetParameterValue("pCustomer",dr["C_Name"].ToString());
                salesInvoice1.SetParameterValue("pAddress",dr["C_Location"].ToString());
                salesInvoice1.SetParameterValue("pPhoneNumber", dr["C_Phone"].ToString());
                salesInvoice1.SetParameterValue("pInvoiceID",1);


                DataSet ds3 = dblayer.Inv_info(1);
                foreach (DataRow dr1 in ds3.Tables[0].Rows)
                {
                    salesInvoice1.SetParameterValue("pDate", dr1["I_Date"]);
                    salesInvoice1.SetParameterValue("Grand_total", dr1["Grand_Total"]);
                    salesInvoice1.SetParameterValue("Total_paid", dr1["Total_Paid"]);
                    salesInvoice1.SetParameterValue("Balance", dr1["Balance"]);
                }


                crystalReportViewer1.ReportSource = salesInvoice1;



            }

        }
    }
}
