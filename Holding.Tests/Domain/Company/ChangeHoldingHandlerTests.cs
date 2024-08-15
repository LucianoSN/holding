using Holding.Company.Domain.Company.UseCases.Commands;
using MediatR;

namespace Holding.Tests.Domain.Company;

[TestClass]
public class ChangeHoldingHandlerTests
{
    private IMediator _bus;

    public ChangeHoldingHandlerTests()
    {
        _bus = DependencyInjection.Get<IMediator>();
    }

    private async Task<Holding.Company.Domain.Company.Entities.Holding> CreateHoldingSut(
        string name,
        string description = "",
        string role =  "Master"
    )
    {
        var command = new CreateHoldingCommand(name, description, role);
        var result = await _bus.Send(command);
        return result.Data as Holding.Company.Domain.Company.Entities.Holding;
    }

    [TestMethod]
    public async Task ShoudReturnValidWhenUpdateIsValid()
    {
        // Arrange
        var holding = await CreateHoldingSut("Holding", "Holding Description");
        var command = new ChangeHoldingCommand(
            holding.Id.ToString(),
            "ChangeHoldingName",
            "Change Holding Description",
            "Master"
        );

        // Act
        var result = await _bus.Send(command);
        var changed = result.Data as Holding.Company.Domain.Company.Entities.Holding;

        // Assert
        Assert.AreEqual(command.IsValid, true);
        Assert.AreEqual(result.Success, true);
        Assert.AreEqual(holding.Id, changed.Id);
        Assert.AreEqual(holding.Name, changed.Name);
        Assert.AreEqual(holding.Description, changed.Description);
    }
}