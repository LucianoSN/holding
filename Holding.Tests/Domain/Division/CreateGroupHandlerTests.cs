using Holding.Company.Domain.Division.Entities;
using Holding.Company.Domain.Division.UseCases.Commands;
using MediatR;

namespace Holding.Tests.Domain.Division;

[TestClass]
public class CreateGroupHandlerTests
{
    private IMediator _bus;
    private Guid _companyId;

    public CreateGroupHandlerTests()
    {
        _bus = DependencyInjection.Get<IMediator>();
        _companyId = Guid.NewGuid();
    }
    
    [TestMethod]
    public async Task ShouldCreateGroupIsInvalid()
    {
        // Arrange
        var command = new CreateGroupCommand(_companyId.ToString(), "");
    
        // Act
        var result = await _bus.Send(command, CancellationToken.None);
    
        // Assert
        Assert.AreEqual(result.Success, false);
    }


    [TestMethod]
    public async Task ShouldCreateHoldingIsValid()
    {
        // Arrange
        var command = new CreateGroupCommand(_companyId.ToString(), "Group Test", "Administrator");
    
        // Act
        var result = await _bus.Send(command);
        var group = result.Data as Group;
    
        // Assert
        Assert.AreEqual(result.Success, true);
        Assert.IsNotNull(group);
        Assert.AreEqual(group.CompanyId, _companyId);
    }
}