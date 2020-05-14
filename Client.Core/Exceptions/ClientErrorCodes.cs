namespace Client.Core.Exceptions.Client
{
    public class ClientErrorCodes
    {
        public static readonly string ClientNotFound = "CLIENT_NOT_FOUND";
        public static readonly string InvalidCommand = "INVALID_COMMAND";
        public static readonly string ClientApplicationStatusNotValid = "CLIENT_APPLICATION_STATUS_NOT_VALID";
        public static readonly string ClientApplicationNotFound = "CLIENT_APPLICATION_NOT_FOUND";
        public static readonly string ClientApplicationMartialStatusNotValid = "CLIENT_APPLICATION_MARTIAL_STATUS_NOT_VALID";
        public static readonly string RejectedClientApplicationNotFound = "REJECTED_CLIENT_APPLICATION_NOT_FOUND";
        public static readonly string DocumentNotFound = "DOCUMENT_NOT_FOUND";
    }
}
