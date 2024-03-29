﻿using System;
using CommunityToolkit.Mvvm.ComponentModel;

namespace ClassIsland.Models;

public class ClassNotificationSettings : ObservableRecipient
{
    private bool _isClassOnNotificationEnabled = true;
    private bool _isClassOnPreparingNotificationEnabled = true;
    private bool _isClassOffNotificationEnabled = true;
    private int _inDoorClassPreparingDeltaTime = 60;
    private int _outDoorClassPreparingDeltaTime = 120;
    private string _classOnPreparingText = "准备上课，请回到座位并保持安静，做好上课准备。";

    public bool IsClassOnNotificationEnabled
    {
        get => _isClassOnNotificationEnabled;
        set
        {
            if (value == _isClassOnNotificationEnabled) return;
            _isClassOnNotificationEnabled = value;
            OnPropertyChanged();
        }
    }

    public bool IsClassOnPreparingNotificationEnabled
    {
        get => _isClassOnPreparingNotificationEnabled;
        set
        {
            if (value == _isClassOnPreparingNotificationEnabled) return;
            _isClassOnPreparingNotificationEnabled = value;
            OnPropertyChanged();
        }
    }

    public bool IsClassOffNotificationEnabled
    {
        get => _isClassOffNotificationEnabled;
        set
        {
            if (value == _isClassOffNotificationEnabled) return;
            _isClassOffNotificationEnabled = value;
            OnPropertyChanged();
        }
    }

    public int InDoorClassPreparingDeltaTime
    {
        get => _inDoorClassPreparingDeltaTime;
        set
        {
            if (value.Equals(_inDoorClassPreparingDeltaTime)) return;
            _inDoorClassPreparingDeltaTime = value;
            OnPropertyChanged();
        }
    }

    public int OutDoorClassPreparingDeltaTime
    {
        get => _outDoorClassPreparingDeltaTime;
        set
        {
            if (value.Equals(_outDoorClassPreparingDeltaTime)) return;
            _outDoorClassPreparingDeltaTime = value;
            OnPropertyChanged();
        }
    }

    public string ClassOnPreparingText
    {
        get => _classOnPreparingText;
        set
        {
            if (value == _classOnPreparingText) return;
            _classOnPreparingText = value;
            OnPropertyChanged();
        }
    }
}