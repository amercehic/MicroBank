using MicroBank.Common.ExceptionHandler.Exceptions;

namespace Organisation.Core.Exceptions
{
    public class StaffMemberNotFoundException : MicroBankException
    {
        public StaffMemberNotFoundException(string id)
            : base($"Staff Member with id {id} was not found.", StaffMemberErrorCodes.StaffMemberNotFound, System.Net.HttpStatusCode.NotFound)
        {
        }
    }
}
