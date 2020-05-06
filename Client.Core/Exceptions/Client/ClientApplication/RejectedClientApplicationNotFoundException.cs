using MicroBank.Common.ExceptionHandler.Exceptions;

namespace Client.Core.Exceptions.Client.ClientApplication
{
    public class RejectedClientApplicationNotFoundException : MicroBankException
    {
        public RejectedClientApplicationNotFoundException(string id)
            : base($"Rejected Client Application with id {id} was not found.", ClientErrorCodes.RejectedClientApplicationNotFound, System.Net.HttpStatusCode.NotFound)
        {
        }
    }
}
