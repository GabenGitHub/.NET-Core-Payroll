namespace PayrollSoftware.Classes
{
    public class Manager : Staff
    {
        private const float _managerHourlyRate = 50;

        public int Allowance { get; private set; } = 1000;

        public Manager(string name) :base(name, _managerHourlyRate) {}

        public override void CalculatePay()
        {
            base.CalculatePay();

            if (HoursWorked > 160)
                TotalPay += Allowance;
        }

        public override string ToString()
        {
            return $"Name of staff: {NameOfStaff} \n Hours worked: {HoursWorked} \n Basic pay: {BasicPay} \n Total pay: {TotalPay}";
        }
    }
}