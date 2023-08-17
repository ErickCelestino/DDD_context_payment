namespace DDD_context_payment.ValueObjects;

public class Name 
{
    public Name(string firstName, string lastName)
    {
        FirstName = firstName;
        LastName = lastName;
    }

    public string FirstName { get; private set; } 
   public string LastName { get; private set; }
}