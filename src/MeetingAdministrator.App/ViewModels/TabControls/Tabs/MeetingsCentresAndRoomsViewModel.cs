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
            View = new MeetingCentresAndPlanningView();
        }

        public MeetingsCentresAndRoomsViewModel(object baseModel)
        {
            MeetingCentresListViewModel = new MeetingCentresListViewModel(this);
            MeetingRoomsListViewModel = new MeetingRoomsListViewModel(this.MeetingCentresListViewModel);

            MeetingCentreViewModel = new MeetingCentreDetailViewModel(this.MeetingCentresListViewModel);
            MeetingRoomViewModel = new MeetingRoomDetailViewModel(this.MeetingRoomsListViewModel);

            View = (Control)baseModel;
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
                    NotifyPropertyChanged(typeof(MeetingCentresListViewModel).Name);
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
                    NotifyPropertyChanged(typeof(MeetingRoomsListViewModel).Name);
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
                    NotifyPropertyChanged(typeof(MeetingRoomDetailViewModel).Name);
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
                    NotifyPropertyChanged(typeof(MeetingCentreDetailViewModel).Name);
                }
            }
        }

        public new string DisplayName => this.GetType().Name.Remove(this.GetType().Name.Length-9);
    }
}
