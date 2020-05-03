namespace MicroBank.Common.ExceptionHandler.Exceptions
{
    public class MicroBankUnauthorizedExeption : MicroBankException
    {
        public MicroBankUnauthorizedExeption() : base("You don't have access to this resource.", ErrorCodes.Unauhtorized, System.Net.HttpStatusCode.Unauthorized)
        {

        }
    }
}
