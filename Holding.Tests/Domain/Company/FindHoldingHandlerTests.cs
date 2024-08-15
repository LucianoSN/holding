using Holding.Company.Domain.Company.UseCases.Commands;
using MediatR;

namespace Holding.Tests.Domain.Company;

[TestClass]
public class FindHoldingHandlerTests
{
    private IMediator _bus;

    public FindHoldingHandlerTests()
    {
        _bus = DependencyInjection.Get<IMediator>();
    }

    private async Task<Holding.Company.Domain.Company.Entities.Holding> CreateHoldingSut(
        string name,
        string description = "",
        string role = "Master"
    )
    {
        var command = new CreateHoldingCommand(name, description, role);
        var result = await _bus.Send(command);
        return result.Data as Holding.Company.Domain.Company.Entities.Holding;
    }

    [TestMethod]
    public async Task ShoudReturnValidWhenFindHoldingByIdIsValid()
    {
        // Arrange
        var holding = await CreateHoldingSut("Holding", "Holding Description");
        var command = new FindHoldingByIdCommand(holding.Id.ToString(), "Master");

        // Act
        var result = await _bus.Send(command);

        // Assert
        Assert.AreEqual(command.IsValid, true);
        Assert.AreEqual(result.Success, true);
    }

    [TestMethod]
    public async Task ShoudReturnInvalidWhenFindHoldingByIdNotFound()
    {
        // Arrange
        var command = new FindHoldingByIdCommand(Guid.NewGuid().ToString(), "Master");

        // Act
        var result = await _bus.Send(command);

        // Assert
        Assert.AreEqual(command.IsValid, true);
        Assert.AreEqual(result.Success, false);
        Assert.IsNull(result.Data);
    }
}