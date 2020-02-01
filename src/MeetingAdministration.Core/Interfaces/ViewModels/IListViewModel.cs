using System.Collections.ObjectModel;
using System.Windows.Input;

namespace MeetingAdministration.Core.Interfaces.ViewModels
{
    public interface IListViewModel<T> where T : class
    {
        public int SelectedItemIndex { get; set; }

        public string Title { get;}

        public ObservableCollection<T> ListItems { get; set; }

        public ICommand NewCommand { get;}

        public ICommand EditCommand { get;}

        public ICommand DeleteCommand { get;}
    }
}
