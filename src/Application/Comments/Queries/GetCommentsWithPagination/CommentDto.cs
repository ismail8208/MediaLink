using MediaLink.Application.Common.Mappings;
using MediaLink.Domain.Entities;

namespace MediaLink.Application.Comments.Queries.GetCommentsWithPagination;
public class CommentDto : IMapFrom<Comment>
{
    public int Id { get; set; }
    public string? Content { get; set; }
    public int PostId { get; set; }
    public int UserId { get; set; }
}
