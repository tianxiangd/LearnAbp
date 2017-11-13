﻿using Abp.MultiTenancy;
using LearningMpaAbp.Authorization.Users;

namespace LearningMpaAbp.MultiTenancy
{
    public class Tenant : AbpTenant<User>
    {
        public Tenant()
        {
            
        }

        public Tenant(string tenancyName, string name)
            : base(tenancyName, name)
        {
        }
    }
}