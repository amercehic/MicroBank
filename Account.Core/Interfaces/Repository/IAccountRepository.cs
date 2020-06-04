using Account.Core.Entities;
using System;
using System.Threading.Tasks;

namespace Account.Core.Interfaces.Repository
{
    public interface IAccountRepository
    {
        Task<Client> CreateClientIfNotExists(Guid id);
    }
}
