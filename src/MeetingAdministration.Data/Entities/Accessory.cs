namespace MeetingAdministration.Data.Entities
{
    public class Accessory
    {
        public int Id { get; set; }

        public Category Category { get; set; }

        public string Name { get; set; }

        public int Amount { get; set; }

        public int Min { get; set; }
    }
}