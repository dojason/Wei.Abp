﻿using System;
using Volo.Abp.EntityFrameworkCore;
using Volo.Abp.Modularity;

namespace Wei.Abp.Notifications
{
    [DependsOn(
        typeof(AbpEntityFrameworkCoreModule)
        )]
    public class NotificationsDomainModule : AbpModule
    {
        public override void ConfigureServices(ServiceConfigurationContext context)
        {

        }
    }
}
