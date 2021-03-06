﻿using MeetingAdministration.Core.Models;
using MeetingAdministrator.App.ViewModels.Details;
using System.Windows;
using System.Windows.Controls;

namespace MeetingAdministrator.App.Views.Details
{
    /// <summary>
    /// Interaction logic for MeetingCentresDetailView.xaml
    /// </summary>
    public partial class MeetingCentresDetailView : UserControl
    {
        private MeetingCentreModel _model;

        public MeetingCentresDetailView()
        {
            InitializeComponent();
        }

        private void StackPanel_Loaded(object sender, RoutedEventArgs e)
        {
            var context = this.DataContext as MeetingCentreDetailViewModel;
            _model = context.MeetingCentre;
            ContentPanel.DataContext = _model;
            context.PropertyChanged += Context_PropertyChanged;
        }

        private void Context_PropertyChanged(object sender, System.ComponentModel.PropertyChangedEventArgs e)
        {
            if (e.PropertyName == "MeetingCentre")
            {
                ContentPanel.DataContext = (sender as MeetingCentreDetailViewModel).MeetingCentre;
            }
        }
    }
}