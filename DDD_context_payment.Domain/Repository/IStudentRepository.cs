using DDD_context_payment.Entities;

namespace DDD_context_payment.Domain.Repositories;

public interface IStudentRepository
{
    bool DocumentExists(string document);
    bool EmailExists(string email);
    void CreateSubscription(Student student);
}