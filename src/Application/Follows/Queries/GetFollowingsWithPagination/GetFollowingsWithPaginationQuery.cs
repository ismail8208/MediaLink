using AutoMapper;
using AutoMapper.QueryableExtensions;
using MediaLink.Application.Common.Interfaces;
using MediaLink.Application.Common.Mappings;
using MediaLink.Application.Common.Models;
using MediaLink.Domain.Entities;
using MediatR;

namespace MediaLink.Application.Follows.Queries.GetFollowingsWithPagination;
public record GetFollowingsWithPaginationQuery : IRequest<PaginatedList<InnerUser>>
{
    public int UserId { get; init; }
    public int PageNumber { get; init; } = 1;
    public int PageSize { get; init; } = 10;
}

public class GetFollowingsWithPaginationQueryHandler : IRequestHandler<GetFollowingsWithPaginationQuery, PaginatedList<InnerUser>>
{
    private readonly IApplicationDbContext _context;

    public GetFollowingsWithPaginationQueryHandler(IApplicationDbContext context)
    {
        _context = context;
    }
    public async Task<PaginatedList<InnerUser>> Handle(GetFollowingsWithPaginationQuery request, CancellationToken cancellationToken)
    {
        return await _context.Follows
           .Where(f => f.FollowingID == request.UserId)
           .Select(f => f.Follower)
           .PaginatedListAsync(request.PageNumber, request.PageSize);
    }
}