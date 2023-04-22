using MediaLink.Application.Common.Mappings;
using MediaLink.Domain.Entities;

namespace MediaLink.Application.Addresses.Queries.SearchAddress;
public class AddressDto : IMapFrom<Address>
{
    public int Id { get; set; }
    public string? Country { get; set; }
    public string? City { get; set; }
    public string? Street { get; set; }
}
