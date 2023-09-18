using aspnet_boilerplate_mvc.DataAccess;
using aspnet_boilerplate_mvc.Entities;
using aspnet_boilerplate_mvc.Repositories.Generic;

namespace aspnet_boilerplate_mvc.Repositories.AbstractionSettings
{
    public class AbstractionSettingRepository : GenericRepository<AbstractionSetting>, IAbstractionSettingRepository
    {
        public AbstractionSettingRepository(AppDbContext context) : base(context)
        {
        }
    }
}
