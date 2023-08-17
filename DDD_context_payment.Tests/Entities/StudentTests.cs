using DDD_context_payment.Entities;

namespace DDD_context_payment.Tests;

[TestClass]
public class StudentTests
{
    [TestMethod]
    public void AddSubscription()
    {
        var subscription = new Subscription(null);
        var student = new Student("Erick", "Celestino", "erickcelestimo@gmail.com", "1121221212");
    }
}