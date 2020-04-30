namespace PayrollSoftware.Classes
{
    public class Admin : Staff
    {
        private const float _overtimeRate = 15.5f;
        private const float _adminHourlyRate = 30f;

        public float Overtime { get; private set; }

        public Admin(string name) :base(name, _adminHourlyRate) {}

        public override void CalculatePay()
        {
            base.CalculatePay();

            if (HoursWorked > 160)
            {
                Overtime = _overtimeRate * (HoursWorked - 160);
                TotalPay += Overtime;
            }
        }

        public override string ToString()
        {
            return $"Name of staff: {NameOfStaff} \nHours worked: {HoursWorked} \nBasic pay: {BasicPay:C} \nTotal pay: {TotalPay:C}";

        }
    }
}