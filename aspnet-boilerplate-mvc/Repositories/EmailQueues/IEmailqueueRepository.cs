using aspnet_boilerplate_mvc.Entities;
using aspnet_boilerplate_mvc.Repositories.Generic;

namespace aspnet_boilerplate_mvc.Repositories.EmailQueues
{
    public interface IEmailqueueRepository : IGenericRepository<Emailqueue>
    {
        Task<List<Emailqueue>> GetPending();
    }
}
