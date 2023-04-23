using MediaLink.Application.Common.Exceptions;
using MediaLink.Application.Common.Interfaces;
using MediaLink.Domain.Entities;
using MediatR;

namespace MediaLink.Application.Posts.Commands.UpdatePost;
public record UpdatePostCommand : IRequest
{
    public int Id { get; set; }
    public string? Content { get; set; }
    public string? ImageURL { get; set; }
    public string? VideoURL { get; set; }
    public int NumberOfLikes { get; set; }
    public int NumberOfComments { get; set; }
}


public class UpdatePostCommandHandler : IRequestHandler<UpdatePostCommand>
{
    private readonly IApplicationDbContext _context;

    public UpdatePostCommandHandler(IApplicationDbContext context)
    {
        _context = context;
    }
    public async Task<Unit> Handle(UpdatePostCommand request, CancellationToken cancellationToken)
    {
        var entity = await _context.Posts.FindAsync(new object[] { request.Id }, cancellationToken);

        if (entity == null)
        {
            throw new NotFoundException(nameof(Post), request.Id);
        }

        entity.Content= request.Content;
        entity.ImageURL= request.ImageURL;
        entity.VideoURL= request.VideoURL;
        entity.NumberOfComments= request.NumberOfLikes;
        entity.NumberOfLikes= request.NumberOfComments;

        await _context.SaveChangesAsync(cancellationToken);

        return Unit.Value;
    }
}
