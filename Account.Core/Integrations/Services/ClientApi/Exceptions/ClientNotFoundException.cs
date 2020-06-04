using MicroBank.Common.ExceptionHandler.Exceptions;

namespace Account.Core.Integrations.Services.ClientApi.Exceptions
{
    public class ClientNotFoundException : MicroBankException
    {
        public ClientNotFoundException(string id)
            : base($"Client with id {id} was not found.", ClientErrorCodes.ClientNotFound, System.Net.HttpStatusCode.NotFound)
        {
        }
    }
}
