using System.Text.RegularExpressions;


namespace HockeyTeamSystem
{
    public class Person
    {
        // define an auto-implemented property with a private set for the full name
        // A private set property cannot be assigned a value 
        //in the constructor or an instance method
        public string FullName { get; private set; }

        // Define a greedy constructor that takes a fullname as a parameter
        // Constructors are used to create instance of an object and also to assign meaningful values
        // to the properties of the class
        public Person(string fullName)
        {
            // Validate that the fullName parameter is not null, whitespaces, or an empty string.
            if(string.IsNullOrWhiteSpace(fullName))
            {
                throw new ArgumentNullException("Person FullName is required.");
            }
            //Validate that the fullname parameter contains only letters a-z and up to two space characters.
            // @"" is literal string where the characters have no meaning to any of characters
            // ^ start of input
            // $ end of input
            // []  range of characters
            // {5,} at least 5 cahracter no upper limit thats why no value
            // {,2} up to 2  [ ] empty square brackets with space meaning space characters // trmoved it
            var fullNameCheck = new Regex(@"^[a-zA-Z \-]{5,}$");

            if(fullNameCheck.IsMatch(fullName) == false)
            {
                throw new ArgumentException("Person FullName must contain at least 5 characters.");
            }

            // The this keyword refers to the current object and it
            // is to access a field or property of the current object
            this.FullName = fullName.Trim();
        }
    }
}
