using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MeetingAdministration.Core.Models
{
    public class MeetingRoomModel
    {
        public string Name { get; set; }

        public string Code { get; set; }

        public string Description { get; set; }

        /// <summary>
        /// This is restricted to &lt 100 people in it.
        /// </summary>
        public int Capacity { get; set; }

        public bool IsVideoConference { get; set; }
    }
}
