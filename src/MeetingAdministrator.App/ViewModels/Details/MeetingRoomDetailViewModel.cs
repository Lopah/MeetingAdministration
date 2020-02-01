using MeetingAdministration.Core.Models;
using MeetingAdministration.Data.Entities;
using MeetingAdministrator.App.Commands;
using MeetingAdministrator.App.ViewModels.Lists;
using System;
using System.Collections.ObjectModel;
using System.Windows.Input;

namespace MeetingAdministrator.App.ViewModels.Details
{
    public class MeetingRoomDetailViewModel : ViewModelBase
    {
        private MeetingRoomModel _meetingRoom;
        public MeetingRoom SelectedMeetingRoom { get; set; }
        private ObservableCollection<MeetingRoom> _meetingRooms;

        public string Title => this.GetType().Name.Remove(this.GetType().Name.Length - 9);

        public MeetingRoomDetailViewModel()
        {
            MeetingRoom = new MeetingRoomModel();
            MeetingRooms = new ObservableCollection<MeetingRoom>();
            MeetingRooms.CollectionChanged += MeetingRooms_CollectionChanged;
        }

        private void MeetingRooms_CollectionChanged(object sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e)
        {
            NotifyPropertyChanged(MeetingRooms.GetType().Name);
        }

        public MeetingRoomModel MeetingRoom {
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

        public ObservableCollection<MeetingRoom> MeetingRooms { 
            get => _meetingRooms;
            set
            {
                _meetingRooms = value;
                NotifyPropertyChanged(_meetingRooms.GetType().Name);
            }
        }

        public MeetingRoomDetailViewModel(MeetingRoomsListViewModel listViewModel)
        {
            MeetingRoom = new MeetingRoomModel();
            _meetingRoomsListViewModel = listViewModel;
            _meetingRoomsListViewModel.PropertyChanged += MeetingRoomsListViewModel_PropertyChanged;
        }

        private void MeetingRoomsListViewModel_PropertyChanged(object sender, System.ComponentModel.PropertyChangedEventArgs e)
        {
            if (e.PropertyName == _meetingRoomsListViewModel.SelectedRoomIndex.GetType().Name)
            {
                if (_meetingRoomsListViewModel.SelectedRoomIndex >= 0)
                {
                    _meetingRoom = _meetingRoomsListViewModel.ListItems[_meetingRoomsListViewModel.SelectedRoomIndex];
                }
                else
                    throw new ArgumentNullException(_meetingRoomsListViewModel.SelectedRoomIndex.GetType().Name);
            }
        }
    }
}
