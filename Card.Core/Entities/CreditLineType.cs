using MicroBank.Common.ExceptionHandler.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Card.Core.Entities
{
    public class CreditLineType
    {
        public static string Available = "Available";
        public static string Credit = "Credit";
        public static string Emergency = "Emergency";
        public static string PreAgreed = "PreAgreed";
        public static string Temporary = "Temporary";

        public static string ValidateAndGet(string creditLineType)
        {
            if (!All.Contains(creditLineType))
            {
                throw new MicroBankException($"Credit Line Type: '{creditLineType}' is not valid", "INVALID_CREADIT_LINE_TYPE" , System.Net.HttpStatusCode.BadRequest);
            }
            return creditLineType;
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
