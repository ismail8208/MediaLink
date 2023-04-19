using MediaLink.Application.Common.Exceptions;
using MediaLink.Application.Common.Interfaces;
using MediaLink.Domain.Entities;
using MediatR;

namespace MediaLink.Application.Projects.Commands.UpdateProject;

public record UpdateProjectCommand : IRequest
{
    public int Id { get; set; }
    public int? ExperienceId { get; set; }
    public string? Content { get; set; }
    public string? ImageURL { get; set; }
    public string? Link { get; set; }
    public int UserId { get; set; }
}

public class UpdateProjectCommandHandler : IRequestHandler<UpdateProjectCommand>
{
    private readonly IApplicationDbContext _context;

    public UpdateProjectCommandHandler(IApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<Unit> Handle(UpdateProjectCommand request, CancellationToken cancellationToken)
    {
        var entity = await _context.Projects
            .FindAsync(new object[] { request.Id }, cancellationToken);

        if (entity == null)
        {
            throw new NotFoundException(nameof(Project), request.Id);
        }

        entity.ExperienceId = request.ExperienceId;
        entity.Content = request.Content;
        entity.ImageURL = request.ImageURL;
        entity.Link = request.Link;
        entity.UserId = request.UserId;

        await _context.SaveChangesAsync(cancellationToken);

        return Unit.Value;
    }

}
