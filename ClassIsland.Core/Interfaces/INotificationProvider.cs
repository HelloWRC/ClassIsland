﻿using ClassIsland.Core.Models.Notification;

namespace ClassIsland.Core.Interfaces;

public interface INotificationProvider
{
    public string Name { get; set; }
    public string Description { get; set; }

    public Guid ProviderGuid { get; set; }

    public object? SettingsElement { get; set; }
    public object? IconElement { get; set; }

}