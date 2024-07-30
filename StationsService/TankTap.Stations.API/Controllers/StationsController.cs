using MediatR;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using TankTap.Stations.Application.Stations.Add;

namespace TankTap.Stations.API.Controllers;

[Route("api/[controller]/[action]")]
[ApiController]
[EnableCors]
public class StationsController(IMediator mediator) : ControllerBase
{
    [HttpPost]
    public async Task<ActionResult<IResult>> AddStaion([FromBody] AddStationCommand model) 
        => Ok(await mediator.Send(model));
}
