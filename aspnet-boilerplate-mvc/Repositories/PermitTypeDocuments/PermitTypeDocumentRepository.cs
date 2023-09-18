using aspnet_boilerplate_mvc.DataAccess;
using aspnet_boilerplate_mvc.Entities;
using aspnet_boilerplate_mvc.Repositories.Generic;

namespace aspnet_boilerplate_mvc.Repositories.PermitTypeDocuments
{
    public class PermitTypeDocumentRepository : GenericRepository<PermitTypeDocument>, IPermitTypeDocumentRepository
    {
        public PermitTypeDocumentRepository(AppDbContext context) : base(context)
        {
        }
    }
}
