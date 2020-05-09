using Client.Core.Exceptions.Client;
using MicroBank.Common.ExceptionHandler.Exceptions;

namespace Client.Core.Exceptions
{
    class ClientApplicationNotFoundException : MicroBankException
    {
        public ClientApplicationNotFoundException(string id)
            : base($"Client Application with id {id} was not found.", ClientErrorCodes.ClientApplicationNotFound, System.Net.HttpStatusCode.NotFound)
        {
        }
    }
}
