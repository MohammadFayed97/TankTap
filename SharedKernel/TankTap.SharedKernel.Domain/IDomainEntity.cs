namespace TankTap.SharedKernel.Domain;

public interface IDomainEntity
{
    IReadOnlyCollection<IDomainEvent> Events { get; }
    void ClearDomainEvents();
}
