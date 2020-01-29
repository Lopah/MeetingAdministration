using MeetingAdministrator.App.ViewModels.TabControls.Tabs;
using System.Collections.ObjectModel;

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
		}

		public ObservableCollection<ViewModelBase> TabCollection { get; } = new ObservableCollection<ViewModelBase>();


		private int _selectedTabIndex;

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
