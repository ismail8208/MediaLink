﻿using MediaLink.Application.Common.Models;
using MediaLink.Application.Skills.Commands.CreateSkill;
using MediaLink.Application.Skills.Commands.DeleteSkill;
using MediaLink.Application.Skills.Commands.UpdateSkill;
using MediaLink.Application.Skills.Queries.GetSkillsWithPagination;
using MediaLink.Domain.Entities;
using Microsoft.AspNetCore.Mvc;

namespace MediaLink.WebUI.Controllers;

public class SkillsController : ApiControllerBase
{
    [HttpGet]
    public async Task<ActionResult<PaginatedList<Skill>>> GetSkillsWithPagination([FromQuery] GetSkillsWithPaginationQuery query)
    {
        return await Mediator.Send(query);
    }


    [HttpPost]
    public async Task<ActionResult<int>> Create([FromBody] CreateSkillCommand command)
    {
        return await Mediator.Send(command);
    }

    [HttpPut("{id}")]
    public async Task<ActionResult> Update(int id, UpdateSkillCommand command)
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
        await Mediator.Send(new DeleteSkillCommand(id));

        return NoContent();
    }
}
