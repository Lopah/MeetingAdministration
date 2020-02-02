using MeetingAdministration.Core.Common;
using Newtonsoft.Json;
using System;
using System.ComponentModel.DataAnnotations;

namespace MeetingAdministration.Core.Models
{
    public class MeetingsPlanningModel : ModelBase
    {
        private const string _message = "The {0} needs to be atleast {1} characters long.";

        [Required]
        public DateTime Date { get; set; }

        [Required]
        public TimeSpan TimeFrom { get; set; }

        [Required]
        public TimeSpan TimeTo { get; set; }

        [Required]
        [Range(1, 100)]
        public int ExpectedPersonsCount { get; set; }

        [Required]
        [StringLength(200, ErrorMessage = _message, MinimumLength = 3)]
        public string Customer { get; set; }

        [Required]
        public bool VideoConference { get; set; } = false;

        [Required]
        [StringLength(200, ErrorMessage = _message, MinimumLength = 3)]
        public string Note { get; set; }

        [JsonProperty(Order = -2)]
        public MeetingCentreModel MeetingCentre { get; set; }

        [JsonProperty(Order = -1)]
        public MeetingRoomModel MeetingRoom { get; set; }

        public override string ToString()
        {
            if (Date != null && Customer != null)
            {
                return $"{Customer} : {Date}";
            }
            return base.ToString();
        }
    }
}