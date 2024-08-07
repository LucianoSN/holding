using Holding.Company.Domain.Company.Queries;
using Holding.Company.Domain.Company.UseCases.Commands;
using Holding.Company.Domain.Company.UseCases.Handlers;

namespace Holding.Tests.Domain.Company;

[TestClass]
public class FindHoldingHandlerTests
{
    private ICompanyRepository _repository;
    private readonly CreateHoldingHandler _createSut;
    private readonly FindHoldingByIdHandler _findSut;

    public FindHoldingHandlerTests()
    {
        _repository = Helper.GetRequiredService<ICompanyRepository>();
        _createSut = new CreateHoldingHandler(_repository);
        _findSut = new FindHoldingByIdHandler(_repository);
    }

    private async Task<Holding.Company.Domain.Company.Entities.Holding> CreateHoldingSut(
        string name,
        string description = "")
    {
        var command = new CreateHoldingCommand(name, description);
        var result = await _createSut.Handle(command, CancellationToken.None);
        if (result.Success) await _repository.Transact.Commit();
        return await _repository.GetHoldingById((result.Data as Holding.Company.Domain.Company.Entities.Holding).Id);
    }

    [TestMethod]
    public async Task ShoudReturnValidWhenFindHoldingByIdIsValid()
    {
        // Arrange
        var holding = await CreateHoldingSut("Holding", "Holding Description");
        var command = new FindHoldingByIdCommand(holding.Id.ToString());

        // Act
        var result = await _findSut.Handle(command, CancellationToken.None);

        // Assert
        Assert.AreEqual(command.IsValid, true);
        Assert.AreEqual(result.Success, true);
    }
    
    [TestMethod]
    public async Task ShoudReturnInvalidWhenFindHoldingByIdNotFound()
    {
        // Arrange
        var command = new FindHoldingByIdCommand(Guid.NewGuid().ToString());

        // Act
        var result = await _findSut.Handle(command, CancellationToken.None);

        // Assert
        Assert.AreEqual(command.IsValid, true);
        Assert.AreEqual(result.Success, false);
        Assert.IsNull(result.Data);
    }
}