using OrderManagement.API.Dtos;
using OrderManagement.Domain;

namespace OrderManagement.API.Mapping
{
    public static class OrderMapper
    {
        public static OrderDto ToDto(this Order order)
        {
            return new OrderDto {
                Id = order.Id,
                Article = order.Article,
                OrderDate = order.OrderDate,
                TotalPrice = order.TotalPrice,
                Customer = order.Customer
            };
        }
    }
}
