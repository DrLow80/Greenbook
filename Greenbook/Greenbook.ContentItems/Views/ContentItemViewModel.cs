﻿using System.Collections.ObjectModel;
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

        public ICommand CreateCommand => new RelayCommand(OnCreate);

        public EncountersViewModel EncountersViewModel { get; private set; }

        public ICommand RemoveCommand => new RelayCommand(OnRemove);

        public ObservableCollection<ContentItemType> ContentItemTypes { get; } =
            new ObservableCollection<ContentItemType>();

        private void OnCreate(object obj)
        {
            ContentItem = new ContentItem();

            _contentItemsRepository.Insert(ContentItem);
        }

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

        private void OnRemove(object obj)
        {
            if (ContentItem == null)
            {
                //what do?
            }

            _contentItemsRepository.Remove(ContentItem);

            ContentItem = null;
        }
    }
}