using DDD_context_payment.Domain.Enums;
using DDD_context_payment.Shared.Commands;
using Flunt.Notifications;
using Flunt.Validations;

namespace DDD_context_payment.Domain.Commands;

public class CreateBoletoSubscriptionCommand: Notifiable<Notification>, ICommand
{
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string Document { get; set; }
    public string Email { get; set; }
 
    public string BarCode { get; set; }
    public string BoletoNumber { get; set; }
    
    public string PaymentNumber { get; set; }
    public DateTime PaidDate { get; set; }
    public DateTime ExpireDate { get; set; }
    public decimal Total { get; set; }
    public decimal TotalPaid { get; set; }
    public string Payer { get; set; }
    public string PayerDocument { get; set; }
    public EDocumentType PayerDocumentType { get; set; }
    public string PayerEmail { get; set; }
    public string Street { get; set; }
    public string Number { get; set; }
    public string Neighborhood { get; set; }
    public string City { get; set; }
    public string State { get; set; }
    public string Coutry { get; set; }
    public string ZipCode { get; set; }

    public void Validate()
    {
        int minStringValue = 3;
        int maxStringValue = 40;

        AddNotifications(new Contract<CreateBoletoSubscriptionCommand>()
            .Requires()
            .IsNotNullOrEmpty(FirstName,"O primeiro nome não pode ser vazio")
            .IsNotMinValue(minStringValue, FirstName, $"O primeiro nome deve conter pelo menos {minStringValue} caracteres")
            .IsNotMaxValue(maxStringValue, FirstName, $"O primeiro nome deve conter até  {maxStringValue} caracteres")
            .IsNotMinValue(minStringValue, LastName, $"O ultimo nome deve conter pelo menos {minStringValue} caracteres")
            .IsNotMaxValue(maxStringValue, LastName, $"O ultimo nome deve conter até  {maxStringValue} caracteres"));
    }
}