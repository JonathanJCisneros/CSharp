namespace OOPDemo;

public class Person
{
    public string FirstName{get;set;}
    public string LastName{get;set;}

    public Person(string firstName, string lastName)
    {
        FirstName = firstName;
        LastName = lastName;
    }

    public string FullName()
    {
        return $"{FirstName} {LastName}";
    }
}
