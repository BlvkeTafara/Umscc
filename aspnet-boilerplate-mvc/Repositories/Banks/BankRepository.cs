using aspnet_boilerplate_mvc.DataAccess;
using aspnet_boilerplate_mvc.Entities;
using aspnet_boilerplate_mvc.Repositories.Generic;

namespace aspnet_boilerplate_mvc.Repositories.Banks
{
    public class BankRepository : GenericRepository<Bank>, IBankRepository
    {
        public BankRepository(AppDbContext context) : base(context)
        {
        }
        public bool Exists(int id)
        {
            return _context.Banks.Any(q => q.Id == id);
        }

    }
}
