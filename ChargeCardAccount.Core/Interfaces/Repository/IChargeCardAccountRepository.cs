using ChargeCardAccount.Core.Entities;
using System;
using System.Threading.Tasks;

namespace ChargeCardAccount.Core.Interfaces.Repository
{
    public interface IChargeCardAccountRepository
    {
        Task<Client> CreateClientIfNotExists(Guid id);
    }
}
