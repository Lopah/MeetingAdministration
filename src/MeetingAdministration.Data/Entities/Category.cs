using System.Collections.Generic;

namespace MeetingAdministration.Data.Entities
{
    public class Category
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public ICollection<Accessory> Accessories { get; set; }
    }
}