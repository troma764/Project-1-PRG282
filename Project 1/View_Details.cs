using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace Project_1
{
    public partial class View_Details : Form
    {
        SqlConnection connection;
        SqlCommand command;
        SqlDataReader reader;
        string conn = @"Server = (local);Initial Catalog = StudentDetails; Integrated Security = true";
        public View_Details()
        {
            InitializeComponent();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            string displayQuery = ("SELECT Student.StudentNumber, FirstName, LastName, Gender, DateOfBirth, Address, Module.ModuleCode, ModuleName, Lecturer, StartDate, EndDate, Credits " +
                        "FROM Student INNER JOIN StudentModule ON StudentModule.StudentNumber = Student.StudentNumber " +
                        "INNER JOIN Module ON Module.ModuleCode = StudentModule.ModuleCode");

            connection = new SqlConnection(conn);
            connection.Open();
            command = new SqlCommand(displayQuery, connection);

            reader = command.ExecuteReader();
            BindingSource source = new BindingSource();
            source.DataSource = reader;
            dataGridView1.DataSource = source;
            reader.Close();
            connection.Close();
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            Capture_Details capture = new Capture_Details();        
            this.Hide();
            capture.ShowDialog();
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            Environment.Exit(0);
        }
    }
}
