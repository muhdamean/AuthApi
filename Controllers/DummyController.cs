using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace AuthApi.Controllers;

[Route("SoftAML/api/")]
[ApiController]
public class DummyController : ControllerBase
{
    public DummyController() { }

    [Authorize]
    [HttpGet("Customers")]
    public IActionResult GetCustomers()
    {
        // Simulate some data
        var signatories = @"[
  {
    ""id"": 1,
    ""accountNumber"": ""ACC123456789"",
    ""clientNumber"": ""CLT0001"",
    ""accountBranch"": ""Main Branch"",
    ""accountName"": ""John Doe"",
    ""accountCurrencyCode"": ""USD"",
    ""accountType"": ""Checking"",
    ""accountOpenedDate"": ""2022-01-15T09:30:00Z"",
    ""accountClosedDate"": ""2025-03-11T12:50:26.259Z"",
    ""accountStatusCode"": ""ACTIVE"",
    ""accountBeneficiary"": ""Jane Doe"",
    ""accountBalance"": 10500.75,
    ""entityName"": ""Doe Enterprises LLC"",
    ""entityIncorporationNumber"": ""INC789456123"",
    ""entityBusiness"": ""Consulting"",
    ""entityPhoneContactType"": ""Mobile"",
    ""entityPhoneType"": ""Cell"",
    ""entityPhoneNumber"": ""+1-555-0123"",
    ""entityAddressType"": ""Business"",
    ""entityAddress"": ""123 Main St"",
    ""entityCity"": ""New York"",
    ""entityState"": ""NY"",
    ""entityCountryCode"": ""US"",
    ""entityEmail"": ""contact@doeenterprises.com"",
    ""isDeleted"": false
  },
  {
    ""id"": 2,
    ""accountNumber"": ""ACC987654321"",
    ""clientNumber"": ""CLT0002"",
    ""accountBranch"": ""Downtown Branch"",
    ""accountName"": ""Alice Smith"",
    ""accountCurrencyCode"": ""EUR"",
    ""accountType"": ""Savings"",
    ""accountOpenedDate"": ""2021-07-20T14:45:00Z"",
    ""accountClosedDate"": ""2025-03-11T12:50:26.259Z"",
    ""accountStatusCode"": ""INACTIVE"",
    ""accountBeneficiary"": ""Bob Smith"",
    ""accountBalance"": 20450.00,
    ""entityName"": ""Smith Ventures"",
    ""entityIncorporationNumber"": ""INC654321987"",
    ""entityBusiness"": ""Retail"",
    ""entityPhoneContactType"": ""Office"",
    ""entityPhoneType"": ""Landline"",
    ""entityPhoneNumber"": ""+49-89-123456"",
    ""entityAddressType"": ""Registered"",
    ""entityAddress"": ""456 Elm St"",
    ""entityCity"": ""Munich"",
    ""entityState"": ""BY"",
    ""entityCountryCode"": ""DE"",
    ""entityEmail"": ""info@smithventures.de"",
    ""isDeleted"": false
  },
  {
    ""id"": 3,
    ""accountNumber"": ""ACC564738291"",
    ""clientNumber"": ""CLT0003"",
    ""accountBranch"": ""Suburban Branch"",
    ""accountName"": ""Carlos Rivera"",
    ""accountCurrencyCode"": ""MXN"",
    ""accountType"": ""Business"",
    ""accountOpenedDate"": ""2020-05-10T10:00:00Z"",
    ""accountClosedDate"": ""2025-03-11T12:50:26.259Z"",
    ""accountStatusCode"": ""CLOSED"",
    ""accountBeneficiary"": ""Ana Rivera"",
    ""accountBalance"": 0.00,
    ""entityName"": ""Rivera Imports"",
    ""entityIncorporationNumber"": ""INC321654987"",
    ""entityBusiness"": ""Import/Export"",
    ""entityPhoneContactType"": ""Mobile"",
    ""entityPhoneType"": ""Cell"",
    ""entityPhoneNumber"": ""+52-55-98765432"",
    ""entityAddressType"": ""Head Office"",
    ""entityAddress"": ""789 Oak St"",
    ""entityCity"": ""Mexico City"",
    ""entityState"": ""CDMX"",
    ""entityCountryCode"": ""MX"",
    ""entityEmail"": ""admin@riveraimports.mx"",
    ""isDeleted"": true
  }
]
";

        return Ok(signatories);
    }

    [Authorize]
    [HttpGet("Signatory")]
    public IActionResult GetSignatories()
    {
        // Simulate some data
        var signatories = @"[
  {
    ""id"": 1,
    ""accountNumber"": ""ACC100001"",
    ""clientNumber"": ""CLT90001"",
    ""personTitle"": ""Mr."",
    ""personFirstName"": ""John"",
    ""personLastName"": ""Doe"",
    ""personGender"": ""Male"",
    ""personBirthDate"": ""1985-04-12T00:00:00Z"",
    ""personPassportNumber"": ""X1234567"",
    ""personPassportCountry"": ""US"",
    ""personIdType"": ""Driver's License"",
    ""personIdNumber"": ""D987654321"",
    ""personIssueCountry"": ""US"",
    ""personNationality"": ""American"",
    ""personPhoneNumber"": ""+1-202-555-0173"",
    ""personAddress"": ""123 Elm Street"",
    ""personCity"": ""New York"",
    ""personState"": ""NY"",
    ""personEmail"": ""john.doe@example.com"",
    ""personOccupation"": ""Engineer"",
    ""personTaxNumber"": ""TAX1234567"",
    ""issueDate"": ""2015-06-30T00:00:00Z"",
    ""isDeleted"": false
  },
  {
    ""id"": 2,
    ""accountNumber"": ""ACC100002"",
    ""clientNumber"": ""CLT90002"",
    ""personTitle"": ""Ms."",
    ""personFirstName"": ""Anna"",
    ""personLastName"": ""Martinez"",
    ""personGender"": ""Female"",
    ""personBirthDate"": ""1990-09-23T00:00:00Z"",
    ""personPassportNumber"": ""M7654321"",
    ""personPassportCountry"": ""MX"",
    ""personIdType"": ""National ID"",
    ""personIdNumber"": ""MX123456789"",
    ""personIssueCountry"": ""MX"",
    ""personNationality"": ""Mexican"",
    ""personPhoneNumber"": ""+52-55-33445566"",
    ""personAddress"": ""456 Avenida Reforma"",
    ""personCity"": ""Mexico City"",
    ""personState"": ""CDMX"",
    ""personEmail"": ""anna.martinez@example.mx"",
    ""personOccupation"": ""Lawyer"",
    ""personTaxNumber"": ""RFC9876543"",
    ""issueDate"": ""2017-03-15T00:00:00Z"",
    ""isDeleted"": false
  },
  {
    ""id"": 3,
    ""accountNumber"": ""ACC100003"",
    ""clientNumber"": ""CLT90003"",
    ""personTitle"": ""Dr."",
    ""personFirstName"": ""Li"",
    ""personLastName"": ""Wei"",
    ""personGender"": ""Non-binary"",
    ""personBirthDate"": ""1978-12-05T00:00:00Z"",
    ""personPassportNumber"": ""CN99887766"",
    ""personPassportCountry"": ""CN"",
    ""personIdType"": ""Passport"",
    ""personIdNumber"": ""P123456789"",
    ""personIssueCountry"": ""CN"",
    ""personNationality"": ""Chinese"",
    ""personPhoneNumber"": ""+86-10-66554433"",
    ""personAddress"": ""789 Beijing Rd"",
    ""personCity"": ""Beijing"",
    ""personState"": ""Beijing"",
    ""personEmail"": ""li.wei@example.cn"",
    ""personOccupation"": ""Researcher"",
    ""personTaxNumber"": ""TAXCN556677"",
    ""issueDate"": ""2012-10-10T00:00:00Z"",
    ""isDeleted"": true
  }
]
";

        return Ok(signatories);
    }

    [Authorize]
    [HttpGet("Transactions")]
    public IActionResult GetTransactions()
    {
        // Simulate some data
        var transactions = @"[
  {
    ""id"": 1,
    ""accountNumber"": ""ACC200001"",
    ""transactionNumber"": ""TXN000001"",
    ""location"": ""New York Branch"",
    ""transactionDate"": ""2025-03-10T10:30:00Z"",
    ""teller"": ""Teller001"",
    ""isAuthorized"": ""Yes"",
    ""isLateDeposit"": false,
    ""transactionDescription"": ""ATM Cash Withdrawal"",
    ""postingDate"": ""2025-03-10T12:00:00Z"",
    ""valueDate"": ""2025-03-10T12:00:00Z"",
    ""transactionModeCode"": ""ATM"",
    ""amountLocal"": 250.00,
    ""sourceClientType"": ""Individual"",
    ""sourceType"": ""Customer"",
    ""sourceFundsCode"": ""CHK"",
    ""sourceCurrencyCode"": ""USD"",
    ""sourceForeignAmount"": 0,
    ""sourceExchangeRate"": 1,
    ""sourceCountry"": ""US"",
    ""sourceInstitutionCode"": ""BANK001"",
    ""sourceAccountNumber"": ""SRC10001"",
    ""sourceAccountName"": ""John Doe"",
    ""sourcePersonFirstName"": ""John"",
    ""sourcePersonLastName"": ""Doe"",
    ""sourceEntityName"": """",
    ""destinationClientType"": ""Bank"",
    ""destinationType"": ""ATM"",
    ""destinationFundsCode"": ""ATM"",
    ""destinationCurrencyCode"": ""USD"",
    ""destinationForeignAmount"": 0,
    ""destinationExchangeRate"": 1,
    ""destinationCountry"": ""US"",
    ""destinationInstitutionCode"": ""BANK001"",
    ""destinationAccountNumber"": ""ATM0001"",
    ""destinationAccountName"": ""ATM Withdrawal"",
    ""destinationPersonFirstName"": """",
    ""destinationPersonLastName"": """",
    ""destinationEntityName"": """",
    ""transactionType"": ""Withdrawal"",
    ""isDeleted"": false
  },
  {
    ""id"": 2,
    ""accountNumber"": ""ACC200002"",
    ""transactionNumber"": ""TXN000002"",
    ""location"": ""Online Banking"",
    ""transactionDate"": ""2025-03-09T08:15:00Z"",
    ""teller"": ""System"",
    ""isAuthorized"": ""Yes"",
    ""isLateDeposit"": false,
    ""transactionDescription"": ""Salary Deposit"",
    ""postingDate"": ""2025-03-09T09:00:00Z"",
    ""valueDate"": ""2025-03-09T09:00:00Z"",
    ""transactionModeCode"": ""EFT"",
    ""amountLocal"": 3200.00,
    ""sourceClientType"": ""Business"",
    ""sourceType"": ""Employer"",
    ""sourceFundsCode"": ""SAL"",
    ""sourceCurrencyCode"": ""USD"",
    ""sourceForeignAmount"": 0,
    ""sourceExchangeRate"": 1,
    ""sourceCountry"": ""US"",
    ""sourceInstitutionCode"": ""BANK002"",
    ""sourceAccountNumber"": ""SRC20001"",
    ""sourceAccountName"": ""TechCorp Inc."",
    ""sourcePersonFirstName"": """",
    ""sourcePersonLastName"": """",
    ""sourceEntityName"": ""TechCorp Inc."",
    ""destinationClientType"": ""Individual"",
    ""destinationType"": ""Employee"",
    ""destinationFundsCode"": ""CHK"",
    ""destinationCurrencyCode"": ""USD"",
    ""destinationForeignAmount"": 0,
    ""destinationExchangeRate"": 1,
    ""destinationCountry"": ""US"",
    ""destinationInstitutionCode"": ""BANK003"",
    ""destinationAccountNumber"": ""DST10001"",
    ""destinationAccountName"": ""Alice Smith"",
    ""destinationPersonFirstName"": ""Alice"",
    ""destinationPersonLastName"": ""Smith"",
    ""destinationEntityName"": """",
    ""transactionType"": ""Deposit"",
    ""isDeleted"": false
  },
  {
    ""id"": 3,
    ""accountNumber"": ""ACC200003"",
    ""transactionNumber"": ""TXN000003"",
    ""location"": ""London Branch"",
    ""transactionDate"": ""2025-03-08T16:45:00Z"",
    ""teller"": ""Teller003"",
    ""isAuthorized"": ""No"",
    ""isLateDeposit"": true,
    ""transactionDescription"": ""International Transfer"",
    ""postingDate"": ""2025-03-10T10:00:00Z"",
    ""valueDate"": ""2025-03-10T10:00:00Z"",
    ""transactionModeCode"": ""SWIFT"",
    ""amountLocal"": 1500.00,
    ""sourceClientType"": ""Individual"",
    ""sourceType"": ""Customer"",
    ""sourceFundsCode"": ""SAV"",
    ""sourceCurrencyCode"": ""GBP"",
    ""sourceForeignAmount"": 1500.00,
    ""sourceExchangeRate"": 1.3,
    ""sourceCountry"": ""UK"",
    ""sourceInstitutionCode"": ""UKB001"",
    ""sourceAccountNumber"": ""SRC30001"",
    ""sourceAccountName"": ""Emma Brown"",
    ""sourcePersonFirstName"": ""Emma"",
    ""sourcePersonLastName"": ""Brown"",
    ""sourceEntityName"": """",
    ""destinationClientType"": ""Individual"",
    ""destinationType"": ""Recipient"",
    ""destinationFundsCode"": ""CHK"",
    ""destinationCurrencyCode"": ""USD"",
    ""destinationForeignAmount"": 1950.00,
    ""destinationExchangeRate"": 1.3,
    ""destinationCountry"": ""US"",
    ""destinationInstitutionCode"": ""USB001"",
    ""destinationAccountNumber"": ""DST20001"",
    ""destinationAccountName"": ""Carlos Rivera"",
    ""destinationPersonFirstName"": ""Carlos"",
    ""destinationPersonLastName"": ""Rivera"",
    ""destinationEntityName"": """",
    ""transactionType"": ""Transfer"",
    ""isDeleted"": true
  }
]
";

        return Ok(transactions);
    }
}
