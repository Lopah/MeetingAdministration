using MeetingAdministration.Core.Interfaces;
using MeetingAdministration.Core.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MeetingAdministration.Core.Repositories
{
    public interface IMeetingRoomRepository : IGenericRepository<MeetingRoomModel>
    {
        Task<IList<MeetingRoomModel>> GetByNameAsync(string name);

        Task<IList<MeetingRoomModel>> GetByRoomCodeAsync(string code);

        Task<IList<MeetingRoomModel>> GetByIsVideoConference(bool isVideoConference);
    }
}