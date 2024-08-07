using Holding.Company.Domain.Company.Queries;
using Holding.Company.Domain.Company.UseCases.Commands;
using Holding.Company.Domain.Company.UseCases.Handlers;

namespace Holding.Tests.Domain.Company;

[TestClass]
public class GetAllHoldingHandlerTests
{
    private ICompanyRepository _repository;
    private readonly CreateHoldingHandler _createSut;
    private readonly GetAllHoldingHandler _getAllSut;

    public GetAllHoldingHandlerTests()
    {
        _repository = Helper.GetRequiredService<ICompanyRepository>();
        _createSut = new CreateHoldingHandler(_repository);
        _getAllSut = new GetAllHoldingHandler(_repository);
    }

    private async Task CreateHoldingSut(
        string name,
        string description = "")
    {
        var command = new CreateHoldingCommand(name, description);
        var result = await _createSut.Handle(command, CancellationToken.None);
        if (result.Success) await _repository.Transact.Commit();
        await _repository.GetHoldingById((result.Data as Holding.Company.Domain.Company.Entities.Holding).Id);
    }
    
    [TestMethod]
    public async Task ShoudReturnInvalidWhenGetAllHoldingIsEmpty()
    {
        // Arrange
        var command = new GetAllHoldingCommand();
    
        // Act
        var result = await _getAllSut.Handle(command, CancellationToken.None);
        var total = (result.Data as List<Holding.Company.Domain.Company.Entities.Holding>).Count();
    
        // Assert
        Assert.AreEqual(command.IsValid, true);
        Assert.AreEqual(result.Success, true);
        Assert.AreEqual(total, 0);
    }

    [TestMethod]
    public async Task ShoudReturnValidWhenGetAllHoldingHasValues()
    {
        // Arrange
        await CreateHoldingSut("Holding", "Holding Description");
        var command = new GetAllHoldingCommand();
    
        // Act
        var result = await _getAllSut.Handle(command, CancellationToken.None);
        var total = (result.Data as List<Holding.Company.Domain.Company.Entities.Holding>).Count();
    
        // Assert
        Assert.AreEqual(command.IsValid, true);
        Assert.AreEqual(result.Success, true);
        Assert.AreNotEqual(total, 0);
    }
    
}