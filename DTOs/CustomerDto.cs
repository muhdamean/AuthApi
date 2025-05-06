namespace AuthApi.DTOs
{
    public class CustomerDto
    {
        public int Id { get; set; }
        public string? AccountNumber { get; set; }
        public string? ClientNumber { get; set; }
        public string? AccountBranch { get; set; }
        public string? AccountName { get; set; }
        public string? AccountCurrencyCode { get; set; }
        public string? AccountType { get; set; }
        public DateTime AccountOpenedDate { get; set; }
        public DateTime AccountClosedDate { get; set; }
        public string? AccountStatusCode { get; set; }
        public string? AccountBeneficiary { get; set; }
        public decimal AccountBalance { get; set; }
        public string? EntityName { get; set; }
        public string? EntityIncorporationNumber { get; set; }
        public string? EntityBusiness { get; set; }
        public string? EntityPhoneContactType { get; set; }
        public string? EntityPhoneType { get; set; }
        public string? EntityPhoneNumber { get; set; }
        public string? EntityAddressType { get; set; }
        public string? EntityAddress { get; set; }
        public string? EntityCity { get; set; }
        public string? EntityState { get; set; }
        public string? EntityCountryCode { get; set; }
        public string? EntityEmail { get; set; }
        public bool IsDeleted { get; set; }
    }
}
