using MicroBank.Common.ExceptionHandler.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;

namespace ChargeCardAccount.Core.Entities
{
    public class AccountStatus
    {
        public static string Pending = "PENDING";
        public static string Approved = "APPROVED";
        public static string Declined = "DECLINED";
        public static string Active = "ACTIVE";
        public static string Inactive = "INACTIVE";

        public static string ValidateAndGet(string status)
        {
            if (!All.Contains(status))
            {
                throw new MicroBankException($"Account status: '{status}' is not valid", AccountErrorCodes.AccountStatusNotValid, System.Net.HttpStatusCode.BadRequest);
            }
            return status;
        }

        public static IEnumerable<string> All
        {
            get
            {
                yield return Pending;
                yield return Approved;
                yield return Declined;
                yield return Active;
                yield return Inactive;
            }
        }
    }
}
