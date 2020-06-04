using MicroBank.Common.ExceptionHandler.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;

namespace ChargeCardAccount.Core.Entities
{
    public class CreditLineType
    {
        public static string Available = "Available";
        public static string Credit = "Credit";
        public static string Emergency = "Emergency";
        public static string PreAgreed = "PreAgreed";
        public static string Temporary = "Temporary";

        public static string ValidateAndGet(string status)
        {
            if (!All.Contains(status))
            {
                throw new MicroBankException($"Client Application status: '{status}' is not valid", AccountErrorCodes.InvalidCreditLineType, System.Net.HttpStatusCode.BadRequest);
            }
            return status;
        }

        public static IEnumerable<string> All
        {
            get
            {
                yield return Available;
                yield return Credit;
                yield return Emergency;
                yield return PreAgreed;
                yield return Temporary;
            }
        }
    }
}
