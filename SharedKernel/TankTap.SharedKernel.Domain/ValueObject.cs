namespace TankTap.SharedKernel.Domain;

/// <summary>
/// See: https://enterprisecraftsmanship.com/posts/value-object-better-implementation/
/// </summary>
public abstract class ValueObject : BaseObject, IComparable, IComparable<ValueObject>
{
	private int? _cachedHashCode;

	protected abstract IEnumerable<object> GetEqualityComponents();

	public override int GetHashCode()
	{
		if (!_cachedHashCode.HasValue)
		{
			_cachedHashCode = GetEqualityComponents()
				.Aggregate(1, (current, obj) =>
				{
					unchecked
					{
						return current * 23 + (obj?.GetHashCode() ?? 0);
					}
				});
		}

		return _cachedHashCode.Value;
	}

	private int CompareComponents(object object1, object object2)
	{
		if (object1 is null && object2 is null)
			return 0;

		if (object1 is null)
			return -1;

		if (object2 is null)
			return 1;

		if (object1 is IComparable comparable1 && object2 is IComparable comparable2)
			return comparable1.CompareTo(comparable2);

		return object1.Equals(object2) ? 0 : -1;
	}

	public static bool operator ==(ValueObject a, ValueObject b)
	{
		if (a is null && b is null)
			return true;

		if (a is null || b is null)
			return false;

		return a.Equals(b);
	}

	public static bool operator !=(ValueObject a, ValueObject b) => !(a == b);

	public override bool Equals(object? obj)
	{
		if (obj is null || GetUnproxiedType(this) != GetUnproxiedType(obj))
			return false;

		var valueObject = (ValueObject)obj;

		return GetEqualityComponents().SequenceEqual(valueObject.GetEqualityComponents());
	}

	public int CompareTo(object? obj)
	{
		Type thisType = GetUnproxiedType(this);
		Type otherType = GetUnproxiedType(obj!);

		if (thisType != otherType)
			return string.Compare(thisType.ToString(), otherType.ToString(), StringComparison.Ordinal);

		var other = (ValueObject)obj!;

		object[] components = GetEqualityComponents().ToArray();
		object[] otherComponents = other.GetEqualityComponents().ToArray();

		for (int i = 0; i < components.Length; i++)
		{
			int comparison = CompareComponents(components[i], otherComponents[i]);
			if (comparison != 0)
				return comparison;
		}

		return 0;
	}

	public int CompareTo(ValueObject? other) => CompareTo(other as object);
}
