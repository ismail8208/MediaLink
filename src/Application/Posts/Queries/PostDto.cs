using MediaLink.Application.Common.Mappings;
using MediaLink.Domain.Entities;

namespace MediaLink.Application.Posts.Queries;
public class PostDto : IMapFrom<Post>
{
    public int Id { get; set; }
    public string? Content { get; set; }
    public string? ImageURL { get; set; }
    public string? VideoURL { get; set; }
    public int NumberOfLikes { get; set; }
    public int NumberOfComments { get; set; }
    public int UserId { get; set; }
}
