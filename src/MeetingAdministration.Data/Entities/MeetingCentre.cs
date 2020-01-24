using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MeetingAdministration.Data.Entities
{
    public class MeetingCentre
    {
        public MeetingCentre()
        {
            MeetingRooms = new List<MeetingRoom>();
        }
        public int Id { get; set; }
        /// <summary>
        /// Represents the name of the <see cref="MeetingCentre"/>. The value is restricted to &#8805; 2 and &#8804; 100 characters.
        /// </summary>
        public string Name { get; set; }
        /// <summary>
        /// Represents a unique code used for this <see cref="MeetingCentre"/>. This is further restricted via regex.
        /// </summary>
        public string Code { get; set; }
        /// <summary>
        /// Represents the description the <see cref="MeetingCentre"/>. The value is restricted to &#8805; 10; and &#8804; 300 characters.
        /// </summary>
        public string Description { get; set; }

        public ICollection<MeetingRoom> MeetingRooms { get; set; }
    }
}
