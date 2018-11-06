using System.Collections.ObjectModel;
using System.Windows.Input;
using Greenbook.Domain;
using Greenbook.Entities;

namespace Greenbook.ContentItems
{
    public class ContentItemViewModel : BaseViewModel
    {
        private readonly IContentItemsRepository _contentItemsRepository;

        public ContentItemViewModel(IContentItemsRepository contentItemsRepository)
        {
            _contentItemsRepository = contentItemsRepository;
        }

        public ContentItem ContentItem { get; set; }

        public ObservableCollection<Encounter> Encounters { get; } = new ObservableCollection<Encounter>();

        public ICommand SelectImageCommand => new RelayCommand(OnSelectImage);

        public ICommand CreateCommand => new RelayCommand(OnCreate);

        public EncountersViewModel EncountersViewModel { get; private set; }

        private void OnCreate(object obj)
        {
            ContentItem = new ContentItem();
        }

        public void Load()
        {
            EncountersViewModel = new EncountersViewModel(ContentItem);
        }

        private void OnSelectImage(object obj)
        {
            var path = _contentItemsRepository.SelectImage();

            if (path.IsSuccess) ContentItem.ImageSource = path.Value;
        }
    }
}