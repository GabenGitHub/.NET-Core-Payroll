using System.IO;
using System.Collections.Generic;
using System.Linq;

namespace PayrollSoftware.Classes
{
    public class PaySlip
    {
        private int _month;
        private int _year;

        enum MonthsOfYear
        {
            JAN = 1,
            FEB = 2,
            MAR = 3,
            APR = 4,
            MAY = 5,
            JUN = 6,
            JUL = 7,
            AUG = 8,
            SEP = 9,
            OCT = 10,
            NOV = 11,
            DEC = 12
        }

        public PaySlip(int payMonth, int payYear)
        {
            _month = payMonth;
            _year = payYear;
        }

        public void GeneratePaySlip(List<Staff> myStaff)
        {
            string path;
            foreach (var staff in myStaff)
            {
                path = staff.NameOfStaff + ".txt";

                using (var streamWriter = new StreamWriter(path))
                {
                    streamWriter.WriteLine($"PAYSLIP FOR {(MonthsOfYear)_month} {_year}");
                    streamWriter.WriteLine($"==================================");
                    streamWriter.WriteLine($"Name of Staff: {staff.NameOfStaff}");
                    streamWriter.WriteLine($"Hours Worked: {staff.HoursWorked}");
                    streamWriter.WriteLine();
                    streamWriter.WriteLine($"Basic Pay: {staff.BasicPay:C}");

                    if (staff.GetType() == typeof(Manager))
                        streamWriter.WriteLine($"Allowance: {((Manager)staff).Allowance:C}");

                    if (staff.GetType() == typeof(Admin))
                        streamWriter.WriteLine($"Overtime: {((Admin)staff).Overtime:C}");

                    streamWriter.WriteLine();
                    streamWriter.WriteLine($"==================================");
                    streamWriter.WriteLine($"Total Pay: {staff.TotalPay:C}");
                    streamWriter.WriteLine($"==================================");

                    streamWriter.Close();
                }
            }
        }

        public void GenerateSummary(List<Staff> myStaff)
        {
            var criteriaOfHoursWorked = 10;
            var result = 
                from staff in myStaff
                where staff.HoursWorked < criteriaOfHoursWorked
                orderby staff.NameOfStaff ascending
                select new { staff.NameOfStaff, staff.HoursWorked };

            var path = "summary.txt";
            using (var streamWriter = new StreamWriter(path))
            {
                streamWriter.WriteLine($"Staff with less than {criteriaOfHoursWorked} working hours");
                streamWriter.WriteLine();

                foreach (var staff in result)
                {
                    streamWriter.WriteLine($"Name of Staff: {staff.NameOfStaff}, Hours Worked: {staff.HoursWorked}");
                }

                streamWriter.Close();
            }
        }
    }
}