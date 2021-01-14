using LocalStorageFileManager.Data;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Hosting;
using LocalStorageFileManager.Setup;

namespace LocalStorageFileManager
{
    public class Program
    {
        public static void Main(string[] args)
        {
            CreateHostBuilder(args)
                .Build()
#if DEBUG
                .SeedFiles<IFileManager>()
#endif
                .Run();
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.UseStartup<Startup>();
                });
    }
}
