using DDD_context_payment.Shared.ValueObjects;
namespace DDD_context_payment.ValueObjects;

public class Name : ValueObject
{
    public Name(string firstName, string lastName)
    {
        FirstName = firstName;
        LastName = lastName;
    }

    public string FirstName { get; private set; } 
   public string LastName { get; private set; }
}