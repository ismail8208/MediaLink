using AutoMapper;
using AutoMapper.QueryableExtensions;
using MediaLink.Application.Common.Interfaces;
using MediaLink.Application.Common.Mappings;
using MediaLink.Application.Common.Models;
using MediaLink.Domain.Entities;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace MediaLink.Application.Educations.Queries.GetEducationsWithPagination;

public record GetEducationsWithPaginationQuery : IRequest<PaginatedList<Education>>
{
    public int UserId { get; set; }
    public int PageNumber { get; init; } = 1;
    public int PageSize { get; init; } = 10;
}

public class GetEducationsWithPaginationQueryHandler : IRequestHandler<GetEducationsWithPaginationQuery, PaginatedList<Education>>
{
    private readonly IApplicationDbContext _context;

    public GetEducationsWithPaginationQueryHandler(IApplicationDbContext context)
    {
        _context = context;
    }
    public async Task<PaginatedList<Education>> Handle(GetEducationsWithPaginationQuery request, CancellationToken cancellationToken)
    {
        return await _context.Educations
              .Where(E => E.UserId == request.UserId)
              .OrderBy(E => E.Created)
              .PaginatedListAsync(request.PageNumber, request.PageSize);
    }
}
