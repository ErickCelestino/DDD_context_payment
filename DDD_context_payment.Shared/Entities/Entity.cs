using Flunt.Notifications;

namespace DDD_context_payment.Entities;

public abstract class Entity : Notifiable<Notification>
{
    protected Entity()
    {
        Id = Guid.NewGuid();
    }

    public Guid Id { get; private set; }
}