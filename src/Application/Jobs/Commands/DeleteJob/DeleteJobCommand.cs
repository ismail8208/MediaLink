using MediaLink.Application.Common.Exceptions;
using MediaLink.Application.Common.Interfaces;
using MediaLink.Domain.Entities;
using MediatR;

namespace MediaLink.Application.Jobs.Commands.DeleteJob;
public record DeleteJobCommand(int Id) : IRequest;

public class DeleteJobCommandHandler : IRequestHandler<DeleteJobCommand>
{
    private readonly IApplicationDbContext _context;

    public DeleteJobCommandHandler(IApplicationDbContext context)
    {
        _context = context;
    }
    public async Task<Unit> Handle(DeleteJobCommand request, CancellationToken cancellationToken)
    {
        var entity = await _context.Jobs
            .FindAsync(new object[] { request.Id }, cancellationToken);

        if (entity == null)
        {
            throw new NotFoundException(nameof(Job), request.Id);
        }
        
        _context.Jobs.Remove(entity);

        await _context.SaveChangesAsync(cancellationToken);

        return Unit.Value;
    }
}
