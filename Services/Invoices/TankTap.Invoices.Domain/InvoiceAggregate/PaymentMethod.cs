namespace TankTap.Invoices.Domain.InvoiceAggregate;


public enum PaymentMethod
{
	Cash = 1,
	PostPaid = 2,
	Check = 3,
	Transfer = 4
}

//public static class PaymentMethods
//{
//	private static readonly Dictionary<PaymentMethod, string> PaymentMethodArabic = new Dictionary<PaymentMethod, string>
//	{
//		{ PaymentMethod.Cash, "كاش" },
//		{ PaymentMethod.PostPaid, "مؤجل" },
//		{ PaymentMethod.Check, "شيك" },
//		{ PaymentMethod.Transfer, "تحويل" }
//	};

//	public static string GetArabicPaymentMethod(PaymentMethod method)
//	{
//		if (PaymentMethodArabic.TryGetValue(method, out string value))
//		{
//			return value;
//		}

//		throw new ArgumentException("Invalid payment method", nameof(method));
//	}
//}

