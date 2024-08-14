using Holding.Company.Domain.Division.UseCases.Commands;

namespace Holding.Tests.Domain.Division;

[TestClass]
public class CreateGroupCommandTests
{
   private static CreateGroupCommand Sut(string companyId, string name = "", string role = "Administrator")
       => new(companyId, name, role); 
   
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