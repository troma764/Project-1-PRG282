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
    public partial class Login : Form
    {
        
        int tries = 0;
        //SqlConnection conn = new SqlConnection("Server =LAPTOP-R3UI0P7F; Initial Catalog =PremierLeague; Integrated Security =True");
        public Login()
        {
            InitializeComponent();
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            string username = "me";
            string password = "123";
            //String username, user_password;

            //username = txtboxUsername.Text;
            //user_password = txtboxPassword.Text;

            if (txtboxUsername.Text == "" || txtboxPassword.Text == "")
            {
                MessageBox.Show("Fields can't be empty", "Empty fields", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                if (tries >= 3)
                {
                    MessageBox.Show("Attempts more than 3. Who are you?");
                    
                }
                else if (username.Equals(txtboxUsername.Text) && password.Equals(txtboxPassword.Text))
                {
                    Capture_Details capture = new Capture_Details();
                    MessageBox.Show($"Welcome back {username}");
                    this.Hide();
                    capture.ShowDialog();

                }

                else
                {
                    MessageBox.Show("Invalid username or password");

                }

                tries++;
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }
    }
}
