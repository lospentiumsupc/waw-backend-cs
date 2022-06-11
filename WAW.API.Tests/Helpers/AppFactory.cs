using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.AspNetCore.TestHost;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using WAW.API.Shared.Persistence.Contexts;

namespace WAW.API.Tests.Helpers;

public static class AppFactory {
  public static WebApplicationFactory<Program> GetWebApplicationFactory() {
    return new WebApplicationFactory<Program>().WithWebHostBuilder(
      builder => {
        builder.ConfigureTestServices(
          services => {
            var descriptor = services.SingleOrDefault(d => d.ServiceType == typeof(DbContextOptions<AppDbContext>));
            if (descriptor is not null) {
              services.Remove(descriptor);
            }

            services.AddDbContext<AppDbContext>(
              options => options.UseInMemoryDatabase("InMemoryTestDatabase")
                .LogTo(Console.WriteLine, LogLevel.Information)
                .EnableSensitiveDataLogging()
                .EnableDetailedErrors()
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
}
