using aspnet_boilerplate_mvc.DataAccess;
using aspnet_boilerplate_mvc.Entities;
using aspnet_boilerplate_mvc.Repositories.Generic;

namespace aspnet_boilerplate_mvc.Repositories.PermitCategories
{
    public class PermitCategoryRepository : GenericRepository<PermitCategory>, IPermitCategoryRepository
    {
        public PermitCategoryRepository(AppDbContext context) : base(context)
        {
        }
    }
}
