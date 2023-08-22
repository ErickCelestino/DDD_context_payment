using DDD_context_payment.Domain.Repositories;
using DDD_context_payment.Domain.Services;
using DDD_context_payment.Entities;

namespace DDD_context_payment.Tests.Mocks;

public class FakeEmailService : IEmailService
{
    public void Send(string to, string email, string subject, string body)
    {}
}