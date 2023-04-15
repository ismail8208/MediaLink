using MediaLink.Application.Posts.Commands.CreatePost;
using Microsoft.AspNetCore.Mvc;


namespace MediaLink.WebUI.Controllers;

public class PostsController : ApiControllerBase
{
    [HttpPost]
    public async Task<ActionResult<int>> Create(CreatePostCommand command)
    {
        return await Mediator.Send(command);
    }
}
