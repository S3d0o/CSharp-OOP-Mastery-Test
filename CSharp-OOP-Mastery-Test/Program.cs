using CSharp_OOP_Mastery_Test.Models;

namespace CSharp_OOP_Mastery_Test
{
    internal class Program
    {
        static void Main()
        {
             HourlyEmployee emp1 = new HourlyEmployee
                ("John", "Doe", 30, 1, 20.5m, 40);
            HourlyEmployee emp2 = new HourlyEmployee
                ("saad", "mo", 23, 1, 22m, 50);
        }
    }
}
