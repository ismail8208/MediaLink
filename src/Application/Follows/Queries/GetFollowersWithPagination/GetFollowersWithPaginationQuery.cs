using System.Data;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using MediaLink.Application.Common.Interfaces;
using MediaLink.Application.Common.Mappings;
using MediaLink.Application.Common.Models;
using MediaLink.Application.Common.Security;
using MediaLink.Domain.Entities;
using MediatR;

namespace MediaLink.Application.Follows.Queries.GetFollowers;
[Authorize(Roles = "member")]
public record GetFollowersWithPaginationQuery : IRequest<PaginatedList<InnerUser>>
{
    public int UserId { get; init; }
    public int PageNumber { get; init; } = 1;
    public int PageSize { get; init; } = 10;
}
public class GetFollowersWithPaginationQueryHandler : IRequestHandler<GetFollowersWithPaginationQuery, PaginatedList<InnerUser>>
{
    private readonly IApplicationDbContext _context;

    public GetFollowersWithPaginationQueryHandler(IApplicationDbContext context)
    {
        _context = context;
    }
    public async Task<PaginatedList<InnerUser>> Handle(GetFollowersWithPaginationQuery request, CancellationToken cancellationToken)
    {
        return await _context.Follows
            .Where(f => f.FollowerID == request.UserId)
            .Select(f => f.Followee)
            .PaginatedListAsync(request.PageNumber, request.PageSize);

    }
}