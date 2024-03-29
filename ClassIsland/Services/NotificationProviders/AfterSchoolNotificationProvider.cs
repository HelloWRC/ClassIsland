﻿using System;
using System.Threading;
using System.Threading.Tasks;
using ClassIsland.Controls.AttachedSettingsControls;
using ClassIsland.Controls.NotificationProviders;
using ClassIsland.Enums;
using ClassIsland.Interfaces;
using ClassIsland.Models;
using ClassIsland.Models.AttachedSettings;
using MaterialDesignThemes.Wpf;
using Microsoft.Extensions.Hosting;

namespace ClassIsland.Services.NotificationProviders;

public class AfterSchoolNotificationProvider : INotificationProvider, IHostedService
{
    public NotificationHostService NotificationHostService { get; }
    public string Name { get; set; } = "放学提醒";
    public string Description { get; set; } = "在当天的课程结束后发出提醒。";
    public Guid ProviderGuid { get; set; } = new Guid("8FBC3A26-6D20-44DD-B895-B9411E3DDC51");
    public object? SettingsElement { get; set; }
    public object? IconElement { get; set; } = new PackIcon()
    {
        Kind = PackIconKind.HumanRunFast,
        Width = 24,
        Height = 24
    };
    public async Task StartAsync(CancellationToken cancellationToken)
    {
    }

    public async Task StopAsync(CancellationToken cancellationToken)
    {
    }

    private AfterSchoolNotificationProviderSettings Settings
    {
        get;
    }

    public AfterSchoolNotificationProvider(NotificationHostService notificationHostService, AttachedSettingsHostService attachedSettingsHostService)
    {
        NotificationHostService = notificationHostService;
        NotificationHostService.RegisterNotificationProvider(this);
        Settings =
            NotificationHostService.GetNotificationProviderSettings<AfterSchoolNotificationProviderSettings>(ProviderGuid) ??
            new AfterSchoolNotificationProviderSettings();
        NotificationHostService.WriteNotificationProviderSettings(ProviderGuid, Settings);
        NotificationHostService.CurrentStateChanged += NotificationHostServiceOnCurrentStateChanged;
        SettingsElement = new AfterSchoolNotificationProviderSettingsControl(Settings);

        var item = typeof(AfterSchoolNotificationAttachedSettingsControl);
        attachedSettingsHostService.ClassPlanSettingsAttachedSettingsControls.Add(item);
        attachedSettingsHostService.TimeLayoutSettingsAttachedSettingsControls.Add(item);
    }

    private void NotificationHostServiceOnCurrentStateChanged(object? sender, EventArgs e)
    {
        var settings = GetAttachedSettings();
        var isEnabled = settings?.IsAttachSettingsEnabled == true ?
            settings.IsEnabled
            : Settings.IsEnabled;
        var msg = settings?.IsAttachSettingsEnabled == true ?
            settings.NotificationMsg
            : Settings.NotificationMsg;
        if (!isEnabled || NotificationHostService.CurrentState != TimeState.None || !NotificationHostService.IsClassPlanLoaded)
        {
            return;
        }

        NotificationHostService.RequestQueue.Enqueue(new NotificationRequest()
        {
            MaskContent = new AfterSchoolNotificationProviderControl(msg, "AfterSchoolMask"),
            OverlayContent = new AfterSchoolNotificationProviderControl(msg, "AfterSchoolOverlay"),
            OverlayDuration = TimeSpan.FromSeconds(30)
        });
    }

    private AfterSchoolNotificationAttachedSettings? GetAttachedSettings()
    {
        var mvm = App.GetService<MainWindow>().ViewModel;
        var settings = AttachedSettingsHostService
            .GetAttachedSettingsByPriority<
                AfterSchoolNotificationAttachedSettings>(
                ProviderGuid,
                classPlan: mvm.CurrentClassPlan,
                timeLayout: mvm.CurrentClassPlan?.TimeLayout
            );
        return settings;
    }
}