using Holding.Company.Domain.Company.UseCases.Commands;

namespace Holding.Tests.Domain.Company;

[TestClass]
public class FindCompanyByIdCommandTests
{
    private static FindCompanyByIdCommand Sut(
        string id,
        string role = "Administrator"
    ) => new(id, role);

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