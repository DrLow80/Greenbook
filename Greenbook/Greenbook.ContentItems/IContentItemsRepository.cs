﻿using System.Collections.Generic;
using CSharpFunctionalExtensions;
using Greenbook.Entities;

namespace Greenbook.ContentItems
{
    public interface IContentItemsRepository
    {
        IEnumerable<ContentItem> LoadContentItems();
        Result<string> SelectImage();
    }
}