using MicroBank.Common.ExceptionHandler.Exceptions;
using System;

namespace Organisation.Core.Exceptions
{
    public class OfficeNotFoundException : MicroBankException
    {
        public OfficeNotFoundException(string id)
            : base($"Office with id {id} was not found.", OfficeErrorCodes.OfficeNotFound, System.Net.HttpStatusCode.NotFound)
        {
        }
    }
}
