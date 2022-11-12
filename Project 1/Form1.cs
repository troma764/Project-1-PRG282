using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Project_1
{
    public partial class Form1 : Form
    {
        SqlConnection conn = new SqlConnection("Server =LAPTOP-R3UI0P7F; Initial Catalog =PremierLeague; Integrated Security =True");
        public Form1()
        {
            InitializeComponent();
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            String username, user_password;

            username = txtboxUsername.Text;
            user_password = txtboxPassword.Text;

            if (txtboxUsername.Text == "" || txtboxPassword.Text == "")
            {
                MessageBox.Show("Need login data", "Wrong Login", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                string uname = txtboxUsername.Text;
                string pass = txtboxPassword.Text;  
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }
    }
}
