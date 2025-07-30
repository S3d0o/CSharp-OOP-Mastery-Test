namespace CSharp_OOP_Mastery_Test.Models
{
    internal class Person
    {
        protected private string firstName;
        protected private string lastName = "";
        public string FullName => $"{firstName} {lastName}";
        internal int age = 0;

        public Person(string firstName, string lastName, int age)
        {
            if (string.IsNullOrWhiteSpace(firstName))
            {
                throw new ArgumentException("First name cannot be null or whitespace.", nameof(firstName));
            }
            if(age<=0)
            {
                throw new ArgumentOutOfRangeException(nameof(age), "Age must be a positive integer.");
            }

            this.firstName = firstName;
            this.lastName = lastName;
            this.age = age;
        }
    }
}
