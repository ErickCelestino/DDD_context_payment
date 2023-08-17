using DDD_context_payment.Shared.ValueObjects;
namespace DDD_context_payment.ValueObjects;

public class Email : ValueObject
{
    public Email(string address)
    {
        Address = address;
    }

    public string Address { get; private set; } 
}