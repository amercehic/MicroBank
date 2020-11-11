namespace MicroBank.Common.Identity
{
    public class MicroBankIdentityConstants
    {
        public static class Roles
        {
            public static string SystemAdmin = "SystemAdmin";
            public static string SystemUser = "SystemUser";
            public static string OrganisationAdmin = "OrgAdmin";
            public static string OrganisationUser = "OrgUser";
        }

        public static class ClaimTypes
        {
            public static string ClientId = "clientid";
        }

        public static class UserStates
        {
            public static string Invited = "INVITED";
            public static string WaitingForEmailConfirmation = "WAITING_FOR__EMAIL_CONFIRMATION";
            public static string WaitingForSMSConfirmation = "WAITING_FOR_SMS_CONFIRMATION";
            public static string WaitingForCreateOrganisation = "WAITING_FOR_CREATE_ORG";
            public static string Active = "ACTIVE";
            public static string Inactive = "INACTIVE";
        }
    }
}
