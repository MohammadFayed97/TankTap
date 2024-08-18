using TankTap.SharedKernel.Application.Contracts;
using TankTap.SharedKernel.Domain.Results;

namespace TankTap.Admistration.Application.Products.Add;

public class AddProductCommand : CommandBase<IResult>
{
	public string ArName { get; set; }
	public string EnName { get; set; }
	public string BnName { get; set; }
	public string UrName { get; set; }
    public string Code { get; set; }
    public string ERPCode { get; set; }
    public decimal Price { get; set; }
}
