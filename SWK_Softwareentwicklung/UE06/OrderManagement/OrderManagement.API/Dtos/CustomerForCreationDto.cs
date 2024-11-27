using OrderManagement.Domain;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace OrderManagement.API.Dtos
{
    public record CustomerForCreationDto
    {
        public Guid Id { get; set; }

        public required string Name { get; set; }

        [Range(1000, 9999, ErrorMessage = "Zip code must have 4 digits.")]
        public required int ZipCode { get; set; }

        public required string City { get; set; }

        [JsonConverter(typeof(JsonStringEnumConverter))]
        public required Rating Rating { get; set; }

    }
}
