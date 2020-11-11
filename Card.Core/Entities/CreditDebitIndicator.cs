using MicroBank.Common.ExceptionHandler.Exceptions;
using System.Collections.Generic;
using System.Linq;

namespace Card.Core.Entities
{
    public class CreditDebitIndicator
    {
        public static string Credit = "Credit";
        public static string Debit = "Debit";

        public static string ValidateAndGet(string creditDebitIndicator)
        {
            if (!All.Contains(creditDebitIndicator))
            {
                throw new MicroBankException($"Credot Debit Indicator: '{creditDebitIndicator}' is not valid", "INVALID_CREDIT_DEBIT_INDICATOR", System.Net.HttpStatusCode.BadRequest);
            }
            return creditDebitIndicator;
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
