﻿using System;
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
    public partial class Capture_Details : Form
    {
        SqlConnection connection;
        SqlCommand cmd;
        SqlDataReader reader;
        public Capture_Details()
        {
            InitializeComponent();
            connection = new SqlConnection("Server=(local); Initial Catalog=BelgiumCampusStud; Integrated Security=SSPI");
        }
        private void Capture_Details_Load(object sender, EventArgs e)
        {
            
           
        }

        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void btnViewDetails_Click(object sender, EventArgs e)
        {
         
            View_Details view= new View_Details();
            this.Hide();
            view.ShowDialog();
        }

    }
}
