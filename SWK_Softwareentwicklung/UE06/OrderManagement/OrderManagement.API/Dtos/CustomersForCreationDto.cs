using OrderManagement.Domain;
using System.Text.Json.Serialization;

namespace OrderManagement.API.Dtos
{
    public record CustomersForCreationDto
    {
        public Guid Id { get; set; }

        public required string Name { get; set; }

        public required int ZipCode { get; set; }

        public required string City { get; set; }

        [JsonConverter(typeof(JsonStringEnumConverter))]
        public required Rating Rating { get; set; }

    }
}
