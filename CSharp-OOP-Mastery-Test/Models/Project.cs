
namespace CSharp_OOP_Mastery_Test.Models
{
    internal class Project
    {
        public string Name { get; set; }
        public int DurationDays { get; set; }
        public Project(string name, int durationDays)
        {
            Name = name;
            DurationDays = durationDays;
        }
        public string PrintInfo()
        {
            return $"Project name : {Name}, Duration {DurationDays} Days";
        }
        public override string ToString()
        {
            return $"Project: {Name}, Duration: {DurationDays} days";
        } // no need for it now 

    }
}
