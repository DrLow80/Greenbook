﻿using System.Collections.ObjectModel;
using System.Linq;
using System.Windows.Input;
using Greenbook.AhoCorasickTrie;
using Greenbook.Domain;
using Greenbook.Entities;
using Greenbook.Extensions;

namespace Greenbook.Sessions.Views
{
    public class ContentItemsViewModel : BaseViewModel
    {
        private readonly ISessionRepository _sessionRepository;

        public ContentItemsViewModel(ISessionRepository sessionRepository)
        {
            _sessionRepository = sessionRepository;
        }

        public ObservableCollection<ContentItem> ContentItems { get; } = new ObservableCollection<ContentItem>();

        public ObservableCollection<ContentItemsByTypeGroup> ContentItemsByTypeGroups { get; } =
            new ObservableCollection<ContentItemsByTypeGroup>();

        public ObservableCollection<ContentItem> ScannedContentItems { get; } = new ObservableCollection<ContentItem>();

        public ICommand ChangeViewCommand => new RelayCommand<ViewType>(OnChangeView);

        public ViewType ViewType { get; private set; } = ViewType.Referenced;

        public ICommand ScanCommand => new RelayCommand<Session>(OnScan);

        public void Load()
        {
            ContentItems.ClearAndLoad(_sessionRepository.LoadContentItems().OrderBy(x => x.Name));

            ContentItemsByTypeGroups.Clear();

            foreach (var type in ContentItems.GroupBy(x => x.ContentType.Content).OrderBy(x => x.Key))
            {
                var contentItemsByTypeGroup = new ContentItemsByTypeGroup(type.Key, type.OrderBy(x => x.Name));

                ContentItemsByTypeGroups.Add(contentItemsByTypeGroup);
            }
        }

        private void OnChangeView(ViewType obj)
        {
            ViewType = obj;
        }

        private void OnScan(Session obj)
        {
            if (!obj.Encounters.Any())
            {
                ScannedContentItems.Clear();

                return;
            }

            var trie = new Trie(ContentItems.Select(x => x.Name).ToArray());

            var sessionTrieIterator = new SessionTrieIterator(obj, ContentItems);

            trie.Iterate(sessionTrieIterator);

            ScannedContentItems.ClearAndLoad(sessionTrieIterator);
        }
    }
}