using aspnet_boilerplate_mvc.DataAccess;
using aspnet_boilerplate_mvc.Entities;
using aspnet_boilerplate_mvc.Repositories.Generic;

namespace aspnet_boilerplate_mvc.Repositories.Rainreadings
{
    public class RainreadingRepository : GenericRepository<Rainreading>, IRainreadingRepository
    {
        public RainreadingRepository(AppDbContext context) : base(context)
        {
        }
    }
}
