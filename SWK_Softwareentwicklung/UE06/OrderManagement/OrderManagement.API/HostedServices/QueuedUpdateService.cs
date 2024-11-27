using OrderManagement.Api.BackgroundServices;
using OrderManagement.Logic;

namespace OrderManagement.API.HostedServices
{
    public class QueuedUpdateService : BackgroundService
    {
        private readonly IServiceProvider serviceProvider;
        private readonly ILogger<QueuedUpdateService> logger;
        private readonly UpdateChannel updateChannel;

        public QueuedUpdateService(
            IServiceProvider serviceProvider, 
            ILogger<QueuedUpdateService> logger,
            UpdateChannel updateChannel)
        {
            this.serviceProvider = serviceProvider;
            this.logger = logger;
            this.updateChannel = updateChannel;
        }

        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {

            await foreach (var customerId in updateChannel.ReadAllAsync(stoppingToken))
            {
                using var scope = serviceProvider.CreateScope();
                var logic = scope.ServiceProvider.GetRequiredService<IOrderManagementLogic>();
                await logic.UpdateTotalRevenueAsync(customerId);

                logger.LogInformation($"Updated total revenue for customer {customerId}" + 
                                      $"at {DateTimeOffset.Now}");
            }
        }

    }
}
