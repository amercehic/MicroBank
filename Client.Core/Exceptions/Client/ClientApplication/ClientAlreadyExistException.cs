using MicroBank.Common.ExceptionHandler.Exceptions;

namespace Client.Core.Exceptions.Client.ClientApplication
{
    public class ClientAlreadyExistException : MicroBankException
    {
        public ClientAlreadyExistException(string id)
            : base($"Client with id {id} already exist.", ClientErrorCodes.ClientAlreadyExist, System.Net.HttpStatusCode.NotFound)
        {
        }
    }
}
