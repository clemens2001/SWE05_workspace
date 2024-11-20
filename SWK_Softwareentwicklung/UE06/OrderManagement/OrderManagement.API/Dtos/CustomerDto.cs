using System.Text.Json.Serialization;
using OrderManagement.Domain;

namespace OrderManagement.API.Dtos
{
    public record CustomerDto
    {
        //[JsonRequired]
        public required Guid Id { get; set; }

        public required string Name { get; set; }

        public required int ZipCode { get; set; }

        //[JsonPropertyName("location")]
        public required string City { get; set; }

        [JsonConverter(typeof(JsonStringEnumConverter))]
        public required Rating Rating { get; set; }

        //[JsonIgnore]
        public decimal TotalRevenue { get; set; }
    }
}
