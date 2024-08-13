using Holding.Company.Domain.Division.UseCases.Commands;

namespace Holding.Tests.Domain.Division;

[TestClass]
public class ChangeSubGroupNameCommandTests
{
   private static ChangeSubGroupNameCommand Sut(string id, string groupId, string name = "")
       => new(id, groupId, name);
   
   [TestMethod]
   public void ShoudReturnInvalidWhenGroupIdIsInvalid()
   {
       var command = Sut(Guid.NewGuid().ToString(), "", "AnySubGroup");
       Assert.AreEqual(command.IsValid, false);
   }
   
   [TestMethod]
   public void ShoudReturnInvalidWhenSubGroupIdIsInvalid()
   {
       var command = Sut("", Guid.NewGuid().ToString(), "AnySubGroup");
       Assert.AreEqual(command.IsValid, false);
   }
   
   [TestMethod]
   public void ShoudReturnInvalidWhenSubGroupNameIsInvalid()
   {
       var command = Sut(Guid.NewGuid().ToString(), Guid.NewGuid().ToString());
       Assert.AreEqual(command.IsValid, false);
   }
   
   [TestMethod]
   public void ShoudReturnValidWhenSubGroupIsValid()
   {
       var command = Sut(Guid.NewGuid().ToString(), Guid.NewGuid().ToString(), "AnySubGroup");
       Assert.AreEqual(command.IsValid, true);
   }
}