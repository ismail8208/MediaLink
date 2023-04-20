﻿using MediaLink.Application.Common.Interfaces;
using MediaLink.Domain.Entities;
using MediaLink.Domain.Events.EducationEvents;
using MediatR;

namespace MediaLink.Application.Educations.Commands.CreateEducation;

public record CreateSkillCommand : IRequest<int>
{
    public string? Level { get; set; }
    public string? Title { get; set; }
    public int UserId { get; set; }
}

public class CreateEducationCommandHandler : IRequestHandler<CreateSkillCommand, int>
{
    private readonly IApplicationDbContext _context;

    public CreateEducationCommandHandler(IApplicationDbContext context)
    {
        _context = context;
    }
    public async Task<int> Handle(CreateSkillCommand request, CancellationToken cancellationToken)
    {
        var entity = new Education
        {
            Level = request.Level,
            Title = request.Title,
            UserId = request.UserId
        };

        entity.AddDomainEvent(new EducationCreatedEvent(entity));

        _context.Educations.Add(entity);

        await _context.SaveChangesAsync(cancellationToken);

        return entity.Id;
    }
}