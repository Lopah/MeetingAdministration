using MeetingAdministrator.App.ViewModels.TabControls.Tabs;
using System;
using System.Collections.ObjectModel;
using System.Linq;

namespace MeetingAdministrator.App.ViewModels.TabControls
{
	public class TabControlViewModel : ViewModelBase
	{
		public TabControlViewModel()
		{
			TabCollection.Add(new MeetingsCentresAndRoomsViewModel());
			TabCollection.Add(new MeetingsPlanningViewModel());
			TabCollection.Add(new AccessoriesViewModel());
			SelectedTabIndex = 0;
			SelectedTab = TabCollection.FirstOrDefault();
		}

		public ObservableCollection<ViewModelBase> TabCollection { get; } = new ObservableCollection<ViewModelBase>();
		private int _selectedTabIndex;
		private ViewModelBase _selectedTab;

		public ViewModelBase SelectedTab
		{
			get
			{
				return TabCollection[_selectedTabIndex];
			}
			set
			{
				if(value != _selectedTab)
				{
					_selectedTab = value;
					NotifyPropertyChanged(_selectedTab.GetType().Name);
				}
			}
		}

		public int SelectedTabIndex
		{
			get { return _selectedTabIndex; }
			set
			{
				if (value != _selectedTabIndex)
				{
					_selectedTabIndex = value;
					NotifyPropertyChanged(_selectedTabIndex.GetType().Name);
				}

			}
		}
	}
}
