using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediaLink.Application.Common.Exceptions;
using MediaLink.Application.Common.Interfaces;
using MediaLink.Application.Educations.Commands.CreateEducation;
using MediaLink.Domain.Entities;
using MediaLink.Domain.Events.EducationEvents;
using MediaLink.Domain.Events.LikeEvents;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace MediaLink.Application.Educations.Commands.DeleteEducation;
public record DeleteEducationCommand(int Id) : IRequest


public class DeleteEducationCommandHandler : IRequestHandler<DeleteEducationCommand, int>
{
    private readonly IApplicationDbContext _context;

    public DeleteEducationCommandHandler(IApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<Unit> Handle(DeleteEducationCommand request, CancellationToken cancellationToken)
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