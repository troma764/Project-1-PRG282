using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project_1
{
    internal class TextFiles
    {
        public string name { get; set; }
        public string surname { get; set; }
        public string emailAddress { get; set; }
        public string username { get; set; }
        public string password { get; set; }

        public string SaveFiles()
        {
            string input = "";

            string filepath = @"C:\Users\pc\Documents\Project\Project 1\bin\\Debug\\" + username + ".txt";

            try
            {
                using (StreamWriter writer = new StreamWriter(filepath))
                {
                    writer.WriteLine($"Name:{name}");
                    writer.WriteLine($"Surname : {surname}");
                    writer.WriteLine($"Email : {emailAddress}");
                    writer.WriteLine($"Username : {username}");
                    writer.WriteLine($"Password :{password}");

                    input = "Registered Succesfully";
                }
                return input;
            }
            catch (Exception)
            {
                return "Invalid Directory";
            }
        }

        public string LoginTxtFiles()
        {
            string input = "";

            string filepath = @"C:\Users\pc\Documents\Project\Project 1\bin\\Debug\\" + username + ".txt";

            try
            {
                using (StreamReader reader = new StreamReader(filepath))
                {
                    string line = reader.ReadLine();
                    while (line != null)
                    {
                        string[] lineArray = new string[3];
                        lineArray = line.Split(':');
                        if (lineArray[1] == password)
                        {
                            input = "Access Granted";
                            return input;
                        }
                        else
                        {
                            input = "Incorrect Paswword";
                        }
                        line = reader.ReadLine();
                    }
                }
            }
            catch (Exception)
            {
                input = "Incorrect Email Address";
            }
            return input;
        }
    }
}
