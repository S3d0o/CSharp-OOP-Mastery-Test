
using CSharp_OOP_Mastery_Test.Interfaces;

namespace CSharp_OOP_Mastery_Test.Models
{
    internal class SalariedEmployee : Employee, ITaxable
    {
        public decimal hourly_rate { get; private set; }
        public int hours_worked { get; private set; }

        public SalariedEmployee(string fname, string lname, int age, int id, decimal hourly_rate, int hours_worked)
            : base(fname, lname, age, id)
        {
            if(hourly_rate <= 0)
                throw new ArgumentOutOfRangeException(nameof(hourly_rate), "Hourly rate must be a positive value.");
            if(hours_worked < 0)
                throw new ArgumentOutOfRangeException(nameof(hours_worked), "Hours worked cannot be negative.");

            this.hourly_rate = hourly_rate;
            this.hours_worked = hours_worked;
        }
        
        public override decimal CalculatePay()
        {
            return hourly_rate * hours_worked;
        }
        public override void Describe()
        {
            Console.WriteLine($"This employee is a salaried employee with the following details:\n" +
                              $"ID: {employeeId}\n" +
                              $"Full Name: {FullName}\n" +
                              $"Hourly Rate: {hourly_rate:C}\n" +
                              $"Hours Worked: {hours_worked}\n" +
                              $"Total Pay: {CalculatePay():C}");
        }
        public decimal CalculateTax()
        {
            return CalculatePay() * 1.2m; // Assuming a flat tax rate of 20%
        }
    }
}
