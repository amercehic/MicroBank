using MicroBank.Common.ExceptionHandler.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;

namespace ChargeCardAccount.Core.Entities
{
    public class CardType
    {
        public static string AmericanExpress = "AmericanExpress";
        public static string Diners = "Diners";
        public static string Discover = "Discover";
        public static string MasterCard = "MasterCard";
        public static string VISA = "VISA";

        public static string ValidateAndGet(string status)
        {
            if (!All.Contains(status))
            {
                throw new MicroBankException($"Client Application status: '{status}' is not valid", AccountErrorCodes.InvalidCardType, System.Net.HttpStatusCode.BadRequest);
            }
            return status;
        }

        public static IEnumerable<string> All
        {
            get
            {
                yield return AmericanExpress;
                yield return Diners;
                yield return Discover;
                yield return MasterCard;
                yield return VISA;
            }
        }
    }
}
