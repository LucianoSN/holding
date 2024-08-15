using Holding.Company.Domain.Division.Entities;
using Holding.Company.Domain.Division.Queries;
using Holding.Company.Domain.Division.UseCases.Commands;
using Holding.Company.Domain.Division.UseCases.Handlers;

namespace Holding.Tests.Domain.Division;

[TestClass]
public class ChangeGroupNameHandlerTests
{
    private IGroupRepository _repository;
    private readonly CreateGroupHandler _createSut;
    private readonly ChangeGroupNameHandler _changeSut;
    private Guid _companyId;

    public ChangeGroupNameHandlerTests()
    {
        _repository = DependencyInjection.Get<IGroupRepository>();
        _createSut = new CreateGroupHandler(_repository);
        _changeSut = new ChangeGroupNameHandler(_repository);
        _companyId = Guid.NewGuid();
    }
    
    private async Task<Group?> CreateGroupSut(string companyId, string name = "", string role = "Administrator")
    {
        var command = new CreateGroupCommand(companyId, name, role);
        var result = await _createSut.Handle(command, CancellationToken.None);
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
       var result = await _changeSut.Handle(command, CancellationToken.None);
       var changedGroup = await _repository.GetGroupById(group.Id);
       
        // Assert
        Assert.AreEqual(command.IsValid, true);
        Assert.AreEqual(result.Success, true);
        Assert.AreEqual(group.Id, changedGroup.Id);
        Assert.AreEqual(name, changedGroup.Name);
        Assert.AreEqual(_companyId, changedGroup.CompanyId);
    }
}