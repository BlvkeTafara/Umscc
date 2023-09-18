﻿using aspnet_boilerplate_mvc.DataAccess;
using aspnet_boilerplate_mvc.Entities;
using aspnet_boilerplate_mvc.Repositories.Generic;

namespace aspnet_boilerplate_mvc.Repositories.PropertyOwners
{
    public class PropertyOwnerRepository : GenericRepository<PropertyOwner>, IPropertyOwnerRepository
    {
        public PropertyOwnerRepository(AppDbContext context) : base(context)
        {
        }
    }
}

