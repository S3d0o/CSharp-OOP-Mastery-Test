using CSharp_OOP_Mastery_Test.Collections;
using CSharp_OOP_Mastery_Test.Models;

namespace CSharp_OOP_Mastery_Test
{
    internal class Program
    {
        static void Main()
        {

            // Create Salaried Employees
            SalariedEmployee se1 = new SalariedEmployee("John", "Doe", 30, 1, 50, 60);
            SalariedEmployee se2 = new SalariedEmployee("Saad", "Mo", 20, 2, 55, 60);

            // Display Salaried Employee Details
            se1.Describe();
            Console.WriteLine("------------------------------------------------");

            // Create Hourly Employees
            HourlyEmployee he1 = new HourlyEmployee("Jane", "Smith", 25, 3, 20, 40);
            HourlyEmployee he2 = new HourlyEmployee("Alice", "Johnson", 28, 4, 25, 35);

            // Recommended way: use EmployeeFactory to create employees
            HourlyEmployee he3 = new(EmployeeFactory.CreateHourly("Kamel", "Ibrahim", 21, 01, 30, 70));
            SalariedEmployee se3 = new(EmployeeFactory.CreatedSalaried("Mohamed", "Sayed", 11, 02, 100, 160));

            he3.Describe();
            Console.WriteLine("------------------------------------------------");
            se3.Describe();
            Console.WriteLine("------------------------------------------------");

            // Display Hourly Employee Details
            he1.Describe();
            Console.WriteLine("------------------------------------------------");

            // Create initial employee list and team
            List<Employee> employees = new List<Employee> { se1, se2 };
            Project projectX = new Project("Project X", 30);
            Team team1 = new Team(employees, projectX);
            
            Console.WriteLine(team1);
            Console.WriteLine($"Salary after tax {he1.FullName}: {he1.CalculateTax()}");
            Console.WriteLine("------------------------------------------------");

            // Add hourly employees to the team
            team1.AddEmployee(he1);
            team1.AddEmployee(he2);

            // Print team details
            team1.PrintTeamDetails();
            Console.WriteLine("------------------------------------------------");

            // Add multiple projects to the team
            team1.AddProject(new Project("Project Alpha", 30));
            team1.AddProject(new Project("Project Beta", 45));

            team1.PrintProjects();
            Console.WriteLine("------------------------------------------------");
            Console.WriteLine(team1);
            Console.WriteLine("------------------------------------------------");

            // Access specific employee from the team, testing the team indexer
            Console.WriteLine($"Employee at index 3: {team1[3].FullName}");
            Console.WriteLine("------------------------------------------------");

            // Create another team
            List<Employee> employees2 = new List<Employee>
            {
                new SalariedEmployee("Alice", "Brown", 35, 5, 60, 50),
                new SalariedEmployee("Charlie", "Black", 32, 7, 65, 55),
                new HourlyEmployee("Bob", "White", 40, 6, 30, 45),
                new HourlyEmployee("Eve", "Green", 29, 8, 28, 50)
            };
            Project projectGamma = new Project("Project Gamma", 50);
            Team team2 = new Team(employees2, projectGamma);

            Console.WriteLine(team2);
            Console.WriteLine("------------------------------------------------");

            // Combine two teams using overloaded + operator
            Team combinedTeam = team1 + team2;
            Console.WriteLine("Combined Team Details:");
            Console.WriteLine(combinedTeam);
            combinedTeam.PrintTeamDetails();
            Console.WriteLine("------------------------------------------------");

            // Clone HourlyEmployee using ICloneable
            HourlyEmployee clonedHe1 = (HourlyEmployee)he1.Clone(); // Requires casting
            HourlyEmployee clonedHe2 = he2.CloneHE();               // Custom typed clone method

            // Display formatted ID with leading zero
            Console.WriteLine($"Employee ID with padding: {se3.GetEmployeeId().ToString("D3")}");
            Console.WriteLine("------------------------------------------------");

            Console.WriteLine("Sorting Employees by ID...");
            List<Employee> emps = new List<Employee> { se1, se2, se3, he1 };

            foreach (var emp in emps)
            {
                Console.WriteLine($"{emp.FullName} (ID: {emp.GetEmployeeId()})");
            }
            Console.WriteLine("------------------------------------------------");

            List<Employee> ee1 = new List<Employee>
            {
                new SalariedEmployee("Alice", "Brown", 35, 5, 60, 50),
                new HourlyEmployee("Eve", "Green", 29, 8, 28, 50)
            };
            List<Employee> ee2 = new List<Employee>
            {
                new SalariedEmployee("Charlie", "Black", 32, 7, 65, 55),
                new HourlyEmployee("Bob", "White", 40, 6, 30, 45)
            };
            Project pp1 = new Project("Project Delta", 60);
            Project pp2 = new Project("Project Epsilon", 70);

            Team ibra = new Team(ee1, pp1);
            Team s3d = new Team(ee2, pp2);
            Team combinedTeam2 = ibra + s3d;
            Console.WriteLine("Combined Team 2 Details:");
            Console.WriteLine(combinedTeam2);


        }
    }
}
