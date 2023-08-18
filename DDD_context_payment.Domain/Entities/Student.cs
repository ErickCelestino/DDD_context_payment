using DDD_context_payment.ValueObjects;
using Flunt.Validations;

namespace DDD_context_payment.Entities;

public class Student: Entity
{
   private IList<Subscription> _subscription;
   public Student(Name name, Email email, Document document)
   {
        Name = Name;
        Email = email;
        Document = document;
        _subscription = new List<Subscription>();
        AddNotifications(name, document, email);
   }

   public Name Name { get; private set; }
   public Email Email { get; private set; } 
   public Document Document { get; private set; } 
   public Address Address { get; private set; }
   public IReadOnlyCollection<Subscription> Subscriptions { get{return _subscription.ToArray();} }

   public void AddSubscription(Subscription subscription)
   {
      var hasSubscriptionActive = false;
      foreach(var sub in _subscription)
      {
         if(sub.Active)
            hasSubscriptionActive = true;
      }
   /*
      AddNotifications(new Contract<Student>()
         .Requires()
         .IsFalse(hasSubscriptionActive, "Student.Subscription", "Você já tem uma assinatura ativa")
      );
   */
      if(hasSubscriptionActive)
         AddNotification("Student.Subscription", "Você já tem uma assinatura ativa");

   }
}