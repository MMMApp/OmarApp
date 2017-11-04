using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;

namespace WindowsFormsApplication2
{
    class db
    {
       SqlConnection con = new SqlConnection("Server=MBP-WIN-M\\SQLEXPRESS;Database=MobileData;User Id=sa;Password = hodaka; ");
        
        public DataSet Invoice_product(int invid)
        {
            SqlCommand com = new SqlCommand("Sp_InvoiceDetail_InvoiceID", con);
            com.CommandType = CommandType.StoredProcedure;
            com.Parameters.AddWithValue("@I_ID", invid);
            SqlDataAdapter da = new SqlDataAdapter(com);
            DataSet ds = new DataSet();
            da.Fill(ds);
            return ds;
        }


        public DataSet Customer_info(int cust_id)
        {
            SqlCommand com = new SqlCommand("Sp_Customer_id", con);
            com.CommandType = CommandType.StoredProcedure;
            com.Parameters.AddWithValue("@Cust_id", cust_id);
            SqlDataAdapter da = new SqlDataAdapter(com);
            DataSet ds = new DataSet();
            da.Fill(ds);
            return ds;
        }


        public DataSet Inv_info(int invid)
        {
            SqlCommand com = new SqlCommand("Sp_Sales_InvoiceInfo_invid", con);
            com.CommandType = CommandType.StoredProcedure;
            com.Parameters.AddWithValue("@I_ID", invid);
            SqlDataAdapter da = new SqlDataAdapter(com);
            DataSet ds = new DataSet();
            da.Fill(ds);
            return ds;
        }


    }
}
