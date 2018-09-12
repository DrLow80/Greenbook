using Greenbook.Entities;
using Greenbook.Services;
using Greenbook.WPF.View.ViewModel;
using System.Collections.ObjectModel;
using System.Linq;
using System.Windows.Input;

namespace Greenbook.WPF.ContentItems
{
    public class ContentItemViewModel : BaseViewModel
    {
        private readonly IDialogService _dialogService;

        public ContentItemViewModel(IDialogService dialogService)
        {
            _dialogService = dialogService;
        }

        private void OnCreate(object obj)
        {
            ContentItem = new ContentItem();
        }

        public ICommand AddCommand => new RelayCommand(OnAdd);

        public ContentItem ContentItem { get; set; }

        public ObservableCollection<Encounter> Encounters { get; } = new ObservableCollection<Encounter>();

        public ICommand SelectImageCommand => new RelayCommand(OnSelectImage);

        public ICommand CreateCommand => new RelayCommand(OnCreate);

        public ICommand RemoveCommand => new RelayCommand<Encounter>(OnRemove);

        private void OnRemove(Encounter obj)
        {
            if (Encounters.Contains(obj))
            {
                Encounters.Remove(obj);
            }

            ContentItem.Encounters.Remove(obj);
        }

        public void Load()
        {
            Encounters.Clear();

            foreach (var encounter in ContentItem.Encounters) Encounters.Add(encounter);
        }

        private void OnAdd(object obj)
        {
            var encounter = new Encounter();

            ContentItem.Encounters.Add(encounter);

            Encounters.Add(encounter);
        }

        private void OnSelectImage(object obj)
        {
            var result = _dialogService.Open();

            if (result.IsSuccess) ContentItem.ImageSource = result.Value;
        }

      
    }
}