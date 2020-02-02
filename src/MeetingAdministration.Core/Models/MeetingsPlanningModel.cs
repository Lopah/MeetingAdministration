using MeetingAdministration.Core.Common;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MeetingAdministration.Core.Models
{
    public class MeetingsPlanningModel : ModelBase
    {
        private const string _message = "The {0} needs to be atleast {1} characters long.";

        [Required]
        public DateTime Date { get; set; }

        [Required]
        public DateTime TimeFrom { get; set; }

        [Required]
        public DateTime TimeTo { get; set; }

        [Required]
        [Range(1,100)]
        public int ExpectedPersonsCount { get; set; }

        [Required]
        [StringLength(200, ErrorMessage = _message, MinimumLength = 3)]
        public string Customer { get; set; }

        [Required]
        public bool VideoConference { get; set; } = false;

        [Required]
        [StringLength(200, ErrorMessage = _message, MinimumLength =3)]
        public string Note { get; set; }
    }
}
