using MeetingAdministration.Core.Interfaces;
using MeetingAdministration.Core.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MeetingAdministration.Core.Repositories
{
    public interface IMeetingCentreRepository : IGenericRepository<MeetingCentreModel>
    {
        Task<IList<MeetingCentreModel>> GetByNameAsync(string name);

        Task<IList<MeetingCentreModel>> GetByCodeAsync(string code);
    }
}