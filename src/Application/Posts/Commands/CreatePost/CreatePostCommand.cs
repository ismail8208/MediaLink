using System.Data;
using MediaLink.Application.Common.Interfaces;
using MediaLink.Application.Common.Security;
using MediaLink.Domain.Entities;
using MediaLink.Domain.Events;
using MediatR;

namespace MediaLink.Application.Posts.Commands.CreatePost;
[Authorize(Roles = "member")]
public record CreatePostCommand : IRequest<int>
{
    public string? Content { get; set; }
    public string? ImageURL { get; set; }
    public string? VideoURL { get; set; }
    public int NumberOfLikes { get; set; }
    public int NumberOfComments { get; set; }
    public int UserId { get; set; }
}

public class CreatePostCommandHandler : IRequestHandler<CreatePostCommand, int>
{
    private readonly IApplicationDbContext _context;

    public CreatePostCommandHandler(IApplicationDbContext context)
    {
        _context = context;
    }
    public async Task<int> Handle(CreatePostCommand request, CancellationToken cancellationToken)
    {
        var entity = new Post
        {
            Content = request.Content,
            ImageURL = request.ImageURL,
            VideoURL = request.VideoURL,
            NumberOfLikes = request.NumberOfLikes,
            NumberOfComments = request.NumberOfComments,
            UserId = request.UserId
        };

        entity.AddDomainEvent(new PostCreatedEvent(entity));
      
        _context.Posts.Add(entity);
        await _context.SaveChangesAsync(cancellationToken);

        return entity.Id;
    }
}
