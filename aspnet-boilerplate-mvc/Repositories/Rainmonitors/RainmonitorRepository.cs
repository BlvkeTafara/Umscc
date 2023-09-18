using aspnet_boilerplate_mvc.DataAccess;
using aspnet_boilerplate_mvc.Entities;
using aspnet_boilerplate_mvc.Repositories.Generic;

namespace aspnet_boilerplate_mvc.Repositories.Rainmonitors
{
    public class RainmonitorRepository : GenericRepository<Rainmonitor>, IRainmonitorRepository
    {
        public RainmonitorRepository(AppDbContext context) : base(context)
        {
        }
    }
}
