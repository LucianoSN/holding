using Holding.Company.Domain.Division.Entities;
using Holding.Company.Domain.Division.UseCases.Commands;
using MediatR;

namespace Holding.Tests.Domain.Division;

[TestClass]
public class ChangeSubGroupNameHandlerTests
{
    private IMediator _bus;
    private Guid _companyId;

    public ChangeSubGroupNameHandlerTests()
    {
        _bus = DependencyInjection.Get<IMediator>();
        _companyId = Guid.NewGuid();
    }

    private async Task<Group?> CreateGroupSut(string companyId, string name = "", string role = "Administrator")
    {
        var command = new CreateGroupCommand(companyId, name, role);
        var result = await _bus.Send(command);

        var group = result.Data as Group;
        var subGroupCommand1 = new CreateSubGroupCommand(group.Id.ToString(), "SubGroupCreation01", role);
        await _bus.Send(subGroupCommand1);

        var subGroupCommand2 = new CreateSubGroupCommand(group.Id.ToString(), "SubGroupCreation02", role);
        await _bus.Send(subGroupCommand2);

        return group;
    }

    [TestMethod]
    public async Task ShouldReturnInvalidWhenSubGroupAlreadyExists()
    {
        // Arrange
        var group = await CreateGroupSut(_companyId.ToString(), "GroupCreation");
        var command = new ChangeSubGroupNameCommand(
            group.SubGroups.First().Id.ToString(),
            group.Id.ToString(),
            "SubGroupCreation02",
            "Administrator"
        );

        // Act
        var result = await _bus.Send(command);

        // Assert
        Assert.AreEqual(command.IsValid, true);
        Assert.AreEqual(result.Success, false);
        Assert.AreEqual(group.SubGroups.Count, 2);
        Assert.AreEqual(result.Message, "SubGroup already exists");
    }

    [TestMethod]
    public async Task ShouldReturnValidWhenSubGroupIsValid()
    {
        // Arrange
        var name = "ChangedSubGroupToAnotherName";
        var group = await CreateGroupSut(_companyId.ToString(), "GroupCreation");
        var command = new ChangeSubGroupNameCommand(
            group.SubGroups.First().Id.ToString(),
            group.Id.ToString(),
            name,
            "Administrator"
        );

        // Act
        var result = await _bus.Send(command);
        var changed = result.Data as Group;

        // Assert
        Assert.AreEqual(command.IsValid, true);
        Assert.AreEqual(result.Success, true);
        Assert.AreEqual(changed.SubGroups.Count, 2);
        Assert.AreEqual(changed.SubGroups.First().Name, name);
    }
}