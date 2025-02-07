namespace B12.Infrastructure;

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;

public class B12DbContextFactory : IDesignTimeDbContextFactory<B12DbContext>
{
    public B12DbContext CreateDbContext(string[] args)
    {
        var configuration = new ConfigurationBuilder()
            .SetBasePath(Path.Combine(Directory.GetCurrentDirectory(), "..", "B12.Api"))
            .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
            .Build();

        var connectionString = configuration.GetConnectionString("DefaultConnection");

        var optionsBuilder = new DbContextOptionsBuilder<B12DbContext>();

        optionsBuilder.UseSqlServer(connectionString);

        return new B12DbContext(optionsBuilder.Options);
    }
}