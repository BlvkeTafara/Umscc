﻿using aspnet_boilerplate_mvc.Interfaces;
using System.ComponentModel.DataAnnotations;

namespace aspnet_boilerplate_mvc.Entities
{
    public class WetlandreportImage : Auditable, IAuditable
    {
        [Key]
        public int Id { get; set; }

        public int WetlandreportId { get; set; }

        public string? filename { get; set; }
    }
}
