using MeetingAdministration.Core.Interfaces.ViewModels;
using MeetingAdministration.Core.Models;
using MeetingAdministration.Core.Repositories;
using MeetingAdministration.Data.Repositories;
using MeetingAdministrator.App.Commands;
using MeetingAdministrator.App.Common.Intefaces;
using MeetingAdministrator.App.Views.Details;
using MeetingAdministrator.App.Views.Tabs;
using Microsoft.Win32;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using Newtonsoft.Json.Serialization;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Windows.Controls;
using System.Windows.Input;

namespace MeetingAdministrator.App.ViewModels.TabControls.Tabs
{
    public class MeetingsPlanningViewModel : ViewModelBase, ITabItem, IListViewModel<MeetingsPlanningModel>
    {
        private ICommand _newCommand;
        private ICommand _editCommand;
        private ICommand _deleteCommand;
        private ICommand _exportCommand;
        private int _selectedItemIndex = -1;
        private MeetingsPlanningModel _selectedItem;
        private ObservableCollection<MeetingsPlanningModel> _listItems;
        private ObservableCollection<MeetingCentreModel> _meetingCentres;
        private ObservableCollection<MeetingRoomModel> _meetingRooms;
        private MeetingRoomModel _selectedRoom;
        private MeetingCentreModel _selectedCentre;

        public MeetingsPlanningViewModel()
        {
            View = new MeetingsPlanningView();
        }

        public MeetingsPlanningViewModel(object baseModel)
        {
            ListItems = new ObservableCollection<MeetingsPlanningModel>()
            {
                new MeetingsPlanningModel()
                {
                    Customer = "CUSTOMER1",
                    Date = DateTime.Now,
                    ExpectedPersonsCount = 2,
                    Note = "hehe xD",
                    TimeFrom = TimeSpan.FromHours(4).Add(TimeSpan.FromMinutes(20)),
                    TimeTo = TimeSpan.FromHours(6).Add(TimeSpan.FromMinutes(09)),
                    VideoConference = true


                }
            };

            if (DesignerProperties.GetIsInDesignMode(
                new System.Windows.DependencyObject())) return;

            MeetingCentres = new ObservableCollection<MeetingCentreModel>
            {
                new MeetingCentreModel
                {
                    Code = "123",
                    Description = "TestCentre",
                    Name = "TestName",
                    MeetingRooms = new ObservableCollection<MeetingRoomModel>
                    {
                        new MeetingRoomModel
                        {
                            Name = "TestRoom",
                            Description = "RoomDesc",
                            Code = "1234",
                            Capacity = 2,
                            IsVideoConference = true
                        }
                    }
                }
            };

            var rooms = MeetingCentres.Select(e => e.MeetingRooms);
            var convertedRoomsTest = new List<MeetingRoomModel>();
            foreach (var room in rooms)
            {
                convertedRoomsTest.AddRange(room);
            }
            MeetingRooms = new ObservableCollection<MeetingRoomModel>(convertedRoomsTest);

            View = (Control)baseModel;
        }

        public new string DisplayName => this.GetType().Name.Remove(this.GetType().Name.Length - 9);

        public int SelectedItemIndex
        {
            get
            {
                return _selectedItemIndex;
            }
            set
            {
                if (_selectedItemIndex != value)
                {
                    _selectedItemIndex = value;
                    NotifyPropertyChanged(nameof(SelectedItemIndex));
                }
            }
        }

        public ObservableCollection<MeetingCentreModel> MeetingCentres
        {
            get
            {
                return _meetingCentres;
            }
            
            set
            {
                if (_meetingCentres != value)
                {
                    _meetingCentres = value;
                    NotifyPropertyChanged(nameof(MeetingCentres));
                }
            }
        }

        public ObservableCollection<MeetingRoomModel> MeetingRooms
        {
            get
            {
                return _meetingRooms;
            }
            set
            {
                if (_meetingRooms != value)
                {
                    _meetingRooms = value;
                    NotifyPropertyChanged(nameof(MeetingRooms));
                }
            }
        }

        public MeetingRoomModel SelectedMeetingRoom
        {
            get
            {
                return _selectedRoom;
            }
            set
            {
                if (value != _selectedRoom)
                {
                    _selectedRoom = value;
                    NotifyPropertyChanged(nameof(SelectedMeetingRoom));
                }
            }
        }

        public MeetingCentreModel SelectedMeetingCentre
        {
            get
            {
                return _selectedCentre;
            }
            set
            {
                if (value != _selectedCentre)
                {
                    _selectedCentre = value;
                    NotifyPropertyChanged(nameof(SelectedMeetingCentre));
                }
            }
        }

        public MeetingsPlanningModel SelectedItem
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
                    NotifyPropertyChanged(nameof(SelectedItem));
                }
            }
        }

        public string Title => nameof(MeetingsPlanningViewModel).Remove(nameof(MeetingsPlanningViewModel).Length - 9);

        public ObservableCollection<MeetingsPlanningModel> ListItems
        {
            get
            {
                return _listItems;
            }
            set
            {
                if (_listItems != value)
                {
                    _listItems = value;
                    NotifyPropertyChanged(nameof(ListItems));
                }
            }
        }
        public ICommand ExportCommand
        {
            get
            {
                if (_exportCommand == null)
                {
                    _exportCommand = new RelayCommand(param => this.Export(), param => this.Export_CanExecute());
                }
                return _exportCommand;
            }
        }

        private void Export()
        {

            var saveDialog = new SaveFileDialog
            {
                FileName = "ExportData",
                DefaultExt = ".json",
                Filter = "JSON files .json|*.json"
            };
            if (saveDialog.ShowDialog().Value)
            {
                
                var customFormat = new
                {
                    schema = "PLUS4U.EBC.MCS.MeetingRoom_Schedule_1.0",
                    uri = "ues:UCL-BT:UCL.INF/DEMO_REZERVACE:EBC.MCS.DEMO/MR001/SCHEDULE",
                    reservations = new
                    {_listItems}
                };
                var serializer = new JsonSerializer();
                serializer.NullValueHandling = NullValueHandling.Ignore;
                
                using var streamWriter = new StreamWriter(saveDialog.FileName);
                using JsonWriter jsonWriter = new JsonTextWriter(streamWriter);
                {
                    var resolver = new DefaultContractResolver
                    {
                        NamingStrategy = new CamelCaseNamingStrategy()
                    };
                    JsonConvert.SerializeObject(customFormat, new JsonSerializerSettings
                    {
                        ContractResolver = resolver,
                        Formatting = Formatting.Indented,
                    });

                }
            }

        }

        private bool Export_CanExecute()
        {
            return _listItems != null ? _listItems.Count > 0 : false;
        }

        public ICommand NewCommand
        {
            get
            {
                if (_newCommand == null)
                {
                    _newCommand = new RelayCommand(param => this.New(), null);
                }
                return _newCommand;
            }
        }

        private void New()
        {
            var entityWindow = new EditEntityWindow(typeof(MeetingsPlanningModel), _selectedItem);
            if(entityWindow.ShowDialog().Value)
            {
                var item = entityWindow.ContentPanel.DataContext as MeetingsPlanningModel;
                ListItems.Add(item);
            }
        }

        public ICommand EditCommand
        {
            get
            {
                if (_editCommand == null)
                {
                    _editCommand = new RelayCommand(param => this.Edit(), param => this.Edit_CanExecute());
                }
                return _editCommand;
            }
        }

        private void Edit()
        {
            var entityWindow = new EditEntityWindow(typeof(MeetingsPlanningModel),_selectedItem);
            if (entityWindow.ShowDialog().Value)
            {
                ListItems[SelectedItemIndex] = entityWindow.ContentPanel.DataContext as MeetingsPlanningModel;
            }
        }

        private bool Edit_CanExecute()
        {
            return SelectedItemIndex >= 0;
        }

        public ICommand DeleteCommand
        {
            get
            {
                if (_deleteCommand == null)
                {
                    _deleteCommand = new RelayCommand(param => this.Delete(), param => this.Delete_CanExecute());
                }
                return _deleteCommand;
            }
        }

        private void Delete()
        {
            ListItems.RemoveAt(SelectedItemIndex);
        }

        private bool Delete_CanExecute()
        {
            return SelectedItemIndex >= 0;
        }
    }
}