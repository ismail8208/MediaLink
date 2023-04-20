using MediaLink.Application.Common.Mappings;
using MediaLink.Domain.Entities;

namespace MediaLink.Application.Endorsements.Queries.GetEndorsmentsWithPagination;

public class EndorsmentDto : IMapFrom<Endorsement>
{
    public int SkillId { get; set; }
    public int UserId { get; set; }
    public InnerUser? User { get; set; }
}
