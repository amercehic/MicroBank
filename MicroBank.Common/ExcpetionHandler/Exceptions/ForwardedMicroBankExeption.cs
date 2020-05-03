using System;
using System.Collections.Generic;
using System.Net;
using System.Text;

namespace MicroBank.Common.ExceptionHandler.Exceptions
{
    /// <summary>
    /// This exceptions is for mapping exceptions from another services
    /// </summary>
    public class ForwardedMicroBankExeption : MicroBankException
    {
        public ForwardedMicroBankExeption(string message, string code, HttpStatusCode httpStatusCode) : base(message, code, httpStatusCode)
        {

        }
    }
}
