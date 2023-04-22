namespace MediaLink.Domain.Entities;

public class Experience : BaseAuditableEntity
{
    public int? ProjectId { get; set; }
    public Project? Project { get; set; }
    public string? Title { get; set; }
    public string? Content { get; set; }
    public DateTime? ExperienceDate { get; set; }
    public int UserId { get; set; }
    public InnerUser? User { get; set; }
}

