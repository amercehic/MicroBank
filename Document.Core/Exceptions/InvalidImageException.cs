using MicroBank.Common.ExceptionHandler.Exceptions;

namespace Document.Core.Exceptions
{
    public class InvalidImageException : MicroBankException
    {
        public InvalidImageException(string contentType)
            : base($"Content type: {contentType} was not supported.",
          DocumentErrorCodes.InvalidContentType,
          System.Net.HttpStatusCode.BadRequest)
        { }

        public InvalidImageException(long length, long maximum)
            : base($"File is to large ({length} bytes). Maximum allowed is: {maximum} bytes.",
                  DocumentErrorCodes.FileIsTooLarge,
                  System.Net.HttpStatusCode.BadRequest)
        { }
    }
}
