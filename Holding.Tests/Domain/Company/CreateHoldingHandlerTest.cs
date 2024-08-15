using Holding.Company.Domain.Company.Queries;
using Holding.Company.Domain.Company.UseCases.Commands;
using Holding.Company.Domain.Company.UseCases.Handlers;

namespace Holding.Tests.Domain.Company;

[TestClass]
public class CreateHoldingHandlerTest
{
    private ICompanyRepository _repository;
    private readonly CreateHoldingHandler _sut;

    public CreateHoldingHandlerTest()
    {
        _repository = DependencyInjection.Get<ICompanyRepository>();
        _sut = new CreateHoldingHandler(_repository);
    }

    [TestMethod]
    public async Task ShouldCreateHoldingIsInvalid()
    {
        // Arrange
        var command = new CreateHoldingCommand("");

        // Act
        var result = await _sut.Handle(command, CancellationToken.None);

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
        var result = await _sut.Handle(command, CancellationToken.None);
        var holdings =
            await _repository.GetHoldingById((result.Data as Holding.Company.Domain.Company.Entities.Holding).Id);

        // Assert
        Assert.AreEqual(result.Success, true);
        Assert.IsNotNull(holdings);
    }
}