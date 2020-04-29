using System;

namespace PayrollSoftware.Classes
{
    public class Staff
    {
        private float _hourlyRate;
        private int _hoursWorked;

        public string NameOfStaff { get; private set; }
        public float BasicPay { get; private set; }
        public float TotalPay { get; protected set; }
        public int HoursWorked
        {
            get => _hoursWorked;
            set
            {
                if (value > 0)
                    _hoursWorked = value;
                else
                    _hoursWorked = 0;
            }
        }

        public Staff(string name, float rate)
        {
            NameOfStaff = name;
            _hourlyRate = rate;
        }

        public virtual void CalculatePay()
        {
            Console.WriteLine("Calculating Pay...");
            BasicPay = _hoursWorked * _hourlyRate;
            TotalPay = BasicPay;
        }

        public override string ToString()
        {
            return $"Name of staff: {NameOfStaff} \n Hourly rate: {_hourlyRate} \n Hours worked: {_hoursWorked} \n Basic pay: {BasicPay} \n Total pay: {TotalPay}";
        }


    }
}