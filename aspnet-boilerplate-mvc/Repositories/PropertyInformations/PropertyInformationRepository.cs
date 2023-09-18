using aspnet_boilerplate_mvc.DataAccess;
using aspnet_boilerplate_mvc.Entities;
using aspnet_boilerplate_mvc.Repositories.Generic;

namespace aspnet_boilerplate_mvc.Repositories.PropertyInformations
{
    public class PropertyInformationRepository : GenericRepository<PropertyInformation>, IPropertyInformationRepository
    {
        public PropertyInformationRepository(AppDbContext context) : base(context)
        {
        }
    }
}
