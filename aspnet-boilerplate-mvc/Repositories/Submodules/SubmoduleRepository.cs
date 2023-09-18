using aspnet_boilerplate_mvc.DataAccess;
using aspnet_boilerplate_mvc.Entities;
using aspnet_boilerplate_mvc.Repositories.Generic;

namespace aspnet_boilerplate_mvc.Repositories.Submodules
{
    public class SubmoduleRepository : GenericRepository<Submodule>, ISubmoduleRepository
    {
        public SubmoduleRepository(AppDbContext context) : base(context)
        {
        }
    }
}
