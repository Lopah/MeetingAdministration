using MeetingAdministration.Core.Interfaces.ViewModels;
using MeetingAdministration.Data.Entities;
using MeetingAdministrator.App.Commands;
using System;
using System.Collections.ObjectModel;
using System.Windows.Input;

namespace MeetingAdministrator.App.ViewModels.TabControls.Lists
{
	public class MeetingCentresListViewModel : ViewModelBase, IListViewModel<MeetingCentre>
    {
		public MeetingCentresListViewModel(string title)
		{
			this.Title = title;
		}
		private int? _selectedItemIndex;
		private ObservableCollection<MeetingCentre> _meetingCentres;
		private ICommand _newCommand;
		private ICommand _editCommand;
		private ICommand _deleteCommand;

		public int? SelectedItemIndex
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

		public string Title { get;}
		public ObservableCollection<MeetingCentre> ListItems
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
			if (_selectedItemIndex.HasValue)
			{
				this.ListItems.RemoveAt(SelectedItemIndex.Value);
			}
			else
				throw new ArgumentNullException("SelectedItemIndex");
		}
	}
}
