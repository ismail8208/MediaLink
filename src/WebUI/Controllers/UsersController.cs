using MediaLink.Application.Comments.Queries.GetCommentsWithPagination;
using MediaLink.Application.Common.Models;
using MediaLink.Application.Users.Queries.FindUser;
using Microsoft.AspNetCore.Mvc;

namespace MediaLink.WebUI.Controllers;
public class UsersController : ApiControllerBase
{
    [HttpGet("{name}")]
    public async Task<ActionResult<PaginatedList<UserDto>>> Search(string name)
    {
        var query = new SearchUserQuery();
        query.Query = name.ToString();
        return await Mediator.Send(query);
    }
}
