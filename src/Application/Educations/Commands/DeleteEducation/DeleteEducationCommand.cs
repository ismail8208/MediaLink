﻿using MediaLink.Application.Common.Exceptions;
using MediaLink.Application.Common.Interfaces;
using MediaLink.Domain.Events.EducationEvents;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace MediaLink.Application.Educations.Commands.DeleteEducation;

public record DeleteSkillCommand(int Id) : IRequest;

public class DeleteEducationCommandHandler : IRequestHandler<DeleteSkillCommand>
{
    private readonly IApplicationDbContext _context;

    public DeleteEducationCommandHandler(IApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<Unit> Handle(DeleteSkillCommand request, CancellationToken cancellationToken)
    {
        var entity = await _context.Educations
           .Where(E => E.Id == request.Id)
           .SingleOrDefaultAsync(cancellationToken);

        if (entity == null)
        {
            throw new NotFoundException(nameof(entity));
        }

        _context.Educations.Remove(entity);

        entity.AddDomainEvent(new EducationDeletedEvent(entity));

        await _context.SaveChangesAsync(cancellationToken);

        return Unit.Value;
    }
}