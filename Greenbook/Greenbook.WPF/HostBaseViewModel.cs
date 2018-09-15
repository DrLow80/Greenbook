using Greenbook.WPF.View.ViewModel;
using System.Windows.Input;

namespace Greenbook.WPF
{
    public abstract class HostBaseViewModel : BaseViewModel
    {
        protected HostBaseViewModel()
        {
            NavigateCommand = new RelayCommand<BaseViewModel>(OnNavigate);
        }

        public BaseViewModel CurrentViewModel { get; set; }

        public ICommand NavigateCommand { get; }

        private void OnNavigate(BaseViewModel obj)
        {
            CurrentViewModel = obj;
        }
    }
}