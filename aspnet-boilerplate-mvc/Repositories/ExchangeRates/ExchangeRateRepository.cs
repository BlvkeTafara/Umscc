using aspnet_boilerplate_mvc.DataAccess;
using aspnet_boilerplate_mvc.Entities;
using aspnet_boilerplate_mvc.Repositories.Generic;

namespace aspnet_boilerplate_mvc.Repositories.ExchangeRates
{
    public class ExchangeRateRepository : GenericRepository<ExchangeRate>, IExchangeRateRepository
    {
        public ExchangeRateRepository(AppDbContext context) : base(context)
        {
        }
    }
}
