using MeetingAdministration.Core.Models;
using MeetingAdministrator.App.ViewModels.Lists;

namespace MeetingAdministrator.App.ViewModels.Details
{
    public class MeetingRoomDetailViewModel : ViewModelBase
    {
        private MeetingRoomModel _meetingRoom;

        public string Title => this.GetType().Name.Remove(this.GetType().Name.Length - 9);

        public MeetingRoomModel MeetingRoom
        {
            get
            {
                return _meetingRoom;
            }
            set
            {
                _meetingRoom = value;
                NotifyPropertyChanged(_meetingRoom.GetType().Name);
            }
        }

        private readonly MeetingRoomsListViewModel _meetingRoomsListViewModel;

        public MeetingRoomDetailViewModel(MeetingRoomsListViewModel listViewModel)
        {
            MeetingRoom = new MeetingRoomModel();
            _meetingRoomsListViewModel = listViewModel;
            _meetingRoomsListViewModel.PropertyChanged += MeetingRoomsListViewModel_PropertyChanged;
        }

        private void MeetingRoomsListViewModel_PropertyChanged(object sender, System.ComponentModel.PropertyChangedEventArgs e)
        {
            if (_meetingRoomsListViewModel.SelectedItemIndex >= 0)
            {
                _meetingRoom = _meetingRoomsListViewModel.ListItems[_meetingRoomsListViewModel.SelectedItemIndex];
            }
        }
    }
}