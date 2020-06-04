using MicroBank.Common.ExceptionHandler.Exceptions;

namespace Client.Core.Exceptions.Client
{
    public class InvalidOfficeIdException : MicroBankException
    {
        public InvalidOfficeIdException()
            : base($"Client and Staff Member must have same OfficeId.", ClientErrorCodes.InvalidOfficeId, System.Net.HttpStatusCode.BadRequest)
        {
        }
    }
}
