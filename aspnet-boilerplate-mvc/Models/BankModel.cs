﻿using aspnet_boilerplate_mvc.Entities;
using aspnet_boilerplate_mvc.Interfaces;
using System.ComponentModel.DataAnnotations;

namespace aspnet_boilerplate_mvc.Models
{
    public class BankModel
   
    {
            [Key]
            public int Id { get; set; }
            public string? Name { get; set; }
            public string? Status { get; set; }
            public List<BankAccount> BankAccounts { get; set; }
        
    }

}
