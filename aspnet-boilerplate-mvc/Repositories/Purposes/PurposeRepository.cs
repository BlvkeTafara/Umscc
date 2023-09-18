using aspnet_boilerplate_mvc.DataAccess;
using aspnet_boilerplate_mvc.Entities;
using aspnet_boilerplate_mvc.Repositories.Generic;

namespace aspnet_boilerplate_mvc.Repositories.Purposes
{
    public class PurposeRepository : GenericRepository<Purpose>, IPurposeRepository
    {
        public PurposeRepository(AppDbContext context) : base(context)
        {
        }
    }
}
