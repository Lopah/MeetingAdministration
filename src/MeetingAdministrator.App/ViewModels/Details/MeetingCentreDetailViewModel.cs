﻿using MeetingAdministration.Core.Models;
using MeetingAdministration.Data.Entities;
using MeetingAdministrator.App.Commands;
using MeetingAdministrator.App.ViewModels.Lists;
using System;
using System.Collections.ObjectModel;
using System.Windows.Input;

namespace MeetingAdministrator.App.ViewModels.Details
{
    public class MeetingCentreDetailViewModel : ViewModelBase
    {
        private MeetingCentreModel _meetingCentre;
        private readonly MeetingCentresListViewModel _meetingCentresListViewModel;

        public string Title => this.GetType().Name.Remove(this.GetType().Name.Length - 9);
        public MeetingCentreModel MeetingCentre
        {
            get { return _meetingCentre; }
            set
            {
                _meetingCentre = value;
                NotifyPropertyChanged(typeof(MeetingCentre).Name);
            }
        }

        public MeetingCentreDetailViewModel(MeetingCentresListViewModel listViewModel)
        {
            MeetingCentre = new MeetingCentreModel();
            _meetingCentresListViewModel = listViewModel;
            _meetingCentresListViewModel.PropertyChanged += ListViewModel_PropertyChanged;
        }

        private void ListViewModel_PropertyChanged(object sender, System.ComponentModel.PropertyChangedEventArgs e)
        {
            if (e.PropertyName == _meetingCentresListViewModel.SelectedItemIndex.GetType().Name)
            {
                if (_meetingCentresListViewModel.SelectedItemIndex >= 0)
                {
                    this._meetingCentre = _meetingCentresListViewModel.ListItems[_meetingCentresListViewModel.SelectedItemIndex];
                }
                else
                    throw new ArgumentNullException(_meetingCentresListViewModel.SelectedItemIndex.GetType().Name);
            }
        }
    }
}