using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.AspNetCore.TestHost;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using WAW.API.Shared.Persistence.Contexts;

namespace WAW.API.Tests.Helpers;

public static class AppFactory {
  public static WebApplicationFactory<Program> GetWebApplicationFactory() {
    var configuration = GetConfiguration();

    return new WebApplicationFactory<Program>().WithWebHostBuilder(
      builder => {
        builder.ConfigureTestServices(
          services => {
            var descriptor = services.SingleOrDefault(d => d.ServiceType == typeof(DbContextOptions<AppDbContext>));
            if (descriptor is not null) {
              services.Remove(descriptor);
            }

            var connectionString = configuration.GetValue<string>("DbConnectionString");
            Console.WriteLine(connectionString);

            services.AddDbContext<AppDbContext>(
              options => {
                var serverVersion = ServerVersion.AutoDetect(connectionString);
                options.UseMySql(connectionString, serverVersion)
                  .LogTo(Console.WriteLine)
                  .EnableSensitiveDataLogging()
                  .EnableDetailedErrors();
              }
            );

            var provider = services.BuildServiceProvider();
            var scope = provider.CreateScope();
            var scopedServices = scope.ServiceProvider;
            var ctx = scopedServices.GetRequiredService<AppDbContext>();

            ctx.Database.EnsureDeleted();
            ctx.Database.EnsureCreated();
          }
        );

        builder.UseEnvironment("Testing");
      }
    );
  }

  private static IConfigurationRoot GetConfiguration() {
    return new ConfigurationBuilder()
      .AddJsonFile("appsettings.json", optional: true)
      .AddJsonFile("appsettings.Testing.json", optional: true)
      .AddUserSecrets("058cde84-9a55-42ad-82e5-511f1ffdac17")
      .AddEnvironmentVariables()
      .Build();
  }
}
