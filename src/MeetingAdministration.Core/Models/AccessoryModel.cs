using MeetingAdministration.Core.Common;
using System;
using System.ComponentModel.DataAnnotations;

namespace MeetingAdministration.Core.Models
{
    public class AccessoryModel : ModelBase
    {
        private const string _message = "The {0} must be at least {1} characters long.";

        [Required]
        [StringLength(200, ErrorMessage = _message, MinimumLength = 3)]
        public string Name { get; set; }

        [Required]
        [Range(1, 100)]
        public int Amount { get; set; }

        [Required]
        [Range(1, 200)]
        public int Min { get; set; }
    }
}