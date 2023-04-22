using MediaLink.Application.Common.Models;
using MediaLink.Application.Projects.Commands.CreateProject;
using MediaLink.Application.Projects.Commands.DeleteProject;
using MediaLink.Application.Projects.Commands.UpdateProject;
using MediaLink.Application.Projects.Queries.GetProjectsWithPagination;
using Microsoft.AspNetCore.Mvc;

namespace MediaLink.WebUI.Controllers;

public class ProjectsController : ApiControllerBase
{
    [HttpGet]
    public async Task<ActionResult<PaginatedList<ProjectDto>>> GetProjectsWithPagination([FromQuery] GetProjectsWithPaginationQuery query)
    {
        return await Mediator.Send(query);
    }

    [HttpPost]
    public async Task<ActionResult<int>> Create([FromBody] CreateProjectCommand command)
    {
        return await Mediator.Send(command);
    }

    [HttpPut("{id}")]
    public async Task<ActionResult> Update(int id, UpdateProjectCommand command)
    {
        if (id != command.Id)
        {
            return BadRequest();
        }

        await Mediator.Send(command);

        return NoContent();
    }

    [HttpDelete("{id}")]
    public async Task<ActionResult> Delete(int id)
    {
        await Mediator.Send(new DeleteProjectCommand(id));

        return NoContent();
    }
}
