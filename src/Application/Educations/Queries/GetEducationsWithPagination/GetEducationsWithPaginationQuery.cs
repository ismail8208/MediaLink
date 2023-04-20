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
    private readonly IMapper _mapper;

    public GetEducationsWithPaginationQueryHandler(IApplicationDbContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }
    public async Task<PaginatedList<Education>> Handle(GetEducationsWithPaginationQuery request, CancellationToken cancellationToken)
    {
        return await _context.Educations
              .Where(E => E.UserId == request.UserId)
              .OrderBy(E => E.Created)
              .Include(u => u.User)
              .ProjectTo<Education>(_mapper.ConfigurationProvider)
              .PaginatedListAsync(request.PageNumber, request.PageSize);
    }
}
