using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Greenbook.Entities;
using Greenbook.WPF.View.ViewModel;

namespace Greenbook.WPF.Sessions
{
    public class SessionViewModel : BaseViewModel
    {
        public Session Session { get; set; }

        public ICommand CreateCommand => new RelayCommand(OnCreate);

        private void OnCreate(object obj)
        {
            Session = new Session();
        }
    }
}
