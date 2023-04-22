using MediaLink.Application.Common.Exceptions;
using MediaLink.Application.Common.Interfaces;
using MediaLink.Domain.Entities;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace MediaLink.Application.Addresses.Queries.GetAddressByUserId;

public record GetAddressQuery(int id) : IRequest<Address>;


public class GetAddressQueryHandler : IRequestHandler<GetAddressQuery, Address>
{
    private readonly IApplicationDbContext _context;

    public GetAddressQueryHandler(IApplicationDbContext context)
    {
        _context = context;
    }
    public async Task<Address> Handle(GetAddressQuery request, CancellationToken cancellationToken)
    {
        var address =  await _context.Addresses.FirstOrDefaultAsync(a=>a.UserId == request.id);
        if (address == null)
        {
            throw new NotFoundException();
        }
        return address;
    }
}
