using DDD_context_payment.Domain.Queries;
using DDD_context_payment.Entities;
using DDD_context_payment.ValueObjects;

namespace DDD_context_payment.Tests;

[TestClass]
public class StudentQueriesTests
{
    private IList<Student> _students;

    public StudentQueriesTests()
    {
        _students = new List<Student>();
        for(var i = 0; i <= 10; i++) 
        {  
            string studentName = i.ToString();
            _students.Add(
                new Student(
                    new Name("Aluno", studentName), 
                    new Email(studentName + "@gmail.com"),
                    new Document("1111111111" + studentName, Domain.Enums.EDocumentType.CPF)
            ));
        }
    }

    [TestMethod]
    public void ShouldReturnNullWhenDocumentNotExists()
    {
        var exp = StudentQueries.GetStudentInfo("12345678910");
        var studn = _students.AsQueryable().Where(exp).FirstOrDefault();

        Assert.AreEqual(null, studn);
    }

    [TestMethod]
    public void ShouldReturnStudentWhenDocumentExists()
    {
        var exp = StudentQueries.GetStudentInfo("11111111111");
        var studn = _students.AsQueryable().Where(exp).FirstOrDefault();

        Assert.AreNotEqual(null, studn);
    }


}