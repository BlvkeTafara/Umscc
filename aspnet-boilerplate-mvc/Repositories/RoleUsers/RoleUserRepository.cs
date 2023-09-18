using aspnet_boilerplate_mvc.DataAccess;
using aspnet_boilerplate_mvc.Entities;
using aspnet_boilerplate_mvc.Repositories.Generic;

namespace aspnet_boilerplate_mvc.Repositories.RoleUsers
{
    public class RoleUserRepository : GenericRepository<RoleUser>, IRoleUserRepository
    {
        public RoleUserRepository(AppDbContext context) : base(context)
        {
        }
    }
}
