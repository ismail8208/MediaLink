using MediaLink.Application.Common.Interfaces;
using MediaLink.Domain.Entities;
using MediaLink.Domain.Events.ProjectEvents;
using MediatR;

namespace MediaLink.Application.Projects.Commands.CreateProject;

public record CreateProjectCommand : IRequest<int>
{
    public int? ExperienceId { get; set; }
    public string? Content { get; set; }
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
            ExperienceId = request.ExperienceId,
            Content = request.Content,
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