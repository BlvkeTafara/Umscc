using aspnet_boilerplate_mvc.DataAccess;
using aspnet_boilerplate_mvc.Entities;
using aspnet_boilerplate_mvc.Repositories.Generic;

namespace aspnet_boilerplate_mvc.Repositories.Roles
{
    public class RoleRepository : GenericRepository<Role>, IRoleRepository
    {
        public RoleRepository(AppDbContext context) : base(context)
        {
        }
    }
}
