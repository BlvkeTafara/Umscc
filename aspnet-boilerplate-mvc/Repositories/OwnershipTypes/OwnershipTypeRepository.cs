using aspnet_boilerplate_mvc.DataAccess;
using aspnet_boilerplate_mvc.Entities;
using aspnet_boilerplate_mvc.Repositories.Generic;

namespace aspnet_boilerplate_mvc.Repositories.OwnershipTypes
{
    public class OwnershipTypeRepository : GenericRepository<OwnershipType>, IOwnershipTypeRepository
    {
        public OwnershipTypeRepository(AppDbContext context) : base(context)
        {
        }
    }
}
