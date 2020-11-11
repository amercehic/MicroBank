namespace ChargeCardAccount.Core.Entities
{
    public class AccountErrorCodes
    {
        public static readonly string AccountApplicationTypeNotValid = "ACCOUNT_TYPE_NOT_VALID";
        public static readonly string AccountSubTypeNotValid = "ACCOUNT_SUB_TYPE_NOT_VALID";
        public static readonly string AccountApplicationNotFound = "ACCOUNT_APPLICATION_NOT_FOUND";
        public static readonly string AccountStatusNotValid = "ACCOUNT_STATUS_NOT_VALID";
        public static readonly string InvalidCreditLineType = "INVALID_CREDIT_LINE_TYPE";
        public static readonly string InvalidCardType = "INVALID_CARD_TYPE";
        public static readonly string BalanceTypeNotValid = "BALANCE_TYPE_NOT_VALID"; 
        public static readonly string CreditDebitIndicatorNotValid = "CREDIT_DEBIT_INDICATOR_NOT_VALID";
    }
}
