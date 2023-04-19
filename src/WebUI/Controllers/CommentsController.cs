﻿using MediaLink.Application.Common.Models;
using Microsoft.AspNetCore.Mvc;
using MediaLink.Application.Comments.Queries.GetCommentsWithPagination;
using MediaLink.Application.Comments.Commands.CreateComment;
using MediaLink.Application.Comments.Commands.UpdateComment;
using MediaLink.Application.Comments.Commands.DeleteComment;

namespace MediaLink.WebUI.Controllers;
public class CommentsController : ApiControllerBase
{
    [HttpGet]
    public async Task<ActionResult<PaginatedList<CommentDto>>> GetCommentsWithPagination([FromQuery] GetCommentsWithPaginationQuery query)
    {
        return await Mediator.Send(query);
    }

    [HttpPost]
    public async Task<ActionResult<int>> Create(CreateCommentCommand command)
    {
        return await Mediator.Send(command);
    }

    [HttpDelete("{id}")]
    public async Task<ActionResult> Delete(int id)
    {
        await Mediator.Send(new DeleteCommentCommand(id));

        return NoContent();
    }

    [HttpPut("{id}")]
    public async Task<ActionResult> Update(int id, [FromBody]UpdateCommentCommand command)
    {
        if (id != command.Id)
        {
            return BadRequest();
        }
        await Mediator.Send(command);

        return NoContent();
    }
}
