﻿using System;
namespace Wei.Abp.Notifications
{
    /// <summary>
    /// Pre-defined setting names for notification system.
    /// </summary>
    public static class NotificationSettingNames
    {
        public const string Group = "Notifications";
        /// <summary>
        /// A top-level switch to enable/disable receiving notifications for a user.
        /// "Abp.Notifications.ReceiveNotifications".
        /// </summary>
        public const string ReceiveNotifications = Group+".ReceiveNotifications";
    }
}
