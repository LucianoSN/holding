using Holding.Company.Domain.Company.Queries;
using Holding.Company.Domain.Company.UseCases.Commands;
using Holding.Company.Domain.Company.UseCases.Handlers;

namespace Holding.Tests.Domain.Company;

[TestClass]
public class ChangeHoldingHandlerTests
{
    private ICompanyRepository _repository;
    private readonly CreateHoldingHandler _createSut;
    private readonly ChangeHoldingHandler _changeSut;

    public ChangeHoldingHandlerTests()
    {
        _repository = DependencyInjection.Get<ICompanyRepository>();
        _createSut = new CreateHoldingHandler(_repository);
        _changeSut = new ChangeHoldingHandler(_repository);
    }

    private async Task<Holding.Company.Domain.Company.Entities.Holding> CreateHoldingSut(
        string name,
        string description = "",
        string role =  "Master"
    )
    {
        var command = new CreateHoldingCommand(name, description, role);
        var result = await _createSut.Handle(command, CancellationToken.None);
        return await _repository.GetHoldingById((result.Data as Holding.Company.Domain.Company.Entities.Holding).Id);
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
        var result = await _changeSut.Handle(command, CancellationToken.None);
        var changedHolding = await _repository.GetHoldingById(holding.Id);

        // Assert
        Assert.AreEqual(command.IsValid, true);
        Assert.AreEqual(result.Success, true);
        Assert.AreEqual(holding.Id, changedHolding.Id);
        Assert.AreEqual(holding.Name, changedHolding.Name);
        Assert.AreEqual(holding.Description, changedHolding.Description);
    }
}