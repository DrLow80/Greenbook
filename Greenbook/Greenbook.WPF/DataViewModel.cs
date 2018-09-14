using System;
using Greenbook.Entities;
using Greenbook.Services;
using Greenbook.WPF.View.ViewModel;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Linq;
using System.Windows.Input;
using Greenbook.WPF.Extensions;

namespace Greenbook.WPF
{
    public class DataViewModel : BaseViewModel
    {
        private readonly IPayloadService _payloadService;

        public DataViewModel(IPayloadService payloadService)
        {
            _payloadService = payloadService;
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
            var result = _payloadService.Load();

            if (result.IsFailure) return;

            ContentItems.ClearAndLoad(result.Value.ContentItems);

            ContentItemTypes.ClearAndLoad(result.Value.ContentItemTypes);

            Sessions.ClearAndLoad(result.Value.Sessions);
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

        private void OnScan(Encounter obj)
        {
            var nameParser = new ContentNameParser(obj.Description);

            foreach (var name in nameParser)
            {
                var contentItem = ContentItems.FirstOrDefault(x => x.Name.Equals(name.LowerName, StringComparison.OrdinalIgnoreCase));

                if (contentItem != null) continue;

                contentItem = new ContentItem()
                {
                    Name = name.Name
                };

                ContentItems.Add(contentItem);
            }
        }
    }
}