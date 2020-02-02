using MeetingAdministration.Core.Models;
using MeetingAdministrator.App.ViewModels.Details;
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

namespace MeetingAdministrator.App.Views.Details
{
    /// <summary>
    /// Interaction logic for MeetingRoomsDetailView.xaml
    /// </summary>
    public partial class MeetingRoomsDetailView : UserControl
    {
        private MeetingRoomModel _model;
        public MeetingRoomsDetailView()
        {
            InitializeComponent();
        }

        private void StackPanel_Loaded(object sender, RoutedEventArgs e)
        {
            var context = this.DataContext as MeetingRoomDetailViewModel;
            _model = context.MeetingRoom;
            ContentPanel.DataContext = _model;
            context.PropertyChanged += Context_PropertyChanged;
        }

        private void Context_PropertyChanged(object sender, System.ComponentModel.PropertyChangedEventArgs e)
        {
            ContentPanel.DataContext = (sender as MeetingRoomDetailViewModel).MeetingRoom;
        }
    }
}
