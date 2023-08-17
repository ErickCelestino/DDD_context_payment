using DDD_context_payment.ValueObjects;

namespace DDD_context_payment.Entities;

public class Student
{
   private IList<Subscription> _subscription;
   public Student(Name name, Email email, Document document)
   {
        Name = Name;
        Email = email;
        Document = document;
        _subscription = new List<Subscription>();
   }

   public Name Name { get; private set; }
   public Email Email { get; private set; } 
   public Document Document { get; private set; } 
   public string Address { get; private set; }
   public IReadOnlyCollection<Subscription> Subscriptions { get{return _subscription.ToArray();} }

   public void AddSubscription(Subscription subscription)
   {
      foreach(var sub in Subscriptions)
         sub.Inactivate();
         
      _subscription.Add(subscription);
   }
}