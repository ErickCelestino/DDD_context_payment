namespace DDD_context_payment.Entities;

public class Student
{
   private IList<Subscription> _subscription;
   public Student(string firstName, string lastName, string email, string document)
   {
        FirstName = firstName;
        LastName = lastName;
        Email = email;
        Document = document;
        _subscription = new List<Subscription>();
   }

   public string FirstName { get; private set; } 
   public string LastName { get; private set; } 
   public string Email { get; private set; } 
   public string Document { get; private set; } 
   public string Address { get; private set; }
   public IReadOnlyCollection<Subscription> Subscriptions { get{return _subscription.ToArray();} }

   public void AddSubscription(Subscription subscription)
   {
      foreach(var sub in Subscriptions)
         sub.Inactivate();
         
      _subscription.Add(subscription);
   }
}