using System;
using System.Windows.Input;
using Greenbook.Entities;
using Greenbook.Extensions;

namespace Greenbook.ContentItems.Views
{
    public class ContentItemViewModelCreateCommand : ICommand
    {
        private readonly ContentItemViewModel _contentItemViewModel;

        private readonly IContentItemsRepository _contentItemsRepository;


        public ContentItemViewModelCreateCommand(ContentItemViewModel contentItemViewModel, IContentItemsRepository contentItemsRepository)
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
            _contentItemViewModel.ContentItem = new ContentItem();

            _contentItemViewModel.EncountersViewModel = new EncountersViewModel(_contentItemViewModel.ContentItem);

            _contentItemViewModel.ContentItemTypes.ClearAndLoad(_contentItemsRepository.LoadContentItemTypes());

            _contentItemsRepository.Insert(_contentItemViewModel.ContentItem);
        }

        public event EventHandler CanExecuteChanged
        {
            add => CommandManager.RequerySuggested += value;
            remove => CommandManager.RequerySuggested -= value;
        }
    }
}