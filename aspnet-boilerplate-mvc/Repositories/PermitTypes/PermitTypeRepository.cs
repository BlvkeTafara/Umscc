using aspnet_boilerplate_mvc.DataAccess;
using aspnet_boilerplate_mvc.Entities;
using aspnet_boilerplate_mvc.Repositories.Generic;

namespace aspnet_boilerplate_mvc.Repositories.PermitTypes
{
    public class PermitTypeRepository : GenericRepository<PermitType>, IPermitTypeRepository
    {
        public PermitTypeRepository(AppDbContext context) : base(context)
        {
        }
    }
}
