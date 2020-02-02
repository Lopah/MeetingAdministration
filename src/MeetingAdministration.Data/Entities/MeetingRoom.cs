namespace MeetingAdministration.Data.Entities
{
    public class MeetingRoom
    {
        public int Id { get; set; }

        /// <summary>
        /// Represents the name of the <see cref="MeetingRoom"/>. The value is restricted to &#8805; 2 and &#8804; 100 characters.
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Represents a unique code used for this <see cref="MeetingRoom"/>. This is further restricted via regex.
        /// </summary>
        public string Code { get; set; }

        /// <summary>
        /// Represents the description the <see cref="MeetingRoom"/>. The value is restricted to &#8805; 10; and &#8804; 300 characters.
        /// </summary>
        public string Description { get; set; }

        /// <summary>
        /// Represents the amount of people in the <see cref="MeetingRoom"/>, which is restricted to &#8805; 1 and &#8804; 100 people in it.
        /// </summary>
        public int Capacity { get; set; }

        /// <summary>
        /// Represents if this <see cref="MeetingRoom"/> is held as a VideoConference or not.
        /// </summary>
        public bool IsVideoConference { get; set; }

        public MeetingCentre MeetingCentre { get; set; }

        public MeetingsPlanning MeetingsPlanning { get; set; }
    }
}