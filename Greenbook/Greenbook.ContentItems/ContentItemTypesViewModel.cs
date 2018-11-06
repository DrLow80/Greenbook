﻿using System.Collections.Generic;
using Greenbook.Domain;

namespace Greenbook.ContentItems
{
    public class ContentItemTypesViewModel : BaseListViewModel<string>
    {
        protected override IEnumerable<string> GetItems()
        {
            return new[] {"TEST", "TEST2", "TEST2"};
        }
    }
}