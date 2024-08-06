using Holding.Company.Domain.Company.UseCases.Commands;

namespace Holding.Tests.Domain.Company;

[TestClass]
public class ChangeHoldingCommandTests
{
   private static ChangeHoldingCommand Sut(string id, string name = "Holding", string? description = "Holding Description")
       => new(id, name, description);
   
   [TestMethod]
   public void ShoudReturnInvalidWhenNameIsInvalid()
   {
       var command = Sut(Guid.NewGuid().ToString(), "", "");
       Assert.AreEqual(command.IsValid, false);
   }
   
   [TestMethod]
   public void ShoudReturnInvalidWhenGuidIsInvalid()
   {
       var command = Sut("00-93343-00");
       Assert.AreEqual(command.IsValid, false);
   }
   
   [TestMethod]
   public void ShoudReturnValidWhenCommandIsValid()
   {
       var command = Sut(Guid.NewGuid().ToString());
       Assert.AreEqual(command.IsValid, true);
   }
}