using aspnet_boilerplate_mvc.DataAccess;
using aspnet_boilerplate_mvc.Entities;
using aspnet_boilerplate_mvc.Repositories.Generic;

namespace aspnet_boilerplate_mvc.Repositories.Uoms
{
    public class UomRepository : GenericRepository<Uom>, IUomRepository
    {
        public UomRepository(AppDbContext context) : base(context)
        {
        }
    }
}
