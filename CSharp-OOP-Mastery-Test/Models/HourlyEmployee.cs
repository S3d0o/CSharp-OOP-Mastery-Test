
using CSharp_OOP_Mastery_Test.Interfaces;

namespace CSharp_OOP_Mastery_Test.Models
{
    internal class HourlyEmployee : Employee ,ITaxable
    {
        private decimal hourlyRate;
        private int hoursWorked;
        public HourlyEmployee(string fname , string lname , int age , int id,decimal hourlyRate, int hoursWorked) 
            : base(fname,lname,age,id)
            
        {
            if (hourlyRate <= 0) throw new ArgumentOutOfRangeException(nameof(hourlyRate));
            if (hoursWorked < 0) throw new ArgumentOutOfRangeException(nameof(hoursWorked));

            this.hourlyRate = hourlyRate;
            this.hoursWorked = hoursWorked;
        }

        public override decimal CalculatePay()
        {
            return hourlyRate * hoursWorked;
        }
        public override void Describe()
        {
            
            Console.WriteLine($"This employee is an hourly employee his details:\n " +
                              $"id : {employeeId}\n" +
                              $"fullName : {FullName}\n" +
                              $"hourlyRate : {hourlyRate}\n hoursWorked :{hoursWorked}\n" +
                              $"Total Pay : {CalculatePay()}");

        }
        public decimal CalculateTax()
        {
            return CalculatePay() * 1.2m; // Assuming a flat tax rate of 20%
        }
    }
}
