
namespace CSharp_OOP_Mastery_Test.Models
{
    internal class Project : ICloneable
    {
        public string Name { get; set; } 
        public int DurationDays { get; set; }
        public Project(string name, int durationDays)
        {
            if (string.IsNullOrEmpty(name))
                throw new ArgumentException("Project name cannot be null or empty.", nameof(name));
            if (durationDays <= 0)
                throw new ArgumentOutOfRangeException(nameof(durationDays), "Duration must be a positive integer.");
            Name = name;
            DurationDays = durationDays;
        }
        public Project(Project other) // Copy constructor
            : this(other.Name, other.DurationDays) // Calls the main constructor
        {
            
        }
        public string PrintInfo()
        {
            return $"Project name : {Name}, Duration {DurationDays} Days";
        }
        public override string ToString()
        {
            return $"Project: {Name}, Duration: {DurationDays} days";
        }
        public object Clone() // This performs a deep copy of the object
        {
            return new Project(this); // Uses the copy constructor for deep copy
        }

    }
}
