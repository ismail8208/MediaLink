using AutoMapper;
using MediaLink.Application.Common.Exceptions;
using MediaLink.Application.Common.Interfaces;
using MediaLink.Application.Users.Queries.FindUser;
using MediaLink.Domain.Entities;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace MediaLink.Application.Users.Queries.GetUser;

public record GetUserQuery(string username) : IRequest<UserDto>;
public class GetUserQueryHandler : IRequestHandler<GetUserQuery, UserDto>
{
    private readonly IApplicationDbContext _context;
    private readonly IMapper _mapper;

    public GetUserQueryHandler(IApplicationDbContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }
    public async Task<UserDto> Handle(GetUserQuery request, CancellationToken cancellationToken)
    {
        var user = await _context.InnerUsers.FirstOrDefaultAsync(u => u.UserName == request.username && u.IsDeleted == false);
        if (user == null)
        {
            throw new NotFoundException(nameof(InnerUser), request.username);
        }

        var entity = new UserDto
        {
            Id = user.Id,
            UserName = user.UserName,
            FirstName = user.FirstName,
            LastName = user.LastName,
            ProfileImage = user.ProfileImage,
        };

        return entity;

    }
}