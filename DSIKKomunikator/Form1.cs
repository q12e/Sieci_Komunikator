using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DSIKKomunikator
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        public static string username = "";
        public static string server = "";
        public static int port;




        private void LogInButton_Click(object sender, EventArgs e)
        {
            username = UserNameBox.Text;
            server = AdressBox.Text;
            bool test = Int32.TryParse(PortBox.Text, out port);
            MessageBox.Show("Name: " + username + "\r\nServer: " + server + "\r\nPort: " + port);
            Form2 kom = new Form2();
            kom.Show();
            this.Hide();
        }
        
    }
}
