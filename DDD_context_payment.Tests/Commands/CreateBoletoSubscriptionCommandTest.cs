using DDD_context_payment.Domain.Commands;

namespace DDD_context_payment.Tests;

[TestClass]
public class CreateBoletoSubscriptionCommandTest
{
    [TestMethod]
    public void ShouldReturnErrorWhenNameIsInvalid()
    {
        var command = new CreateBoletoSubscriptionCommand()
        {
            FirstName = "aaaa"
        };

        command.Validate();
        Assert.AreEqual(false, command.IsValid);
    }
}