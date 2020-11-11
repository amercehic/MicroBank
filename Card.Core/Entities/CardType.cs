using MicroBank.Common.ExceptionHandler.Exceptions;
using System.Collections.Generic;
using System.Linq;

namespace Card.Core.Entities
{
    public class CardType
    {
        public static string AmericanExpress = "AmericanExpress";
        public static string Diners = "Diners";
        public static string Discover = "Discover";
        public static string MasterCard = "MasterCard";
        public static string VISA = "VISA";

        public static string ValidateAndGet(string cardType)
        {
            if (!All.Contains(cardType))
            {
                throw new MicroBankException($"Card Type: '{cardType}' is not valid", "INVALID_CARD_TYPE", System.Net.HttpStatusCode.BadRequest);
            }
            return cardType;
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
