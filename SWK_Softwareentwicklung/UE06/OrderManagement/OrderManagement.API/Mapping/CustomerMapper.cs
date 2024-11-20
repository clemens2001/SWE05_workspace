using OrderManagement.API.Dtos;
using OrderManagement.Domain;

namespace OrderManagement.API.Mapping
{
    public static class CustomerMapper
    {
        public static CustomerDto ToDto(this Customer customer)
        {
            return new CustomerDto {
                Id = customer.Id,
                Name = customer.Name,
                ZipCode = customer.ZipCode,
                City = customer.City,
                Rating = customer.Rating,
                TotalRevenue = customer.TotalRevenue
            };
        }
    }
}
