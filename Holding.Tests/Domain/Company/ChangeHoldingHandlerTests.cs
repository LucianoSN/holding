using Holding.Company.Domain.Company.Queries;
using Holding.Company.Domain.Company.UseCases.Commands;
using Holding.Company.Domain.Company.UseCases.Handlers;

namespace Holding.Tests.Domain.Company;

// [TestClass]
public class ChangeHoldingHandlerTests
{
    // private ICompanyRepository _repository;
    // private readonly CreateHoldingHandler _sut;
    //
    // public ChangeHoldingCommandTests()
    // {
    //     _repository = Helper.GetRequiredService<ICompanyRepository>();
    //     _sut = new CreateHoldingHandler(_repository);
    // }

   //  private async Task<Holding.Company.Domain.Company.Entities.Holding> CreateHoldingSut(string name, string description = null)
   //  {
   //      var command = new CreateHoldingCommand(name, description);
   //      var result = await _sut.Handle(command, CancellationToken.None);
   //      if (result.Success) await _repository.Transact.Commit();
   //      return await _repository.GetHoldingById((result.Data as Holding.Company.Domain.Company.Entities.Holding).Id);
   //  }
   //
   //  [TestMethod]
   // public void ShoudReturnInvalidWhenUpdateIsInvalid()
   // {
   //     // var command = Sut("");
   //     // Assert.AreEqual(command.IsValid, false);
   // }
   //
   // [TestMethod]
   // public async Task ShoudReturnValidWhenUpdateIsValid()
   // {
   //     // Arrange
   //     var holding = await CreateHoldingSut("Holding", "Holding Description");
   //     
   //     // Act
   //     var command = new ChangeHoldingCommand(holding.Id.ToString(), "ChangeHolding", "Ghange Holding Description");
   //     
   //     // Assert
   //     Assert.AreEqual(command.IsValid, true);
   // }
}