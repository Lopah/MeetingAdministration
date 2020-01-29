using System;

namespace MeetingAdministration.Data.Entities
{
    public class MeetingsPlanning
    {
        public int Id { get; set; }

        public MeetingRoom MeetingRoom { get; set; }

        public DateTime Date { get; set; }

        public DateTime TimeFrom { get; set; }

        public DateTime TimeTo { get; set; }

        public int ExpectedPersonsCount { get; set; }

        public string Customer { get; set; }

        public bool VideoConference { get; set; }

        public string Note { get; set; }
    }
}
