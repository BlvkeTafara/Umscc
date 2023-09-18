using aspnet_boilerplate_mvc.DataAccess;
using aspnet_boilerplate_mvc.Entities;
using aspnet_boilerplate_mvc.Repositories.Generic;

namespace aspnet_boilerplate_mvc.Repositories.Areas
{
    public class AreaRepository : GenericRepository<Area>, IAreaRepository
    {
        public AreaRepository(AppDbContext context) : base(context)
        {
        }
    }
}
