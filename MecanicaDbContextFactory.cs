using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;

namespace Mecanica.NET
{
    public class MecanicaDbContextFactory : IDesignTimeDbContextFactory<AngularDbContext>
    {
        public AngularDbContext CreateDbContext(string[] args)
        {
            var configuration = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json")
                .Build();

            var connectionString = configuration.GetConnectionString("cn");

            var optionsBuilder = new DbContextOptionsBuilder<AngularDbContext>();
            optionsBuilder.UseMySql(connectionString, ServerVersion.AutoDetect(connectionString));

            return new AngularDbContext(optionsBuilder.Options);
        }
    }
}