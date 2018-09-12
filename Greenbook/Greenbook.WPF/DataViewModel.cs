using System;
using Greenbook.Entities;
using Greenbook.Services;
using Greenbook.WPF.View.ViewModel;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Windows.Input;

namespace Greenbook.WPF
{
    public class DataViewModel : BaseViewModel
    {
        private readonly IPayloadService _playloadService;

        public DataViewModel(IPayloadService playloadService)
        {
            _playloadService = playloadService;
        }

        private void OnAddContentItem(ContentItem obj)
        {
            if (!ContentItems.Contains(obj))
            {
                ContentItems.Add(obj);
            }
        }

        public ObservableCollection<ContentItem> ContentItems { get; } = new ObservableCollection<ContentItem>();

        public void Load()
        {
            var result = _playloadService.Load();

            if (result.IsFailure) return;

            ContentItems.Clear();

            foreach (var contentItem in result.Value.ContentItems) ContentItems.Add(contentItem);

            ContentItemTypes.Clear();

            foreach (var contentItemType in result.Value.ContentItemTypes) ContentItemTypes.Add(contentItemType);

            Sessions.Clear();

            foreach (var session in result.Value.Sessions) Sessions.Add(session);
        }

        public ICommand AddSessionCommand => new RelayCommand<Session>(OnAddSession);

        private void OnAddSession(Session obj)
        {
            if (!Sessions.Contains(obj))
            {
                Sessions.Add(obj);
            }
        }

        public ObservableCollection<Session> Sessions { get; private set; } = new ObservableCollection<Session>();

        public ICommand AddContentItemCommand => new RelayCommand<ContentItem>(OnAddContentItem);

        public ObservableCollection<string> ContentItemTypes { get; private set; } = new ObservableCollection<string>();

        public ICommand ScanCommand => new RelayCommand<Encounter>(OnScan);

        private static void OnScan(Encounter obj)
        {
            
        }
    }
}