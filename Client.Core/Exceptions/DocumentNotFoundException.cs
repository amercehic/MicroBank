using Client.Core.Exceptions.Client;
using MicroBank.Common.ExceptionHandler.Exceptions;

namespace Client.Core.Exceptions
{
    public class DocumentNotFoundException : MicroBankException
    {
        public DocumentNotFoundException(string id)
            : base($"Document with id {id} was not found.", ClientErrorCodes.DocumentNotFound, System.Net.HttpStatusCode.NotFound)
        {
        }
    }
}
