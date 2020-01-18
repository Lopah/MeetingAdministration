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

        public string Name { get; set; }

        public string Code { get; set; }

        public string Description { get; set; }

        public ICollection<MeetingRoom> MeetingRooms { get; set; }
    }
}
