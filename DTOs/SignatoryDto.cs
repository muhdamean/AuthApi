namespace AuthApi.DTOs
{
    public class SignatoryDto
    {
        public int Id { get; set; }
        public string? AccountNumber { get; set; }
        public string? ClientNumber { get; set; }
        public string? PersonTitle { get; set; }
        public string? PersonFirstName { get; set; }
        public string? PersonLastName { get; set; }
        public string? PersonGender { get; set; }
        public DateTime PersonBirthDate { get; set; }
        public string? PersonPassportNumber { get; set; }
        public string? PersonPassportCountry { get; set; }
        public string? PersonIdType { get; set; }
        public string? PersonIdNumber { get; set; }
        public string? PersonIssueCountry { get; set; }
        public string? PersonNationality { get; set; }
        public string? PersonPhoneNumber { get; set; }
        public string? PersonAddress { get; set; }
        public string? PersonCity { get; set; }
        public string? PersonState { get; set; }
        public string? PersonEmail { get; set; }
        public string? PersonOccupation { get; set; }
        public string? PersonTaxNumber { get; set; }
        public DateTime IssueDate { get; set; }
        public bool IsDeleted { get; set; }
    }
}
