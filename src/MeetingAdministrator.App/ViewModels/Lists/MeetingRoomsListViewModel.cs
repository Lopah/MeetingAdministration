using MeetingAdministration.Core.Models;
using MeetingAdministration.Data.Entities;
using MeetingAdministrator.App.Commands;
using System;
using System.Collections.ObjectModel;
using System.Windows;
using System.Windows.Input;

namespace MeetingAdministrator.App.ViewModels.Lists
{
    public class MeetingRoomsListViewModel : ViewModelBase
    {
        private int _selectedRoomIndex = -1;
		private ICommand _newCommand;
		private ICommand _editCommand;
		private ICommand _deleteCommand;

		public string Title => this.GetType().Name.Remove(this.GetType().Name.Length - 9);

        public int SelectedRoomIndex
        {
            get { return _selectedRoomIndex; }
            set
            {
                if (value != _selectedRoomIndex)
                {
                    _selectedRoomIndex = value;
                    NotifyPropertyChanged(_selectedRoomIndex.GetType().Name);
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

		public ObservableCollection<MeetingRoomModel> ListItems { get; set; }

        private void NewCommand_CanExecute(object sender, CanExecuteRoutedEventArgs e)
        {
            e.CanExecute = _selectedRoomIndex >= 0;
        }

        private void NewCommand_Execute(object sender, ExecutedRoutedEventArgs e)
        {
            MessageBox.Show("Command executed. test msg.");
        }
    }
}
