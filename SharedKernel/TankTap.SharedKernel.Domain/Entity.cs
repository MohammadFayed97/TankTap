namespace TankTap.SharedKernel.Domain;

public abstract class Entity<TId> : BaseObject, IEntity<TId>, IDomainEntity, IEquatable<Entity<TId>>
	where TId : IEquatable<TId>
{

	protected Entity(TId id) => Id = id;
	protected Entity() : this(default!) { }
	/// <summary>
	///     To help ensure hash code uniqueness, a carefully selected random number multiplier
	///     is used within the calculation.  Goodrich and Tamassia's Data Structures and
	///     Algorithms in Java asserts that 31, 33, 37, 39 and 41 will produce the fewest number
	///     of collisions.  See http://computinglife.wordpress.com/2008/11/20/why-do-hash-functions-use-prime-numbers/
	///     for more information.
	/// </summary>
	const int HashMultiplier = 31;
	int? _cachedHashcode;

	private List<IDomainEvent> _events = [];

	/// <summary>
	///     Gets or sets the ID.
	/// </summary>
	/// <remarks>
	///     <para>
	///         The ID may be of type <c>string</c>, <c>int</c>, a custom type, etc.
	///         The setter is protected to allow unit tests to set this property via reflection
	///         and to allow domain objects more flexibility in setting this for those objects
	///         with assigned IDs. It's virtual to allow NHibernate-backed objects to be lazily
	///         loaded. This is ignored for XML serialization because it does not have a public
	///         setter (which is very much by design). See the FAQ within the documentation if
	///         you'd like to have the ID XML serialized.
	///     </para>
	/// </remarks>
	public virtual TId Id { get; protected set; }

	/// <summary>
	///     Returns a value indicating whether the current object is transient.
	/// </summary>
	/// <remarks>
	///     Transient objects are not associated with an item already in storage. For instance,
	///     a Customer is transient if its ID is 0.  It's virtual to allow NHibernate-backed
	///     objects to be lazily loaded.
	/// </remarks>
	public virtual bool IsTransient() => Id is null || Id.Equals(default!);

	/// <summary>
	///     Returns a hash code for this instance.
	/// </summary>
	/// <returns>A hash code for this instance, suitable for use in hashing algorithms and data structures like a hash table.</returns>
	/// <remarks>
	///     This is used to provide the hash code identifier of an object using the signature
	///     properties of the object; although it's necessary for NHibernate's use, this can
	///     also be useful for business logic purposes and has been included in this base
	///     class, accordingly. Since it is recommended that GetHashCode change infrequently,
	///     if at all, in an object's lifetime, it's important that properties are carefully
	///     selected which truly represent the signature of an object.
	/// </remarks>
	public override int GetHashCode()
	{
		if (_cachedHashcode.HasValue)
			return _cachedHashcode.Value;

		if (IsTransient())
			_cachedHashcode = base.GetHashCode();
		else
		{
			unchecked
			{
				// It's possible for two objects to return the same hash code based on 
				// identically valued properties, even if they're of two different types, 
				// so we include the object's type in the hash calculation
				int hashCode = GetType().GetHashCode() * HashMultiplier;

				if (Id is null)
					_cachedHashcode = hashCode;
				else
					_cachedHashcode = hashCode ^ Id.GetHashCode();
			}
		}

		return _cachedHashcode.Value;
	}

	/// <summary>
	///     Returns a value indicating whether the current entity and the provided entity have
	///     the same ID values and the IDs are not of the default ID value.
	/// </summary>
	/// <returns>
	///     <c>true</c> if the current entity and the provided entity have the same ID values and the IDs are not of the
	///     default ID value; otherwise; <c>false</c>.
	/// </returns>
	bool HasSameNonDefaultIdAs(Entity<TId> compareTo)
		=> !IsTransient() && !compareTo.IsTransient() && Id!.Equals(compareTo.Id!);

	/// <inheritdoc />
	public virtual bool Equals(Entity<TId>? other)
	{
		if (other == null || GetType() != GetUnproxiedType(other))
			return false;

		if (ReferenceEquals(this, other) || HasSameNonDefaultIdAs(other))
			return true;

		return false;
	}

	/// <summary>
	///     Determines whether the specified <see cref="object" /> is equal to this instance.
	/// </summary>
	/// <param name="obj">The <see cref="object" /> to compare with the current <see cref="object" />.</param>
	/// <returns><c>true</c> if the specified <see cref="object" /> is equal to this instance; otherwise, <c>false</c>.</returns>
	public override bool Equals(object? obj)
	{
		var compareTo = obj as Entity<TId>;
		return Equals(compareTo);
	}

	public static bool operator ==(Entity<TId>? left, Entity<TId>? right)
		=> Equals(left, right);

	public static bool operator !=(Entity<TId>? left, Entity<TId>? right)
		=> !Equals(left, right);

	public IReadOnlyCollection<IDomainEvent> Events => _events.AsReadOnly();
	protected void AddEvent<TDomainEvent>(TDomainEvent @event)
		where TDomainEvent : IDomainEvent => _events.Add(@event);
	public void ClearDomainEvents() => _events.Clear();
}
