namespace TankTap.SharedKernel;

/// <summary>
///     This serves as a base interface for <see cref="Entity{TId}" />.
///     It also provides a simple means to develop your own base entity.
/// </summary>
public interface IEntity<out TId>
    where TId : IEquatable<TId>
{
    /// <summary>
    ///     Gets the ID which uniquely identifies the entity instance within its type's bounds.
    /// </summary>
    TId Id { get; }

    /// <summary>
    ///     Returns a value indicating whether the current object is transient.
    /// </summary>
    /// <remarks>
    ///     Transient objects are not associated with an item already in storage. For instance,
    ///     a Customer is transient if its ID is 0.
    /// </remarks>
    bool IsTransient();
}