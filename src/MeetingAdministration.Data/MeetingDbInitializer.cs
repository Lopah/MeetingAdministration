using MeetingAdministration.Data.Entities;
using System.Collections.Generic;

namespace MeetingAdministration.Data
{
    public static class MeetingDbInitializer
    {
        public static MeetingDbContext Initialize()
        {
            using (var context = new MeetingDbContext())
            {
                context.MeetingCentres.AddRange(
                    new MeetingCentre
                    {
                        Code = "123",
                        Description = "TestDesc",
                        Id = 1,
                        Name = "TestName",
                        MeetingRooms = new List<MeetingRoom>()
                        { 
                            new MeetingRoom
                            {
                                Name = "TestNameRoom",
                                Id = 1,
                                Capacity = 2,
                                Description = "RoomTestDesc",
                                Code = "1234",
                                IsVideoConference = false
                            }
                        }

                    }
                    );
                context.SaveChangesAsync();
                return context;
            }
        }
    }
}
