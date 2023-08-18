using DDD_context_payment.Domain.Enums;
using DDD_context_payment.Entities;
using DDD_context_payment.ValueObjects;

namespace DDD_context_payment.Tests;

[TestClass]
public class DocumentTests
{
    [TestMethod]
    public void ShouldReturnErrorWhenCNPJIsInvalid()
    {
        var doc = new Document("123", EDocumentType.CNPJ);
        Assert.IsTrue(!doc.IsValid);
    }

    [TestMethod]
    public void ShouldReturnSuccessWhenCNPJIsValid()
    {
        var doc = new Document("12345678910112", EDocumentType.CNPJ);
        Assert.IsTrue(doc.IsValid);
    }

    [TestMethod]
    public void ShouldReturnErrorWhenCPFIsInvalid()
    {
         var doc = new Document("123", EDocumentType.CPF);
        Assert.IsTrue(!doc.IsValid);
    }

    [TestMethod]
    //Para testar mais de um cpf 
    [DataTestMethod]
    [DataRow("12342678940")]
    [DataRow("12244578940")]
    public void ShouldReturnSuccessWhenCPFIsValid(string cpf)
    {
         var doc = new Document(cpf, EDocumentType.CPF);
        Assert.IsTrue(doc.IsValid);
    }
}