using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Project_1
{
    public partial class Registration : Form
    {
        public Registration()
        {
            InitializeComponent();
        }

        private void btnRegister_Click(object sender, EventArgs e)
        {   TextFiles filetext = new TextFiles();

            filetext.name = tbxFirstName.Text;
            filetext.surname = tbxLastname.Text;
            filetext.emailAddress = tbxEmail.Text;
            filetext.username = tbxUsername.Text;
            filetext.password = tbxPassword.Text;

            MessageBox.Show(filetext.SaveFiles());

            this.Close();
            
        }
    }
}
