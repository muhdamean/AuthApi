namespace AuthApi.DTOs
{
    public class TransactionDto
    {
        public int Id { get; set; }
        public string? AccountNumber { get; set; }
        public string? TransactionNumber { get; set; }
        public string? Location { get; set; }
        public DateTime TransactionDate { get; set; }
        public string? Teller { get; set; }
        public string? IsAuthorized { get; set; }
        public bool IsLateDeposit { get; set; }
        public string? TransactionDescription { get; set; }
        public DateTime PostingDate { get; set; }
        public DateTime ValueDate { get; set; }
        public string? TransactionModeCode { get; set; }
        public decimal AmountLocal { get; set; }
        public string? SourceClientType { get; set; }
        public string? SourceType { get; set; }
        public string? SourceFundsCode { get; set; }
        public string? SourceCurrencyCode { get; set; }
        public decimal SourceForeignAmount { get; set; }
        public decimal SourceExchangeRate { get; set; }
        public string? SourceCountry { get; set; }
        public string? SourceInstitutionCode { get; set; }
        public string? SourceAccountNumber { get; set; }
        public string? SourceAccountName { get; set; }
        public string? SourcePersonFirstName { get; set; }
        public string? SourcePersonLastName { get; set; }
        public string? SourceEntityName { get; set; }
        public string? DestinationClientType { get; set; }
        public string? DestinationType { get; set; }
        public string? DestinationFundsCode { get; set; }
        public string? DestinationCurrencyCode { get; set; }
        public decimal DestinationForeignAmount { get; set; }
        public decimal DestinationExchangeRate { get; set; }
        public string? DestinationCountry { get; set; }
        public string? DestinationInstitutionCode { get; set; }
        public string? DestinationAccountNumber { get; set; }
        public string? DestinationAccountName { get; set; }
        public string? DestinationPersonFirstName { get; set; }
        public string? DestinationPersonLastName { get; set; }
        public string? DestinationEntityName { get; set; }
        public string? TransactionType { get; set; }
        public bool IsDeleted { get; set; }
    }
}
