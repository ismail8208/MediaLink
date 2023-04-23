using System.Data;
using MediaLink.Application.Common.Interfaces;
using MediaLink.Application.Common.Security;
using MediaLink.Domain.Entities;
using MediaLink.Domain.Events.ProjectEvents;
using MediatR;

namespace MediaLink.Application.Projects.Commands.CreateProject;
[Authorize(Roles = "member")]
public record CreateProjectCommand : IRequest<int>
{
    public string? Title { get; set; }
    public string? Description { get; set; }
    public string? ImageURL { get; set; }
    public string? Link { get; set; }
    public int UserId { get; set; }
}

public class CreateProjectCommandHandler : IRequestHandler<CreateProjectCommand, int>
{
    private readonly IApplicationDbContext _context;

    public CreateProjectCommandHandler(IApplicationDbContext context)
    {
        _context = context;
    }
    public async Task<int> Handle(CreateProjectCommand request, CancellationToken cancellationToken)
    {
        var entity = new Project
        {
            Title = request.Title,
            Description = request.Description,
            ImageURL = request.ImageURL,
            Link = request.Link,
            UserId = request.UserId
        };

        entity.AddDomainEvent(new ProjectCreatedEvent(entity));

        _context.Projects.Add(entity);

        await _context.SaveChangesAsync(cancellationToken);

        return entity.Id;
    }
}