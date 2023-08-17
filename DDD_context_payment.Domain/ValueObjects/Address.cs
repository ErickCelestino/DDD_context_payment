using DDD_context_payment.Shared.ValueObjects;

namespace DDD_context_payment.ValueObjects;

public class Address: ValueObject
{
    public string Street { get; private set; }
    public string Number { get; private set; }
    public string Neighborhood { get; private set; }
    public string City { get; private set; }
    public string State { get; private set; }
    public string Coutry { get; private set; }
    public string ZipCode { get; private set; }
}