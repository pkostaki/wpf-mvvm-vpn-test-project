using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace WebSolutionsTestProject.ViewModel.Base
{
    /// <summary>
    /// Base for viewmodels
    /// </summary>
    public class BaseViewModel:INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        public void SetProperty<T>(ref T property, T value, [CallerMemberName] string name = null)
        {
            property = value;
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
        }

        public virtual void CleanUp() { }
    }
}
