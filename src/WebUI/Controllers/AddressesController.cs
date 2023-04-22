﻿using MediaLink.Application.Addresses.Commands.CreateAddress;
using MediaLink.Application.Addresses.Commands.DeleteAddress;
using MediaLink.Application.Addresses.Commands.UpdateAddress;
using MediaLink.Application.Addresses.Queries.GetAddressByUserId;
using MediaLink.Domain.Entities;
using Microsoft.AspNetCore.Mvc;

namespace MediaLink.WebUI.Controllers;

public class AddressesController : ApiControllerBase
{
    [HttpGet("{id}")]
    public async Task<ActionResult<Address>> Get(int id)
    {
        return await Mediator.Send(new GetAddressQuery(id));
    }

    [HttpPost]
    public async Task<ActionResult<int>> Create([FromBody] CreateAddressCommand command)
    {
        return await Mediator.Send(command);
    }

    [HttpPut("{id}")]
    public async Task<ActionResult> Update(int id, UpdateAddressCommand command)
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
        await Mediator.Send(new DeleteAddressCommand(id));

        return NoContent();
    }
}
