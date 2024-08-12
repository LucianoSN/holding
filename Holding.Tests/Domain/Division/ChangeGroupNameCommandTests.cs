using Holding.Company.Domain.Division.UseCases.Commands;

namespace Holding.Tests.Domain.Division;

[TestClass]
public class ChangeGroupNameCommandTests
{
   private static ChangeGroupNameCommand Sut(string id, string name = "")
       => new(id, name); 
   
   [TestMethod]
   public void ShoudReturnInvalidWhenCommandIsInvalid()
   {
       var command = Sut("");
       Assert.AreEqual(command.IsValid, false);
   }
   
   [TestMethod]
   public void ShoudReturnValidWhenCommandIsValid()
   {
       var command = Sut(Guid.NewGuid().ToString(), "AnyGroup");
       Assert.AreEqual(command.IsValid, true);
   }
}