
using CSharp_OOP_Mastery_Test.Models;


namespace CSharp_OOP_Mastery_Test.Collections
{
    internal class Team
    {
        public int Count => _employees.Count();
        public Project[] Projects { get; set; } = new Project[5]; // Array of projects with a capacity of 5

        private List<Employee> _employees;
        private Dictionary<int, Employee> employeeMap;

        public Team(List<Employee> initialEmployees)
        {
            _employees = new List<Employee>();
            employeeMap = new Dictionary<int, Employee>();

            if (initialEmployees == null)
                throw new ArgumentNullException(nameof(initialEmployees), "Initial employees list cannot be null.");

            foreach (Employee emp in initialEmployees)
            {
                if (emp == null)
                    throw new ArgumentNullException(nameof(emp), "Employee cannot be null.");
                if (emp.GetEmployeeId() <= 0)
                    throw new ArgumentOutOfRangeException(nameof(emp), "Employee ID must be a positive integer.");

                AddEmployee(emp);
            }
        }
        public Team(List<Employee> initialEmployees,Project p)
            :this(initialEmployees)
        {
            if (Projects[4] is not null)
                throw new InvalidOperationException("Project array is full. Cannot add more projects.");
            for (int i  = 0; i<Projects.Length; i++)
            {
                if (Projects[i] is null)
                {
                    Projects[i] = p;
                    break; // Exit the loop once the project is added
                }
            }
        }
        public Team(List<Employee> employees , Project[] projects , Dictionary<int,Employee> empMap )
        {
            _employees = employees;
            Projects = projects;
            employeeMap = empMap;
        }
        // indexer to fast acsess member of the team, ex: team[0]
        public Employee this[int index]
        {
            get
            {
                if (index < 0)
                    throw new ArgumentOutOfRangeException(nameof(index), "Index cannot be a negative");
                if (index >= _employees.Count)
                    throw new ArgumentOutOfRangeException(nameof(index), "Index is out of range.");
                return _employees[index];
            }
        }
        public void AddEmployee(Employee emp)
        {
            if (employeeMap.ContainsKey(emp.employeeId))
                throw new ArgumentException("Employee with this ID already exists.", nameof(emp));

            employeeMap.Add(emp.GetEmployeeId(), emp);
            _employees.Add(emp);
        }
        public Employee GetEmployeeById(int id)
        {
            if (id <= 0)
                throw new ArgumentOutOfRangeException(nameof(id), "Employee ID must be a positive integer.");
            if (!employeeMap.ContainsKey(id))
                throw new KeyNotFoundException($"No employee found with ID {id}.");
            return employeeMap[id];
        }
        public void RemoveEmployeeById(int id)
        {
            #region Remove Emp from the Dictionary 

            if (id <= 0)
                throw new ArgumentOutOfRangeException(nameof(id), "Employee ID must be a positive integer.");
            if (!employeeMap.ContainsKey(id))
                throw new KeyNotFoundException($"No employee found with ID {id}.");
            employeeMap.Remove(id);

            #endregion

            #region Remove Emp from the list 

            //_employees.RemoveAll(emp => emp.GetEmplyeeId() == id);// this is overkill but it works
            //better way to remove employee
            //since is id is unique we can use FirstOrDefault
            var employeeToRemove = _employees.FirstOrDefault(emp => emp.GetEmployeeId() == id);
            if (employeeToRemove != null)
            {
                _employees.Remove(employeeToRemove);
            }
            else
            {
                throw new KeyNotFoundException($"No employee found with ID {id}.");
            }

            #endregion

        }
        public void AddProject(Project pj)
        {
            if (string.IsNullOrEmpty(pj.Name))
                throw new ArgumentException("Project name cannot be null or empty.", nameof(pj));
            if (pj.DurationDays <= 0)
                throw new ArgumentOutOfRangeException(nameof(pj), "Project duration must be a positive integer.");

            for (int i = 0; i < Projects.Length; i++)
            {
                if (Projects[i] is null)
                {
                    Projects[i] = pj;
                    return;
                }
            }
        }
        public bool ContainsEmployee(int id) => employeeMap.ContainsKey(id);
        public void PrintTeamDetails()
        {
            if (_employees.Count == 0)
            {
                Console.WriteLine("The team is empty.");
                return;
            }

            Console.WriteLine($"The team contains {Count} members : ");

            _employees.Sort(); // Sorts the employees based on their employeeId
            foreach (var emp in _employees)
            {
                emp.Describe();
            }
        }
        public void ClearTeam()
        {
            _employees.Clear();
            employeeMap.Clear();
        }
        public void PrintProjects()
        {
            if (Projects == null || Projects.Length == 0)
            {
                Console.WriteLine("No projects available.");
                throw new InvalidOperationException("No projects available in the team.");
            }

            Console.WriteLine("Projects in the team:");

            foreach (Project p in Projects)
            {
                // If a project is null, we stop printing further projects
                if (p?.Name == null) break;

                Console.WriteLine(p.PrintInfo());
            }





        }
        public override string ToString()
        {
            return $"Team with {Count} employees and {Projects.Length} projects.";
        }
        public static Team operator +(Team t1, Team t2)
        {
            if (t1 is null )
                throw new ArgumentNullException(nameof(t1), "Team cannot be null."); 
            if (t2 is null )
                throw new ArgumentNullException(nameof(t2), "Team cannot be null.");
            var combinedEmployees = t1._employees.Concat(t2._employees).ToList();
            var combinedProjects = t1.Projects.Concat(t2.Projects).ToArray();
            var combinedEmployeeMap = t1.employeeMap.Concat(t2.employeeMap)
                                      .ToDictionary(pair => pair.Key, pair => pair.Value);

            return new Team(combinedEmployees, combinedProjects, combinedEmployeeMap);

        }

    }
}
