namespace DDD_context_payment.Entities;

public abstract class Entity
{
    protected Entity()
    {
        Id = Guid.NewGuid();
    }

    public Guid Id { get; private set; }
}