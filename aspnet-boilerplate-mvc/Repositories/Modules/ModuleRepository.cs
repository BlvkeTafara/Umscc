using aspnet_boilerplate_mvc.DataAccess;
using aspnet_boilerplate_mvc.Entities;
using aspnet_boilerplate_mvc.Repositories.Generic;
using Microsoft.EntityFrameworkCore;

namespace aspnet_boilerplate_mvc.Repositories.Modules
{
    public class ModuleRepository : GenericRepository<Module>, IModuleRepository
    {
        public ModuleRepository(AppDbContext context) : base(context)
        {
        }

        public async Task<List<Module>> GetByRole(string roleId)
        {
            var modules = await _context.Modules
                                        .Include(q=>q.submodules)
                                        .ThenInclude(q=>q.Permissions)
                                        .ThenInclude(q=>q.rolepermissions.Where(q=>q.RoleId == roleId))
                                        .ToListAsync();
            return modules;
        }
    }
}
