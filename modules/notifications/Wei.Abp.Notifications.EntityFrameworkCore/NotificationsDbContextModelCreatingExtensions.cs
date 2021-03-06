﻿using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Volo.Abp;
using Volo.Abp.EntityFrameworkCore.Modeling;

namespace Wei.Abp.Notifications.EntityFrameworkCore
{
    public static class NotificationsDbContextModelCreatingExtensions
    {
        public static void ConfigureNotifycations(
            this ModelBuilder builder,
            Action<NotificationsModelBuilderConfigurationOptions> optionsAction = null)
        {
            Check.NotNull(builder, nameof(builder));

            var options = new NotificationsModelBuilderConfigurationOptions(NotificationsDbProperties.DbTablePrefix, NotificationsDbProperties.DbSchema);

            optionsAction?.Invoke(options);

            /* Configure all entities here. Example:
             * 

            builder.Entity<Question>(b =>
            {
                //Configure table & schema name
                b.ToTable(options.TablePrefix + "Questions", options.Schema);

                b.ConfigureFullAuditedAggregateRoot();

                //Properties
                b.Property(q => q.Title).IsRequired().HasMaxLength(QuestionConsts.MaxTitleLength);

                //Relations
                b.HasMany(question => question.Tags).WithOne().HasForeignKey(qt => qt.QuestionId);

                //Indexes
                b.HasIndex(q => q.CreationTime);
            });
            */

            builder.Entity<Notification>(b =>
            {
                b.ToTable(options.TablePrefix + "Notifications", options.Schema);
                b.ConfigureFullAuditedAggregateRoot();

                b.Property(c => c.UserIds).HasConversion(d => string.Join(';', d), s => s.Split(";", StringSplitOptions.RemoveEmptyEntries).Select(c => Guid.Parse(c)).ToList()).HasColumnName("UserIds");
                b.Property(c => c.ExcludedUserIds).HasConversion(d => string.Join(';', d), s => s.Split(";", StringSplitOptions.RemoveEmptyEntries).Select(c => Guid.Parse(c)).ToList()).HasColumnName("ExcludedUserIds");

            });

            builder.Entity<NotificationSubscription>(b =>
            {
                b.ToTable(options.TablePrefix + "NotificationSubscriptions", options.Schema);
                b.ConfigureFullAuditedAggregateRoot();
            });

            //builder.Entity<TenantNotificationInfo>(b =>
            //{
            //    b.ToTable(options.TablePrefix + "TenantNotificationInfos", options.Schema);
            //    b.ConfigureFullAuditedAggregateRoot();
            //});

            builder.Entity<UserNotification>(b =>
            {
                b.ToTable(options.TablePrefix + "UserNotifications", options.Schema);
                b.ConfigureFullAuditedAggregateRoot();
            });
        }
    }
}
