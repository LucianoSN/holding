using Holding.Company.Domain.Company.Queries;
using Holding.Company.Domain.Company.UseCases.Commands;
using Holding.Company.Domain.Company.UseCases.Handlers;

namespace Holding.Tests.Domain.Company;

[TestClass]
public class GetAllHoldingHandlerTests
{
    private readonly CreateHoldingHandler _createSut;
    private readonly GetAllHoldingHandler _getAllSut;

    public GetAllHoldingHandlerTests()
    {
        var repository = Helper.GetRequiredService<ICompanyRepository>();
        _createSut = new CreateHoldingHandler(repository);
        _getAllSut = new GetAllHoldingHandler(repository);
    }

    private async Task CreateHoldingSut(
        string name,
        string description = "",
        string role = "Master"
    )
    {
        var command = new CreateHoldingCommand(name, description, role);
        await _createSut.Handle(command, CancellationToken.None);
    }

    [TestMethod]
    public async Task ShoudReturnInvalidWhenGetAllHoldingIsEmpty()
    {
        // Arrange
        var command = new GetAllHoldingCommand(role: "Master");

        // Act
        var result = await _getAllSut.Handle(command, CancellationToken.None);

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
        var result = await _getAllSut.Handle(command, CancellationToken.None);

        // Assert
        Assert.AreEqual(command.IsValid, true);
        Assert.AreEqual(result.Success, true);
        Assert.AreNotEqual(result.TotalCount, 0);
    }
}