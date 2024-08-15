using Holding.Company.Domain.Division.Entities;
using Holding.Company.Domain.Division.UseCases.Commands;
using MediatR;

namespace Holding.Tests.Domain.Division;

[TestClass]
public class ChangeGroupNameHandlerTests
{
    private IMediator _bus;
    private Guid _companyId;

    public ChangeGroupNameHandlerTests()
    {
        _bus = DependencyInjection.Get<IMediator>();
        _companyId = Guid.NewGuid();
    }
    
    private async Task<Group?> CreateGroupSut(string companyId, string name = "", string role = "Administrator")
    {
        var command = new CreateGroupCommand(companyId, name, role);
        var result = await _bus.Send(command);
        return result.Data as Group;
    }

    [TestMethod]
    public async Task ShoudReturnValidWhenUpdateIsValid()
    {
       // Arrange
       var name = "GroupChangeName";
       var group = await CreateGroupSut(_companyId.ToString(), "GroupCreation");
       var command = new ChangeGroupNameCommand(group.Id.ToString(), name, "Administrator");
       
       // Act
        var result = await _bus.Send(command);
       var changedGroup = result.Data as Group;
       
        // Assert
        Assert.AreEqual(command.IsValid, true);
        Assert.AreEqual(result.Success, true);
        Assert.AreEqual(group.Id, changedGroup.Id);
        Assert.AreEqual(name, changedGroup.Name);
        Assert.AreEqual(_companyId, changedGroup.CompanyId);
    }
}