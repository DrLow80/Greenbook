using CSharpFunctionalExtensions;
using Greenbook.Domain;
using Greenbook.Entities;
using System.Collections.ObjectModel;
using System.Windows.Input;

namespace Greenbook.ContentItems
{
    public class ContentItemViewModel : BaseViewModel
    {
        public ContentItem ContentItem { get; set; }

        public ObservableCollection<Encounter> Encounters { get; } = new ObservableCollection<Encounter>();

        public ICommand SelectImageCommand => new RelayCommand(OnSelectImage);

        public ICommand CreateCommand => new RelayCommand(OnCreate);

        private void OnCreate(object obj)
        {
            ContentItem = new ContentItem();
        }

        public EncountersViewModel EncountersViewModel { get; private set; }

        public void Load()
        {
            EncountersViewModel = new EncountersViewModel(ContentItem);
        }

        private void OnSelectImage(object obj)
        {
            Result<string> path = _contentItemsRepository.SelectImage();

            if (path.IsSuccess)
            {
                ContentItem.ImageSource = path.Value;
            }
        }

        private IContentItemsRepository _contentItemsRepository;

        public ContentItemViewModel(IContentItemsRepository contentItemsRepository)
        {
            _contentItemsRepository = contentItemsRepository;
        }
    }
}