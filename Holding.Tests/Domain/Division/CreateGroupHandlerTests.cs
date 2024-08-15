using Holding.Company.Domain.Division.Entities;
using Holding.Company.Domain.Division.Queries;
using Holding.Company.Domain.Division.UseCases.Commands;
using Holding.Company.Domain.Division.UseCases.Handlers;

namespace Holding.Tests.Domain.Division;

[TestClass]
public class CreateGroupHandlerTests
{
    private IGroupRepository _repository;
    private readonly CreateGroupHandler _sut;
    private Guid _companyId;

    public CreateGroupHandlerTests()
    {
        _repository = DependencyInjection.Get<IGroupRepository>();
        _sut = new CreateGroupHandler(_repository);
        _companyId = Guid.NewGuid();
    }
    
    [TestMethod]
    public async Task ShouldCreateGroupIsInvalid()
    {
        // Arrange
        var command = new CreateGroupCommand(_companyId.ToString(), "");
    
        // Act
        var result = await _sut.Handle(command, CancellationToken.None);
    
        // Assert
        Assert.AreEqual(result.Success, false);
    }


    [TestMethod]
    public async Task ShouldCreateHoldingIsValid()
    {
        // Arrange
        var command = new CreateGroupCommand(_companyId.ToString(), "Group Test", "Administrator");
    
        // Act
        var result = await _sut.Handle(command, CancellationToken.None);
        if (result.Success) await _repository.Transact.Commit();
        var group = result.Data as Group;
    
        // Assert
        Assert.AreEqual(result.Success, true);
        Assert.IsNotNull(group);
        Assert.AreEqual(group.CompanyId, _companyId);
    }
}