﻿using Greenbook.WPF.ContentItems;
using Greenbook.WPF.Sessions;

namespace Greenbook.WPF
{
    public class ViewModelLocator
    {
        public static ApplicationViewModel ApplicationViewModel =>
            SpringContext.GetObject<ApplicationViewModel>(nameof(ApplicationViewModel));

        public static ContentItemListViewModel ContentItemListViewModel =>
            SpringContext.GetObject<ContentItemListViewModel>(nameof(ContentItemListViewModel));

        public static DataViewModel DataViewModel => SpringContext.GetObject<DataViewModel>(nameof(DataViewModel));

        public static ContentItemViewModel ContentItemViewModel =>
            SpringContext.GetObject<ContentItemViewModel>(nameof(ContentItemViewModel));

        public static SessionViewModel SessionViewModel =>
            SpringContext.GetObject<SessionViewModel>(nameof(SessionViewModel));

        public static ListSessionsViewModel ListSessionsViewModel =>
            SpringContext.GetObject<ListSessionsViewModel>(nameof(ListSessionsViewModel));
    }
}