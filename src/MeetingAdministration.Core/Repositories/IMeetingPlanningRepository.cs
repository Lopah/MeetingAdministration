using MeetingAdministration.Core.Interfaces;
using MeetingAdministration.Core.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MeetingAdministration.Core.Repositories
{
    public interface IMeetingPlanningRepository : IGenericRepository<MeetingsPlanningModel>
    {
        Task<IList<MeetingsPlanningModel>> GetByName(string name);
    }
}
