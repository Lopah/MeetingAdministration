using MeetingAdministration.Core.Interfaces;
using MeetingAdministration.Core.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MeetingAdministration.Core.Repositories
{
    public interface IAccessoryRepository : IGenericRepository<AccessoryModel>
    {
        Task<IList<AccessoryModel>> GetByName(string name);
    }
}