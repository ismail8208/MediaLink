using MediaLink.Application.Common.Mappings;
using MediaLink.Domain.Entities;

namespace MediaLink.Application.Projects.Queries.GetProjectsWithPagination;

public class ProjectDto : IMapFrom<Project>
{
    public int Id { get; set; }
    public int? ExperienceId { get; set; }
    public string? Content { get; set; }
    public string? ImageURL { get; set; }
    public string? Link { get; set; }
    public int UserId { get; set; }
    public InnerUser? User { get; set; }
}
