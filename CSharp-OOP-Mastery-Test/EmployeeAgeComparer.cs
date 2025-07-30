using CSharp_OOP_Mastery_Test.Models;

namespace CSharp_OOP_Mastery_Test
{
    internal class EmployeeAgeComparer : IComparer<Employee>
    {
        public int Compare(Employee? x, Employee? y)
        {
            return x?.age.CompareTo(y?.age ?? 0) ?? 0;
        }
    }
}
