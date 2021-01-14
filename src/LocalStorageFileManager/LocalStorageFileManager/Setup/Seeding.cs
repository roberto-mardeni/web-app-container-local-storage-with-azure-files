using LocalStorageFileManager.Data;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace LocalStorageFileManager.Setup
{
    public static class Seeding
    {
        public static IHost SeedFiles<TContext>(this IHost host) where TContext : IFileManager
        {
            // Create a scope to get scoped services.
            using (var scope = host.Services.CreateScope())
            {
                var services = scope.ServiceProvider;
                var context = services.GetService<TContext>();
                context.Seed();
            }

            return host;
        }
    }
}
