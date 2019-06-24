using System;
using System.Windows.Input;

namespace Greenbook.ContentItems.Views
{
    public class ContentItemViewModelRemoveCommand : ICommand
    {
        private readonly ContentItemViewModel _contentItemViewModel;

        private readonly IContentItemsRepository _contentItemsRepository;

        public ContentItemViewModelRemoveCommand(ContentItemViewModel contentItemViewModel, IContentItemsRepository contentItemsRepository)
        {
            _contentItemViewModel = contentItemViewModel;
            _contentItemsRepository = contentItemsRepository;
        }

        public bool CanExecute(object parameter)
        {
            return true;
        }

        public void Execute(object parameter)
        {
            if (_contentItemViewModel.ContentItem != null)
            {
                _contentItemsRepository.Remove(_contentItemViewModel.ContentItem);
            }

            _contentItemViewModel.ContentItem = null;
        }

        public event EventHandler CanExecuteChanged
        {
            add => CommandManager.RequerySuggested += value;
            remove => CommandManager.RequerySuggested -= value;
        }
    }
}