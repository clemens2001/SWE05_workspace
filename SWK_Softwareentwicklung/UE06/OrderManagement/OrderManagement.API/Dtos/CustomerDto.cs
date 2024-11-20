using OrderManagement.Domain;

namespace OrderManagement.API.Dtos
{
    public record CustomerDto
    {
        public Guid Id { get; set; }

        public string Name { get; set; }

        public int ZipCode { get; set; }

        public string City { get; set; }

        public Rating Rating { get; set; }

        public decimal TotalRevenue { get; set; }
    }
}
