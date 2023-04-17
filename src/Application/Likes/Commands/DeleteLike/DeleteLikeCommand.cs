using MediaLink.Application.Common.Exceptions;
using MediaLink.Application.Common.Interfaces;
using MediaLink.Domain.Events.LikeEvents;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace MediaLink.Application.Likes.Commands.DeleteLike;

public record DeleteLikeCommand(int Id) : IRequest;

public class DeleteLikeCommandHandler : IRequestHandler<DeleteLikeCommand>
{
    private readonly IApplicationDbContext _context;

    public DeleteLikeCommandHandler(IApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<Unit> Handle(DeleteLikeCommand request, CancellationToken cancellationToken)
    {
        var entity = await _context.Likes
            .Where(l => l.Id == request.Id)
            .SingleOrDefaultAsync(cancellationToken);
        
        if (entity == null)
        {
            throw new NotFoundException(nameof(entity));
        }

        _context.Likes.Remove(entity);

        entity.AddDomainEvent(new LikeDeletedEvent(entity));

        await _context.SaveChangesAsync(cancellationToken);

        return Unit.Value;
    }
}
