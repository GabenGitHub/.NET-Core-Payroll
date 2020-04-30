using System;
using System.Collections.Generic;
using PayrollSoftware.Classes;

namespace PayrollSoftware
{
    class Program
    {
        static void Main(string[] args)
        {
            var myStaff = new List<Staff>();
            var fileReader = new FileReader();
            int month = 0;
            int year = 0;

            while(year == 0)
            {
                Console.Write("Please enter the year between 1970 and 2020: ");
                try
                {
                    var input = Convert.ToInt32(Console.ReadLine());
                    if (input > 1970 && input <= 2020)
                    {
                        year = input;
                    }
                    else
                        Console.WriteLine("Invalid number");
                }
                catch (System.Exception)
                {
                    Console.WriteLine("Not a number");                    
                }
            }

            while (month == 0)
            {
                Console.Write("Please enter the month number: ");
                try
                {
                    var input = Convert.ToInt32(Console.ReadLine());
                    if (input >= 1 && input <= 12)
                    {
                        month = input;
                    }
                    else
                        Console.WriteLine("Invalid number");
                }
                catch (System.Exception)
                {
                    Console.WriteLine("Not a number"); 
                }
            }

            myStaff = fileReader.ReadFile();

            for (int i = 0; i < myStaff.Count; i++)
            {
                try
                {
                    Console.WriteLine();
                    Console.Write($"Enter hours worked for {myStaff[i].NameOfStaff}: ");
                    myStaff[i].HoursWorked = Convert.ToInt32(Console.ReadLine());
                    myStaff[i].CalculatePay();
                    Console.WriteLine(myStaff[i].ToString());
                }
                catch (System.Exception)
                {
                    Console.WriteLine("Invalid number");
                    i--;
                }
            }

            var paySlip = new PaySlip(month, year);
            paySlip.GeneratePaySlip(myStaff);
            paySlip.GenerateSummary(myStaff);

            Console.WriteLine();
            Console.WriteLine("Press any key to exit...");
            Console.ReadLine();
        }
    }
}
