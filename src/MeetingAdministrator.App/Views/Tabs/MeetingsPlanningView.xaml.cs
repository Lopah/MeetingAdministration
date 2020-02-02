using MeetingAdministration.Core.Models;
using MeetingAdministrator.App.ViewModels.TabControls.Tabs;
using System.Windows;
using System.Windows.Controls;

namespace MeetingAdministrator.App.Views.Tabs
{
    /// <summary>
    /// Interaction logic for MeetingsPlanningView.xaml
    /// </summary>
    public partial class MeetingsPlanningView : UserControl
    {
        private MeetingsPlanningViewModel _viewModel;

        public MeetingsPlanningView()
        {
            InitializeComponent();
        }

        private void Grid_Loaded(object sender, RoutedEventArgs e)
        {
            this.DataContext = new MeetingsPlanningViewModel((this.DataContext.GetType().GetProperty("View").GetValue(this.DataContext, null)));
            _viewModel = this.DataContext as MeetingsPlanningViewModel;

        }

        private void ListBox_Loaded(object sender, RoutedEventArgs e)
        {
            PlanningList.ItemsSource = _viewModel.ListItems;
        }

        private void PlanningList_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            _viewModel.SelectedItem = (MeetingsPlanningModel)PlanningList.SelectedItem;
            _viewModel.SelectedItemIndex = PlanningList.SelectedIndex;
        }

        private void ComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void ComboBox_SelectionChanged_1(object sender, SelectionChangedEventArgs e)
        {

        }
    }
}