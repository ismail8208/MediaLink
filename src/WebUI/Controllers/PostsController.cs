using MediaLink.Application.Common.Models;
using MediaLink.Application.Posts.Commands.CreatePost;
using MediaLink.Application.Posts.Commands.DeletePost;
using MediaLink.Application.Posts.Commands.UpdatePost;
using MediaLink.Application.Posts.Queries;
using MediaLink.Application.Posts.Queries.GetPost;
using MediaLink.Application.Posts.Queries.GetPostsWithPagination;
using MediaLink.Application.Posts.Queries.LatestNews;
using Microsoft.AspNetCore.Mvc;


namespace MediaLink.WebUI.Controllers;
public class PostsController : ApiControllerBase
{
    [HttpGet]
    public async Task<ActionResult<PaginatedList<PostDto>>> GetPostsWithPagination([FromQuery] GetPostsWithPaginationQuery query)
    {
        return await Mediator.Send(query);
    }

    [HttpGet("LatestNews")]
    public async Task<ActionResult<PaginatedList<PostDto>>> LatestNews([FromQuery] LatestNewsQuery query)
    {
        return await Mediator.Send(query);
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<PostDto>> Get(int id)
    {
        return await Mediator.Send(new GetPostQurey(id));
    }

    [HttpPost]
    public async Task<ActionResult<int>> Create(CreatePostCommand command)
    {
        return await Mediator.Send(command);
    }

    [HttpDelete("{id}")]
    public async Task<ActionResult> Delete(int id)
    {
        await Mediator.Send(new DeletePostCommand(id));

        return NoContent();
    }

    [HttpPut("{id}")]
    public async Task<ActionResult> Update(int id, [FromBody]UpdatePostCommand command)
    {
        if (id != command.Id)
        {
            return BadRequest();
        }
        await Mediator.Send(command);

        return NoContent();
    }

}

