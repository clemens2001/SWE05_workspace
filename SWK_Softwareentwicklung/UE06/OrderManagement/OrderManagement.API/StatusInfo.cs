using Microsoft.AspNetCore.Mvc;

namespace OrderManagement.API
{
    public static class StatusInfo
    {
        public static ProblemDetails CustomerAlreadyExists(Guid customerId) =>
            new ProblemDetails {
                Title = "Conflicting customer IDs",
                Detail = $"Customer with id {customerId} already exists"
            };

        public static ProblemDetails InvalidCustomerId(Guid customerId) =>
            new ProblemDetails {
                Title = "Invalid customer ID",
                Detail = $"Customer with id {customerId} does not exist"
            };
    }
}
