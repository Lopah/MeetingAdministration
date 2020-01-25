using MeetingAdministration.Data.Entities;
using MeetingAdministrator.App.Commands;
using System.Collections.ObjectModel;
using System.Windows.Input;

namespace MeetingAdministrator.App.ViewModels
{
    public class MeetingCentreViewModel : ViewModelBase
    {
        private MeetingCentre _meetingCentre;
        private ObservableCollection<MeetingCentre> _meetingCentres;
        private ICommand _submitCommand;

        public MeetingCentre MeetingCentre
        {
            get { return _meetingCentre; }
            set
            {
                _meetingCentre = value;
                NotifyPropertyChanged(typeof(MeetingCentre).Name);
            }
        }

        public ObservableCollection<MeetingCentre> MeetingCentres
        {
            get { return _meetingCentres; }
            set
            {
                _meetingCentres = value;
                NotifyPropertyChanged(typeof(ObservableCollection<MeetingCentre>).Name);
            }
        }

        public ICommand SubmitCommand
        {
            get
            {
                if (_submitCommand == null)
                {
                    _submitCommand = new RelayCommand(param => this.Submit(), null);
                }
                return _submitCommand;
            }
        }

        public MeetingCentreViewModel()
        {
            MeetingCentre = new MeetingCentre();
            MeetingCentres = new ObservableCollection<MeetingCentre>();
            MeetingCentres.CollectionChanged += MeetingCentres_CollectionChanged;
        }

        private void MeetingCentres_CollectionChanged(object sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e)
        {
            NotifyPropertyChanged(MeetingCentres.GetType().Name);
        }

        private void Submit()
        {
            MeetingCentres.Add(MeetingCentre);
            MeetingCentre = new MeetingCentre();
        }


    }
}
