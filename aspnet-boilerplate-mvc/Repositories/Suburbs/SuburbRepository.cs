using aspnet_boilerplate_mvc.DataAccess;
using aspnet_boilerplate_mvc.Entities;
using aspnet_boilerplate_mvc.Repositories.Generic;

namespace aspnet_boilerplate_mvc.Repositories.Suburbs
{
    public class SuburbRepository : GenericRepository<Suburb>, ISuburbRepository
    {
        public SuburbRepository(AppDbContext context) : base(context)
        {
        }
    }
}
