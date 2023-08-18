using DDD_context_payment.Shared.ValueObjects;
using Flunt.Validations;

namespace DDD_context_payment.ValueObjects;

public class Address: ValueObject
{
    public Address(string street, string number, string neighborhood, string city, string state, string coutry, string zipCode)
    {
        Street = street;
        Number = number;
        Neighborhood = neighborhood;
        City = city;
        State = state;
        Coutry = coutry;
        ZipCode = zipCode;

        AddNotifications(new Contract<Address>()
            .IsMinValue(3,Street,"A rua deve conter pelo menos 3 caracteres")
        );
    }

    public string Street { get; private set; }
    public string Number { get; private set; }
    public string Neighborhood { get; private set; }
    public string City { get; private set; }
    public string State { get; private set; }
    public string Coutry { get; private set; }
    public string ZipCode { get; private set; }
}