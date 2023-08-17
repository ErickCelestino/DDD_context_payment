namespace DDD_context_payment.ValueObjects;

public class Email 
{
    public Email(string address)
    {
        Address = address;
    }

    public string Address { get; private set; } 
}