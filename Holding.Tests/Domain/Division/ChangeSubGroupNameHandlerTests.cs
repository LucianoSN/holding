using Holding.Company.Domain.Division.Entities;
using Holding.Company.Domain.Division.Queries;
using Holding.Company.Domain.Division.UseCases.Commands;
using Holding.Company.Domain.Division.UseCases.Handlers;

namespace Holding.Tests.Domain.Division;

[TestClass]
public class ChangeSubGroupNameHandlerTests
{
    private IGroupRepository _repository;
    private readonly CreateGroupHandler _createSut;
    private readonly CreateSubGroupHandler _addSubGroupSut;
    private readonly ChangeSubGroupNameHandler _changeSubGroupSut;
    private Guid _companyId;

    public ChangeSubGroupNameHandlerTests()
    {
        _repository = Helper.GetRequiredService<IGroupRepository>();
        _createSut = new CreateGroupHandler(_repository);
        _addSubGroupSut = new CreateSubGroupHandler(_repository);
        _changeSubGroupSut = new ChangeSubGroupNameHandler(_repository);
        _companyId = Guid.NewGuid();
    }

    private async Task<Group?> CreateGroupSut(string companyId, string name = "", string role = "Administrator")
    {
        var command = new CreateGroupCommand(companyId, name, role);
        var result = await _createSut.Handle(command, CancellationToken.None);
        if (result.Success) await _repository.Transact.Commit();

        var group = result.Data as Group;
        var subGroupCommand1 = new CreateSubGroupCommand(group.Id.ToString(), "SubGroupCreation01");
        await _addSubGroupSut.Handle(subGroupCommand1, CancellationToken.None);

        var subGroupCommand2 = new CreateSubGroupCommand(group.Id.ToString(), "SubGroupCreation02");
        await _addSubGroupSut.Handle(subGroupCommand2, CancellationToken.None);

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
        var result = await _changeSubGroupSut.Handle(command, CancellationToken.None);

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
        var result = await _changeSubGroupSut.Handle(command, CancellationToken.None);
        var getGroup = await _repository.GetGroupByIdWithSubGroupsTracking(group.Id);

        // Assert
        Assert.AreEqual(command.IsValid, true);
        Assert.AreEqual(result.Success, true);
        Assert.AreEqual(getGroup.SubGroups.Count, 2);
        Assert.AreEqual(getGroup.SubGroups.First().Name, name);
    }
}