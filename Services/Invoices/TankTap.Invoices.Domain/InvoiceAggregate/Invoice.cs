using TankTap.SharedKernel.Domain;

namespace TankTap.Invoices.Domain.InvoiceAggregate;

public abstract class Invoice<T> : Entity<int>
	where T : InvoiceCondition
{
	public int StationId { get; }
	public PaymentMethod PaymentMethod { get; }
	public InvoiceType InvoiceType { get; }
	public string? Notes { get; set; }
	public decimal TotalPrice { get; private set; }
	public decimal TotalTax { get; private set; }
	public decimal TotalPriceAfterDiscount { get; private set; }
	public decimal FinalPrice { get; private set; }
	public string LiteralTotalPrice { get; }
	public DateTime InvoiceDate { get; }
	public string? CreatedBy { get; set; }


}