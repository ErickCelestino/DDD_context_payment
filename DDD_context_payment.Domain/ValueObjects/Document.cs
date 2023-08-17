using DDD_context_payment.Domain.Enums;
using DDD_context_payment.Shared.ValueObjects;

namespace DDD_context_payment.ValueObjects;

public class Document : ValueObject
{
    public Document(string number, EDocumentType type)
    {
        Number = number;
        Type = type;
    }
    public string Number { get; private set; } 
    public EDocumentType Type { get; private set; }
}