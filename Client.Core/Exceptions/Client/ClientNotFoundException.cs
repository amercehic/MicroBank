using MicroBank.Common.ExceptionHandler.Exceptions;

namespace Client.Core.Exceptions.Client
{
    public class ClientNotFoundException : MicroBankException
    {
        public ClientNotFoundException(string id)
            : base($"Client with id {id} was not found.", ClientErrorCodes.ClientNotFound, System.Net.HttpStatusCode.NotFound)
        {
        }
    }
}
