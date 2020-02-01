using MeetingAdministration.Core.Interfaces.ViewModels;
using MeetingAdministration.Core.Models;
using MeetingAdministration.Data.Entities;
using MeetingAdministrator.App.Commands;
using System;
using System.Collections.ObjectModel;
using System.Windows.Input;

namespace MeetingAdministrator.App.ViewModels.Lists
{
	public class MeetingCentresListViewModel : ViewModelBase, IListViewModel<MeetingCentreModel>
    {
		private int _selectedItemIndex = -1;
		private ObservableCollection<MeetingCentreModel> _meetingCentres;
		private ICommand _newCommand;
		private ICommand _editCommand;
		private ICommand _deleteCommand;
		private MeetingCentreModel _selectedItem;

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

		public MeetingCentresListViewModel()
		{
			ListItems = new ObservableCollection<MeetingCentreModel>()
			{
				new MeetingCentreModel()
				{
					Code = "123",
					Description = "Fuck you",
					Name = "Bitch"
				}

			};

		}
		public MeetingCentreModel SelectedItem
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
					NotifyPropertyChanged(_selectedItemIndex.GetType().Name);
				}
			}
		}


		public string Title => this.GetType().Name.Remove(this.GetType().Name.Length - 9);

		public ObservableCollection<MeetingCentreModel> ListItems
		{
			get
			{
				return _meetingCentres;
			}
			set
			{
				if (value != _meetingCentres)
				{
					_meetingCentres = value;
					NotifyPropertyChanged(typeof(ObservableCollection<MeetingCentre>).Name);
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

		private void ShowNew()
		{

		}

		private void ShowEdit()
		{

		}

		private void Delete()
		{
			if (_selectedItemIndex >= 0)
			{
				this.ListItems.RemoveAt(SelectedItemIndex);
			}
			else
				throw new ArgumentNullException("SelectedItemIndex");
		}
	}
}
