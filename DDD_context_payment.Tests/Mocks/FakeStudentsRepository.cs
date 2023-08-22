using DDD_context_payment.Domain.Repositories;
using DDD_context_payment.Entities;

namespace DDD_context_payment.Tests.Mocks;

public class FakeStudentRepository : IStudentRepository
{
    public void CreateSubscription(Student student)
    {
    }

    public bool DocumentExists(string document)
    {
        if(document == "99999999999")
            return true;
        
        return false;
    }

    public bool EmailExists(string email)
    {
        if(email == "hello@gmail.com")
            return true;
            
        return false;
    }
}