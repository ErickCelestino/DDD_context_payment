using System.Linq.Expressions;
using DDD_context_payment.Entities;

namespace DDD_context_payment.Domain.Queries;

public static class StudentQueries
{
    public static Expression<Func<Student, bool>> GetStudentInfo(string document)
    {
        return x => x.Document.Number == document;
    }
}