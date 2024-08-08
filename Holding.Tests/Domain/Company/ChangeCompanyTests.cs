using Holding.Company.Domain.Company.UseCases.Commands;

namespace Holding.Tests.Domain.Company;

[TestClass]
public class ChangeCompanyTests
{
    private static ChangeCompanyCommand Sut(
        string id,
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
        var command = new ChangeCompanyCommand(
            id,
            name,
            addressCountry,
            addressPostalCode,
            addressState,
            addressStreet,
            contactFullName,
            contactEmail,
            contactPhone
        );

        return command;
    }

    [TestMethod]
    public void ShoudReturnInvalidWhenNameIsInvalid()
    {
        var command = Sut(Guid.NewGuid().ToString(), "");
        Assert.AreEqual(command.IsValid, false);
    }
   
   [TestMethod]
   public void ShoudReturnInvalidWhenGuidIsInvalid()
   {
       var command = Sut("00-93343-00");
       Assert.AreEqual(command.IsValid, false);
   }
   
   [TestMethod]
   public void ShoudReturnValidWhenCommandIsValid()
   {
       var command = Sut(Guid.NewGuid().ToString());
       Assert.AreEqual(command.IsValid, true);
   }
}