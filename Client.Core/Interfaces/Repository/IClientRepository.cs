using Client.Core.Entities.Staff;
using System;
using System.Threading.Tasks;

namespace Client.Core.Interfaces.Repository
{
    public interface IClientRepository
    {
        Task<StaffMember> CreateIfNotExists(Guid id);
    }
}
