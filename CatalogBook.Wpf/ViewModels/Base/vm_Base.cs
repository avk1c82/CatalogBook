using System.Collections.Specialized;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace CatalogBook.Wpf.ViewModels.Base
{
    public abstract class vm_Base : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler? PropertyChanged;


        protected virtual void OnPropertyChanged([CallerMemberName] string? PropertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(PropertyName));
        }

        protected virtual bool Set<T>(ref T field, T value, [CallerMemberName] string? PropetyName = null)
        {
            if(Equals(field, value))
            {
                return false;
            }

            field = value;

            OnPropertyChanged(PropetyName);

            return true;
        }
    }
}
