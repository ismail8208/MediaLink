using MediaLink.Application.Common.Mappings;
using MediaLink.Domain.Entities;

namespace MediaLink.Application.Likes.Queries.GetLikesWithPagination;
public class LikeDto : IMapFrom<Like>
{
    public int Id { get; set; }
    public int UserId { get; set; }
    public int PostId { get; set; }
    public InnerUser? User { get; set; }
}
