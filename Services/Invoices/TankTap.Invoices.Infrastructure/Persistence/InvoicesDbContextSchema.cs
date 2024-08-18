namespace TankTap.Invoices.Infrastructure.Persistence;

public class InvoicesDbContextSchema
{
    public const string DefaultSchema = "invoices";

    public static class Station
    {
        public const string TableName = "Stations";
	}
	public static class Product
	{
		public const string TableName = "Products";
	}
}
