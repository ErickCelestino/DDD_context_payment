using System.Diagnostics.Contracts;
using DDD_context_payment.Shared.ValueObjects;
using Flunt.Validations;

namespace DDD_context_payment.ValueObjects;

public class Email : ValueObject
{
    public Email(string address)
    {
        Address = address;
        AddNotifications(new Contract<Address>()
            .Requires()
            .IsEmail(Address, "Email.Address", "E-mail inválido")
        );
    }

    public string Address { get; private set; } 
}