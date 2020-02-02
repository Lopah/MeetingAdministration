using AutoMapper;
using MeetingAdministration.Core.Models;
using MeetingAdministration.Data.Entities;

namespace MeetingAdministration.Data.Mappings
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<MeetingCentre, MeetingCentreModel>();

            CreateMap<MeetingRoom, MeetingRoomModel>();

            CreateMap<MeetingCentreModel, MeetingCentre>();

            CreateMap<MeetingRoomModel, MeetingRoom>();
        }
    }
}