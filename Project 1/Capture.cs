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
    public partial class Capture_Details : Form
    {
        SqlConnection connection;
        SqlCommand cmd;
        SqlDataReader reader;
        DataHandler dataHandler = new DataHandler();
        public Capture_Details()
        {
            InitializeComponent();
            connection = new SqlConnection("Server=(local); Initial Catalog=StudentDetails; Integrated Security=SSPI");
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

        private void btnInsert_Click(object sender, EventArgs e)
        {
            if (txtStudentNo.Text == "" || txtName.Text == "" || txtSurname.Text == "" || txtAddress.Text == "" ||
                dateTimePicker1.Text == "" || comboBox1.Text == "")
            {
                MessageBox.Show("Please enter student details");
            }
            else
            {
                if (rbtnMale.Checked == true)
                {
                    dataHandler.insertStudent(Convert.ToInt32(txtStudentNo.Text), txtName.Text, txtSurname.Text, "Male",
                        dateTimePicker1.Text, txtAddress.Text, comboBox1.Text);
                }
                else if (rbtnFemale.Checked == true)
                {
                    dataHandler.insertStudent(Convert.ToInt32(txtStudentNo.Text), txtName.Text, txtSurname.Text, "Female",
                        dateTimePicker1.Text, txtAddress.Text, comboBox1.Text);
                }
                else
                {
                    MessageBox.Show("Please choose student gender");
                }
            }
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            if (txtStudentNo.Text == "" || txtName.Text == "" || txtSurname.Text == "" || txtAddress.Text == "" ||
                dateTimePicker1.Text == "" || comboBox1.Text == "")
            {
                MessageBox.Show("Please enter student details");
            }
            else
            {
                if (dataHandler.searchStudent(Convert.ToInt32(txtStudentNo.Text)) == true)
                {
                    if (rbtnMale.Checked == true)
                    {
                        dataHandler.updateStudent(Convert.ToInt32(txtStudentNo.Text), txtName.Text, txtSurname.Text, "Male",
                            dateTimePicker1.Text, txtAddress.Text);
                    }
                    else if (rbtnFemale.Checked == true)
                    {
                        dataHandler.updateStudent(Convert.ToInt32(txtStudentNo.Text), txtName.Text, txtSurname.Text, "Female",
                            dateTimePicker1.Text, txtAddress.Text);
                    }
                    else
                    {
                        MessageBox.Show("Please choose student gender");
                    }
                }
                else
                {
                    MessageBox.Show("Student details not updated");
                }

            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (txtStudentNo.Text == "")
            {
                MessageBox.Show("Please enter student number");
            }
            else
            {
                if (dataHandler.searchStudent(Convert.ToInt32(txtStudentNo.Text)) == true)
                {
                    dataHandler.deleteStudent(Convert.ToInt32(txtStudentNo.Text));
                }
                else
                {
                    MessageBox.Show("Student details not deleted");
                }
            }
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            if (txtSearch.Text == "")
            {
                MessageBox.Show("Please enter student number");
            }
            else
            {
                if (dataHandler.searchStudent(Convert.ToInt32(txtSearch.Text)) == true)
                {
                    string searchQuery = ("SELECT Student.StudentNumber, FirstName, LastName, Module.ModuleCode, ModuleName, Lecturer, StartDate, EndDate, Credits " +
                        "FROM Student INNER JOIN StudentModule ON StudentModule.StudentNumber = Student.StudentNumber " +
                        "INNER JOIN Module ON Module.ModuleCode = StudentModule.ModuleCode " +
                        "WHERE Student.StudentNumber = '" + Convert.ToInt32(txtSearch.Text) + "'");

                    connection.Open();
                    cmd = new SqlCommand(searchQuery, connection);

                    reader = cmd.ExecuteReader();
                    BindingSource source = new BindingSource();
                    source.DataSource = reader;
                    dGVStudentSearch.DataSource = source;
                    reader.Close();
                    connection.Close();
                }
            }
        }
    }
}
