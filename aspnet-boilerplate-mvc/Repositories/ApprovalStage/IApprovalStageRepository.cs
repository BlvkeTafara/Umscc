using aspnet_boilerplate_mvc.Entities;
using aspnet_boilerplate_mvc.Repositories.Generic;

namespace aspnet_boilerplate_mvc.Repositories.ApprovalStages
{
    public interface IApprovalStageRepository: IGenericRepository<ApprovalStage>
    {
        void Create(ApprovalStage approvalStage);
    }
}
