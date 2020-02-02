using MeetingAdministration.Core.Common;
using MeetingAdministrator.App.Commands;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Input;

namespace MeetingAdministrator.App.ViewModels.Details
{
    public class EditEntityViewModel : ViewModelBase
    {
        private ICommand _addCommand;
        private readonly StackPanel _panel;
        private ICommand _closeCommand;
        private readonly Window _window;

        /// <summary>
        /// Assigns this view model the entity I want to display for editing.
        /// </summary>
        /// <param name="entity">Represents the DataContext of the view/></param>
        public EditEntityViewModel(StackPanel panel, Type entityType, object value, Window window)
        {
            _window = window;
            _panel = panel;
            AddFieldsAccordingToProperties(panel, entityType, value);
        }

        public ICommand AddCommand
        {
            get
            {
                if (_addCommand != null)
                {
                    _addCommand = new RelayCommand(param => this.Add(), null);
                }
                return _addCommand;
            }
        }

        private void Add()
        {
            _window.DataContext = _panel.DataContext;
            _window.DialogResult = true;
            _window.Close();
        }

        public ICommand CloseCommand
        {
            get
            {
                if (_closeCommand != null)
                {
                    _closeCommand = new RelayCommand(param => this.Close(), null);
                }
                return _closeCommand;
            }
        }

        private void Close()
        {
            _window.DialogResult = false;
            _window.Close();
        }

        private void AddFieldsAccordingToProperties(StackPanel panel, Type entityType, object value)
        {
            PropertyInfo[] properties = entityType.GetProperties();
            foreach (var property in properties)
            {
                if (
                    (
                    property.Name.Contains("Error", comparisonType: StringComparison.CurrentCultureIgnoreCase) ||
                    property.Name.Contains("Item", StringComparison.CurrentCultureIgnoreCase) ||
                    property.Name.Contains("Meeting", StringComparison.CurrentCultureIgnoreCase)
                    )||
                    !typeof(string).Equals(property.PropertyType) &&
                    property.PropertyType.GetInterface(typeof(IEnumerable<>).FullName) != null)
                {
                    continue;
                }

                var labelProp = new Label
                {
                    Content = property.Name
                };

                var textBox = new TextBox();
                if (value != null && value.GetType().GetProperty(property.Name).GetValue(value,null) != null)
                {
                    textBox.Text = value.GetType().GetProperty(property.Name).GetValue(value,null).ToString();
                }
                var binding = new Binding(panel.DataContext.GetType().GetProperty(property.Name).Name)
                {
                    //Source = panel.DataContext,
                    //Path = property.Name
                    Mode = BindingMode.TwoWay,
                    UpdateSourceTrigger = UpdateSourceTrigger.LostFocus,
                    ValidatesOnNotifyDataErrors = true,
                    ValidatesOnDataErrors = true
                };

                textBox.SetBinding(TextBox.TextProperty, binding);

                panel.Children.Add(labelProp);
                panel.Children.Add(textBox);
            }
            panel.InvalidateArrange();
            panel.UpdateLayout();
        }
    }
}
