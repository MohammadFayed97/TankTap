using MediatR;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using TankTap.Admistration.Application;
using TankTap.Admistration.Application.Stations.Add;
using TankTap.SharedKernel.Application.Contracts;

namespace TankTap.Admistration.API.Controllers;

[Route("api/[controller]/[action]")]
[ApiController]
[EnableCors]
public class StationsController(IAdminstrationModule adminstrationModule) : ControllerBase
{
    [HttpPost]
    public async Task<ActionResult<IResult>> AddStaion([FromBody] AddStationCommand model) 
        => Ok(await adminstrationModule.ExecuteCommandAsync(model));
}
