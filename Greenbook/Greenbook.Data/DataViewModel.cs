using System.Windows.Input;
using Greenbook.Domain;

namespace Greenbook.Data
{
    public class DataViewModel : BaseViewModel
    {
        private readonly IDataRepository _dataRepository;

        public DataViewModel(IDataRepository dataRepository)
        {
            _dataRepository = dataRepository;
        }

        public ICommand SaveCommand => new RelayCommand(OnSave);

        public ICommand LoadCommand => new RelayCommand(OnLoad);

        private void OnSave(object obj)
        {
            var result = _dataRepository.Save();
        }

        private void OnLoad(object obj)
        {
            var result = _dataRepository.Load();
        }
    }
}