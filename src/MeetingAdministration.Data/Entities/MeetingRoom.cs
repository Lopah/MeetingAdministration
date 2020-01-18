using System;
using System.Collections.Generic;
using System.Text;

namespace MeetingAdministration.Data.Entities
{
    public class MeetingRoom
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string Code { get; set; }

        public string Description { get; set; }

        /// <summary>
        /// This is restricted to &lt 100 people in it.
        /// </summary>
        public int Capacity { get; set; }

        public bool IsVideoConference { get; set; }

        public MeetingCentre MeetingCentre { get; set; }
    }
}
