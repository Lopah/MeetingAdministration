using MeetingAdministration.Data.Repositories;
using MeetingAdministrator.App.Commands;
using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace MeetingAdministrator.App.ViewModels
{
    public class MainWindowViewModel : ViewModelBase
    {
        private ICommand _importCommand;

        private ICommand _exitCommand;

        private ICommand _saveCommand;

        public MainWindowViewModel()
        {

        }

        public ICommand ImportCommand
        {
            get
            {
                if (_importCommand == null)
                {
                    _importCommand = new RelayCommand(param => this.Import(), null);
                }
                return _importCommand;
            }
            
        }

        private void Import()
        {
            var openDialog = new OpenFileDialog();
            openDialog.FileName = "ImportData";
            openDialog.DefaultExt = ".csv";
            openDialog.Filter = "CSV Files (.csv)|*.csv";

            if (openDialog.ShowDialog().Value)
            {
                // IMPORT DATA
            }
        }

        public ICommand ExitCommand
        {
            get
            {
                if (_exitCommand == null)
                {
                    _exitCommand = new RelayCommand(param => this.Exit(), null);
                }
                return _exitCommand;
            }

        }

        private void Exit()
        {
            // CHECK FOR CHANGES IN DB

            var messageBox = MessageBox.Show("You have unsaved changes in your application. Do you wish to save?",
                            "Save Changes",
                            MessageBoxButton.YesNo,
                            MessageBoxImage.Warning);
            if (messageBox == MessageBoxResult.Yes)
            {
                // SAVE CHANGES
            }
            Application.Current.Shutdown();

        }

        public ICommand SaveCommand
        {
            get
            {
                if (_saveCommand == null)
                {
                    _saveCommand = new RelayCommand(param => this.Save(), null);
                }
                return _saveCommand;
            }

        }

        private void Save()
        {
            var saveDialog = new SaveFileDialog();
            saveDialog.FileName = "Data";
            saveDialog.DefaultExt = ".json";
            saveDialog.Filter = "JSON Files (.json)|*.json";

            if (saveDialog.ShowDialog().Value)
            {
                // SAVE DATA
            }
        }
    }
}
