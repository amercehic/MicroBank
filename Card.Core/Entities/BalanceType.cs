using MicroBank.Common.ExceptionHandler.Exceptions;
using System.Collections.Generic;
using System.Linq;

namespace Card.Core.Entities
{
    public class BalanceType
    {
        public static string ClosingAvailable = "ClosingAvailable";
        public static string ClosingBooked = "ClosingBooked";
        public static string ClosingCleared = "ClosingCleared";
        public static string Expected = "Expected";
        public static string ForwardAvailable = "ForwardAvailable";
        public static string Information = "Information";
        public static string InterimAvailable = "InterimAvailable";
        public static string InterimBooked = "InterimBooked";
        public static string InterimCleared = "InterimCleared";
        public static string OpeningAvailable = "OpeningAvailable";
        public static string OpeningBooked = "OpeningBooked";
        public static string OpeningCleared = "OpeningCleared";
        public static string PreviouslyClosedBooked = "PreviouslyClosedBooked";

        public static string ValidateAndGet(string balanceType)
        {
            if (!All.Contains(balanceType))
            {
                throw new MicroBankException($"Balance Type: '{balanceType}' is not valid", "INVALID_BALANCE_TYPE", System.Net.HttpStatusCode.BadRequest);
            }
            return balanceType;
        }

        public static IEnumerable<string> All
        {
            get
            {
                yield return ClosingAvailable;
                yield return ClosingBooked;
                yield return ClosingCleared;
                yield return Expected;
                yield return ForwardAvailable;
                yield return Information;
                yield return InterimAvailable;
                yield return InterimBooked;
                yield return InterimCleared;
                yield return OpeningAvailable;
                yield return OpeningBooked;
                yield return OpeningCleared;
                yield return PreviouslyClosedBooked;
            }
        }
    }
}
