using System.Collections.ObjectModel;
using System.Windows.Input;
using Greenbook.Entities;
using Greenbook.Services;
using Greenbook.WPF.View.ViewModel;

namespace Greenbook.WPF.ContentItems
{
    public class ContentItemViewModel : BaseViewModel
    {
        private readonly IDialogService _dialogService;

        public ContentItemViewModel(IDialogService dialogService)
        {
            _dialogService = dialogService;
            AddCommand = new RelayCommand(OnAdd);
            SelectImageCommand = new RelayCommand(OnSelectImage);
        }

        public ICommand AddCommand { get; }

        public ContentItem ContentItem { get; set; }

        public ObservableCollection<Encounter> Encounters { get; } = new ObservableCollection<Encounter>();

        public ICommand SelectImageCommand { get; }

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