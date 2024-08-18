using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using TankTap.Admistration.Application;
using TankTap.Admistration.Application.Products.Add;

namespace TankTap.API.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	[EnableCors]
	public class ProductController(IAdminstrationModule adminstrationModule) : ControllerBase
	{
		[HttpPost]
		public async Task<ActionResult<IResult>> AddProduct([FromBody] AddProductCommand model) 
			=> Ok(await adminstrationModule.ExecuteCommandAsync(model));
	}
}
