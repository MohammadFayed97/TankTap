namespace TankTap.SharedKernel.Domain;

/// <summary>
/// This marker interface only to aggregate root entities
/// Repositories will only work with aggregate roots, not their children
/// </summary>
public interface IAggregateRoot { }
