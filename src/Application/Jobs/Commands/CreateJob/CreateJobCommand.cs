﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using MediaLink.Application.Common.Interfaces;
using MediaLink.Domain.Entities;
using MediatR;

namespace MediaLink.Application.Jobs.Commands.CreateJob;
public record CreateJobCommand : IRequest<int>
{
    public string? Title { get; set; }
    public string? Description { get; set; }
    public int UserId { get; set; }
    public List<Skill>? Skills { get; set; }
}

public class CreateJobCommandHandler : IRequestHandler<CreateJobCommand, int>
{
    private readonly IApplicationDbContext _context;

    public CreateJobCommandHandler(IApplicationDbContext context)
    {
        _context = context;
    }
    public async Task<int> Handle(CreateJobCommand request, CancellationToken cancellationToken)
    {
        var entity = new Job
        {
            Title = request.Title,
            Skills = request.Skills,
            Description = request.Description,
            UserId = request.UserId,
        };

        _context.Jobs.Add(entity);
        await _context.SaveChangesAsync(cancellationToken);

        return entity.Id;
    }
}
