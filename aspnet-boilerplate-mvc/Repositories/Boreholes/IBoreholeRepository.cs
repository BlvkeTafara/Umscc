using aspnet_boilerplate_mvc.Entities;
using aspnet_boilerplate_mvc.Repositories.Generic;

namespace aspnet_boilerplate_mvc.Repositories.Boreholes
{
    public interface IBoreholeRepository : IGenericRepository<Borehole>
    {
        bool Exists(int id);
        void Remove(int id);
    }
}
