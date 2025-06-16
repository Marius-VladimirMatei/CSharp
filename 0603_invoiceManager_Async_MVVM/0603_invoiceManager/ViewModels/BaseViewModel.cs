using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace _0603_invoiceManager_Async_MVVM.ViewModels
{

    // MVVM: Base ViewModel implementing INotifyPropertyChanged for property change notifications.
    // Ensures separation of logic and UI - MVVM model, data binding support).

    // BaseViewModel extends INotifyPropertyChanged to notify the UI of property changes events.
    public abstract class BaseViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;


        // Raises the PropertyChanged event for data binding.

        protected void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }


        // Sets the field and notifies if the value changes.
        // Uses CallerMemberName to automatically get the property name.
        //A generic “set-and-notify” helper used inside every property setter in the ViewModels.
        protected bool SetProperty<T>(ref T field, T value, [CallerMemberName] string propertyName = null)
        {
            if (Equals(field, value)) return false;
            field = value;
            OnPropertyChanged(propertyName);
            return true;
        }
    }
}