using System.ComponentModel;
using System.Runtime.CompilerServices;
using Greenbook.WPF.Annotations;
using PropertyChanged;

namespace Greenbook.WPF
{
    [AddINotifyPropertyChangedInterface]
    public abstract class BaseViewModel:INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        [NotifyPropertyChangedInvocator]
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}