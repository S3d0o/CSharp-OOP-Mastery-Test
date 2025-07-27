
namespace CSharp_OOP_Mastery_Test.Models
{
    // just a helper class that creates employees, like a factory in real life.
    // It’s static because it’s a global service
    internal static class EmployeeFactory
    {
        private static HashSet<int> existingIds = new();

        internal static HourlyEmployee CreateHourly(string fname, string lname, int age, int id, decimal rate, int hours)
        {
            if (existingIds.Contains(id))
                throw new Exception("Duplicate employee ID");

            existingIds.Add(id);
            return new HourlyEmployee(fname, lname, age, id, rate, hours);
        }
        internal static SalariedEmployee CreatedSalaried(string fname, string lname, int age, int id, decimal hourly_rate, int hours_worked)
        {
            if (existingIds.Contains(id))
                throw new Exception("Duplicate employee ID");

            existingIds.Add(id);
            return new SalariedEmployee(fname, lname, age, id,  hourly_rate,  hours_worked);
        }
    }

}

