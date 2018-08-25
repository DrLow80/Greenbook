using PropertyChanged;

namespace Greenbook.WPF
{
    [AddINotifyPropertyChangedInterface]
    public abstract class BaseViewModel
    {
        public virtual void Unload()
        {
        }

        public virtual void Load()
        {
        }
    }
}