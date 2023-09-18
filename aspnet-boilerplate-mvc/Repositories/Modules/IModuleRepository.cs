using aspnet_boilerplate_mvc.Entities;
using aspnet_boilerplate_mvc.Repositories.Generic;

namespace aspnet_boilerplate_mvc.Repositories.Modules
{
    public interface IModuleRepository:IGenericRepository<Module>
    {
        Task<List<Module>> GetByRole(string roleId);
    }
}
