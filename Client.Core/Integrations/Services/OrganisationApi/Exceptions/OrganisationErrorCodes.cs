using MicroBank.Common.ExceptionHandler;

namespace Client.Core.Integrations.Services.OfficeApi.Exceptions
{
    public class OrganisationErrorCodes : ErrorCodes
    {
        public static readonly string OfficeNotFound = "OFFICE_NOT_FOUND";
        public static readonly string StaffMemberNotFound = "STAFF_MEMBER_NOT_FOUND";
    }
}
