using MicroBank.Common.ExceptionHandler.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Account.Core.Entities
{
    public class AccountSubType
    {
        public static string ChargeCard = "ChargeCard";
        public static string CreditCard = "CreditCard";
        public static string CurrentAccount = "CurrentAccount";
        public static string EMoney = "EMoney";
        public static string Loan = "Loan";
        public static string Mortgage = "Mortgage";
        public static string PrePaidCard = "PrePaidCard";
        public static string Savings = "Savings";


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
                yield return CreditCard;
                yield return CurrentAccount;
                yield return EMoney;
                yield return Loan;
                yield return Mortgage;
                yield return PrePaidCard;
                yield return Savings;
            }
        }
    }
}
