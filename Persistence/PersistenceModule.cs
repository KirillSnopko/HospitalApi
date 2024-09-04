using Microsoft.EntityFrameworkCore.Diagnostics;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Persistence.Context;
using System.Diagnostics.CodeAnalysis;
using Z.EntityFramework.Extensions;
using Microsoft.EntityFrameworkCore;
using Shared;

namespace Persistence;

public static class PersistenceModule
{
    public static void AddPersistenceModule([NotNull] this IServiceCollection services,
        [NotNull] IConfiguration configuration)
    {
        EntityFrameworkManager.IsCommunity = true;

        var connectionString = configuration.GetValue<string>(nameof(ApplicationConfiguration.DbConnectionString));

        services.AddDbContext<HospitalContext>(options =>
        {
            options.EnableDetailedErrors();
            options.EnableSensitiveDataLogging();
            options.UseLazyLoadingProxies();
            options.UseSqlServer(connectionString, x =>
            {
                x.EnableRetryOnFailure(2);
                x.CommandTimeout(5);
            });
            options.ConfigureWarnings(warnings => warnings.Ignore(RelationalEventId.BoolWithDefaultWarning));
        });
    }
}
