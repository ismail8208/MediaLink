using MediaLink.Application.Common.Interfaces;
using MediaLink.Application.Common.Mappings;
using MediaLink.Application.Common.Models;
using MediaLink.Domain.Entities;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace MediaLink.Application.Experiences.Queries.GetExperiencesWithPagination;

public record GetExperiencesWithPaginationQuery : IRequest<PaginatedList<Experience>>
{
    public int UserId { get; set; }
    public int PageNumber { get; init; } = 1;
    public int PageSize { get; init; } = 10;
}

public class GetExperiencesWithPaginationQueryHandler : IRequestHandler<GetExperiencesWithPaginationQuery, PaginatedList<Experience>>
{
    private readonly IApplicationDbContext _context;
    public GetExperiencesWithPaginationQueryHandler(IApplicationDbContext context)
    {
        _context = context;
    }
    public async Task<PaginatedList<Experience>> Handle(GetExperiencesWithPaginationQuery request, CancellationToken cancellationToken)
    {
        return await _context.Experiences
            .Where(E => E.UserId == request.UserId)
            .OrderBy(E => E.Created)
            .PaginatedListAsync(request.PageNumber, request.PageSize);
    }
}
