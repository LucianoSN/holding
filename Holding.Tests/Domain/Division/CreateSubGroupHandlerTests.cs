using Holding.Company.Domain.Division.Entities;
using Holding.Company.Domain.Division.Queries;
using Holding.Company.Domain.Division.UseCases.Commands;
using Holding.Company.Domain.Division.UseCases.Handlers;

namespace Holding.Tests.Domain.Division;

[TestClass]
public class CreateSubGroupHandlerTests
{
    private IGroupRepository _repository;
    private readonly CreateGroupHandler _createSut;
    private readonly CreateSubGroupHandler _addSubGroupSut;
    private Guid _companyId;

    public CreateSubGroupHandlerTests()
    {
        _repository = Helper.GetRequiredService<IGroupRepository>();
        _createSut = new CreateGroupHandler(_repository);
        _addSubGroupSut = new CreateSubGroupHandler(_repository);
        _companyId = Guid.NewGuid();
    }
    
    private async Task<Group?> CreateGroupSut(string companyId, string name = "")
    {
        var command = new CreateGroupCommand(companyId, name);
        var result = await _createSut.Handle(command, CancellationToken.None);
        if (result.Success) await _repository.Transact.Commit();
        
        var group = result.Data as Group;
        var subGroupCommand = new CreateSubGroupCommand(group.Id.ToString(), "SubGroupCreation01");
        await _addSubGroupSut.Handle(subGroupCommand, CancellationToken.None);
        
        return group;
    }

    [TestMethod]
    public async Task ShouldReturnInvalidWhenSubGroupAlreadyExists()
    {
        // Arrange
        var group = await CreateGroupSut(_companyId.ToString(), "GroupCreation");
        var command = new CreateSubGroupCommand(group.Id.ToString(), "SubGroupCreation01");
        
        // Act
        var result = await _addSubGroupSut.Handle(command, CancellationToken.None);
        
        // Assert
        Assert.AreEqual(command.IsValid, true);
        Assert.AreEqual(result.Success, false);
        Assert.AreEqual(group.SubGroups.Count, 1);
        Assert.AreEqual(result.Message, "SubGroup already exists");
    }
}