using MicroBank.Common.ExceptionHandler.Exceptions;
using System.Collections.Generic;
using System.Linq;

namespace ChargeCardAccount.Core.Entities
{
    public class CreditDebitIndicator
    {
        public static string Credit = "Credit";
        public static string Debit = "Debit";

        public static string ValidateAndGet(string status)
        {
            if (!All.Contains(status))
            {
                throw new MicroBankException($"Client Application status: '{status}' is not valid", AccountErrorCodes.CreditDebitIndicatorNotValid, System.Net.HttpStatusCode.BadRequest);
            }
            return status;
        }

        public static IEnumerable<string> All
        {
            get
            {
                yield return Credit;
                yield return Debit;
            }
        }
    }
}
