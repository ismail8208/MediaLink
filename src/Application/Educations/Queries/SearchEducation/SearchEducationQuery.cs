﻿using AutoMapper;
using AutoMapper.QueryableExtensions;
using MediaLink.Application.Common.Interfaces;
using MediaLink.Application.Common.Mappings;
using MediaLink.Application.Common.Models;
using MediatR;

namespace MediaLink.Application.Educations.Queries.SearchEducation;
public record SearchEducationQuery : IRequest<PaginatedList<EducationDto>>
{
    public string? Query { get; set; }
    public int PageNumber { get; init; } = 1;
    public int PageSize { get; init; } = 10;
}

public class SearchEducationQueryHandler : IRequestHandler<SearchEducationQuery, PaginatedList<EducationDto>>
{
    private readonly IApplicationDbContext _context;
    private readonly IMapper _mapper;

    public SearchEducationQueryHandler(IApplicationDbContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }
    public async Task<PaginatedList<EducationDto>> Handle(SearchEducationQuery request, CancellationToken cancellationToken)
    {
        return await _context.Educations
            .Where(u => u.Title.StartsWith(request.Query))
            .ProjectTo<EducationDto>(_mapper.ConfigurationProvider)
            .PaginatedListAsync(request.PageNumber, request.PageSize);
    }
}
