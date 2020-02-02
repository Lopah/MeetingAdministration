using MeetingAdministration.Core.Interfaces.ViewModels;
using MeetingAdministration.Core.Models;
using MeetingAdministration.Data.Entities;
using MeetingAdministrator.App.Commands;
using System;
using System.Collections.ObjectModel;
using System.Linq;
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
			{
				SetContextFromCentre(_meetingCentresListViewModel.ListItems[_meetingCentresListViewModel.SelectedItemIndex]);
			}
		}

		private	void SetContextFromCentre(MeetingCentreModel model)
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
					NotifyPropertyChanged(SelectedItem.GetType().Name);
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
			throw new NotImplementedException();
		}

		public ICommand EditCommand
		{
			get
			{
				if (_editCommand == null)
				{
					_editCommand = new RelayCommand(param => this.ShowEdit(), null);
				}

				return _editCommand;
			}

		}

		private void ShowEdit()
		{
			throw new NotImplementedException();
		}

		public ICommand DeleteCommand
		{
			get
			{
				if (_deleteCommand == null)
				{
					_deleteCommand = new RelayCommand(param => this.Delete(), null);
				}

				return _deleteCommand;
			}
		}

		private void Delete()
		{
			throw new NotImplementedException();
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


        private void NewCommand_CanExecute(object sender, CanExecuteRoutedEventArgs e)
        {
            e.CanExecute = _selectedItemIndex >= 0;
        }

        private void NewCommand_Execute(object sender, ExecutedRoutedEventArgs e)
        {
            MessageBox.Show("Command executed. test msg.");
        }
    }
}
