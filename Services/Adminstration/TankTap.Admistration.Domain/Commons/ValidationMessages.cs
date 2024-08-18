namespace TankTap.Admistration.Domain.Commons;

internal class ValidationMessages
{
	public static string NotNullOrEmpty(string parameterName) => $"{parameterName} cannot be null or empty.";
	public static string NotNull(string parameterName) => $"{parameterName} cannot be null.";
}
