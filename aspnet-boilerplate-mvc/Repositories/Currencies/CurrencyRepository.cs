using aspnet_boilerplate_mvc.DataAccess;
using aspnet_boilerplate_mvc.Entities;
using aspnet_boilerplate_mvc.Repositories.Generic;

namespace aspnet_boilerplate_mvc.Repositories.Currencies
{
    public class CurrencyRepository : GenericRepository<Currency>, ICurrencyRepository
    {
        public CurrencyRepository(AppDbContext context) : base(context)
        {
        }

        public void BulkUpdate(Currency currency)
        {
            List<Currency> currencies = GetOne(currency);
            foreach (var currencyToUpdate in currencies)
            {
                currencyToUpdate.Name = currency.Name;
                currencyToUpdate.Code = currency.Code;
            }
            _context.SaveChanges();
        }

        private List<Currency> GetOne(Currency currency)
        {
        List<Currency> currencies = _context.Currency
        .Where(q => q.Id == currency.Id)
        .ToList();

            return currencies;
        }
    }
}
