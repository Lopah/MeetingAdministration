using System;
using System.Windows.Input;

namespace MeetingAdministrator.App.ViewModels
{
    public class CommandViewModel : ViewModelBase
    {
        public CommandViewModel(string displayName, ICommand command)
        {
            if (command == null)
                throw new ArgumentNullException("Command");
            base.DisplayName = displayName;
            this.Command = command;
        }

        public ICommand Command { get; set; }
    }
}