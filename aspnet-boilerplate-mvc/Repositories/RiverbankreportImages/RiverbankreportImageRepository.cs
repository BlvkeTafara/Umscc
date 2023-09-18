using aspnet_boilerplate_mvc.DataAccess;
using aspnet_boilerplate_mvc.Entities;
using aspnet_boilerplate_mvc.Repositories.Generic;

namespace aspnet_boilerplate_mvc.Repositories.RiverbankreportImages
{
    public class RiverbankreportImageRepository : GenericRepository<RiverbankreportImage>, IRiverbankreportImageRepository
    {
        public RiverbankreportImageRepository(AppDbContext context) : base(context)
        {
        }
    }
}
