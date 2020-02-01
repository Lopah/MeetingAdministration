using MeetingAdministrator.App.Common.Intefaces;
using MeetingAdministrator.App.Views.Tabs;

namespace MeetingAdministrator.App.ViewModels.TabControls.Tabs
{
    public class MeetingsPlanningViewModel : ViewModelBase, ITabItem
    {
        public MeetingsPlanningViewModel()
        {
            View = new MeetingsPlanningView();
        }
        public new string DisplayName => this.GetType().Name.Remove(this.GetType().Name.Length - 9);
    }
}
