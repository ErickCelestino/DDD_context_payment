using DDD_context_payment.Shared.ValueObjects;
namespace DDD_context_payment.ValueObjects;

public class Name : ValueObject
{
    public Name(string firstName, string lastName)
    {
        FirstName = firstName;
        LastName = lastName;

        if(string.IsNullOrEmpty(FirstName))
            AddNotification("Name.FirstName","Invalid Name");
    }

    public string FirstName { get; private set; } 
    public string LastName { get; private set; }
}