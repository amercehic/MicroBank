namespace MicroBank.Common.ExceptionHandler.Exceptions
{
    public class MicroBankInternalServerErrorException : MicroBankException
    {
        public MicroBankInternalServerErrorException() : base("There has been internal server error, please try again later or contact support", ErrorCodes.InternalServerError, System.Net.HttpStatusCode.InternalServerError)

        {

        }
    }
}
