using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Windows.Input;
using Greenbook.Extensions;

namespace Greenbook.Domain
{
    public abstract class BaseListViewModel<T> : BaseViewModel
    {
        public ObservableCollection<T> Items { get; } = new ObservableCollection<T>();

        public ICommand AddCommand => new RelayCommand<T>(OnAdd);

        public ICommand RemoveCommand => new RelayCommand<T>(OnRemove);

        public ICommand InsertCommand => new RelayCommand(OnInsert);

        protected virtual void OnAdd(T obj)
        {
            if (!Items.Contains(obj)) Items.Add(obj);
        }

        protected virtual void OnRemove(T obj)
        {
            if (Items.Contains(obj)) Items.Remove(obj);
        }

        public void Load()
        {
            Items.ClearAndLoad(GetItems());
        }

        protected abstract IEnumerable<T> GetItems();

        protected virtual void OnInsert(object obj)
        {
            throw new NotImplementedException();
        }
    }
}