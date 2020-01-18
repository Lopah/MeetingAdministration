using System.ComponentModel.DataAnnotations;

namespace MeetingAdministration.Core.Models
{
    public class MeetingCentreModel
    {
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
    }
}
