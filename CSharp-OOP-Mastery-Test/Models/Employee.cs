

namespace CSharp_OOP_Mastery_Test.Models
{
    internal abstract class Employee : Person, IComparable<Employee>, ICloneable
    {
        public int employeeId;
       
        protected Employee(string fname, string lname, int age, int id)
            : base(fname, lname, age)
        {
            if (id <= 0)
                throw new ArgumentOutOfRangeException(nameof(id), "Employee ID must be a positive integer.");
            employeeId = id;
        }
        public int GetEmployeeId()
        {
            return employeeId;
        }
        public abstract decimal CalculatePay(); // will be implemented in derived classes
        public virtual void Describe() // will be overridden in derived classes
        {
            Console.WriteLine($"This person is an employee his details:\n " +
                                    $"id : {employeeId}\n fullName :{FullName}");
        }
        public int CompareTo(Employee? other)
        {
            return this.employeeId.CompareTo(other?.employeeId ?? 0);
        }
        public abstract object Clone();



    }
}
