﻿using AutoMapper;
using AutoMapper.QueryableExtensions;
using MediaLink.Application.Common.Interfaces;
using MediaLink.Application.Common.Mappings;
using MediaLink.Application.Common.Models;
using MediaLink.Domain.Entities;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace MediaLink.Application.Skills.Queries.GetSkillsWithPagination;

public record GetSkillsWithPaginationQuery : IRequest<PaginatedList<Skill>>
{
    public int UserId { get; set; }
    public int PageNumber { get; init; } = 1;
    public int PageSize { get; init; } = 10;
}

public class GetSkillsWithPaginationQueryHandler : IRequestHandler<GetSkillsWithPaginationQuery, PaginatedList<Skill>>
{
    private readonly IApplicationDbContext _context;
    private readonly IMapper _mapper;

    public GetSkillsWithPaginationQueryHandler(IApplicationDbContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }
    public async Task<PaginatedList<Skill>> Handle(GetSkillsWithPaginationQuery request, CancellationToken cancellationToken)
    {
        return await _context.Skills
              .Where(S => S.UserId == request.UserId)
              .OrderBy(S => S.Created)
              .Include(u => u.User)
              .ProjectTo<Skill>(_mapper.ConfigurationProvider)
              .PaginatedListAsync(request.PageNumber, request.PageSize);
    }
}