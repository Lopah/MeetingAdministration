using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Reflection;
using System.Text.Json.Serialization;

namespace MeetingAdministration.Core.Common
{
    public class ModelBase : INotifyPropertyChanged, IDataErrorInfo
    {
        [JsonIgnore]
        public string this[string columnName]
        {
            get
            {
                if (string.IsNullOrEmpty(columnName))
                {
                    throw new ArgumentException("Invalid property name", columnName);
                }
                string error = string.Empty;
                var value = GetValue(columnName);
                var results = new List<ValidationResult>(1);
                var result = Validator.TryValidateProperty(
                    value,
                    new ValidationContext(this, null, null)
                    {
                        MemberName = columnName
                    },
                    results);
                if (!result)
                {
                    var validationResult = results.First();
                    error = validationResult.ErrorMessage;
                }
                return error;
            }
        }

        [JsonIgnore]
        public string Error => null;

        public event PropertyChangedEventHandler PropertyChanged;

        private void NotifyPropertyChanged(string property)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(property));
        }

        private object GetValue(string columnName)
        {
            PropertyInfo propertyInfo = GetType().GetProperty(columnName);
            return propertyInfo.GetValue(this);
        }
    }
}