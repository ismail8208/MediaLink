using MediaLink.Application.Common.Interfaces;
using MediaLink.Domain.Entities;
using MediaLink.Domain.Events.ExperienceEvents;
using MediatR;

namespace MediaLink.Application.Experiences.Commands.CreateExperience;

public record CreateExperienceCommand : IRequest <int>
{
    public string? Title { get; set; }
    public string? Content { get; set; }
    public DateTime? ExperienceDate { get; set; }
    public int UserId { get; set; }
}

public class CreateExperienceCommandHandler : IRequestHandler<CreateExperienceCommand, int>
{

    private readonly IApplicationDbContext _context;

    public CreateExperienceCommandHandler(IApplicationDbContext context)
    {
        _context = context;
    }
    public async Task<int> Handle(CreateExperienceCommand request, CancellationToken cancellationToken)
    {
        var entity = new Experience
        {
            Title = request.Title,
            Content = request.Content,
            ExperienceDate = request.ExperienceDate,
            UserId = request.UserId
            
        };

        entity.AddDomainEvent(new ExperienceCreatedEvent(entity));

        _context.Experiences.Add(entity);

        await _context.SaveChangesAsync(cancellationToken);

        return entity.Id;
    }
}
