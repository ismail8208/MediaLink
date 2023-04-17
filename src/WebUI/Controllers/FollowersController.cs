using MediaLink.Application.Common.Models;
using MediaLink.Application.Follows.Commands.CancelFollower;
using MediaLink.Application.Follows.Commands.Follow;
using MediaLink.Application.Follows.Commands.UnFollow;
using MediaLink.Application.Follows.Queries.GetFollowers;
using MediaLink.Application.Follows.Queries.GetFollowingsWithPagination;
using MediaLink.Domain.Entities;
using Microsoft.AspNetCore.Mvc;

namespace MediaLink.WebUI.Controllers;
public class FollowersController : ApiControllerBase
{
    [HttpPost]
    public async Task<ActionResult<int>> Follow([FromBody] FollowCommand command)
    {
        return Ok(await Mediator.Send(command));
    }

    [HttpGet]
    public async Task<ActionResult<PaginatedList<InnerUser>>> GetFollowersWithPagination([FromQuery] GetFollowersWithPaginationQuery query)
    {
        return await Mediator.Send(query);
    }
}
