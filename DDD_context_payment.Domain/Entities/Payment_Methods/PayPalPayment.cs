using DDD_context_payment.ValueObjects;

namespace DDD_context_payment.Entities.PaymentMehods;

public class PayPalPayment : Payment
{
    public PayPalPayment(
        string transactionCode, 
        DateTime paidDate, 
        DateTime expireDate, 
        decimal total, 
        decimal totalPaid, 
        string payer, 
        Document document, 
        Address address, 
        Email email): base( paidDate,  expireDate,  total,  totalPaid, payer, document, address, email)
    {
        TransactionCode = transactionCode;
    }

    public string TransactionCode { get; private set; }
}