using aspnet_boilerplate_mvc.DataAccess;
using aspnet_boilerplate_mvc.Entities;
using aspnet_boilerplate_mvc.Repositories.ApprovalStages;
using aspnet_boilerplate_mvc.Repositories.Generic;
using Microsoft.EntityFrameworkCore;

namespace aspnet_boilerplate_mvc.Repositories.ApprovalStages
{
    public class ApprovalStageRepository : GenericRepository<ApprovalStage>, IApprovalStageRepository
    {
        private readonly AppDbContext _context;

        public ApprovalStageRepository(AppDbContext context) : base(context)
        {
            _context = context;
        }
        public void Create(ApprovalStage approvalStage)
        {
            _context.Set<ApprovalStage>().Add(approvalStage);
        }
    }
}
