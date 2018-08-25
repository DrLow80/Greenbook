using System.Windows.Input;
using Greenbook.WPF.View.ViewModel;

namespace Greenbook.WPF
{
    public abstract class HostBaseViewModel : BaseViewModel
    {
        private BaseViewModel _baseViewModel;

        protected HostBaseViewModel()
        {
            NavigateCommand = new RelayCommand<BaseViewModel>(OnNavigate);
        }

        public BaseViewModel CurrentViewModel
        {
            get => _baseViewModel;
            set
            {
                _baseViewModel?.Unload();
                _baseViewModel = value;
                _baseViewModel?.Load();
            }
        }

        public ICommand NavigateCommand { get; }

        private void OnNavigate(BaseViewModel obj)
        {
            CurrentViewModel = obj;
        }
    }
}