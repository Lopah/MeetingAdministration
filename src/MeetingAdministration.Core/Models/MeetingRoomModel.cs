using MeetingAdministration.Core.Common;
using System;
using System.ComponentModel.DataAnnotations;

namespace MeetingAdministration.Core.Models
{
    public class MeetingRoomModel : ModelBase
    {
        private const string _message = "The {0} must be at least {2} and at max {1} characters long";

        [Required]
        [StringLength(100, ErrorMessage = _message, MinimumLength = 3)]
        public string Name { get; set; }

        [Required]
        [StringLength(50, ErrorMessage = _message, MinimumLength = 5)]
        public string Code { get; set; }

        [Required]
        [StringLength(300, ErrorMessage = _message, MinimumLength = 10)]
        public string Description { get; set; }

        /// <summary>
        /// This is restricted to &gt 1 and &lt 100 people in it.
        /// </summary>
        [Required]
        [Range(1, 100)]
        public int Capacity { get; set; }

        [Required]
        public bool IsVideoConference { get; set; }

        public override string ToString()
        {
            if (Name != null && Code != null)
                return $"{Code} : {Name}";
            else
                return base.ToString();
        }
    }
}
