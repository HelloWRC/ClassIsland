﻿using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Windows.Documents;

namespace ClassIsland.Models;

public class TimeLayoutUpdateEventArgs
{
    public NotifyCollectionChangedAction Action { get; set; }

    public List<TimeLayoutItem> AddedItems { get; set; } = new();

    public List<TimeLayoutItem> RemovedItems { get; set; } = new();

    public int AddIndex { get; set; } = -1;

    public int RemoveIndex { get; set; } = -1;

    public int AddIndexClasses { get; set; } = -1;

    public int RemoveIndexClasses { get; set; } = -1;
}