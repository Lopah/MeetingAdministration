using System.ComponentModel;
using System.Windows.Controls;

namespace MeetingAdministrator.App.ViewModels
{
    public class ViewModelBase : INotifyPropertyChanged
    {
        public string DisplayName { get; set; }

        public Control View { get; set; }

        public event PropertyChangedEventHandler PropertyChanged;

        protected void NotifyPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}