using Holding.Company.Domain.Division.UseCases.Commands;

namespace Holding.Tests.Domain.Division;

[TestClass]
public class CreateSubGroupCommandTests
{
   private static CreateSubGroupCommand Sut(string groupId, string name = "")
       => new(groupId, name); 
   
   [TestMethod]
   public void ShoudReturnInvalidWhenCommandIsInvalid()
   {
       var command = Sut("");
       Assert.AreEqual(command.IsValid, false);
   }
   
   [TestMethod]
   public void ShoudReturnValidWhenCommandIsValid()
   {
       var command = Sut(Guid.NewGuid().ToString(), "AnySubGroup");
       Assert.AreEqual(command.IsValid, true);
   }
}