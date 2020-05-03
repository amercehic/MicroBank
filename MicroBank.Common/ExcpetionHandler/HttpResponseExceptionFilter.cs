using System.Net;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.AspNetCore.Mvc;
using MicroBank.Common.ExceptionHandler.Exceptions;

namespace MicroBank.Common.ExceptionHandler
{
    public class HttpResponseExceptionFilter : IActionFilter, IOrderedFilter
    {
        public int Order { get; set; } = int.MaxValue - 10;

        public void OnActionExecuting(ActionExecutingContext context) { }

        public void OnActionExecuted(ActionExecutedContext context)
        {
            if (context.Exception is MicroBankException exception)
            {
                HandleMicroRabbitException(context, exception);
                return;
            }

            if (context.Exception != null)
            {
#if DEBUG
                HandleDebugModeException(context);
#else
                HandleInternalServerException(context);
#endif
                return;
            }
        }

        private void HandleMicroRabbitException(ActionExecutedContext context, MicroBankException exception)
        {
            HandleException(context, exception.ResultObject, exception.StatusCode);
        }

        private void HandleDebugModeException(ActionExecutedContext context)
        {
            var resultObject = new
            {
                context.Exception.Message,
                context.Exception.StackTrace
            };

            HandleException(context, resultObject, HttpStatusCode.InternalServerError);
        }

        private void HandleInternalServerException(ActionExecutedContext context)
        {
            string resultMessage = "There has been internal server error, please try again later or contact support";
            string exceptionCode = ErrorCodes.InternalServerError;

            HandleException(context, new { Message = resultMessage, Code = exceptionCode }, HttpStatusCode.InternalServerError);
        }

        private void HandleException(ActionExecutedContext context, object resultObject, HttpStatusCode statusCode)
        {
            context.Result = new ObjectResult(resultObject)
            {
                StatusCode = (int)statusCode
            };
            context.ExceptionHandled = true;
        }

    }
}
