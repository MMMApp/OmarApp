using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApplication2
{
    public partial class Settings : Form
    {
        public Settings()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
           
        }

        private void Settings_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            var config = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);
            var connectionStringsSection = (ConnectionStringsSection)config.GetSection("connectionStrings");
            connectionStringsSection.ConnectionStrings["dbx"].ConnectionString = "Data Source=" + textBox1.Text + ";Initial Catalog=MobileData;Persist Security Info=True;User ID= sa;Password= " + textBox2.Text;
            config.Save();
            ConfigurationManager.RefreshSection("connectionStrings");

            Application.Restart();
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
