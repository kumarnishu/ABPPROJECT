using Microsoft.EntityFrameworkCore;
using Volo.Abp.DependencyInjection;

namespace Acme.BookStore2.Data;

public class BookStore2EFCoreDbSchemaMigrator : ITransientDependency
{
    private readonly IServiceProvider _serviceProvider;

    public BookStore2EFCoreDbSchemaMigrator(
        IServiceProvider serviceProvider)
    {
        _serviceProvider = serviceProvider;
    }

    public async Task MigrateAsync()
    {
        /* We intentionally resolve the BookStore2DbContext
         * from IServiceProvider (instead of directly injecting it)
         * to properly get the connection string of the current tenant in the
         * current scope.
         */

        await _serviceProvider
            .GetRequiredService<BookStore2DbContext>()
            .Database
            .MigrateAsync();
    }
}
