using aspnet_boilerplate_mvc.DataAccess;
using aspnet_boilerplate_mvc.Entities;
using aspnet_boilerplate_mvc.Repositories.Generic;

namespace aspnet_boilerplate_mvc.Repositories.Riverbanks
{
    public class RiverbankRepository : GenericRepository<Riverbank>, IRiverbankRepository
    {
        public RiverbankRepository(AppDbContext context) : base(context)
        {
        }
    }
}
