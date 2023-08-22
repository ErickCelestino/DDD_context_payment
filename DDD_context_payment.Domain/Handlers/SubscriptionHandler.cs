using DDD_context_payment.Domain.Commands;
using DDD_context_payment.Domain.Repositories;
using DDD_context_payment.Domain.Services;
using DDD_context_payment.Entities;
using DDD_context_payment.Entities.PaymentMehods;
using DDD_context_payment.Shared.Commands;
using DDD_context_payment.Shared.Handlers;
using DDD_context_payment.ValueObjects;
using Flunt.Notifications;

namespace DDD_context_payment.Domain.Handlers;

public class SubscriptionHandler : 
    Notifiable<Notification>, 
    IHandler<CreateBoletoSubscriptionCommand>,
    IHandler<CreatePayPalSubscriptionCommand>,
    IHandler<CreateCredCardSubscriptionCommand>
{
    private readonly IStudentRepository _repository;
    private readonly IEmailService _emailService;

    public SubscriptionHandler(IStudentRepository repository, IEmailService emailService)
    {
        _repository = repository;
        _emailService = emailService;
    }
    public ICommandResult Handle(CreateBoletoSubscriptionCommand command)
    {
        command.Validate();
        if(!command.IsValid)
        {
            AddNotifications(command);
            return new CommandResult(false, "Não foi possível realizar sua assinatura");
        }
        if(_repository.DocumentExists(command.Document))
            AddNotification("Document", "Este CPF já está em uso");
    
        if(_repository.EmailExists(command.Email))
            AddNotification("Email", "Este E-mail já está em uso");
        
        var email = new Email(command.Email);
        var name = new Name(command.FirstName, command.LastName);
        var document = new Document(command.Document, Enums.EDocumentType.CPF);
        var address = new Address(
            command.Street, 
            command.Number, 
            command.Neighborhood, 
            command.City, 
            command.State, 
            command.ZipCode, 
            command.Coutry);
        
        var student = new Student(name, email, document);
        var subscription = new Subscription(DateTime.Now.AddMonths(1));
        var payment = new BoletoPayment(
            command.BarCode, 
            command.BoletoNumber, 
            command.PaidDate, 
            command.ExpireDate, 
            command.Total, 
            command.TotalPaid, 
            command.Payer, 
            new Document(command.PayerDocument, command.PayerDocumentType), 
            address, 
            email);

        subscription.AddPayment(payment);
        student.AddSubscription(subscription);

        AddNotifications(name, document, email, address, student, payment);

        _repository.CreateSubscription(student);

        _emailService.Send(student.Name.ToString(), student.Email.Address,"Bem vindo ao site de cursos", "Sua assinatura foi criada");
        return new CommandResult(true, "Assinatura realizada com sucesso");
    }

    public ICommandResult Handle(CreatePayPalSubscriptionCommand command)
    {
        if(_repository.DocumentExists(command.Document))
            AddNotification("Document", "Este CPF já está em uso");
    
        if(_repository.EmailExists(command.Email))
            AddNotification("Email", "Este E-mail já está em uso");
        
        var email = new Email(command.Email);
        var name = new Name(command.FirstName, command.LastName);
        var document = new Document(command.Document, Enums.EDocumentType.CPF);
        var address = new Address(
            command.Street, 
            command.Number, 
            command.Neighborhood, 
            command.City, 
            command.State, 
            command.ZipCode, 
            command.Coutry);
        
        var student = new Student(name, email, document);
        var subscription = new Subscription(DateTime.Now.AddMonths(1));
        var payment = new PayPalPayment(
            command.TransactionCode,
            command.PaidDate, 
            command.ExpireDate, 
            command.Total, 
            command.TotalPaid, 
            command.Payer, 
            new Document(command.PayerDocument, command.PayerDocumentType), 
            address, 
            email);

        subscription.AddPayment(payment);
        student.AddSubscription(subscription);

        AddNotifications(name, document, email, address, student, payment);

        _repository.CreateSubscription(student);

        _emailService.Send(student.Name.ToString(), student.Email.Address,"Bem vindo ao site de cursos", "Sua assinatura foi criada");
        return new CommandResult(true, "Assinatura realizada com sucesso");
    }

    public ICommandResult Handle(CreateCredCardSubscriptionCommand command)
    {
                if(_repository.DocumentExists(command.Document))
            AddNotification("Document", "Este CPF já está em uso");
    
        if(_repository.EmailExists(command.Email))
            AddNotification("Email", "Este E-mail já está em uso");
        
        var email = new Email(command.Email);
        var name = new Name(command.FirstName, command.LastName);
        var document = new Document(command.Document, Enums.EDocumentType.CPF);
        var address = new Address(
            command.Street, 
            command.Number, 
            command.Neighborhood, 
            command.City, 
            command.State, 
            command.ZipCode, 
            command.Coutry);
        
        var student = new Student(name, email, document);
        var subscription = new Subscription(DateTime.Now.AddMonths(1));
        var payment = new CreditCardPayment(
            command.CardHolderName,
            command.CardNumber,
            command.LastTransactionNumber,
            command.PaidDate, 
            command.ExpireDate, 
            command.Total, 
            command.TotalPaid, 
            command.Payer, 
            new Document(command.PayerDocument, command.PayerDocumentType), 
            address, 
            email);

        subscription.AddPayment(payment);
        student.AddSubscription(subscription);

        AddNotifications(name, document, email, address, student, payment);

        _repository.CreateSubscription(student);

        _emailService.Send(student.Name.ToString(), student.Email.Address,"Bem vindo ao site de cursos", "Sua assinatura foi criada");
        return new CommandResult(true, "Assinatura realizada com sucesso");
    }
}