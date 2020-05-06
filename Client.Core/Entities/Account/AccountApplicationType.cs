using Client.Core.Exceptions.Account;
using MicroBank.Common.ExceptionHandler.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Client.Core.Entities
{
    public class AccountApplicationType
    {
        public static string BasicChecking = "BASIC_CHECKING";
        public static string Savings = "SAVINGS";
        public static string InterestBearingChecking = "INTEREST_BEARING_CHECKING";
        public static string MoneyMarketAccounts = "MONEY'MARKET";
        public static string CD = "CERTIFICATE_OF_DEPOSIT";
        public static string InvestmentRetirement = "INVESTMENT_TERIREMENT";
        public static string Brokerage = "BROKERAGE";

        public static string ValidateAndGet(string status)
        {
            if (!All.Contains(status))
            {
                throw new MicroBankException($"Client Application status: '{status}' is not valid", AccountApplicationErrorCodes.AccountApplicationTypeNotValid, System.Net.HttpStatusCode.BadRequest);
            }
            return status;
        }

        public static IEnumerable<string> All
        {
            get
            {
                yield return BasicChecking;
                yield return Savings;
                yield return InterestBearingChecking;
                yield return MoneyMarketAccounts;
                yield return CD;
                yield return InvestmentRetirement;
                yield return Brokerage;
            }
        }
    }
}
