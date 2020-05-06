using MicroBank.Common.ExceptionHandler.Exceptions;

namespace Client.Core.Exceptions
{
    class ClientApplicationNotFoundException : MicroBankException
    {
        public ClientApplicationNotFoundException(string id)
            : base($"Client Application with id {id} was not found.", ClientApplicationErrorCodes.ClientApplicationNotFound, System.Net.HttpStatusCode.NotFound)
        {
        }
    }
}
