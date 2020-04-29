using System.IO;
using System.Collections.Generic;
using System;

namespace PayrollSoftware.Classes
{
    public class FileReader
    {
        public List<Staff> ReadFile()
        {
            var myStaff = new List<Staff>();
            var result = new string[2];
            var path = "staff.txt";
            string[] separator = {", "};

            if (File.Exists(path))
            {
                using (var streamReader = new StreamReader(path))
                {
                    while (!streamReader.EndOfStream)
                    {
                        result = streamReader.ReadLine().Split(separator, StringSplitOptions.None);
                        if (result[1] == "Manager")
                            myStaff.Add(new Manager(result[0]));
                        
                        if (result[1] == "Admin")
                            myStaff.Add(new Admin(result[0]));
                    }
                    streamReader.Close();
                }
            }
            else
            {
                Console.WriteLine("The file ");
            }

            return myStaff;
        }
    }
}