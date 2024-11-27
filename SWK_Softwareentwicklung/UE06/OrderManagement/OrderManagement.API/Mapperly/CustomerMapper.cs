using OrderManagement.API.Dtos;
using OrderManagement.Domain;
using Riok.Mapperly.Abstractions;

namespace OrderManagement.API.Mapperly
{
    [Mapper]
    public static partial class CustomerMapper
    {
        public static partial CustomerDto ToDto(this Customer customer);
        public static partial IEnumerable<CustomerDto> ToDtoEnumeration(this IEnumerable<Customer> customers);

        [MapperIgnoreTarget(nameof(Customer.TotalRevenue))]
        public static partial Customer ToEntity(this CustomerForCreationDto customer);
    }
}
