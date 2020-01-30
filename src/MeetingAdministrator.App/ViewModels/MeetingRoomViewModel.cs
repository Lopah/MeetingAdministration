using MeetingAdministration.Data.Entities;
using MeetingAdministrator.App.Commands;
using System.Collections.ObjectModel;
using System.Windows.Input;

namespace MeetingAdministrator.App.ViewModels
{
    public class MeetingRoomViewModel : ViewModelBase
    {
        private MeetingRoom _meetingRoom;
        private ObservableCollection<MeetingRoom> _meetingRooms;
        private ICommand _relayCommand;

        public MeetingRoomViewModel()
        {
            MeetingRoom = new MeetingRoom();
            MeetingRooms = new ObservableCollection<MeetingRoom>();
            MeetingRooms.CollectionChanged += MeetingRooms_CollectionChanged;
        }

        private void MeetingRooms_CollectionChanged(object sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e)
        {
            NotifyPropertyChanged(MeetingRooms.GetType().Name);
        }

        public MeetingRoom MeetingRoom {
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

        public ObservableCollection<MeetingRoom> MeetingRooms { 
            get => _meetingRooms;
            set
            {
                _meetingRooms = value;
                NotifyPropertyChanged(_meetingRooms.GetType().Name);
            }
        }

        public ICommand RelayCommand {
            get
            {
                if (_relayCommand == null)
                {
                    _relayCommand = new RelayCommand(param => this.Submit(), null);
                }
                return _relayCommand;
            }
           
        }

        private void Submit()
        {
            MeetingRooms.Add(MeetingRoom);
            MeetingRoom = new MeetingRoom();
        }
    }
}
