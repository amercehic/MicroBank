using Client.Core.Exceptions.Client;
using MicroBank.Common.ExceptionHandler.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Client.Core.Entities
{
    public class ClientType
    {
        public static string Business = "Business";
        public static string Personal = "Personal";

        public static string ValidateAndGet(string status)
        {
            if (!All.Contains(status))
            {
                throw new MicroBankException($"Client type: '{status}' is not valid", ClientErrorCodes.ClientTypeNotValid, System.Net.HttpStatusCode.BadRequest);
            }
            return status;
        }

        public static IEnumerable<string> All
        {
            get
            {
                yield return Business;
                yield return Personal;
            }
        }
    }
}
