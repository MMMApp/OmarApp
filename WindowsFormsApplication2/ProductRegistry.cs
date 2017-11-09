using AesEncDec;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Management;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml;

namespace WindowsFormsApplication2
{
    public partial class ProductRegistry : Form
    {
      
        public ProductRegistry()
        {
            InitializeComponent();
        }

        private void ProductRegistry_Load(object sender, EventArgs e)
        {
            ManagementObjectSearcher searcher = new ManagementObjectSearcher("SELECT SerialNumber FROM Win32_BaseBoard");
            foreach (ManagementObject MySerial in searcher.Get())
            {

                string bserial = MySerial.GetPropertyValue("SerialNumber").ToString();
                txtcopycode.Text = AesCrypt.Encrypt(bserial);
            }
            ProductRegistry pf = new ProductRegistry();
   
        }

        private void button1_Click(object sender, EventArgs e)
        {
            XmlTextReader reader = new XmlTextReader("LI.txt");
            XmlDocument doc = new XmlDocument();



            doc.Load(reader); //Assuming reader is your XmlReader 

            doc.SelectSingleNode("ActivationCode").InnerText = textBox2.Text.ToString();
            reader.Close();
            doc.Save(@"LI.txt");

            Application.Exit();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            ProductRegistry pf = new ProductRegistry();
            pf.Close();
            Application.Exit();

        }
    }
}
