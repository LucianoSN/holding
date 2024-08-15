using Holding.Company.Domain.Company.UseCases.Commands;
using MediatR;

namespace Holding.Tests.Domain.Company;

[TestClass]
public class CreateHoldingHandlerTest
{
    private IMediator _bus;

    public CreateHoldingHandlerTest()
    {
        _bus = DependencyInjection.Get<IMediator>();
    }

    [TestMethod]
    public async Task ShouldCreateHoldingIsInvalid()
    {
        // Arrange
        var command = new CreateHoldingCommand("");

        // Act
        var result = await _bus.Send(command);

        // Assert
        Assert.AreEqual(result.Success, false);
    }

    [TestMethod]
    public async Task ShouldCreateHoldingIsValid()
    {
        // Arrange
        var command = new CreateHoldingCommand(
            "Holding Test",
            "Holding Test Description",
            "Master"
        );

        // Act
        var result = await _bus.Send(command);
        var holdings = result.Data as Holding.Company.Domain.Company.Entities.Holding;

        // Assert
        Assert.AreEqual(result.Success, true);
        Assert.IsNotNull(holdings);
    }
}