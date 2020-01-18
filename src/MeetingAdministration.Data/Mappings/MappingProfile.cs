using AutoMapper;
using MeetingAdministration.Core.Models;
using MeetingAdministration.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
