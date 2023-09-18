using aspnet_boilerplate_mvc.Entities;
using aspnet_boilerplate_mvc.Repositories.Generic;

namespace aspnet_boilerplate_mvc.Repositories.Banks
{
    public interface IBankRepository : IGenericRepository<Bank>
    {
        bool Exists(int id);
    }
}
