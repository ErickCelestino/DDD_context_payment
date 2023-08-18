using DDD_context_payment.Shared.ValueObjects;
using Flunt.Validations;

namespace DDD_context_payment.ValueObjects;

public class Name : ValueObject
{
    public Name(string firstName, string lastName)
    {
        FirstName = firstName;
        LastName = lastName;

        AddNotifications(
            new Contract<Name>()
            .Requires()
            .IsNotMinValue(3, FirstName, "O primeiro nome deve conter pelo menos 3 caracteres")
            .IsNotMaxValue(40, FirstName, "O primeiro nome deve conter até  40 caracteres")
            .IsNotMinValue(3, LastName, "O ultimo nome deve conter pelo menos 3 caracteres")
            .IsNotMaxValue(40, LastName, "O ultimo nome deve conter até  40 caracteres")
        );
    }

    public string FirstName { get; private set; }
    public string LastName { get; private set; }
}