namespace MediaLink.Domain.Entities;

public class Project : BaseAuditableEntity
{
    public int? ExperienceId { get; set; }
    public Experience? Experience { get; set; }
    public string? Content { get; set; }
    public string? ImageURL { get; set; }
    public string? Link { get; set; }
    public int UserId { get; set; }
    public InnerUser? User { get; set; }
}

