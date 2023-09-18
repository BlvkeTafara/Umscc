using aspnet_boilerplate_mvc.DataAccess;
using aspnet_boilerplate_mvc.Entities;
using aspnet_boilerplate_mvc.Repositories.Generic;

namespace aspnet_boilerplate_mvc.Repositories.OwnershipTypeDocuments
{
    public class OwnershipTypeDocumentRepository : GenericRepository<OwnershipTypeDocument>, IOwnershipTypeDocumentRepository
    {
        public OwnershipTypeDocumentRepository(AppDbContext context) : base(context)
        {
        }
    }
}
