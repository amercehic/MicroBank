using Client.Core.Entities.Client;
using Client.Core.Exceptions.Client.ClientApplication;
using Client.Core.Interfaces.Service;
using Client.Core.Models.Dto.ClientApplication;
using Client.Core.Models.Filters;
using Client.Core.Specifications;
using MicroBank.Common.Models;
using MicroBank.Common.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Client.Core.Services
{
    public class RejectedClientApplicationService : IRejectedClientApplicationService
    {
        private readonly IEfRepository<Entities.Client.RejectedClientApplication, Guid> rejectedClientApplicationRepository;

        public RejectedClientApplicationService(IEfRepository<Entities.Client.RejectedClientApplication, Guid> rejectedClientApplicationRepository)
        {
            this.rejectedClientApplicationRepository = rejectedClientApplicationRepository;
        }

        public async Task<QueryResultDto<RejectedClientApplicationDto, Guid>> GetByFilterAsync(RejectedClientApplicationFilter filter)
        {
            var spec = new RejectedClientApplicationFilterSpecifications(filter);
            (IEnumerable<RejectedClientApplication> list, int totalCount) = await rejectedClientApplicationRepository.ListAsync(spec).ConfigureAwait(false);

            return new QueryResultDto<RejectedClientApplicationDto, Guid>()
            {
                Items = list?.Select(s => new RejectedClientApplicationDto(s)),
                TotalCount = totalCount
            };
            throw new NotImplementedException();
        }

        public async Task<RejectedClientApplicationDto> GetByIdAsync(Guid id)
        {
            var rejectedClientApplication = await rejectedClientApplicationRepository.FindByAsync(
                o => o.Id == id,
                c => c.Client).ConfigureAwait(false);

            if (rejectedClientApplication == null)
            {
                throw new RejectedClientApplicationNotFoundException(id: id.ToString());
            }

            return new RejectedClientApplicationDto(rejectedClientApplication);
        }
    }
}
