using MeetingAdministrator.App.ViewModels.Details;
using MeetingAdministrator.App.ViewModels.Lists;
using MeetingAdministrator.App.ViewModels.TabControls.Tabs;
using System;
using System.Collections.Generic;
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
            //_meetingCentresAndPlanning = (DataContext as MeetingsCentresAndRoomsViewModel);
            //_meetingCentresAndPlanning.MeetingCentresListViewModel.PropertyChanged += MeetingCentresListViewModel_PropertyChanged;
        }

        private void MeetingCentresListViewModel_PropertyChanged(object sender, System.ComponentModel.PropertyChangedEventArgs e)
        {
            if (e.PropertyName == _meetingCentresAndPlanning.MeetingCentresListViewModel.SelectedItem.GetType().Name)
            {
                _meetingCentresAndPlanning.MeetingCentreViewModel.MeetingCentre = _meetingCentresAndPlanning.MeetingCentresListViewModel.SelectedItem;
                MessageBox.Show("Meeting Centre Item Changed!");
            }
        }
    }
}
