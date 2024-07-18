using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace Acme.BookStore2.Data;

public class BookStore2DbContextFactory : IDesignTimeDbContextFactory<BookStore2DbContext>
{
    public BookStore2DbContext CreateDbContext(string[] args)
    {

        var configuration = BuildConfiguration();

        var builder = new DbContextOptionsBuilder<BookStore2DbContext>()
            .UseSqlServer(configuration.GetConnectionString("Default"));

        return new BookStore2DbContext(builder.Options);
    }

    private static IConfigurationRoot BuildConfiguration()
    {
        var builder = new ConfigurationBuilder()
            .SetBasePath(Directory.GetCurrentDirectory())
            .AddJsonFile("appsettings.json", optional: false);

        return builder.Build();
    }
}
