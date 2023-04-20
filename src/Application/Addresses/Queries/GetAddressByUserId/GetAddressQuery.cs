using MediaLink.Application.Common.Interfaces;
using MediaLink.Domain.Entities;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace MediaLink.Application.Addresses.Queries.GetAddressByUserId;

public record GetAddressQuery : IRequest<Address>
{
    public int UserId { get; set; }
}


public class GetAddressQueryHandler : IRequestHandler<GetAddressQuery, Address>
{
    private readonly IApplicationDbContext _context;

    public GetAddressQueryHandler(IApplicationDbContext context)
    {
        _context = context;
    }
    public async Task<Address> Handle(GetAddressQuery request, CancellationToken cancellationToken)
    {
        return  await _context.Addresses
            .FirstOrDefaultAsync(A=>A.UserId == request.UserId);
        
    }
}
