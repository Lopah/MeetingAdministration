namespace MeetingAdministrator.App.ViewModels.TabControls.Tabs
{
    public class MeetingsCentresAndRoomsViewModel : ViewModelBase
    {
        private MeetingRoomViewModel _meetingRoomViewModel;
        private MeetingCentreViewModel _meetingCentreViewModel;

        public MeetingRoomViewModel MeetingRoomViewModel
        {
            get
            {
                return _meetingRoomViewModel;
            }
            set
            {
                if (value != _meetingRoomViewModel)
                {
                    _meetingRoomViewModel = value;
                    NotifyPropertyChanged(_meetingRoomViewModel.GetType().Name);
                }
            }
        }

        public MeetingCentreViewModel MeetingCentreViewModel
        {
            get
            {
                return _meetingCentreViewModel;
            }
            set
            {
                if (value != _meetingCentreViewModel)
                {
                    _meetingCentreViewModel = value;
                    NotifyPropertyChanged(_meetingCentreViewModel.GetType().Name);
                }
            }
        }


    }
}
