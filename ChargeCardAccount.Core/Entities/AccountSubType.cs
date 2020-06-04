using MicroBank.Common.ExceptionHandler.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;

namespace ChargeCardAccount.Core.Entities
{
    public class AccountSubType
    {
        public static string ChargeCard = "ChargeCard";

        public static string ValidateAndGet(string status)
        {
            if (!All.Contains(status))
            {
                throw new MicroBankException($"Client Application status: '{status}' is not valid", AccountErrorCodes.AccountSubTypeNotValid, System.Net.HttpStatusCode.BadRequest);
            }
            return status;
        }

        public static IEnumerable<string> All
        {
            get
            {
                yield return ChargeCard;
            }
        }
    }
}
