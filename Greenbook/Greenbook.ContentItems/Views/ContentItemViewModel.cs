using System.Collections.ObjectModel;
using System.Linq;
using System.Windows.Input;
using Greenbook.Domain;
using Greenbook.Entities;
using Greenbook.Extensions;

namespace Greenbook.ContentItems.Views
{
    public class ContentItemViewModel : BaseViewModel
    {
        private readonly IContentItemsRepository _contentItemsRepository;

        public ContentItemViewModel(IContentItemsRepository contentItemsRepository)
        {
            _contentItemsRepository = contentItemsRepository;
        }

        public ContentItem ContentItem { get; set; }

        public ICommand SelectImageCommand => new RelayCommand(OnSelectImage);

        public ICommand CreateCommand { get; set; }

        public EncountersViewModel EncountersViewModel { get; set; }

        public ICommand RemoveCommand { get; set; }

        public ObservableCollection<ContentItemType> ContentItemTypes { get; } =
            new ObservableCollection<ContentItemType>();

        public void Load()
        {
            EncountersViewModel = new EncountersViewModel(ContentItem);

            //HACK: Find a better way to do this
            if (!ContentItemTypes.Any()) ContentItemTypes.ClearAndLoad(_contentItemsRepository.LoadContentItemTypes());
        }

        private void OnSelectImage(object obj)
        {
            var path = _contentItemsRepository.SelectImage();

            if (path.IsSuccess) ContentItem.ImageSource = path.Value;
        }
    }
}