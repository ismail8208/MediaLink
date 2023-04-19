using MediaLink.Application.Follows.Commands.CancelFollower;
using Microsoft.AspNetCore.Mvc;

namespace MediaLink.WebUI.Controllers;
public class CancelFollowerController : ApiControllerBase
{
    [HttpPost]
    public async Task<ActionResult<int>> CancelFollow([FromBody] CancelFollowerCommand command)
    {
        return Ok(await Mediator.Send(command));
    }
}
