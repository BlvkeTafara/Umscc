using aspnet_boilerplate_mvc.DataAccess;
using aspnet_boilerplate_mvc.Entities;
using aspnet_boilerplate_mvc.Repositories.Generic;

namespace aspnet_boilerplate_mvc.Repositories.Riverbankreports
{
    public class RiverbankreportRepository : GenericRepository<Riverbankreport>, IRiverbankreportRepository
    {
        public RiverbankreportRepository(AppDbContext context) : base(context)
        {
        }
    }
}
