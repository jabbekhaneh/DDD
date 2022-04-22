using FluentMigrator.Runner;
using Microsoft.Extensions.DependencyInjection;

namespace Portal.EF.Migrations;

public static class Runner
{
    public static string ConnectionString { get; set; } = "Server=.;Database=_dbPortal;Trusted_Connection=True;";
    public static void Main()
    {
        var serviceProvider = CreateServices();
        // Put the database update into a scope to ensure
        // that all resources will be disposed.
        using (var scope = serviceProvider.CreateScope())
        {
            UpdateDatabase(scope.ServiceProvider);
        }
    }

    /// <summary>
    /// Configure the dependency injection services
    /// </summary>
    private static IServiceProvider CreateServices()
    {
        return new ServiceCollection()

            .AddFluentMigratorCore()
            .ConfigureRunner(_ => _
                .AddSqlServer()
                .WithGlobalConnectionString(ConnectionString)
                .ScanIn(typeof(Runner).Assembly).For.Migrations())
            .AddLogging(_ => _.AddFluentMigratorConsole())
            .BuildServiceProvider(false);
    }

    /// <summary>
    /// Update the database
    /// </summary>
    private static void UpdateDatabase(IServiceProvider serviceProvider)
    {
        // Instantiate the runner
        var runner = serviceProvider.GetRequiredService<IMigrationRunner>();

        // Execute the migrations
        runner.MigrateUp();
    }
}
