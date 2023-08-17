namespace DDD_context_payment.Entities;

public class Subscription
{
    private IList<Payment> _payment;
    public Subscription(DateTime? expireDate)
    {
        CreateDate= DateTime.Now;
        LastUpdateDate = DateTime.Now;
        ExpireDate = expireDate;
        Active = true;
        _payment = new List<Payment>();
    }
    public DateTime CreateDate { get; private set; }
    public DateTime LastUpdateDate { get; private set;}
    public DateTime? ExpireDate { get; private set;}
    public bool Active { get; private set; }
    public List<Payment> Payments { get; private set; }

    public void AddPayment(Payment payment)
    {
        _payment.Add(payment);
    }

    public void Activate()
    {
        Active = true;
        LastUpdateDate  = DateTime.Now;
    }

     public void Inactivate()
    {
        Active = false;
        LastUpdateDate  = DateTime.Now;
    }
}