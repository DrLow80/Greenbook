using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Windows.Input;

namespace Greenbook.Domain
{
    public abstract class BaseListViewModel<T> : BaseViewModel
    {
        public ObservableCollection<T> Items { get; } = new ObservableCollection<T>();

        public ICommand AddCommand => new RelayCommand<T>(OnAdd);

        protected virtual void OnAdd(T obj)
        {
            if (!Items.Contains(obj)) Items.Add(obj);
        }

        public ICommand RemoveCommand=>new RelayCommand<T>(OnRemove);

        protected virtual void OnRemove(T obj)
        {
            if (Items.Contains(obj)) Items.Remove(obj);
        }

        public void Load()
        {
            IEnumerable<T> items = GetItems();

            Items.Clear();

            foreach (var item in items)
            {
                OnAdd(item);
            }
        }

        protected abstract IEnumerable<T> GetItems();

        public ICommand InsertCommand=>new RelayCommand(OnInsert);

        protected virtual void OnInsert(object obj)
        {
            throw new NotImplementedException();
        }
    }
}