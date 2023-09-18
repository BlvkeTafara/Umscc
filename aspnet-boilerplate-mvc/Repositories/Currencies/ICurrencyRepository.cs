using aspnet_boilerplate_mvc.Entities;
using aspnet_boilerplate_mvc.Repositories.Generic;

namespace aspnet_boilerplate_mvc.Repositories.Currencies
{
    public interface ICurrencyRepository : IGenericRepository<Currency>
    {
        void BulkUpdate(Currency currency);
    }
}
