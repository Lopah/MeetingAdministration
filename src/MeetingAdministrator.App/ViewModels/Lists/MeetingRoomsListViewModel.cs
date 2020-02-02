using MeetingAdministration.Core.Interfaces.ViewModels;
using MeetingAdministration.Core.Models;
using MeetingAdministrator.App.Commands;
using MeetingAdministrator.App.Views.Details;
using System;
using System.Collections.ObjectModel;
using System.Windows;
using System.Windows.Input;

namespace MeetingAdministrator.App.ViewModels.Lists
{
    public class MeetingRoomsListViewModel : ViewModelBase, IListViewModel<MeetingRoomModel>
    {
        private int _selectedItemIndex = -1;
        private ICommand _newCommand;
        private ICommand _editCommand;
        private ICommand _deleteCommand;
        private MeetingCentresListViewModel _meetingCentresListViewModel;
        private MeetingRoomModel _selectedItem;
        private ObservableCollection<MeetingRoomModel> _meetingRooms;

        public string Title => this.GetType().Name.Remove(this.GetType().Name.Length - 9);

        public MeetingRoomsListViewModel(MeetingCentresListViewModel listViewModel)
        {
            _meetingCentresListViewModel = listViewModel;
            SetContextFromCentre(listViewModel.SelectedItem);
            _meetingCentresListViewModel.PropertyChanged += ListViewModel_PropertyChanged;
        }

        private void ListViewModel_PropertyChanged(object sender, System.ComponentModel.PropertyChangedEventArgs e)
        {
            if (_meetingCentresListViewModel.SelectedItemIndex >= 0)
                SetContextFromCentre(_meetingCentresListViewModel.ListItems[_meetingCentresListViewModel.SelectedItemIndex]);
            else
                SetContextFromCentre(new MeetingCentreModel());
        }

        private void SetContextFromCentre(MeetingCentreModel model)
        {
            var selectedCentre = model;
            if (selectedCentre != null)
            {
                this.ListItems = selectedCentre.MeetingRooms as ObservableCollection<MeetingRoomModel>;
            }
        }

        public MeetingRoomModel SelectedItem
        {
            get
            {
                return _selectedItem;
            }
            set
            {
                if (value != _selectedItem)
                {
                    _selectedItem = value;
                    NotifyPropertyChanged(nameof(SelectedItem));
                }
            }
        }

        public int SelectedItemIndex
        {
            get { return _selectedItemIndex; }
            set
            {
                if (value != _selectedItemIndex)
                {
                    _selectedItemIndex = value;
                    NotifyPropertyChanged(_selectedItemIndex.GetType().Name);
                }
            }
        }

        public ICommand NewCommand
        {
            get
            {
                if (_newCommand == null)
                {
                    _newCommand = new RelayCommand(param => this.ShowNew(), null);
                }

                return _newCommand;
            }
        }

        private void ShowNew()
        {
            var entityWindow = new EditEntityWindow(SelectedItem.GetType(), _meetingCentresListViewModel.SelectedItem);
            if (entityWindow.ShowDialog().Value)
            {
                ListItems.Add(entityWindow.DataContext as MeetingRoomModel);
                SelectedItemIndex = -1;
            }
        }

        public ICommand EditCommand
        {
            get
            {
                if (_editCommand == null)
                {
                    _editCommand = new RelayCommand(param => this.ShowEdit(), param => this.SelectedExistingEntity());
                }

                return _editCommand;
            }
        }

        private void ShowEdit()
        {
            var entityWindow = new EditEntityWindow(SelectedItem.GetType(),_meetingCentresListViewModel.SelectedItem);
            if(entityWindow.ShowDialog().Value)
            {
                ListItems[SelectedItemIndex] = entityWindow.DataContext as MeetingRoomModel;
                SelectedItemIndex = -1;
            }
        }

        public ICommand DeleteCommand
        {
            get
            {
                if (_deleteCommand == null)
                {
                    _deleteCommand = new RelayCommand(param => this.Delete(), param => this.SelectedExistingEntity());
                }

                return _deleteCommand;
            }
        }

        private void Delete()
        {
            _meetingRooms.RemoveAt(_selectedItemIndex);
        }

        private bool SelectedExistingEntity()
        {
            return _selectedItemIndex >= 0;
        }

        public ObservableCollection<MeetingRoomModel> ListItems
        {
            get
            {
                return _meetingRooms;
            }
            set
            {
                if (value != _meetingRooms)
                {
                    _meetingRooms = value;
                    NotifyPropertyChanged(typeof(ObservableCollection<MeetingRoomModel>).Name);
                }
            }
        }
    }
}