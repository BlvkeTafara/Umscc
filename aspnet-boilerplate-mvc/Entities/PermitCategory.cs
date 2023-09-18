﻿using aspnet_boilerplate_mvc.Interfaces;
using System.ComponentModel.DataAnnotations;

namespace aspnet_boilerplate_mvc.Entities
{
    public class PermitCategory:Auditable, IAuditable
    {
        [Key]
        public int Id { get; set; }

        public string Name { get; set; }

        public string Status { get; set; }
    }
}
