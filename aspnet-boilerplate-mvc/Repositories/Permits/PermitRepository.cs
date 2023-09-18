using aspnet_boilerplate_mvc.DataAccess;
using aspnet_boilerplate_mvc.Entities;
using aspnet_boilerplate_mvc.Repositories.Generic;

namespace aspnet_boilerplate_mvc.Repositories.Permits
{
    public class PermitRepository : GenericRepository<Permit>, IPermitRepository
    {
        public PermitRepository(AppDbContext context) : base(context)
        {
        }
    }
}
