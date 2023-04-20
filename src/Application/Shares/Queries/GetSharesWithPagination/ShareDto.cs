using MediaLink.Application.Common.Mappings;
using MediaLink.Domain.Entities;

namespace MediaLink.Application.Shares.Queries.GetSharesWithPagination;
public class ShareDto : IMapFrom<Share>
{
    public int Id { get; set; }
    public int UserId { get; set; }
    public int PostId { get; set; }
    public InnerUser? User { get; set; }
}
