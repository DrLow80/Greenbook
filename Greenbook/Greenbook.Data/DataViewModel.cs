using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using CSharpFunctionalExtensions;
using Greenbook.Domain;

namespace Greenbook.Data
{
    public class DataViewModel : BaseViewModel
    {
        public ICommand SaveCommand => new RelayCommand(OnSave);

        private void OnSave(object obj)
        {
            Result result = _dataRepository.Save();
        }

        public ICommand LoadCommand =>new RelayCommand(OnLoad);

        private void OnLoad(object obj)
        {
            Result result = _dataRepository.Load();
        }

        private IDataRepository _dataRepository;

        public DataViewModel(IDataRepository dataRepository)
        {
            _dataRepository = dataRepository;
        }
    }
}
