using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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
