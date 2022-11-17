using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Windows.Forms;
using System.Threading;

namespace Project_1
{
    class DataHandler
    {
        private int studentNumber;
        private string studentName;
        private string studentSurname;
        private string module;
        private string gender;
        private string dob;
        private string address;

        SqlConnection connection;
        SqlCommand command;
        SqlDataReader reader;
        string conn = @"Server = (local);Initial Catalog = StudentDetails; Integrated Security = true";

        public DataHandler()
        {
        }

        public DataHandler(int studentNumber, string studentName, string studentSurname, string module, string gender,
            string dob, string address)
        {
            this.StudentNumber = studentNumber;
            this.StudentName = studentName;
            this.StudentSurname = studentSurname;
            this.Module = module;
            this.Gender = gender;
            this.Dob = dob;
            this.Address = address;
        }

        public int StudentNumber { get => studentNumber; set => studentNumber = value; }
        public string StudentName { get => studentName; set => studentName = value; }
        public string StudentSurname { get => studentSurname; set => studentSurname = value; }
        public string Module { get => module; set => module = value; }
        public string Gender { get => gender; set => gender = value; }
        public string Dob { get => dob; set => dob = value; }
        public string Address { get => address; set => address = value; }

        public void openConnection()
        {
            connection = new SqlConnection(conn);
            connection.Open();
        }

        public void insertStudent(int studentNumber, string studentName, string studentSurname,
            string gender, string dob, string address, string moduleCode)
        {
            string insertQuery = ("INSERT INTO Student VALUES('" + studentNumber + "', '" + studentName + "', '" +
                studentSurname + "', '" + gender + "', '" + Convert.ToDateTime(dob) + "', '" + address + "')");
            string insertConnection = ("INSERT INTO StudentModule VALUES('" + studentNumber + "', '" + moduleCode + "')");

            openConnection();
            command = new SqlCommand(insertQuery, connection);
            SqlCommand comm = new SqlCommand(insertConnection, connection);

            try
            {
                command.ExecuteNonQuery();
                comm.ExecuteNonQuery();
                MessageBox.Show("Student detials entered");
            }
            catch (SqlException error)
            {
                MessageBox.Show(error.ToString());
            }
            finally
            {
                if (connection != null)
                {
                    connection.Close();
                }
            }
        }

        public void deleteStudent(int studentNumber)
        {
            string deleteQuery = ("DELETE FROM StudentModule WHERE StudentNumber = '" + studentNumber + "'");
            string deleteStudent = ("DELETE FROM Student WHERE StudentNumber = '" + studentNumber + "'");

            openConnection();
            command = new SqlCommand(deleteQuery, connection);
            SqlCommand comm = new SqlCommand(deleteStudent, connection);

            try
            {
                command.ExecuteNonQuery();
                Thread.Sleep(3000);
                comm.ExecuteNonQuery();

                MessageBox.Show("Student with student number " + studentNumber + " has been deleted");
            }
            catch (SqlException error)
            {
                MessageBox.Show(error.ToString());
            }
            finally
            {
                if (connection != null)
                {
                    connection.Close();
                }
            }
        }

        public void updateStudent(int studentNumber, string studentName, string studentSurname,
            string gender, string dob, string address)
        {
            string updateQuery = ("UPDATE Student SET FirstName = '" + studentName + "', LastName = '" +
                studentSurname + "', Gender = '" + gender + "', DateOfBirth = '" + Convert.ToDateTime(dob) + "', Address = '" + address
                + "' WHERE StudentNumber = '" + studentNumber + "'");

            openConnection();
            command = new SqlCommand(updateQuery, connection);

            try
            {
                command.ExecuteNonQuery();
                MessageBox.Show("Student details has been updated");
            }
            catch (SqlException error)
            {
                MessageBox.Show(error.ToString());
            }
            finally
            {
                if (connection != null)
                {
                    connection.Close();
                }
            }
        }

        public bool searchStudent(int studentNumber)
        {
            bool found = false;
            string searchQuery = ("SELECT * FROM Student WHERE StudentNumber = '" + studentNumber + "'");

            openConnection();
            command = new SqlCommand(searchQuery, connection);

            try
            {
                reader = command.ExecuteReader();

                if (reader.Read())
                {
                    MessageBox.Show("Student with student number " + studentNumber + " has been found");
                    found = true;
                }
                else
                {
                    MessageBox.Show("Student with student number " + studentNumber + " has not been found");
                }

            }
            catch (SqlException error)
            {
                MessageBox.Show(error.ToString());
            }
            finally
            {
                if (connection != null)
                {
                    connection.Close();
                }

                if (reader != null)
                {
                    reader.Close();
                }
            }

            if (found == true)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
