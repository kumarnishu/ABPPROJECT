using Acme.BookStore2.Localization;
using Volo.Abp.Application.Services;

namespace Acme.BookStore2.Services;

/* Inherit your application services from this class. */
public abstract class BookStore2AppService : ApplicationService
{
    protected BookStore2AppService()
    {
        LocalizationResource = typeof(BookStore2Resource);
    }
}