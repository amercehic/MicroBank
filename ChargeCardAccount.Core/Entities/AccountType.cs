using MicroBank.Common.ExceptionHandler.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;

namespace ChargeCardAccount.Core.Entities
{
    public class AccountType
    {
        public static string Business = "Business";
        public static string Personal = "Personal";

        public static string ValidateAndGet(string status)
        {
            if (!All.Contains(status))
            {
                throw new MicroBankException($"Client Application status: '{status}' is not valid", AccountErrorCodes.AccountApplicationTypeNotValid, System.Net.HttpStatusCode.BadRequest);
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
