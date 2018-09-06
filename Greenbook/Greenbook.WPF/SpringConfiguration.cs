﻿using Greenbook.Services;
using Greenbook.WPF.ContentItems;
using Greenbook.WPF.Services;
using Greenbook.WPF.Sessions;
using Spring.Context.Attributes;

namespace Greenbook.WPF
{
    [Configuration]
    public class SpringConfiguration
    {
        [Definition]
        public virtual ApplicationViewModel ApplicationViewModel()
        {
            return new ApplicationViewModel();
        }

        [Definition]
        public virtual ContentItemListViewModel ContentItemListViewModel()
        {
            return new ContentItemListViewModel();
        }

        [Definition]
        public virtual DataViewModel DataViewModel()
        {
            return new DataViewModel(PayloadService());
        }

        [Definition]
        public virtual IPayloadService PayloadService()
        {
            return new PayloadService();
        }

        [Definition]
        public virtual ContentItemViewModel ContentItemViewModel()
        {
            return new ContentItemViewModel(DialogService());
        }

        [Definition]
        public virtual IDialogService DialogService()
        {
            return new DialogService();
        }

        [Definition]
        public virtual SessionViewModel SessionViewModel()
        {
            return new SessionViewModel();
        }

        [Definition]
        public virtual ListSessionsViewModel ListSessionsViewModel()
        {
            return new ListSessionsViewModel();
        }
    }
}