using Ardalis.GuardClauses;
using TankTap.SharedKernel.Domain;

namespace TankTap.Invoices.Domain.InvoiceAggregate;

public abstract class InvoiceCondition : Entity<int>
{
	public const int AmountLimit = 100000;

	protected InvoiceCondition(int invoiceId, decimal unitPrice, decimal amount, string description = "")
	{
		InvoiceId = invoiceId;
		UnitPrice = unitPrice;
		Amount = amount;
		Description = description;

		Calculate();
	}
	protected InvoiceCondition() { } // EF Core

	public int InvoiceId { get; }
	public string TaxType { get; } = InvoiceConstants.TaxType;
	public string? Description { get; }
	public short TaxRate { get; } = InvoiceConstants.TaxRate;
	public decimal UnitPrice { get; }
	public decimal Amount { get; }
	public decimal TotalPriceWithoutTax => (UnitPrice * Amount - TaxValue);
	public decimal TaxValue { get; private set; }
	public decimal TotalPrice { get; private set; }

	private void Calculate()
	{
		//decimal taxRate = 100 + TaxRate;
		//taxRate = 100 / taxRate;
		TaxValue = (UnitPrice * Amount) - ((UnitPrice * Amount) / (decimal)1.15);
		TotalPrice = UnitPrice * Amount;
	}
}

public class PostpaidClientInvoiceCondition : InvoiceCondition
{
	private PostpaidClientInvoiceCondition(int invoiceId, decimal unitPrice, decimal amount, int productId, string description = "")
		: base(invoiceId, unitPrice, amount, description)
	{
		ProductId = productId;
	}
	private PostpaidClientInvoiceCondition() { } // EF Core

	public static PostpaidClientInvoiceCondition Create(int invoiceId, decimal unitPrice, decimal amount, int productId, string description = "")
	{
		Guard.Against.NegativeOrZero(productId, nameof(productId));

		return new PostpaidClientInvoiceCondition(invoiceId, unitPrice, amount, productId, description);
	}

	public int ProductId { get; }
	//public LKProduct? Product { get; }
}