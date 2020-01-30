using MeetingAdministration.Data.Entities;
using System.Collections.ObjectModel;
using System.Windows;
using System.Windows.Input;

namespace MeetingAdministrator.App.ViewModels.TabControls.Lists
{
    public class MeetingRoomsListViewModel : ViewModelBase
    {
        private int? _selectedRoomIndex = null;

        public string Title { get; set; }

        public int? SelectedRoomIndex
        {
            get { return _selectedRoomIndex; }
            set
            {
                if (value != _selectedRoomIndex)
                {
                    _selectedRoomIndex = value;
                    NotifyPropertyChanged(_selectedRoomIndex.GetType().Name);
                }
            }
        }

        public ObservableCollection<MeetingRoom> MeetingRooms { get; set; }

        private void NewCommand_CanExecute(object sender, CanExecuteRoutedEventArgs e)
        {
            if (_selectedRoomIndex != null)
            e.CanExecute = true;
        }

        private void NewCommand_Execute(object sender, ExecutedRoutedEventArgs e)
        {
            MessageBox.Show("Command executed. test msg.");
        }
    }
}
