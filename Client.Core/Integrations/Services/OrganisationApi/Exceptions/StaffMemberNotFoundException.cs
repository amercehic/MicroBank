using Client.Core.Integrations.Services.OfficeApi.Exceptions;
using MicroBank.Common.ExceptionHandler.Exceptions;

namespace Client.Core.Integrations.Services.OrganisationApi.Exceptions
{
    public class StaffMemberNotFoundException : MicroBankException
    {
        public StaffMemberNotFoundException(string id)
            : base($"Staff member with id {id} was not found.", OrganisationErrorCodes.StaffMemberNotFound, System.Net.HttpStatusCode.NotFound)
        {
        }
    }
}
