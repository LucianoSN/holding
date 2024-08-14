using Holding.Company.Domain.Company.UseCases.Commands;

namespace Holding.Tests.Domain.Company;

[TestClass]
public class CreateCompanyCommandTests
{
    private static CreateCompanyCommand Sut(
        string holdingId,
        string name = "CompanyName",
        string addressCountry = "CountryName",
        string addressPostalCode = "08000000",
        string addressState = "AddressStateName",
        string addressStreet = "AddressStreetName",
        string contactFullName = "ContatctFullName",
        string contactEmail = "valid@email.com",
        string contactPhone = "123456789"
    )
    {
        var command = new CreateCompanyCommand(
            holdingId,
            name,
            addressCountry,
            addressPostalCode,
            addressState,
            addressStreet,
            contactFullName,
            contactEmail,
            contactPhone,
            "SuperAdministrator"
        );

        return command;
    }

    [TestMethod]
    public void ShoudReturnValidWhenCommandIsValid()
    {
        var command = Sut(Guid.NewGuid().ToString());
        Assert.AreEqual(command.IsValid, true);
    }

    [TestMethod]
    public void ShoudReturnInvalidWhenCommandIsInvalid()
    {
        var command = Sut("");
        Assert.AreEqual(command.IsValid, false);
    }

    [TestMethod]
    public void ShoudReturnInvalidWhenCompanyNameIsEmpty()
    {
        var command = Sut(Guid.NewGuid().ToString(), string.Empty);
        Assert.AreEqual(command.IsValid, false);
    }
}