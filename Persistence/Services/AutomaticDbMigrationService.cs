using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Persistence.Context;
using Persistence.DbInitializer;

namespace Persistence.Services;

public sealed class AutomaticDbMigrationService : IAutomaticDbMigrationService
{
    private readonly ILogger<AutomaticDbMigrationService> _logger;

    private readonly IServiceScopeFactory _serviceScopeFactory;

    public AutomaticDbMigrationService(ILogger<AutomaticDbMigrationService> logger,
        IServiceScopeFactory serviceScopeFactory)
    {
        _logger = logger;
        _serviceScopeFactory = serviceScopeFactory;
    }

    public void Run()
    {
        using (var scope = _serviceScopeFactory.CreateScope())
        {
            var services = scope.ServiceProvider;

            var logger = services.GetRequiredService<ILogger<HospitalContext>>();

            var database = services.GetRequiredService<HospitalContext>().Database;

            database.SetCommandTimeout(160);

            database.Migrate();

            var initializer = services.GetRequiredService<IDatabaseInitializer>();

            initializer.InitializeIfNeededAsync().GetAwaiter().GetResult();

            _logger.LogInformation("Finished running automatic migration...");
        }
    }
}
