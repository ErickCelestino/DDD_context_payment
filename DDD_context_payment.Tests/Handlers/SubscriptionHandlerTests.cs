using DDD_context_payment.Domain.Commands;
using DDD_context_payment.Domain.Handlers;
using DDD_context_payment.Tests.Mocks;

namespace DDD_context_payment.Tests;

[TestClass]
public class SubscriptionHandlerTests
{
    [TestMethod]
    public void ShoulReturnErrorWhenDocumentExists()
    {
        var handler = new SubscriptionHandler(new FakeStudentRepository(), new FakeEmailService());
        var command = new CreateBoletoSubscriptionCommand();
        command.FirstName= "Erick";
        command.LastName= "Celestino";
        command.Document= "99999999999";
        command.Email= "hello@gmail.com";
        command.BarCode= "54155";
        command.BoletoNumber= "65165165";
        command.PaymentNumber= "1561615";
        command.ExpireDate= DateTime.Now;
        command.PaidDate= DateTime.Now.AddMonths(1);
        command.Total= 60;
        command.TotalPaid= 60;
        command.Payer= "PURE LTDA";
        command.PayerDocument= "660506";
        command.PayerDocumentType= Domain.Enums.EDocumentType.CPF;
        command.PayerEmail= "erickc@gmail.com";
        command.Street= "Chapes";
        command.Number= "20";
        command.Neighborhood= "chapeco bairro";
        command.City= "chapeco";
        command.State= "mt";
        command.Coutry= "br";
        command.ZipCode= "1219232191-13";

        handler.Handle(command);
        Assert.AreEqual(false, handler.IsValid);
}
}