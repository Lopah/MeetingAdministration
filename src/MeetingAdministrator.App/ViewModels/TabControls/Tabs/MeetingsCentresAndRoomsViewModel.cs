using MeetingAdministrator.App.Common.Intefaces;
using MeetingAdministrator.App.ViewModels.Details;
using MeetingAdministrator.App.ViewModels.Lists;
using MeetingAdministrator.App.Views.Lists;
using MeetingAdministrator.App.Views.Tabs;
using System.Windows.Controls;

namespace MeetingAdministrator.App.ViewModels.TabControls.Tabs
{
    public class MeetingsCentresAndRoomsViewModel : ViewModelBase, ITabItem
    {
        private MeetingRoomDetailViewModel _meetingRoomViewModel;
        private MeetingCentreDetailViewModel _meetingCentreViewModel;
        private MeetingCentresListViewModel _meetingCentresListViewModel;
        private MeetingRoomsListViewModel _meetingRoomsListViewModel;

        
        public MeetingsCentresAndRoomsViewModel()
        {
            MeetingCentresListViewModel = new MeetingCentresListViewModel();
            MeetingRoomsListViewModel = new MeetingRoomsListViewModel();

            MeetingCentreViewModel = new MeetingCentreDetailViewModel(this.MeetingCentresListViewModel);
            MeetingRoomViewModel = new MeetingRoomDetailViewModel(this.MeetingRoomsListViewModel);

            View = new MeetingCentresAndPlanningView();
        }

        public MeetingCentresListViewModel MeetingCentresListViewModel
        {
            get
            {
                return _meetingCentresListViewModel;
            }
            set
            {
                if (value != _meetingCentresListViewModel)
                {
                    _meetingCentresListViewModel = value;
                    NotifyPropertyChanged(_meetingCentresListViewModel.GetType().Name);
                }
            }
        }

        public MeetingRoomsListViewModel MeetingRoomsListViewModel
        {
            get
            {
                return _meetingRoomsListViewModel;
            }
            set
            {
                if (value != _meetingRoomsListViewModel)
                {
                    _meetingRoomsListViewModel = value;
                    NotifyPropertyChanged(_meetingRoomsListViewModel.GetType().Name);
                }
            }
        }

        public MeetingRoomDetailViewModel MeetingRoomViewModel
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

        public MeetingCentreDetailViewModel MeetingCentreViewModel
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

        public new string DisplayName => this.GetType().Name.Remove(this.GetType().Name.Length-9);
    }
}
