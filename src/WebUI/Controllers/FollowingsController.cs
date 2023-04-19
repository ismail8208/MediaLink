using MediaLink.Application.Common.Models;
using MediaLink.Application.Follows.Commands.UnFollow;
using MediaLink.Application.Follows.Queries.GetFollowingsWithPagination;
using MediaLink.Domain.Entities;
using Microsoft.AspNetCore.Mvc;

namespace MediaLink.WebUI.Controllers;
public class FollowingsController : ApiControllerBase
{
    [HttpPost]
    public async Task<ActionResult<int>> UnFollow([FromBody] UnFollowCommand command)
    {
        return Ok(await Mediator.Send(command));
    }

    [HttpGet]
    public async Task<ActionResult<PaginatedList<InnerUser>>> GetFollowingsWithPagination([FromQuery] GetFollowingsWithPaginationQuery query)
    {
        return await Mediator.Send(query);
    }

}
