using MediaLink.Application.Common.Interfaces;
using MediaLink.Domain.Entities;
using MediaLink.Domain.Events.SkillEvents;
using MediatR;

namespace MediaLink.Application.Skills.Commands.CreateSkill;

public record CreateSkillCommand : IRequest<int>
{
    public string? Title { get; set; }
    public int UserId { get; set; }
}

public class CreateSkillCommandHandler : IRequestHandler<CreateSkillCommand, int>
{
    private readonly IApplicationDbContext _context;

    public CreateSkillCommandHandler(IApplicationDbContext context)
    {
        _context = context;
    }
    public async Task<int> Handle(CreateSkillCommand request, CancellationToken cancellationToken)
    {
        var entity = new Skill
        {
            
            Title = request.Title,
            UserId = request.UserId
        };

        entity.AddDomainEvent(new SkillCreatedEvent(entity));

        _context.Skills.Add(entity);

        await _context.SaveChangesAsync(cancellationToken);

        return entity.Id;
    }
}