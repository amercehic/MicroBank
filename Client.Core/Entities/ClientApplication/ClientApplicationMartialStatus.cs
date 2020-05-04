using Client.Core.Exceptions;
using MicroBank.Common.ExceptionHandler.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Client.Core.Entities
{
    public static class ClientApplicationMartialStatus
    {
        public static string Married = "MARRIED";
        public static string Widowed = "WIDOWED";
        public static string Separated = "SEPARATED";
        public static string Divorced = "DIVORCED";
        public static string Single = "SINGLE";


        public static string ValidateAndGet(string status)
        {
            if (!All.Contains(status))
            {
                throw new MicroBankException($"Client Application status: '{status}' is not valid", ClientApplicationErrorCodes.ClientApplicationStatusNotValid, System.Net.HttpStatusCode.BadRequest);
            }
            return status;
        }

        public static IEnumerable<string> All
        {
            get
            {
                yield return Married;
                yield return Widowed;
                yield return Separated;
                yield return Divorced;
                yield return Single;
            }
        }
    }
}
