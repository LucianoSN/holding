using Holding.Company.Domain.Company.UseCases.Commands;
using MediatR;

namespace Holding.Tests.Domain.Company;

[TestClass]
public class GetAllHoldingHandlerTests
{
    private IMediator _bus;

    public GetAllHoldingHandlerTests()
    {
        _bus = DependencyInjection.Get<IMediator>();
    }

    private async Task CreateHoldingSut(
        string name,
        string description = "",
        string role = "Master"
    )
    {
        var command = new CreateHoldingCommand(name, description, role);
        await _bus.Send(command);
    }

    [TestMethod]
    public async Task ShoudReturnInvalidWhenGetAllHoldingIsEmpty()
    {
        // Arrange
        var command = new GetAllHoldingCommand(role: "Master");

        // Act
        var result = await _bus.Send(command);

        // Assert
        Assert.AreEqual(command.IsValid, true);
        Assert.AreEqual(result.Success, true);
        Assert.AreEqual(result.TotalCount, 0);
    }

    [TestMethod]
    public async Task ShoudReturnValidWhenGetAllHoldingHasValues()
    {
        // Arrange
        await CreateHoldingSut("Holding", "Holding Description");
        var command = new GetAllHoldingCommand(role: "Master");

        // Act
        var result = await _bus.Send(command);

        // Assert
        Assert.AreEqual(command.IsValid, true);
        Assert.AreEqual(result.Success, true);
        Assert.AreNotEqual(result.TotalCount, 0);
    }
}