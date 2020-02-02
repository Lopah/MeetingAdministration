using MeetingAdministration.Core.Models;
using MeetingAdministrator.App.ViewModels.Details;
using MeetingAdministrator.App.ViewModels.Lists;
using MeetingAdministrator.App.ViewModels.TabControls.Tabs;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace MeetingAdministrator.App.Views.Tabs
{
    /// <summary>
    /// Interaction logic for MeetingsAndPlanningView.xaml
    /// </summary>
    public partial class MeetingCentresAndPlanningView : UserControl
    {
        private MeetingsCentresAndRoomsViewModel _meetingCentresAndPlanning;

        public MeetingCentresAndPlanningView()
        {
            InitializeComponent();
        }

        private void MeetingCentresListViewModel_PropertyChanged(object sender, System.ComponentModel.PropertyChangedEventArgs e)
        {
            if (sender is MeetingCentresListViewModel)
            {
                if (e.PropertyName == _meetingCentresAndPlanning.MeetingCentresListViewModel.SelectedItem.GetType().Name)
                {
                    _meetingCentresAndPlanning.MeetingCentreViewModel.MeetingCentre = _meetingCentresAndPlanning.MeetingCentresListViewModel.SelectedItem;
                }
            }
            else if(sender is MeetingRoomsListViewModel)
            {
                if (_meetingCentresAndPlanning.MeetingRoomsListViewModel.SelectedItem != null)
                {
                    
                    _meetingCentresAndPlanning.MeetingRoomViewModel.MeetingRoom = _meetingCentresAndPlanning.MeetingRoomsListViewModel.SelectedItem;
                }
            }
        }

        private void Grid_Loaded(object sender, RoutedEventArgs e)
        {
            this.DataContext = new MeetingsCentresAndRoomsViewModel((this.DataContext.GetType().GetProperty("View").GetValue(this.DataContext, null)));
            _meetingCentresAndPlanning = this.DataContext as MeetingsCentresAndRoomsViewModel;
            _meetingCentresAndPlanning.MeetingRoomsListViewModel.PropertyChanged += MeetingCentresListViewModel_PropertyChanged;
            _meetingCentresAndPlanning.MeetingCentresListViewModel.PropertyChanged += MeetingCentresListViewModel_PropertyChanged1;
        }

        private void MeetingCentresListViewModel_PropertyChanged1(object sender, System.ComponentModel.PropertyChangedEventArgs e)
        {
            if ((sender as MeetingCentresListViewModel).SelectedItemIndex >= 0)
            {
                RoomList.DataContext = _meetingCentresAndPlanning.MeetingRoomsListViewModel;
                RoomList.ListBox.ItemsSource = _meetingCentresAndPlanning.MeetingRoomsListViewModel.ListItems;
                RoomList.InvalidateArrange();
                RoomList.UpdateLayout();
            }
        }

        private void MeetingCentresDetailView_Loaded(object sender, RoutedEventArgs e)
        {
            CentresDetail.DataContext = _meetingCentresAndPlanning.MeetingCentreViewModel;
        }

        private void MeetingRoomsDetailView_Loaded(object sender, RoutedEventArgs e)
        {
            RoomsDetail.DataContext = _meetingCentresAndPlanning.MeetingRoomViewModel;
        }

        private void ListView_Loaded(object sender, RoutedEventArgs e)
        {
            RoomList.DataContext = _meetingCentresAndPlanning.MeetingRoomsListViewModel;

        }

        private void ListView_DataContextChanged(object sender, DependencyPropertyChangedEventArgs e)
        {
            if (_meetingCentresAndPlanning != null)
            {
                RoomList.DataContext = _meetingCentresAndPlanning.MeetingRoomsListViewModel;
            }
            
        }
    }
}
