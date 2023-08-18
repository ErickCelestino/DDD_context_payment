using DDD_context_payment.Entities;
using DDD_context_payment.Entities.PaymentMehods;
using DDD_context_payment.ValueObjects;

namespace DDD_context_payment.Tests;

[TestClass]
public class StudentTests
{
    private readonly Name _name;
    private readonly Email _email;
    private readonly Document _document;
    private readonly Address _address;
    private readonly Student _student;
    private readonly Subscription _subscription;

    public StudentTests()
    {
        _email = new Email("joaoc@gmail.com");
        _name = new Name("João", "das couves");
        _document = new Document("12345678910", Domain.Enums.EDocumentType.CPF);
        _address = new Address("Rua 1", "222", "Limoeiro", "Limões","Parana","1231241234","Brasil");
        _student = new Student(_name, _email, _document);
        _subscription = new Subscription(null);
    }

    [TestMethod]
    public void ShouldReturnErrorWhenHadActiveSubscription()
    {
        var payment = new PayPalPayment("1231212", DateTime.Now, DateTime.Now.AddDays(5),10,10,"JOAO LIMITADO", _document, _address, _email);
        _subscription.AddPayment(payment);
        _student.AddSubscription(_subscription);
        _student.AddSubscription(_subscription);

        Assert.IsTrue(!_student.IsValid);
    }

    [TestMethod]
    public void ShouldReturnErrorWhenSubscriptionHasNoPayment()
    {
        _student.AddSubscription(_subscription);
        Assert.IsTrue(!_student.IsValid);
    }

    [TestMethod]
    public void ShouldReturnSuccessWhenAddSubscription()
    {
        var payment = new PayPalPayment("1231212", DateTime.Now, DateTime.Now.AddDays(5),10,10,"JOAO LIMITADO", _document, _address, _email);
        _subscription.AddPayment(payment);
        _student.AddSubscription(_subscription);

        Assert.IsTrue(_student.IsValid);
    }
}