using System.Windows.Input;

namespace Greenbook.Domain
{
    public abstract class BaseHostViewModel : BaseViewModel
    {
        public BaseViewModel CurrentViewModel { get; private set; }

        public ICommand NavigateCommand => new RelayCommand<BaseViewModel>(OnNavigate);

        private void OnNavigate(BaseViewModel obj)
        {
            CurrentViewModel = obj;
        }
    }
}