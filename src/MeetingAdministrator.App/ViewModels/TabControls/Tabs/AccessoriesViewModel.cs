using MeetingAdministrator.App.Common.Intefaces;
using MeetingAdministrator.App.Views.Tabs;

namespace MeetingAdministrator.App.ViewModels.TabControls.Tabs
{
    public class AccessoriesViewModel : ViewModelBase, ITabItem
    {
        public AccessoriesViewModel()
        {
            View = new AccessoriesView();
        }
        public new string DisplayName => this.GetType().Name.Remove(this.GetType().Name.Length - 9);
    }
}
