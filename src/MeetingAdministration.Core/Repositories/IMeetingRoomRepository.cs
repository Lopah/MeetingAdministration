using MeetingAdministration.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MeetingAdministration.Core.Interfaces
{
    public interface IMeetingRoomRepository : IGenericRepository<MeetingRoomModel>
    {
        Task<IList<MeetingRoomModel>> GetByNameAsync(string name);

        Task<IList<MeetingRoomModel>> GetByRoomCodeAsync(string code);

        Task<IList<MeetingRoomModel>> GetByIsVideoConference(bool isVideoConference);
    }
}
