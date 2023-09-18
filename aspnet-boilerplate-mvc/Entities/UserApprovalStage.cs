﻿using aspnet_boilerplate_mvc.Interfaces;
using System.ComponentModel.DataAnnotations;

namespace aspnet_boilerplate_mvc.Entities
{
    public class UserApprovalStage : Auditable, IAuditable
    {
        [Key]
        public int Id { get; set; }

        public int UserId { get; set; }

        public int ApprovalStageId { get; set; }

        public ApprovalStage approvalStage { get; set; }
    }
}
