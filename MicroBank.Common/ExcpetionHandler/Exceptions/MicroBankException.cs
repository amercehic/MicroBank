using System;
using System.Collections.Generic;
using System.Net;
using System.Text;

namespace MicroBank.Common.ExceptionHandler.Exceptions
{
    public class MicroBankException : Exception
    {
        public string Code { get; private set; }

        public HttpStatusCode StatusCode { get; set; }

        public MicroBankException(string message, string code, HttpStatusCode httpStatusCode = HttpStatusCode.InternalServerError) : base(message)
        {
            Code = code;
            StatusCode = httpStatusCode;
        }

        public object ResultObject { get { return new { Message, Code }; } }
    }
}
