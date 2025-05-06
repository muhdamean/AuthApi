using AuthApi.DTOs;
using Bogus;
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
        var faker = new Faker<CustomerDto>()
           .RuleFor(a => a.Id, f => f.IndexFaker)
           .RuleFor(a => a.AccountNumber, f => "ACC" + f.Random.ReplaceNumbers("##########"))
           .RuleFor(a => a.ClientNumber, f => "CLT" + f.Random.ReplaceNumbers("#######"))
           .RuleFor(a => a.AccountBranch, f => f.Company.CompanyName() + " Branch")
           .RuleFor(a => a.AccountName, f => f.Name.FullName())
           .RuleFor(a => a.AccountCurrencyCode, f => f.Finance.Currency().Code)
           .RuleFor(a => a.AccountType, f => f.PickRandom("Savings", "Checking", "Investment"))
           .RuleFor(a => a.AccountOpenedDate, f => f.Date.Past(5))
           .RuleFor(a => a.AccountClosedDate, f => f.Date.Future(1))
           .RuleFor(a => a.AccountStatusCode, f => f.PickRandom("OPEN", "CLOSED", "SUSPENDED"))
           .RuleFor(a => a.AccountBeneficiary, f => f.Name.FullName())
           .RuleFor(a => a.AccountBalance, f => f.Finance.Amount(0, 100000))
           .RuleFor(a => a.EntityName, f => f.Company.CompanyName())
           .RuleFor(a => a.EntityIncorporationNumber, f => "INC-" + f.Random.ReplaceNumbers("#######"))
           .RuleFor(a => a.EntityBusiness, f => f.Commerce.Department())
           .RuleFor(a => a.EntityPhoneContactType, f => "Primary")
           .RuleFor(a => a.EntityPhoneType, f => f.PickRandom("Mobile", "Office"))
           .RuleFor(a => a.EntityPhoneNumber, f => f.Phone.PhoneNumber("+1-###-###-####"))
           .RuleFor(a => a.EntityAddressType, f => "Business")
           .RuleFor(a => a.EntityAddress, f => f.Address.StreetAddress())
           .RuleFor(a => a.EntityCity, f => f.Address.City())
           .RuleFor(a => a.EntityState, f => f.Address.StateAbbr())
           .RuleFor(a => a.EntityCountryCode, f => "US")
           .RuleFor(a => a.EntityEmail, f => f.Internet.Email())
           .RuleFor(a => a.IsDeleted, f => f.Random.Bool(0.1f)); // 10% chance to be true

        // Generate 5 mock accounts
        var signatories = faker.Generate(5);

        return Ok(signatories);
    }

    [Authorize]
    [HttpGet("Signatory")]
    public IActionResult GetSignatories()
    {
        // Simulate some data
        var faker = new Faker<SignatoryDto>()
           .RuleFor(p => p.Id, f => f.IndexFaker)
           .RuleFor(p => p.AccountNumber, f => "ACC" + f.Random.ReplaceNumbers("##########"))
           .RuleFor(p => p.ClientNumber, f => "CLT" + f.Random.ReplaceNumbers("#######"))
           .RuleFor(p => p.PersonGender, f => f.PickRandom("Male", "Female"))
           .RuleFor(p => p.PersonTitle, (f, p) => p.PersonGender == "Male" ? "Mr." : "Ms.")
           .RuleFor(p => p.PersonFirstName, (f, p) => p.PersonGender == "Male" ? f.Name.FirstName(Bogus.DataSets.Name.Gender.Male) : f.Name.FirstName(Bogus.DataSets.Name.Gender.Female))
           .RuleFor(p => p.PersonLastName, f => f.Name.LastName())
           .RuleFor(p => p.PersonBirthDate, f => f.Date.Past(40, DateTime.Today.AddYears(-18)))
           .RuleFor(p => p.PersonPassportNumber, f => f.Random.Replace("A######"))
           .RuleFor(p => p.PersonPassportCountry, f => f.Address.CountryCode())
           .RuleFor(p => p.PersonIdType, f => f.PickRandom("National ID", "Driver's License", "Passport"))
           .RuleFor(p => p.PersonIdNumber, f => f.Random.ReplaceNumbers("#########"))
           .RuleFor(p => p.PersonIssueCountry, f => f.Address.CountryCode())
           .RuleFor(p => p.PersonNationality, f => f.Address.Country())
           .RuleFor(p => p.PersonPhoneNumber, f => f.Phone.PhoneNumber("+1-###-###-####"))
           .RuleFor(p => p.PersonAddress, f => f.Address.StreetAddress())
           .RuleFor(p => p.PersonCity, f => f.Address.City())
           .RuleFor(p => p.PersonState, f => f.Address.StateAbbr())
           .RuleFor(p => p.PersonEmail, (f, p) => f.Internet.Email(p.PersonFirstName, p.PersonLastName))
           .RuleFor(p => p.PersonOccupation, f => f.Name.JobTitle())
           .RuleFor(p => p.PersonTaxNumber, f => f.Random.ReplaceNumbers("##########"))
           .RuleFor(p => p.IssueDate, f => f.Date.Past(5))
           .RuleFor(p => p.IsDeleted, f => f.Random.Bool(0.1f)); // 10% chance

        // Generate and print 3 mock entries
        var signatories = faker.Generate(5);
        return Ok(signatories);
    }

    [Authorize]
    [HttpGet("Transactions")]
    public IActionResult GetTransactions()
    {
        // Simulate some data
        var faker = new Faker<TransactionDto>()
           .RuleFor(t => t.Id, f => f.IndexFaker)
           .RuleFor(t => t.AccountNumber, f => "ACC" + f.Random.ReplaceNumbers("##########"))
           .RuleFor(t => t.TransactionNumber, f => "TXN" + f.Random.ReplaceNumbers("########"))
           .RuleFor(t => t.Location, f => f.Address.City())
           .RuleFor(t => t.TransactionDate, f => f.Date.Recent())
           .RuleFor(t => t.Teller, f => f.Name.FullName())
           .RuleFor(t => t.IsAuthorized, f => f.PickRandom("Yes", "No"))
           .RuleFor(t => t.IsLateDeposit, f => f.Random.Bool(0.2f)) // 20% chance
           .RuleFor(t => t.TransactionDescription, f => f.Lorem.Sentence())
           .RuleFor(t => t.PostingDate, (f, t) => t.TransactionDate.AddDays(1))
           .RuleFor(t => t.ValueDate, (f, t) => t.TransactionDate)
           .RuleFor(t => t.TransactionModeCode, f => f.PickRandom("ATM", "Online", "Branch"))
           .RuleFor(t => t.AmountLocal, f => f.Finance.Amount(10, 10000))
           .RuleFor(t => t.SourceClientType, f => f.PickRandom("Individual", "Corporate"))
           .RuleFor(t => t.SourceType, f => f.PickRandom("Account", "Card"))
           .RuleFor(t => t.SourceFundsCode, f => f.Random.AlphaNumeric(6))
           .RuleFor(t => t.SourceCurrencyCode, f => "USD")
           .RuleFor(t => t.SourceForeignAmount, f => f.Finance.Amount(10, 10000))
           .RuleFor(t => t.SourceExchangeRate, f => f.Random.Decimal(0.5m, 1.5m))
           .RuleFor(t => t.SourceCountry, f => f.Address.CountryCode())
           .RuleFor(t => t.SourceInstitutionCode, f => "BANK" + f.Random.ReplaceNumbers("###"))
           .RuleFor(t => t.SourceAccountNumber, f => f.Finance.Account())
           .RuleFor(t => t.SourceAccountName, f => f.Name.FullName())
           .RuleFor(t => t.SourcePersonFirstName, f => f.Name.FirstName())
           .RuleFor(t => t.SourcePersonLastName, f => f.Name.LastName())
           .RuleFor(t => t.SourceEntityName, f => f.Company.CompanyName())
           .RuleFor(t => t.DestinationClientType, f => f.PickRandom("Individual", "Corporate"))
           .RuleFor(t => t.DestinationType, f => f.PickRandom("Account", "Card"))
           .RuleFor(t => t.DestinationFundsCode, f => f.Random.AlphaNumeric(6))
           .RuleFor(t => t.DestinationCurrencyCode, f => "EUR")
           .RuleFor(t => t.DestinationForeignAmount, f => f.Finance.Amount(10, 10000))
           .RuleFor(t => t.DestinationExchangeRate, f => f.Random.Decimal(0.5m, 1.5m))
           .RuleFor(t => t.DestinationCountry, f => f.Address.CountryCode())
           .RuleFor(t => t.DestinationInstitutionCode, f => "BANK" + f.Random.ReplaceNumbers("###"))
           .RuleFor(t => t.DestinationAccountNumber, f => f.Finance.Account())
           .RuleFor(t => t.DestinationAccountName, f => f.Name.FullName())
           .RuleFor(t => t.DestinationPersonFirstName, f => f.Name.FirstName())
           .RuleFor(t => t.DestinationPersonLastName, f => f.Name.LastName())
           .RuleFor(t => t.DestinationEntityName, f => f.Company.CompanyName())
           .RuleFor(t => t.TransactionType, f => f.PickRandom("Credit", "Debit", "Transfer"))
           .RuleFor(t => t.IsDeleted, f => f.Random.Bool(0.1f));

        var transactions = faker.Generate(5);

        return Ok(transactions);
    }
}
