

namespace _0301_persAddress
{
    public abstract class Person
    {
        // Properties
        public string FirstName { get; set; }
        public string LastName { get; set; }

        // Constructor
        protected Person(string firstName, string lastName)
        {
            FirstName = firstName;
            LastName = lastName;
        }

        // to be overridden in derived classes
        public abstract string DisplayInfo();
    }
}
