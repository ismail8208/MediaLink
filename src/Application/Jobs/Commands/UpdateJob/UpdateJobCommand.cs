using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediaLink.Application.Common.Exceptions;
using MediaLink.Application.Common.Interfaces;
using MediaLink.Domain.Entities;
using MediatR;

namespace MediaLink.Application.Jobs.Commands.UpdateJob;
public record UpdateJobCommand : IRequest
{
    public int Id { get; set; }
    public string? Title { get; set; }
    public string? Description { get; set; }
    public List<Skill>? Skills { get; set; }
}

public class UpdateJobCommandHandler : IRequestHandler<UpdateJobCommand>
{
    private readonly IApplicationDbContext _context;

    public UpdateJobCommandHandler(IApplicationDbContext context)
    {
        _context = context;
    }
    public async Task<Unit> Handle(UpdateJobCommand request, CancellationToken cancellationToken)
    {
        var entity = await _context.Jobs.FindAsync(new object[] { request.Id }, cancellationToken);

        if (entity == null)
        { 
            throw new NotFoundException(nameof(Job), request.Id);
        }
        entity.Title = request.Title;
        entity.Description = request.Description;
        entity.Skills = request.Skills;

        await _context.SaveChangesAsync(cancellationToken);

        return Unit.Value;
    }
}