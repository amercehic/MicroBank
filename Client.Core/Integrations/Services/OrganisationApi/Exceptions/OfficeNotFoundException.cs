using MicroBank.Common.ExceptionHandler.Exceptions;
using System;

namespace Client.Core.Integrations.Services.OfficeApi.Exceptions
{
    public class OfficeNotFoundException : MicroBankException
    {
        public OfficeNotFoundException(string id)
            : base($"Office with id {id} was not found.", OrganisationErrorCodes.OfficeNotFound, System.Net.HttpStatusCode.NotFound)
        {
        }
    }
}
