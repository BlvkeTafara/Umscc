using aspnet_boilerplate_mvc.DataAccess;
using aspnet_boilerplate_mvc.Entities;
using aspnet_boilerplate_mvc.Repositories.Generic;

namespace aspnet_boilerplate_mvc.Repositories.PermitTypeDocumentExemptions
{
    public class PermitTypeDocumentExemptionRepository : GenericRepository<PermitTypeDocumentExemption>, IPermitTypeDocumentExemptionRepository
    {
        public PermitTypeDocumentExemptionRepository(AppDbContext context) : base(context)
        {
        }
    }
}
