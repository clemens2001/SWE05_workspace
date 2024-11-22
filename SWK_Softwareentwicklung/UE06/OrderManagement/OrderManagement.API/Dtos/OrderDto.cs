using System.Text.Json.Serialization;
using OrderManagement.Domain;

namespace OrderManagement.API.Dtos
{
    public record OrderDto
    {
        public required Guid Id { get; set; }

        public required string Article { get; set; }

        public required DateTimeOffset OrderDate { get; set; }

        public decimal TotalPrice { get; set; }

        public required Customer? Customer { get; set; }
    }
}
