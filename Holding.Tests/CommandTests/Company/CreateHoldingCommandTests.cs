using Holding.Company.Domain.Company.UseCases.Commands;

namespace Holding.Tests.CommandTests.Company;

[TestClass]
public class CreateHoldingCommandTests
{
   private static CreateHoldingCommand Sut(string name = "Holding", string? description = "Holding Description")
       => new(name, description);
   
   [TestMethod]
   public void ShoudReturnInvalidWhenCommandIsInvalid()
   {
       var command = Sut("");
       Assert.AreEqual(command.IsValid, false);
   }
   
   [TestMethod]
   public void ShoudReturnValidWhenCommandIsValid()
   {
       var command = Sut();
       Assert.AreEqual(command.IsValid, true);
   }
}