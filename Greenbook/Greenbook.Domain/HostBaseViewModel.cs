using System.Windows.Input;

namespace Greenbook.Domain
{
    public abstract class HostBaseViewModel : BaseViewModel
    {
        public BaseViewModel CurrentViewModel { get; set; }

        public ICommand NavigateCommand => new RelayCommand<BaseViewModel>(OnNavigate);

        private void OnNavigate(BaseViewModel obj)
        {
            CurrentViewModel = obj;
        }
    }
}