namespace TankTap.SharedKernel;

public interface IDomainEntity
{
    IReadOnlyCollection<BaseDomainEvent> Events { get; }
    void ClearDomainEvents();
}
