using MeetingAdministration.Core.Common;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations;

namespace MeetingAdministration.Core.Models
{
    public class MeetingCentreModel : ModelBase
    {
        public MeetingCentreModel()
        {
            MeetingRooms = new ObservableCollection<MeetingRoomModel>();
        }
        [Required]
        [StringLength(100, ErrorMessage = "The name of the room cannot exceed 100 characters.", MinimumLength = 3)]
        [Display(Name = "Name of the meeting centre")]
        public string Name { get; set; }

        [Required]
        [StringLength(50, ErrorMessage = "The {0} must be at least {2} and at max {1} characters long", MinimumLength = 5)]
        [Display(Name = "Centre code")]
        public string Code { get; set; }

        [StringLength(300, ErrorMessage = "The {0} must be at least {2} and at max {1} characters long", MinimumLength = 10)]
        public string Description { get; set; }

        public override string ToString()
        {
            if (Code != null && Name != null)
                return $"{Code} : {Name}";
            else
                return base.ToString();
            
        }
        
        public ICollection<MeetingRoomModel> MeetingRooms { get; set; }
    }
}
