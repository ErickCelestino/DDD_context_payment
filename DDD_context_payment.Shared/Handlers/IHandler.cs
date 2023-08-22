using DDD_context_payment.Shared.Commands;

namespace DDD_context_payment.Shared.Handlers;

public interface IHandler<T> where T: ICommand
{
    ICommandResult Handle(T command);
}