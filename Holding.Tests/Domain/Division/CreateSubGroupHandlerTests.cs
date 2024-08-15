using Holding.Company.Domain.Division.Entities;
using Holding.Company.Domain.Division.UseCases.Commands;
using MediatR;

namespace Holding.Tests.Domain.Division;

[TestClass]
public class CreateSubGroupHandlerTests
{
    private IMediator _bus;
    private Guid _companyId;

    public CreateSubGroupHandlerTests()
    {
        _bus = DependencyInjection.Get<IMediator>();
        _companyId = Guid.NewGuid();
    }
    
    private async Task<Group?> CreateGroupSut(string companyId, string name = "", string role = "Administrator")
    {
        var command = new CreateGroupCommand(companyId, name, role);
        var result = await _bus.Send(command);
        
        var group = result.Data as Group;
        var subGroupCommand = new CreateSubGroupCommand(group.Id.ToString(), "SubGroupCreation01", role);
        await _bus.Send(subGroupCommand);
        
        return group;
    }

    [TestMethod]
    public async Task ShouldReturnInvalidWhenSubGroupAlreadyExists()
    {
        // Arrange
        var group = await CreateGroupSut(_companyId.ToString(), "GroupCreation");
        var command = new CreateSubGroupCommand(group.Id.ToString(), "SubGroupCreation01", "Administrator");
        
        // Act
        var result = await _bus.Send(command);
        
        // Assert
        Assert.AreEqual(command.IsValid, true);
        Assert.AreEqual(result.Success, false);
        Assert.AreEqual(group.SubGroups.Count, 1);
        Assert.AreEqual(result.Message, "SubGroup already exists");
    }

    [TestMethod]
    public async Task ShouldReturnValidWhenSubGroupIsValid()
    {
        // Arrange
        var group = await CreateGroupSut(_companyId.ToString(), "GroupCreation");
        var command = new CreateSubGroupCommand(group.Id.ToString(), "SubGroupCreation02", "Administrator");
        
        // Act
        var result = await _bus.Send(command);
        var changed = result.Data as SubGroup;
        
        // Assert
        Assert.AreEqual(command.IsValid, true);
        Assert.AreEqual(result.Success, true);
        Assert.AreEqual(changed.Group.SubGroups.Count, 2);
    }
}