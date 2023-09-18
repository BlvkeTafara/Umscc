using aspnet_boilerplate_mvc.DataAccess;
using aspnet_boilerplate_mvc.Entities;
using aspnet_boilerplate_mvc.Repositories.Generic;
using Microsoft.EntityFrameworkCore;

namespace aspnet_boilerplate_mvc.Repositories.EmailQueues
{
    public class EmailqueueRepository : GenericRepository<Emailqueue>, IEmailqueueRepository
    {
        public EmailqueueRepository(AppDbContext context) : base(context)
        {
        }

        public async Task<List<Emailqueue>> GetPending()
        {
            return await _context.emailqueues.Where(q => q.Status == "PENDING").Take(10).ToListAsync();
        }
    }
}
