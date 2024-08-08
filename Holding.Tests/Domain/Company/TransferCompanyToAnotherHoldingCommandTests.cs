using Holding.Company.Domain.Company.UseCases.Commands;

namespace Holding.Tests.Domain.Company;

[TestClass]
public class TransferCompanyToAnotherHoldingCommandTests
{
    private static TransferCompanyToAnotherHoldingCommand Sut(string companyId, string holdingId)
    {
        return new TransferCompanyToAnotherHoldingCommand(companyId, holdingId);
    }

    [TestMethod]
    public void ShoudReturnInvalidIfCompanyIdIsInvalid()
    {
        var command = Sut("", Guid.NewGuid().ToString());
        Assert.AreEqual(command.IsValid, false);
    }

    [TestMethod]
    public void ShoudReturnInvalidIfHoldingIdIsInvalid()
    {
        var command = Sut(Guid.NewGuid().ToString(), "");
        Assert.AreEqual(command.IsValid, false);
    }

    [TestMethod]
    public void ShoudReturnValidTransferCompanyToAnotherHoldingCommnand()
    {
        var command = Sut(Guid.NewGuid().ToString(), Guid.NewGuid().ToString());
        Assert.AreEqual(command.IsValid, true);
    }
}