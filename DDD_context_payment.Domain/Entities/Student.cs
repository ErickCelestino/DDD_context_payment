using DDD_context_payment.ValueObjects;
using Flunt.Validations;

namespace DDD_context_payment.Entities;

public class Student : Entity
{
   private IList<Subscription> _subscriptions;
   public Student(Name name, Email email, Document document)
   {
      Name = name;
      Email = email;
      Document = document;
      _subscriptions = new List<Subscription>();
      AddNotifications(name, document, email);
   }

   public Name Name { get; private set; }
   public Email Email { get; private set; }
   public Document Document { get; private set; }
   public Address Address { get; private set; }
   public IReadOnlyCollection<Subscription> Subscriptions { get { return _subscriptions.ToArray(); } }

   public void AddSubscription(Subscription subscription)
   {
      var hasSubscriptionActive = false;
      foreach (var sub in _subscriptions)
      {
         if (sub.Active)
            hasSubscriptionActive = true;
      }

      AddNotifications(new Contract<Student>()
         .Requires()
         .IsFalse(hasSubscriptionActive, "Student.Subscription", "Você já tem uma assinatura ativa")
         .AreNotEquals(0, subscription.Payments.Count, "Student.Subscription.Payments", "Esta assinatura não possui pagamentos")
      );
      _subscriptions.Add(subscription);
      /*
         if(hasSubscriptionActive)
            AddNotification("Student.Subscription", "Você já tem uma assinatura ativa");
      */
   }
}