using Client.Core.Exceptions.Client;
using MicroBank.Common.ExceptionHandler.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Client.Core.Commands.Client
{
    public class ClientActionCommand
    {
        public static string Approved = "APPROVED";
        public static string Declined = "DECLINED";

        public static string ValidateAndGet(string status)
        {
            if (!All.Contains(status))
            {
                throw new MicroBankException($"Client Application status: '{status}' is not valid", ClientErrorCodes.InvalidCommand, System.Net.HttpStatusCode.BadRequest);
            }
            return status;
        }

        public static IEnumerable<string> All
        {
            get
            {
                yield return Approved;
                yield return Declined;
            }
        }
    }
}
