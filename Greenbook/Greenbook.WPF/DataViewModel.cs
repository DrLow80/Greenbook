using System.Collections.ObjectModel;
using Greenbook.Entities;
using Greenbook.Services;

namespace Greenbook.WPF
{
    public class DataViewModel : BaseViewModel
    {
        private readonly IPayloadService _playloadService;

        public DataViewModel(IPayloadService playloadService)
        {
            _playloadService = playloadService;
        }

        public ObservableCollection<ContentItem> ContentItems { get; } = new ObservableCollection<ContentItem>();

        public void Load()
        {
            var result = _playloadService.Load();

            if (result.IsFailure) return;

            ContentItems.Clear();

            foreach (var contentItem in result.Value.ContentItems) ContentItems.Add(contentItem);
        }
    }
}